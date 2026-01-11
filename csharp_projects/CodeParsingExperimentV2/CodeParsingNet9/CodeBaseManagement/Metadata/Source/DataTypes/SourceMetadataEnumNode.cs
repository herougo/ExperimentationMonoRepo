using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeParsingNet9.CodeBaseManagement.Metadata.Source.DataTypes
{
    internal class SourceMetadataEnumNode : INode, IFileNodeMember, IClassNodeMember
    {
        public readonly string Name;
        public readonly string Id;
        private readonly SourceMetadataMethodNodeMetadata Metadata = new SourceMetadataMethodNodeMetadata();

        public SourceMetadataEnumNode(EnumDeclarationSyntax enumNode, string id)
        {
            Id = id;
            Name = enumNode.Identifier.Text;
        }
    }
}
