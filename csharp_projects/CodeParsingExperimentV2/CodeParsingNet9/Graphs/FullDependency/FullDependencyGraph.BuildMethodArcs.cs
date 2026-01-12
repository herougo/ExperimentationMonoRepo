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
        public async Task BuildMethodArcs(List<Project> projects)
        {
            foreach (var project in projects)
            {
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

                        var callerNode = GetNode(methodSymbol);

                        // find all invocation expressions in this method body
                        var invocations = methodDecl.DescendantNodes().OfType<InvocationExpressionSyntax>();

                        foreach (var invocation in invocations)
                        {
                            var targetSymbol = semanticModel.GetSymbolInfo(invocation).Symbol as IMethodSymbol;
                            if (targetSymbol == null) continue;

                            var calleeNode = GetOrAddNode(targetSymbol);

                            // add edge caller -> callee
                            AddDirectedEdgeIfMissing(callerNode, calleeNode, CodeBlockArcType.MethodInvocation);
                        }
                    }
                }
            }

        }
    }
}
