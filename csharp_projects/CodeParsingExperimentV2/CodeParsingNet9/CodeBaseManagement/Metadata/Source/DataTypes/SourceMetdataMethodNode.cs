using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Collections.Generic;
using System.Linq;
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

    internal class SourceMetdataMethodNode : INode, IClassNodeMember
    {
        public readonly string Name;
        public readonly string Id;
        private readonly SourceMetadataMethodNodeMetadata Metadata = new SourceMetadataMethodNodeMetadata();

        public SourceMetdataMethodNode(MethodDeclarationSyntax methodNode, string id)
        {
            Id = id;
            Name = methodNode.Identifier.Text;
        }
    }
}
