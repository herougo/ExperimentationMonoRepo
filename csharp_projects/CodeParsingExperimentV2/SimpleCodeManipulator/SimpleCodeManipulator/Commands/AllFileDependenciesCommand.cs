using CodeParsingNet9;
using CodeParsingNet9.CodeManipulator2;
using SimpleCodeManipulator.Utils;
using System;
using System.Collections.Generic;
using System.CommandLine;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleCodeManipulator.SimpleCodeManipulator.Commands
{
    public static class AllFileDependenciesCommandCreator
    {
        public const string ArgPathName = "path";

        public static CliSubcommand Create()
        {
            var pathArg = new CliArgument(ArgPathName, "The path to the solution file to analyze.");
            ICliCommandHandler handler = new AllFileDependenciesCommandHandler();

            var cmd = new CliSubcommand(
                "all-file-dependencies",
                "Prints dependency information for each file in the project.",
                new List<CliArgument>() { pathArg },
                new List<CliOption>() { },
                handler
            );

            return cmd;
        }
    }

    public class AllFileDependenciesCommandHandler : ICliCommandHandler
    {
        public void Handle(Dictionary<string, string> arguments, Dictionary<string, string> options)
        {
            string path = arguments[AllFileDependenciesCommandCreator.ArgPathName];

            CodeManipulator2 manipulator = new CodeManipulator2(path);

        }
    }
}
