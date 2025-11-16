using CodeParsingNet9.CodeManipulator2;
using CodeParsingNet9.CodeManipulator2.StaticUtils;
using Microsoft.CodeAnalysis;
using SimpleCodeManipulator.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleCodeManipulator.SimpleCodeManipulator.Commands
{
    public static class ResourceTreeCommandCreator
    {
        public const string ArgPathName = "path";
        public const string ArgProjectsName = "projects";

        public static CliSubcommand Create()
        {
            var pathArg = new CliArgument(ArgPathName, "The path to the solution file to analyze.");
            var projectsArg = new CliArgument(ArgProjectsName, "A comma-separated list of the projects to analyze.");
            ICliCommandHandler handler = new ResourceTreeCommandHandler();

            var cmd = new CliSubcommand(
                "resource-tree",
                "Prints tree of resources for each project specified and also outputs naming conflicts.",
                new List<CliArgument>() { pathArg, projectsArg },
                new List<CliOption>() { },
                handler
            );

            return cmd;
        }
    }

    public class ResourceTreeCommandHandler : ICliCommandHandler
    {
        public void Handle(Dictionary<string, string> arguments, Dictionary<string, string> options)
        {
            string path = arguments[ResourceTreeCommandCreator.ArgPathName];
            List<string> projects = arguments[ResourceTreeCommandCreator.ArgProjectsName].Split(",").ToList();

            CodeManipulator2 manipulator = new CodeManipulator2(path);
            Solution solution = manipulator.GetSolution();

            foreach (string project in projects)
            {
                Console.WriteLine("    -------------------");
                Console.WriteLine("    " + project);
                Console.WriteLine("    -------------------");

                Console.WriteLine(CodeUtils.GetResourceTreeInfo(solution, project));
                Console.WriteLine();
            }
        }
    }
}
