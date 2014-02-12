namespace CodurerApp.Commands
{
    using System;
    public class CommandFactory
    {
        public static Command GetCommand(string commandLine, Codurer codurer)
        {
            if (IsPostCommand(commandLine))
                return new PostCommand(codurer);
            else if (IsTimelineCommand(commandLine))
                return new TimelineCommand(codurer);

            throw new ArgumentException("The command line contains no valid command.");
        }

        private static bool IsTimelineCommand(string commandLine)
        {
            return IsThereOnlyOneWord(commandLine);
        }

        private static bool IsThereOnlyOneWord(string commandLine)
        {
            return commandLine.IndexOf(' ') == -1;
        }

        private static bool IsPostCommand(string commandLine)
        {
            return commandLine.Contains("->");
        }
    }
}