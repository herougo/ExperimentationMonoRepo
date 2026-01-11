using CodeParsingNet9.CodeManipulator2.StaticUtils;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeParsingNet9.CodeBaseManagement.Metadata.Source.DataTypes
{
    internal class SourceMetadataFileNode : ISourceMetadataNode
    {
        public readonly string FilePath;
        public readonly List<ISourceMetadataFileNodeMember> Content = new List<ISourceMetadataFileNodeMember>();

        public SourceMetadataFileNode(string filePath, Document doc, IdGenerator idGenerator)
        {
            FilePath = filePath;

            var rootNode = CodeUtils.GetRootNode(doc);
            var namespaceNode = CodeUtils.GetNamespaceNode(rootNode);

            foreach (var member in namespaceNode.Members)
            {
                switch (member)
                {
                    case ClassDeclarationSyntax classDeclaration:
                        Content.Add(new SourceMetadataClassNode(classDeclaration, idGenerator));
                        break;
                    case EnumDeclarationSyntax enumDeclaration:
                        Content.Add(new SourceMetadataEnumNode(enumDeclaration, idGenerator));
                        break;
                    case InterfaceDeclarationSyntax interfaceDeclaration:
                        Content.Add(new SourceMetadataInterfaceNode(interfaceDeclaration, idGenerator));
                        break;
                }
            }
        }
    }
}
