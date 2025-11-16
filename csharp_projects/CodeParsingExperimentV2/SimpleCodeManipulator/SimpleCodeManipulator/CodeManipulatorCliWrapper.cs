using SimpleCodeManipulator.SimpleCodeManipulator.Commands;
using SimpleCodeManipulator.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleCodeManipulator.SimpleCodeManipulator
{
    public static class CodeManipulatorCliWrapperCreator
    {
        public static CliWrapper Create()
        {
            var subcommands = new List<CliSubcommand>() {
                AllFileDependenciesCommandCreator.Create(),
                ResourceTreeCommandCreator.Create(),
                MethodDependencyGraphCommandCreator.Create()
            };

            return new CliWrapper("CLI tool for analyzing codebases using Roslyn", subcommands);
        }
    }
}
