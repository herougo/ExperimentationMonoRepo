using Microsoft.CodeAnalysis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace CodeParsingNet9.CodeBaseManagement.Metadata.Source
{
    public class CodeBaseSourceMetadataFile
    {
        public CodeBaseSourceMetadataFile(string path)
        {
            string json = File.ReadAllText(path);
            JsonDocument doc = JsonDocument.Parse(json);

            // TODO ...............
        }

        public CodeBaseSourceMetadataFile(Document doc)
        {

            // TODO ...............
        }

        public void Save(string destPath)
        {
            // TODO ...............
        }
    }
}
