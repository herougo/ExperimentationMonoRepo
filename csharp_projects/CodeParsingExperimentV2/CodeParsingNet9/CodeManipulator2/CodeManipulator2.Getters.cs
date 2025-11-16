using CodeParsingNet9.CodeManipulator2.StaticUtils;
using CodeParsingNet9.Utility;
using Microsoft.Build.Tasks;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Linq;
using System.Reflection;

namespace CodeParsingNet9.CodeManipulator2
{
    public partial class CodeManipulator2
    {
        public string GetSolutionFolder()
        {
            return CodeUtils.GetSolutionFolder(_solution);
        }

        public Project GetProject(string filePath)
        {
            return CodeUtils.GetProject(_solution, filePath);
        }

        public Project GetProjectByName(string name)
        {
            return CodeUtils.GetProjectByName(_solution, name);
        }

        public Document GetDocument(string filePath)
        {
            return CodeUtils.GetDocument(_solution, filePath);
        }

        public Solution GetSolution()
        {
            return _solution;
        }

        public Dictionary<string, Compilation> GetCompilations()
        {
            return _compilations;
        }

        public string GetProjectFolder(Project project)
        {
            return CodeUtils.GetProjectFolder(project);
        }
    }
}
