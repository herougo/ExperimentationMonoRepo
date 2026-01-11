using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeParsingNet9.CodeBaseManagement.Metadata.Source.DataTypes
{
    internal class SourceMetadataEnumNode : ISourceMetadataNode, ISourceMetadataFileNodeMember, ISourceMetadataClassNodeMember
    {
        public readonly string Name;
        public readonly string Id;
        private readonly SourceMetadataMethodNodeMetadata Metadata = new SourceMetadataMethodNodeMetadata();

        public SourceMetadataEnumNode(EnumDeclarationSyntax enumNode, IdGenerator idGenerator)
        {
            Id = idGenerator.GetNext();
            Name = enumNode.Identifier.Text;
        }
    }
}
