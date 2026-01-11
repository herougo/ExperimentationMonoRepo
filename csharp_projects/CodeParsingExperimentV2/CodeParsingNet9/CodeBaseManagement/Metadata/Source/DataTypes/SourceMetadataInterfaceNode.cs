using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace CodeParsingNet9.CodeBaseManagement.Metadata.Source.DataTypes
{
    internal class SourceMetadataInterfaceNodeMetadata
    {
        public string? DirectImportedTypes { get; set; } = null;
        public string? DirectExportedMethods { get; set; } = null;
        public string? IndirectExportedMethods { get; set; } = null;
    }

    internal class SourceMetadataInterfaceNode : ISourceMetadataNode, ISourceMetadataClassNodeMember, ISourceMetadataFileNodeMember
    {
        // TODO: adapt to have content

        public readonly string Name;
        public readonly string Id;
        private readonly SourceMetadataInterfaceNodeMetadata Metadata = new SourceMetadataInterfaceNodeMetadata();

        public SourceMetadataInterfaceNode(InterfaceDeclarationSyntax interfaceNode, IdGenerator idGenerator)
        {
            Id = idGenerator.GetNext();
            Name = interfaceNode.Identifier.Text;
        }
    }
}
