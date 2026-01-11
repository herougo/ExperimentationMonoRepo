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
    internal class SourceMetadataFileNode : INode
    {
        private string _filePath;
        private List<IFileNodeMember>? _content = null;

        public SourceMetadataFileNode(string filePath, Document doc, IdGenerator idGenerator)
        {
            _filePath = filePath;
            _content = new List<IFileNodeMember>();

            var rootNode = CodeUtils.GetRootNode(doc);
            var namespaceNode = CodeUtils.GetNamespaceNode(rootNode);

            foreach (var member in namespaceNode.Members)
            {
                if (member is ClassDeclarationSyntax classDeclaration)
                {
                    _content.Add(new SourceMetadataClassNode(classDeclaration, idGenerator));
                }
                else if (member is EnumDeclarationSyntax enumDeclaration)
                {
                    _content.Add(new SourceMetadataEnumNode(enumDeclaration, idGenerator));
                }
                else if (member is InterfaceDeclarationSyntax interfaceDeclaration)
                {
                    _content.Add(new SourceMetadataInterfaceNode(interfaceDeclaration, idGenerator));
                }
            }
        }
    }
}
