using CodeParsingNet9.CodeManipulator2.StaticUtils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeParsingNet9.CodeBaseManagement.Metadata.Source
{
    internal class CodeBaseSourceMetadata
    {
        private string _sourceCodeBasePath;
        private string _metadataFolderPath;

        public CodeBaseSourceMetadata(string sourceCodeBasePath, string metadataFolderPath)
        {
            _sourceCodeBasePath = sourceCodeBasePath;
            _metadataFolderPath = metadataFolderPath;

            if (!Directory.Exists(sourceCodeBasePath))
            {
                throw new ArgumentException($"CodeBaseSourceMetadata: {sourceCodeBasePath} is not a folder");
            }

            if (!Directory.Exists(metadataFolderPath))
            {
                throw new ArgumentException($"CodeBaseSourceMetadata: {metadataFolderPath} is not a folder");
            }
        }

        public void BuildAndSave()
        {
            string solutionPath = CodeUtils.GetSolutionFilePathFromDirectory(_sourceCodeBasePath);
            var manipulator = new CodeParsingNet9.CodeManipulator2.CodeManipulator2(solutionPath);


        }
    }
}
