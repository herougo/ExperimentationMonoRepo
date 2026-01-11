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


    internal class SourceMetadataClassNode : INode, IFileNodeMember
    {
        public readonly string Name;
        public readonly string Id;
        private List<IFileNodeMember>? _content = null;
        private readonly SourceMetadataClassNodeMetadata Metadata = new SourceMetadataClassNodeMetadata();

        public SourceMetadataClassNode(ClassDeclarationSyntax classNode, string id)
        {
            Id = id;
            Name = classNode.Identifier.Text;
            // TODO: populate content
        }

    }
}
