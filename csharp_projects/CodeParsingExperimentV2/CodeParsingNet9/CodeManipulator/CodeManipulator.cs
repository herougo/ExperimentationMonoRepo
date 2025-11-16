using Microsoft.Build.Evaluation;
using Microsoft.Build.Locator;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.MSBuild;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeParsingNet9.CodeManipulator
{
    public partial class CodeManipulator : IDisposable
    {
        private string _projectPath;
        private Microsoft.CodeAnalysis.Project _project = null;
        private Microsoft.CodeAnalysis.MSBuild.MSBuildWorkspace _workspace = null;

        public CodeManipulator(string projectPath) {
            _projectPath = projectPath;
            var setupResult = Setup().Result;
        }

        public async Task<bool> Setup()
        {
            if (!MSBuildLocator.IsRegistered) MSBuildLocator.RegisterDefaults();

            _workspace = MSBuildWorkspace.Create();
            Console.WriteLine("Loading project...");
            _project = await _workspace.OpenProjectAsync(_projectPath);
            Console.WriteLine($"Loaded project: {_project.Name}");
            var compilation = await _project.GetCompilationAsync().ConfigureAwait(false);
            // compilation is very useful for updating the csproj file
            if (compilation == null)
                throw new InvalidOperationException("Failed to get project compilation.");
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
