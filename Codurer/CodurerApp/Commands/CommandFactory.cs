namespace CodurerApp.Commands
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class CommandFactory
    {
        List<CommandDescriptor> commandDescriptors;

        public CommandFactory(List<CommandDescriptor> commandDescriptors)
        {
            this.commandDescriptors = commandDescriptors;
        }

        public Command GetCommand(string commandLine, Codurer codurer)
        {
            foreach( var commandDescriptor in commandDescriptors)
            {
                if (commandDescriptor.CanHandle(commandLine))
                    return commandDescriptor.GetCommand(codurer, commandLine);
            }

            throw new ArgumentException("The command line contains no valid command.");
        }
    }
}