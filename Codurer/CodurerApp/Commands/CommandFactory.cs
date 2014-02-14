namespace CodurerApp.Commands
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

     public static class CommandFactory
    {
        public static Command GetCommand(string commandLine, Codurer codurer)
        {
            var postCommandDescriptor = new CommandDescriptor(typeof(PostCommand),
                cLine => cLine.Contains("->"),
                cLine => cLine
                    .Split(new string[] { "->" }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(parameter => parameter.Trim())
                    .ToArray<string>());

            var timelineCommandDescriptor = new CommandDescriptor(typeof(TimelineCommand),
                cLine => cLine.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries).Count() == 1,
                cLine => new string[] { cLine });

            var followCommandDescriptor = new CommandDescriptor(typeof(FollowCommand),
                cLine => cLine.Contains("follows"),
                cLine => cLine
                    .Split(new string[] { "follows" }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(parameter => parameter.Trim())
                    .ToArray<string>());

            var wallCommandDescriptor = new CommandDescriptor(typeof(WallCommand),
                cLine => cLine.Contains("wall"),
                cLine => cLine
                    .Split(new string[] { "wall" }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(parameter => parameter.Trim())
                    .ToArray<string>());

            if ( postCommandDescriptor.IsCommand(commandLine))
            {
                return postCommandDescriptor.GetCommand(codurer, commandLine);
            }
            else if ( timelineCommandDescriptor.IsCommand(commandLine))
            {
                return timelineCommandDescriptor.GetCommand(codurer, commandLine);
            }
            else if ( followCommandDescriptor.IsCommand(commandLine))
            {
                return followCommandDescriptor.GetCommand(codurer, commandLine);
            }
            else if ( wallCommandDescriptor.IsCommand(commandLine))
            {
                return wallCommandDescriptor.GetCommand(codurer, commandLine);
            }

            throw new ArgumentException("The command line contains no valid command.");
        }
    }
}