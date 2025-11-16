using CodeParsingNet9.CodeManipulator;
using CodeParsingNet9.CodeManipulator2;
using CodeParsingNet9.CodeManipulator2.StaticUtils;
using CodeParsingNet9.Utility;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using SimpleCodeManipulator.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace SimpleCodeManipulator.SimpleCodeManipulator.Commands
{
    public class MethodDependencyGraphDfsManager : IDfsManager<MethodNode>
    {
        private StringBuilder _stringBuilder = new StringBuilder();
        private readonly Dictionary<MethodNode, HashSet<MethodNode>> _graph;

        public MethodDependencyGraphDfsManager(Dictionary<MethodNode, HashSet<MethodNode>> graph)
        {
            _graph = graph;
        }

        public List<MethodNode> GetChildren(MethodNode node)
        {
            return _graph[node].ToList();
        }

        public void ProcessNode(MethodNode node, List<MethodNode> pathFromRoot)
        {
            // Do nothing
        }

        public void ProcessNodeBeforeVisitCheck(MethodNode node, List<MethodNode> pathFromRoot, bool visited)
        {
            StringBuilder result = new StringBuilder();
            for (int i = 2; i < pathFromRoot.Count; i++)
            {
                result.Append("  ");
            }
            if (pathFromRoot.Count > 1) result.Append("- ");
            if (visited)
            {
                result.Append("(VISITED) ");
            }
            result.Append(node.ToString());

            _stringBuilder.AppendLine(result.ToString());
        }

        public string ExtractValue()
        {
            return _stringBuilder.ToString();
        }
    }

    public static class MethodDependencyGraphCommandCreator
    {
        public const string ArgPathName = "solution-path";
        public const string ArgProjectsName = "projects";
        public const string ArgOutputPathName = "--output-path";

        public static CliSubcommand Create()
        {
            var pathArg = new CliArgument(ArgPathName, "The path to the solution file to analyze.");
            var projectsArg = new CliArgument(ArgProjectsName, "A comma-separated list of the projects to analyze.");
            var outputPathArg = new CliArgument(ArgOutputPathName, "Where to put the 'output' folder.");
            ICliCommandHandler handler = new MethodDependencyGraphCommandHandler();

            var cmd = new CliSubcommand(
                "method-dependency-graph",
                "For every method in the solution, create a file which contains the call graph info.",
                new List<CliArgument>() { pathArg, projectsArg, outputPathArg },
                new List<CliOption>() {  },
                handler
            );

            return cmd;
        }
    }

    public class MethodDependencyGraphCommandHandler : ICliCommandHandler
    {
        public void Handle(Dictionary<string, string> arguments, Dictionary<string, string> options)
        {
            string path = arguments[MethodDependencyGraphCommandCreator.ArgPathName];
            List<string> projectNames = arguments[MethodDependencyGraphCommandCreator.ArgProjectsName].Split(",").ToList();
            string outputPath = arguments[MethodDependencyGraphCommandCreator.ArgOutputPathName];

            if (!Directory.Exists(outputPath))
            {
                Directory.CreateDirectory(outputPath);
            }

            
            CodeManipulator2 manipulator = new CodeManipulator2(path);
            List<Project> projects = projectNames.Select(name => manipulator.GetProjectByName(name)).ToList();

            var graph = CodeUtils.BuildMethodDependencyGraphAsync(projects, manipulator.GetCompilations()).Result;

            foreach (var node in graph.Keys)
            {
                var manager = new MethodDependencyGraphDfsManager(graph);
                if (!CodeUtils.IsAssemblyInSolution(manipulator.GetCompilations(), node.Symbol.ContainingAssembly)) {
                    continue;
                }

                Console.WriteLine("Looking at " + node.ToString());

                DepthFirstSearch.Execute(node, manager);
                string callGraph = manager.ExtractValue();
                if (callGraph.Length > 5_000_000)
                {
                    throw new Exception($"big file: {callGraph.Length}");
                }

                List<string> folders = node.MethodId.Split(".").ToList();
                string fileName = folders[folders.Count - 1] + ".txt";
                folders = CodeParsingNet9.Utility.Utils.PopLast(folders);

                string dir = Path.Combine(outputPath, Path.Combine(folders.ToArray()));
                string filePath = Path.Combine(dir, fileName);

                if (!Directory.Exists(dir)) Directory.CreateDirectory(dir);
                File.WriteAllText(filePath, callGraph);

            }
        }
    }
}
