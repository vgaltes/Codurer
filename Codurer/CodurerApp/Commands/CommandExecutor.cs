namespace CodurerApp.Commands
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using CodurerApp.CommandDescriptors;

    public class CommandExecutor
    {
        private List<CommandDescriptor> commandDescriptors;
        private Codurer codurer;

        public CommandExecutor(Codurer codurer, List<CommandDescriptor> commandDescriptors)
        {
            this.codurer = codurer;
            this.commandDescriptors = commandDescriptors;
        }

        public CommandResult ExecuteCommand(string commandLine)
        {
            return commandDescriptors
                .First(commandDescriptor => commandDescriptor.CanHandle(commandLine))
                .GetCommand(codurer, commandLine)
                .Execute();
        }

        public CommandResult ExecuteCommand(string commandLine, DateTime postingTime)
        {
            CommandResult commandResult = new CommandResult();

            foreach (CommandDescriptor commandDescriptor in commandDescriptors)
            {
                if (commandDescriptor.CanHandle(commandLine))
                {
                    Command command = commandDescriptor.GetCommand(codurer, commandLine);
                    commandResult = command.Execute(postingTime);
                }
            }

            return commandResult;
        }
    }
}