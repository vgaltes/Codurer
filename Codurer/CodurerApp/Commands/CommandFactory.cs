namespace CodurerApp.Commands
{
    using System;
    public static class CommandFactory
    {
        public static Command GetCommand(string commandLine, Codurer codurer)
        {
            var user = CommandLineParser.GetPostingUserFrom(commandLine);

            if (CommandLineParser.IsPostCommand(commandLine))
            {   
                var message = CommandLineParser.GetMessageFrom(commandLine);
                return new PostCommand(codurer, message, user);
            }
            else if (CommandLineParser.IsTimelineCommand(commandLine))
            {
                return new TimelineCommand(codurer, user);
            }
            else if ( CommandLineParser.IsFollowingCommand(commandLine))
            {
                var following = CommandLineParser.GetFollowingUserFrom(commandLine);
                return new FollowCommand(codurer, user, following);
            }

            throw new ArgumentException("The command line contains no valid command.");
        }
    }
}