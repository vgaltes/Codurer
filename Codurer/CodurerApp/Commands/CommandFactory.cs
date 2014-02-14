namespace CodurerApp.Commands
{
    using System;
    public static class CommandFactory
    {
        public static Command GetCommand(string commandLine, Codurer codurer)
        {
            if (CommandLineParser.IsPostCommand(commandLine))
            {
                var user = CommandLineParser.GetPostingUserFrom(commandLine);
                var message = CommandLineParser.GetMessageFrom(commandLine);
                string[] parameters = new string[] { message, user };
                return new PostCommand(codurer, parameters);
            }
            else if (CommandLineParser.IsTimelineCommand(commandLine))
            {
                var user = CommandLineParser.GetPostingUserFrom(commandLine);
                return new TimelineCommand(codurer, user);
            }
            else if ( CommandLineParser.IsFollowingCommand(commandLine))
            {
                var user = CommandLineParser.GetFollowerUserFrom(commandLine);
                var following = CommandLineParser.GetFollowingUserFrom(commandLine);
                return new FollowCommand(codurer, user, following);
            }
            else if (CommandLineParser.IsWallCommand(commandLine))
            {
                var user = CommandLineParser.GetWallUserFrom(commandLine);
                return new WallCommand(codurer, user);
            }

            throw new ArgumentException("The command line contains no valid command.");
        }
    }
}