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
    public static partial class CodeUtils
    {
        public static async Task<Dictionary<MethodNode, HashSet<MethodNode>>> BuildMethodDependencyGraphAsync(
            Solution solution, Dictionary<string, Compilation> compilations
        )
        {
            return await BuildMethodDependencyGraphAsync(solution.Projects.ToList(), compilations);
        }

        public static async Task<Dictionary<MethodNode, HashSet<MethodNode>>> BuildMethodDependencyGraphAsync(
            List<Project> projects, Dictionary<string, Compilation> compilations
        )
        {
            var edges = new Dictionary<MethodNode, HashSet<MethodNode>>(new MethodNodeComparer());
            var allNodes = new Dictionary<IMethodSymbol, MethodNode>(SymbolEqualityComparer.Default);

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
                        var methodSymbol = GetDeclaredSymbol(methodDecl, semanticModel) as IMethodSymbol;
                        if (methodSymbol == null) continue;

                        var callerNode = GetOrAddNode(methodSymbol, allNodes, edges);

                        // find all invocation expressions in this method body
                        var invocations = methodDecl.DescendantNodes().OfType<InvocationExpressionSyntax>();

                        foreach (var invocation in invocations)
                        {
                            var targetSymbol = semanticModel.GetSymbolInfo(invocation).Symbol as IMethodSymbol;
                            if (targetSymbol == null) continue;

                            var calleeNode = GetOrAddNode(targetSymbol, allNodes, edges);

                            // add edge caller -> callee
                            if (!edges[callerNode].Contains(calleeNode))
                                edges[callerNode].Add(calleeNode);
                        }
                    }
                }
            }

            return edges;
        }

        public static bool IsAssemblyInSolution(
            Dictionary<string, Microsoft.CodeAnalysis.Compilation> compilations,
            IAssemblySymbol assembly
        )
        {
            foreach (var compilation in compilations.Values)
            {
                if (assembly == compilation.Assembly)
                {
                    return true;
                }
            }
            return false;
        }

        private static MethodNode GetOrAddNode(IMethodSymbol symbol, Dictionary<IMethodSymbol, MethodNode> allNodes, Dictionary<MethodNode, HashSet<MethodNode>> edges)
        {
            if (!allNodes.TryGetValue(symbol, out var node))
            {
                node = new MethodNode(symbol);
                allNodes[symbol] = node;
                edges[node] = new HashSet<MethodNode>(new MethodNodeComparer());
            }
            return node;
        }
    }
}
