namespace CodurerApp.Commands
{
    using System;
    public class CommandFactory
    {
        public static Command GetCommand(string commandLine, Codurer codurer)
        {
            if (IsPostCommand(commandLine))
            {
                var user = GetUserFrom(commandLine);
                var message = GetMessageFrom(commandLine);
                return new PostCommand(codurer, message, user);
            }
            else if (IsTimelineCommand(commandLine))
            {
                var user = GetUserFrom(commandLine);
                return new TimelineCommand(codurer, user);
            }

            throw new ArgumentException("The command line contains no valid command.");
        }

        private static string GetMessageFrom(string commandLine)
        {
            return SplitCommandLine(commandLine)[1].Trim();
        }

        private static string GetUserFrom(string commandLine)
        {
            return SplitCommandLine(commandLine)[0].Trim();
        }

        private static string[] SplitCommandLine(string commandLine)
        {
            return commandLine.Split(new string[] { "->" }, StringSplitOptions.RemoveEmptyEntries);
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