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
                return new PostCommand(codurer, message, user);
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

            throw new ArgumentException("The command line contains no valid command.");
        }
    }
}