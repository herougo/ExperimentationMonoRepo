using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeParsingNet9.CodeBaseManagement.Metadata.Source.DataTypes
{
    internal class SourceMetadataClassNodeMetadata
    {
        public string? DirectImportedTypes { get; set; } = null;
        public string? IndirectImportedTypes { get; set; } = null;
        public string? DirectImportedMethods { get; set; } = null;
        public string? IndirectImportedMethods { get; set; } = null;
        public string? DirectExportedMethods { get; set; } = null;
        public string? IndirectExportedMethods { get; set; } = null;
    }


    internal class SourceMetadataClassNode : INode, IFileNodeMember, IClassNodeMember
    {
        public readonly string Name;
        public readonly string Id;
        private List<IClassNodeMember>? _content = null;
        private readonly SourceMetadataClassNodeMetadata Metadata = new SourceMetadataClassNodeMetadata();

        public SourceMetadataClassNode(ClassDeclarationSyntax classNode, IdGenerator idGenerator)
        {
            Id = idGenerator.GetNext();
            Name = classNode.Identifier.Text;

            _content = new List<IClassNodeMember>();

            foreach (var member in classNode.Members)
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
                else if (member is MethodDeclarationSyntax methodDeclaration)
                {
                    _content.Add(new SourceMetadataMethodNode(methodDeclaration, idGenerator));
                }
            }
        }

    }
}
