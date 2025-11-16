using System.CommandLine;
using SimpleCodeManipulator.SimpleCodeManipulator.Commands;
using SimpleCodeManipulator.SimpleCodeManipulator;
using SimpleCodeManipulator.Utils;

var wrapper = CodeManipulatorCliWrapperCreator.Create();
wrapper.Run(args);
