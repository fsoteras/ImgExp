using ImgExpnd.Commands;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ImgExpnd
{
    public class CommandParser
    {
        readonly IEnumerable<ICommandFactory> availableCommands;

        public CommandParser(IEnumerable<ICommandFactory> availableCommands)
        {
            this.availableCommands = availableCommands;
        }

        internal ICommand ParseCommand(string[] args)
        {

            // if there are no params , it should show help , so call ShowHelpCommand.
            if (args.Length == 0)
            {
                return new ShowHelpCommand();
            }
            else
            {

                var requestedCommandName = args[0];
                //remove middle dash and add *Command*
                if (requestedCommandName[0] == '-')
                {
                    requestedCommandName = requestedCommandName.Remove(0, 1);
                    //requestedCommandName = CommandParser.UppercaseFirst(requestedCommandName);
                    //  requestedCommandName += "Command";
                };

                var command = FindRequestedCommand(requestedCommandName);
                if (null == command)
                    return new NotFoundCommand { Name = requestedCommandName };

                return command.MakeCommand(args);

            };

        }

        ICommandFactory FindRequestedCommand(string commandName)
        {
            return availableCommands
                .FirstOrDefault(cmd => (String)cmd.CommandName == commandName);
        }

        static string UppercaseFirst(string s)
        {
            // Check for empty string.
            if (string.IsNullOrEmpty(s))
            {
                return string.Empty;
            }
            // Return char and concat substring.
            return char.ToUpper(s[0]) + s.Substring(1);
        }


    }
}
