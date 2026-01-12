using CodeParsingNet9.CodeManipulator;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeParsingNet9.CodeManipulator2.StaticUtils
{
    public enum CodeBlockNodeType : int
    {
        Other = 0,
        Class = 1,
        Method = 2,
        Enum = 3,
        Interface = 4
        // TODO: add record and struct?
    }

    public class CodeBlockNode
    {
        public string Id { get; }
        public CodeBlockNodeType SymbolType { get; }
        public ISymbol Symbol { get; }

        public CodeBlockNode(ISymbol symbol)
        {
            Symbol = symbol;
            Id = CodeUtils.GetSymbolId(symbol);
            SymbolType = CodeUtils.GetSymbolType(symbol);
        }

        public override string ToString() => Id;
    }

    public class CodeBlockNodeComparer : IEqualityComparer<CodeBlockNode>
    {
        public bool Equals(CodeBlockNode? x, CodeBlockNode? y)
        {
            if (x is null || y is null) return false;
            if (ReferenceEquals(x, y)) return true;
            return SymbolEqualityComparer.Default.Equals(x.Symbol, y.Symbol);
        }

        public int GetHashCode(CodeBlockNode obj)
        {
            if (obj is null) return 0;
            return SymbolEqualityComparer.Default.GetHashCode(obj.Symbol);
        }
    }

    public enum CodeBlockArcType : int
    {
        MethodInvocation = 0,
        TypeUsage = 1,
        ContainedMember = 2
    }

    public class CodeBlockArc
    {
        public readonly CodeBlockNode InNode;
        public readonly CodeBlockNode OutNode;
        public readonly CodeBlockArcType Type;

        public CodeBlockArc(CodeBlockNode inNode, CodeBlockNode outNode, CodeBlockArcType type)
        {
            InNode = inNode;
            OutNode = outNode;
            Type = type;
        }
    }

    public class CodeBlockArcComparer : IEqualityComparer<CodeBlockArc>
    {
        private CodeBlockNodeComparer _comparer = new CodeBlockNodeComparer();

        public bool Equals(CodeBlockArc? x, CodeBlockArc? y)
        {
            if (x is null || y is null) return false;
            if (ReferenceEquals(x, y)) return true;
            if (x.Type != y.Type) return false;
            if (!_comparer.Equals(x.InNode, y.InNode)) return false;
            if (!_comparer.Equals(x.OutNode, y.OutNode)) return false;
            return true;
        }

        public int GetHashCode(CodeBlockArc obj)
        {
            if (obj is null) return 0;
            string id = obj.InNode.Id + "-" + obj.Type + "-" + obj.OutNode.Id;
            return string.GetHashCode(id);
        }
    }

    public class FullDependencyGraph
    {
        public readonly Dictionary<CodeBlockNode, HashSet<CodeBlockArc>> DirectedEdges = new Dictionary<CodeBlockNode, HashSet<CodeBlockArc>>(new CodeBlockNodeComparer());

        public readonly Dictionary<ISymbol, CodeBlockNode> AllNodes = new Dictionary<ISymbol, CodeBlockNode>(SymbolEqualityComparer.Default);

        private CodeBlockNode GetOrAddNode(ISymbol symbol)
        {
            if (!AllNodes.TryGetValue(symbol, out var node))
            {
                node = new CodeBlockNode(symbol);
                AllNodes[symbol] = node;
                DirectedEdges[node] = new HashSet<CodeBlockArc>(new CodeBlockArcComparer());
            }
            return node;
        }

        private async Task BuildAllNodes(List<Project> projects)
        {
            foreach (var project in projects)
            {
                foreach (var document in project.Documents)
                {
                    var syntaxRoot = await document.GetSyntaxRootAsync();
                    if (syntaxRoot == null) continue;


                }
            }
        }

        public async Task BuildAsync(List<Project> projects, Dictionary<string, Compilation> compilations)
        {
            var edges = new Dictionary<CodeBlockNode, HashSet<CodeBlockNode>>(new CodeBlockNodeComparer());
            var allNodes = new Dictionary<ISymbol, CodeBlockNode>(SymbolEqualityComparer.Default);

            foreach (var project in projects)
            {
                var compilation = compilations[project.Name];

                // Analyze all method declarations in all syntax trees
                foreach (var document in project.Documents)
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

                        var callerNode = GetOrAddNode(methodSymbol);

                        // find all invocation expressions in this method body
                        var invocations = methodDecl.DescendantNodes().OfType<InvocationExpressionSyntax>();

                        foreach (var invocation in invocations)
                        {
                            var targetSymbol = semanticModel.GetSymbolInfo(invocation).Symbol as IMethodSymbol;
                            if (targetSymbol == null) continue;

                            var calleeNode = GetOrAddNode(targetSymbol);

                            // add edge caller -> callee
                            if (!edges[callerNode].Contains(calleeNode))
                                edges[callerNode].Add(calleeNode);
                        }
                    }
                }
            }
        }

    }

    public static partial class CodeUtils
    {
        public static async Task<FullDependencyGraph> BuildFullDependencyGraphAsync(
            Solution solution, Dictionary<string, Compilation> compilations
        )
        {
            return await BuildFullDependencyGraphAsync(solution.Projects.ToList(), compilations);
        }

        public static async Task<FullDependencyGraph> BuildFullDependencyGraphAsync(
            List<Project> projects, Dictionary<string, Compilation> compilations
        )
        {
            
        }
    }
}