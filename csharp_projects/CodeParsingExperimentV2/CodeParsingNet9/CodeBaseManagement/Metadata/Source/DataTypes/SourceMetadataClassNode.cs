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
        public readonly List<IClassNodeMember>? Content  = new List<IClassNodeMember>();
        public readonly SourceMetadataClassNodeMetadata Metadata = new SourceMetadataClassNodeMetadata();

        public SourceMetadataClassNode(ClassDeclarationSyntax classNode, IdGenerator idGenerator)
        {
            Id = idGenerator.GetNext();
            Name = classNode.Identifier.Text;

            foreach (var member in classNode.Members)
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

                    case MethodDeclarationSyntax methodDeclaration:
                        Content.Add(new SourceMetadataMethodNode(methodDeclaration, idGenerator));
                        break;
                }
            }
        }
    }
}
