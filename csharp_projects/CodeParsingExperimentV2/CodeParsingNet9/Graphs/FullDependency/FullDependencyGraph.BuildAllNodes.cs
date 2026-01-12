using CodeParsingNet9.CodeBaseManagement;
using CodeParsingNet9.CodeBaseManagement.Metadata.Source.DataTypes;
using CodeParsingNet9.CodeManipulator2.StaticUtils;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace CodeParsingNet9.Graphs.FullDependency
{
    public partial class FullDependencyGraph
    {
        private async Task BuildAllNodesAndMemberArcs(List<Project> projects)
        {
            foreach (var project in projects)
            {
                foreach (var document in project.Documents)
                {
                    var syntaxRoot = CodeUtils.GetRootNode(document);
                    if (syntaxRoot == null) continue;

                    var semanticModel = await document.GetSemanticModelAsync();
                    if (semanticModel == null) continue;

                    foreach (var member in CodeUtils.GetChildren(syntaxRoot))
                    {
                        await BuildAllMemberNodesRecursively(member, semanticModel);
                    }

                }
            }
        }

        private async Task<CodeBlockNode?> BuildAllMemberNodesRecursively(MemberDeclarationSyntax node, SemanticModel semanticModel)
        {
            var symbol = CodeUtils.GetDeclaredSymbol(node, semanticModel);
            if (symbol == null)
            {
                return null;
            }
            
            switch (node)
            {
                case ClassDeclarationSyntax classDeclaration:
                    var parentNode = GetOrAddNode(symbol);
                    foreach (var member in CodeUtils.GetChildren(classDeclaration)) {
                        CodeBlockNode? memberNode = await BuildAllMemberNodesRecursively(member, semanticModel);
                        if (memberNode == null) continue;

                        AddDirectedEdge(parentNode, memberNode, CodeBlockArcType.ContainedMember);
                    }
                    return parentNode;
                case EnumDeclarationSyntax enumDeclaration:
                case InterfaceDeclarationSyntax interfaceDeclaration:
                case MethodDeclarationSyntax methodDeclaration:
                case FieldDeclarationSyntax fieldDeclaration:
                case PropertyDeclarationSyntax propertyDeclaration:
                    return GetOrAddNode(symbol);
                default:
                    return null;
            }
        }
    }
}
