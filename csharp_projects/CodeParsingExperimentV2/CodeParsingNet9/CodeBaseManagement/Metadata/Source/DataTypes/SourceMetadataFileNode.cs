using Microsoft.CodeAnalysis;
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

        public SourceMetadataFileNode(string filePath, Document doc)
        {
            _filePath = filePath;

            // TODO: fill content
        }
    }
}
