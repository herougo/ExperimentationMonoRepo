using CodeParsingNet9.CodeManipulator2.StaticUtils;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeParsingNet9.Graphs.FullDependency
{


    public partial class FullDependencyGraph
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

        private CodeBlockArc AddDirectedEdge(CodeBlockNode codeBlockIn, CodeBlockNode codeBlockOut, CodeBlockArcType codeBlockArcType)
        {
            var arc = new CodeBlockArc(codeBlockIn, codeBlockOut, codeBlockArcType);

            DirectedEdges[codeBlockIn].Add(arc);

            return arc;
        }

        public async Task BuildAsync(List<Project> projects, Dictionary<string, Compilation> compilations)
        {
            await BuildAllNodesAndMemberArcs(projects);


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
}
