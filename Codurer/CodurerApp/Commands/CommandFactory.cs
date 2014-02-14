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

            if ( postCommandDescriptor.IsCommand(commandLine))
            {
                return postCommandDescriptor.GetCommand(codurer, commandLine);
            }
            if (CommandLineParser.IsTimelineCommand(commandLine))
            {
                var user = CommandLineParser.GetPostingUserFrom(commandLine);
                string[] parameters = new string[] { user }; 
                return new TimelineCommand(codurer, parameters);
            }
            else if ( CommandLineParser.IsFollowingCommand(commandLine))
            {
                var user = CommandLineParser.GetFollowerUserFrom(commandLine);
                var following = CommandLineParser.GetFollowingUserFrom(commandLine);
                string[] parameters = new string[] { user, following };
                return new FollowCommand(codurer, parameters);
            }
            else if (CommandLineParser.IsWallCommand(commandLine))
            {
                var user = CommandLineParser.GetWallUserFrom(commandLine);
                string[] parameters = new string[] { user };
                return new WallCommand(codurer, parameters);
            }

            throw new ArgumentException("The command line contains no valid command.");
        }
    }
}