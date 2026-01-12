using CodeParsingNet9.CodeManipulator2.SyntaxWalkers;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodeParsingNet9.Graphs.FullDependency
{
    public partial class FullDependencyGraph
    {
        public async Task BuildTypeArcs(List<Project> projects)
        {
            /* Includes
               - enums
               - classes
            */

            foreach (var project in projects)
            {
                // Analyze all method declarations in all syntax trees
                foreach (var document in project.Documents)
                {
                    var syntaxRoot = await document.GetSyntaxRootAsync();
                    if (syntaxRoot == null) continue;

                    var semanticModel = await document.GetSemanticModelAsync();
                    if (semanticModel == null) continue;

                    // methods
                    var methods = syntaxRoot.DescendantNodes().OfType<MethodDeclarationSyntax>();
                    foreach (var methodDecl in methods)
                    {
                        var methodSymbol = semanticModel.GetDeclaredSymbol(methodDecl) as IMethodSymbol;
                        if (methodSymbol == null) continue;

                        var callerNode = GetNode(methodSymbol);

                        var walker = new TypeUsageWalker(semanticModel, default);
                        walker.Visit(methodDecl);

                        foreach (ISymbol type in walker.Results)
                        {
                            var typeNode = GetOrAddNode(type);

                            AddDirectedEdgeIfMissing(typeNode, callerNode, CodeBlockArcType.TypeUsage);
                        }
                    }

                    // fields
                    var fields = syntaxRoot.DescendantNodes().OfType<FieldDeclarationSyntax>();
                    foreach (var fieldDecl in fields)
                    {
                        var fieldSymbol = semanticModel.GetDeclaredSymbol(fieldDecl) as IFieldSymbol;
                        if (fieldSymbol == null) continue;

                        var fieldNode = GetNode(fieldSymbol);

                        var typeNode = GetOrAddNode(fieldSymbol.Type);

                        AddDirectedEdgeIfMissing(typeNode, fieldNode, CodeBlockArcType.TypeUsage);
                    }

                    // properties
                    var properties = syntaxRoot.DescendantNodes().OfType<PropertyDeclarationSyntax>();
                    foreach (var propertyDecl in properties)
                    {
                        var propertySymbol = semanticModel.GetDeclaredSymbol(propertyDecl) as IFieldSymbol;
                        if (propertySymbol == null) continue;

                        var propertyNode = GetNode(propertySymbol);

                        var typeNode = GetOrAddNode(propertySymbol.Type);

                        AddDirectedEdgeIfMissing(typeNode, propertyNode, CodeBlockArcType.TypeUsage);
                    }
                }
            }
        }
    }
}
