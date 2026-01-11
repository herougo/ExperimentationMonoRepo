using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeParsingNet9.CodeBaseManagement
{
    public class CodeBaseManager
    {
        private string _pathToCodeBase;

        public CodeBaseManager(string pathToCodeBase)
        {
            _pathToCodeBase = pathToCodeBase;

            if (!Directory.Exists(_pathToCodeBase))
            {
                throw new ArgumentException($"CodeBaseManager: {pathToCodeBase} is not a folder");
            }
        }

        public void CreateSourceMetadataFolder(string destinationPath)
        {
            if (!Directory.Exists(destinationPath))
            {
                throw new ArgumentException($"CreateSourceMetadataFolder: {destinationPath} is not a folder");
            }

            // TODO: iterate over every document and create a readable json file
        }
    }
}
