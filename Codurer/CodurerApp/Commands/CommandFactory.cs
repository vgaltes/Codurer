namespace CodurerApp.Commands
{
    using System;
    public static class CommandFactory
    {
        public static Command GetCommand(string commandLine, Codurer codurer)
        {
            var user = CommandLineParser.GetUserFrom(commandLine);

            if (CommandLineParser.IsPostCommand(commandLine))
            {   
                var message = CommandLineParser.GetMessageFrom(commandLine);
                return new PostCommand(codurer, message, user);
            }
            else if (CommandLineParser.IsTimelineCommand(commandLine))
            {
                return new TimelineCommand(codurer, user);
            }

            throw new ArgumentException("The command line contains no valid command.");
        }
    }
}