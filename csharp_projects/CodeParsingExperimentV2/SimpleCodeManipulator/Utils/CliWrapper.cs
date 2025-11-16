using System;
using System.Collections.Generic;
using System.CommandLine;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleCodeManipulator.Utils
{
    public class CliOption
    {
        public readonly string Name;

        public readonly string Description;

        public CliOption(string name, string description)
        {
            Name = name;
            Description = description;
        }
    }

    public class CliArgument
    {
        public readonly string Name;

        public readonly string Description;

        public CliArgument(string name, string description)
        {
            Name = name;
            Description = description;
        }
    }

    public class CliSubcommand
    {
        public readonly string Name;

        public readonly string Description;

        public readonly List<CliArgument> Arguments;

        public readonly List<CliOption> Options;

        public readonly ICliCommandHandler Handler;

        public CliSubcommand(
            string name, string description,
            List<CliArgument> arguments, List<CliOption> options,
            ICliCommandHandler handler
        )
        {
            Name = name;
            Description = description;
            Arguments = arguments;
            Options = options;
            Handler = handler;
        }
    }

    public static class CliExtensions
    {
        public static Argument<string> ToSystemCommandLineArgument(this CliArgument argument)
        {
            return new Argument<string>(argument.Name)
            {
                Description = argument.Description
            };
        }

        public static Option<string> ToSystemCommandLineOption(this CliOption option)
        {
            return new Option<string>(option.Name)
            {
                Description = option.Description
            };
        }

        public static Command ToSystemCommandLineSubCommand(this CliSubcommand subcommand)
        {
            Command cmd = new Command(subcommand.Name, subcommand.Description);
            foreach (CliArgument argument in subcommand.Arguments)
            {
                cmd.Add(argument.ToSystemCommandLineArgument());
            }
            foreach (CliOption option in subcommand.Options)
            {
                cmd.Add(option.ToSystemCommandLineOption());
            }
            cmd.SetAction(parseResult =>
            {
                var arguments = new Dictionary<string, string>();
                foreach (Argument<string> argument in cmd.Arguments)
                {
                    arguments.Add(argument.Name, parseResult.GetValue(argument) ?? "");
                }
                var options = new Dictionary<string, string>();
                foreach (Option<string> option in cmd.Options)
                {
                    options.Add(option.Name, parseResult.GetValue(option) ?? "");
                }

                subcommand.Handler.Handle(arguments, options);
            });
            return cmd;
        }
    }

    public interface ICliCommandHandler
    {
        void Handle(Dictionary<string, string> arguments, Dictionary<string, string> options);
    }

    public class CliWrapper
    {
        private readonly RootCommand _root;

        public CliWrapper(string description, List<CliSubcommand> subcommmands)
        {
            _root = new RootCommand() { Description = description };

            foreach (var subcommand in subcommmands)
            {
                _root.Add(subcommand.ToSystemCommandLineSubCommand());
            }
        }

        public void Run(string[] args)
        {
            ParseResult result = _root.Parse(args);
            result.Invoke();
        }
    }
}
