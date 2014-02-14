namespace CodurerApp.Commands
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

     public static class CommandFactory
    {
        public static Command GetCommand(string commandLine, Codurer codurer)
        {
            var postCommandDescriptor = CommandDescriptorFactory.GetPostCommandDescriptor();
            var timelineCommandDescriptor = CommandDescriptorFactory.GetTimelineCommandDescriptor();
            var followCommandDescriptor = CommandDescriptorFactory.GetFollowingCommandDescriptor();
            var wallCommandDescriptor = CommandDescriptorFactory.GetWallCommandDescriptor();

            var commandDescriptors = new List<CommandDescriptor>
            {
                postCommandDescriptor,
                timelineCommandDescriptor,
                followCommandDescriptor,
                wallCommandDescriptor
            };

            foreach( var commandDescriptor in commandDescriptors)
            {
                if (commandDescriptor.IsCommand(commandLine))
                    return commandDescriptor.GetCommand(codurer, commandLine);
            }

            throw new ArgumentException("The command line contains no valid command.");
        }
    }
}