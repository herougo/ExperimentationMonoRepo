using Microsoft.Build.Evaluation;
using Microsoft.Build.Locator;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.MSBuild;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeParsingNet9.CodeManipulator2
{
    public partial class CodeManipulator2
    {
        private Microsoft.CodeAnalysis.Solution _solution = null;
        private Microsoft.CodeAnalysis.MSBuild.MSBuildWorkspace _workspace = null;
        private Dictionary<string, Microsoft.CodeAnalysis.Compilation> _compilations = new Dictionary<
            string, Microsoft.CodeAnalysis.Compilation
        >();

        public CodeManipulator2(string solutionPath)
        {
            var setupResult = Setup(solutionPath).Result;
        }

        public async Task<bool> Setup(string solutionPath)
        {
            if (!MSBuildLocator.IsRegistered) MSBuildLocator.RegisterDefaults();

            _workspace = MSBuildWorkspace.Create();
            Console.WriteLine("Loading solution...");
            _solution = await _workspace.OpenSolutionAsync(solutionPath);
            Console.WriteLine($"Loaded solution: {_solution.FilePath}");
            foreach (var project in _solution.Projects)
            {
                var compilation = await project.GetCompilationAsync().ConfigureAwait(false);
                // compilation is very useful for updating the csproj file
                if (compilation == null)
                    throw new InvalidOperationException("Failed to get project compilation.");
                _compilations.Add(project.Name, compilation);
                Console.WriteLine($"Project {project.Name} compiled");
            }
            Console.WriteLine($"Compiled!");

            return true;
        }

        public bool TryApplyChanges(Solution newSolution)
        {
            return _workspace.TryApplyChanges(newSolution);
        }

        public void Dispose()
        {
            _workspace.Dispose();
        }
    }
}
