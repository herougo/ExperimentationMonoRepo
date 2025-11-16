using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeParsingNet9.CodeManipulator
{
    public class MethodNode
    {
        public string MethodId { get; }
        public IMethodSymbol Symbol { get; }

        public MethodNode(IMethodSymbol symbol)
        {
            Symbol = symbol;
            MethodId = $"{symbol.ContainingType.ToDisplayString()}.{symbol.Name}";
        }

        public override string ToString() => MethodId;
    }

    public class MethodNodeComparer : IEqualityComparer<MethodNode>
    {
        public bool Equals(MethodNode? x, MethodNode? y)
        {
            if (x is null || y is null) return false;
            if (ReferenceEquals(x, y)) return true;
            return SymbolEqualityComparer.Default.Equals(x.Symbol, y.Symbol);
        }

        public int GetHashCode(MethodNode obj)
        {
            if (obj is null) return 0;
            return SymbolEqualityComparer.Default.GetHashCode(obj.Symbol);
        }
    }

    public partial class CodeManipulator
    {
        public async Task<Dictionary<MethodNode, HashSet<MethodNode>>> BuildMethodDependencyGraphAsync()
        {
            var compilation = await _project.GetCompilationAsync();
            if (compilation == null)
                throw new InvalidOperationException("Failed to get compilation for project.");

            var edges = new Dictionary<MethodNode, HashSet<MethodNode>>(new MethodNodeComparer());
            var allNodes = new Dictionary<IMethodSymbol, MethodNode>(SymbolEqualityComparer.Default);

            // Analyze all method declarations in all syntax trees
            foreach (var document in _project.Documents)
            {
                var syntaxRoot = await document.GetSyntaxRootAsync();
                if (syntaxRoot == null) continue;

                var semanticModel = await document.GetSemanticModelAsync();
                if (semanticModel == null) continue;

                var methods = syntaxRoot.DescendantNodes().OfType<MethodDeclarationSyntax>();

                foreach (var methodDecl in methods)
                {
                    var methodSymbol = semanticModel.GetDeclaredSymbol(methodDecl) as IMethodSymbol;
                    if (methodSymbol == null) continue;

                    var callerNode = GetOrAddNode(methodSymbol, allNodes, edges);

                    // find all invocation expressions in this method body
                    var invocations = methodDecl.DescendantNodes().OfType<InvocationExpressionSyntax>();

                    foreach (var invocation in invocations)
                    {
                        var targetSymbol = semanticModel.GetSymbolInfo(invocation).Symbol as IMethodSymbol;
                        if (targetSymbol == null) continue;

                        // skip external methods (i.e. not from the same project)
                        if (targetSymbol.ContainingAssembly != compilation.Assembly) continue;

                        var calleeNode = GetOrAddNode(targetSymbol, allNodes, edges);

                        // add edge caller -> callee
                        if (!edges[callerNode].Contains(calleeNode))
                            edges[callerNode].Add(calleeNode);
                    }
                }
            }

            return edges;
        }

        private MethodNode GetOrAddNode(IMethodSymbol symbol, Dictionary<IMethodSymbol, MethodNode> allNodes, Dictionary<MethodNode, HashSet<MethodNode>> edges)
        {
            if (!allNodes.TryGetValue(symbol, out var node))
            {
                node = new MethodNode(symbol);
                allNodes[symbol] = node;
                edges[node] = new HashSet<MethodNode>(new MethodNodeComparer());
            }
            return node;
        }

        public List<MethodNode> TopologicalSort(Dictionary<MethodNode, HashSet<MethodNode>> graph)
        {
            var visited = new HashSet<MethodNode>(new MethodNodeComparer());
            var temp = new HashSet<MethodNode>(new MethodNodeComparer());
            var result = new List<MethodNode>();

            void Visit(MethodNode node)
            {
                if (temp.Contains(node))
                    throw new InvalidOperationException("Cycle detected in method dependency graph.");
                if (visited.Contains(node))
                    return;

                temp.Add(node);
                foreach (var dep in graph[node])
                    Visit(dep);
                temp.Remove(node);
                visited.Add(node);
                result.Add(node);
            }

            foreach (var node in graph.Keys)
                Visit(node);

            result.Reverse(); // ensure topological order
            return result;
        }
    }
}
