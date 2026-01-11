using CodeParsingNet9.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace CodeParsingNet9.CodeBaseManagement
{
    public class MigrationManager
    {
        private CodeRepositoryManager _sourceRepo;
        private CodeRepositoryManager _destRepo;

        public MigrationManager(string metadataPath)
        {
            string json = File.ReadAllText(metadataPath);
            JsonDocument doc = JsonDocument.Parse(json);
            JsonElement root = doc.RootElement;
            string sourceRepoPath = JsonUtils.GetPropertyString(root, "source_repo_path");
            string destRepoPath = JsonUtils.GetPropertyString(root, "dest_repo_path");

            _sourceRepo = new CodeRepositoryManager(sourceRepoPath);
            _destRepo = new CodeRepositoryManager(destRepoPath);
        }


    }
}
