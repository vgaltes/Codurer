namespace CodurerApp.Commands
{
    using System;
    using System.Linq;

    public static class CommandFactory
    {
        public static Command GetCommand(string commandLine, Codurer codurer)
        {
            CommandDescriptor<PostCommand> postCommandDescriptor = new CommandDescriptor<PostCommand>(
                cLine => cLine.Contains("->"),
                cLine => cLine
                    .Split(new string[] { "->" }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(parameter => parameter.Trim())
                    .ToArray<string>());

            CommandDescriptor<TimelineCommand> timelineCommandDescriptor = new CommandDescriptor<TimelineCommand>(
                cLine => cLine.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries).Count() == 1,
                cLine => new string[] { cLine });

            CommandDescriptor<FollowCommand> followCommandDescriptor = new CommandDescriptor<FollowCommand>(
                cLine => cLine.Contains("follows"),
                cLine => cLine
                    .Split(new string[] { "follows" }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(parameter => parameter.Trim())
                    .ToArray<string>());

            CommandDescriptor<WallCommand> wallCommandDescriptor = new CommandDescriptor<WallCommand>(
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