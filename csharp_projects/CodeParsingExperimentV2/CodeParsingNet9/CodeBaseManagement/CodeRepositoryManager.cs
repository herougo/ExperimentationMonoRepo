using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeParsingNet9.CodeBaseManagement
{
    public class CodeRepositoryManager
    {
        private string _pathToRepo;

        public CodeRepositoryManager(string pathToRepo)
        {
            _pathToRepo = pathToRepo;

            if (!Directory.Exists(_pathToRepo))
            {
                throw new ArgumentException($"Not a git repository: {pathToRepo}");
            }

            // TODO: check that the path is a git repository
        }
    }
}
