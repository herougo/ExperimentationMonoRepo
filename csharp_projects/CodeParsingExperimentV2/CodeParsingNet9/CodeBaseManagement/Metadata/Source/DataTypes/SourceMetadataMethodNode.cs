using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace CodeParsingNet9.CodeBaseManagement.Metadata.Source.DataTypes
{
    internal class SourceMetadataMethodNodeMetadata
    {
        public string? DirectImportedTypes { get; set; } = null;
        public string? IndirectImportedTypes { get; set; } = null;
        public string? DirectImportedMethods { get; set; } = null;
        public string? IndirectImportedMethods { get; set; } = null;
        public string? DirectExportedMethods { get; set; } = null;
        public string? IndirectExportedMethods { get; set; } = null;
    }

    internal class SourceMetadataMethodNode : ISourceMetadataNode, ISourceMetadataClassNodeMember
    {
        public readonly string Name;
        public readonly string Id;
        private readonly SourceMetadataMethodNodeMetadata Metadata = new SourceMetadataMethodNodeMetadata();

        public SourceMetadataMethodNode(MethodDeclarationSyntax methodNode, IdGenerator idGenerator)
        {
            Id = idGenerator.GetNext();
            Name = methodNode.Identifier.Text;
        }
    }
}
