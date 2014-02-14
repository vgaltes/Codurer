namespace CodurerApp
{
    using System;

    public static class CommandLineParser
    {
        private const string postingSplitWord = "->";
        private const string followingSplitWord = "follows";
        private const string wallSplitWord = "wall";

        public static string GetMessageFrom(string commandLine)
        {
            return SplitCommandLine(commandLine, postingSplitWord)[1].Trim();
        }

        public static string GetPostingUserFrom(string commandLine)
        {
            return SplitCommandLine(commandLine, postingSplitWord)[0].Trim();
        }

        public static string GetFollowerUserFrom(string commandLine)
        {
            return SplitCommandLine(commandLine, followingSplitWord)[0].Trim();
        }

        public static bool IsPostCommand(string commandLine)
        {
            return commandLine.Contains(postingSplitWord);
        }

        public static bool IsTimelineCommand(string commandLine)
        {
            return IsThereOnlyOneWord(commandLine);
        }

        internal static string GetFollowingUserFrom(string commandLine)
        {
            return SplitCommandLine(commandLine, followingSplitWord)[1].Trim();
        }

        internal static bool IsFollowingCommand(string commandLine)
        {
            return commandLine.Contains(followingSplitWord);
        }

        internal static bool IsWallCommand(string commandLine)
        {
            return commandLine.Contains(wallSplitWord);
        }

        internal static string GetWallUserFrom(string commandLine)
        {
            return SplitCommandLine(commandLine, wallSplitWord)[0].Trim();
        }

        private static string[] SplitCommandLine(string commandLine, string splitWord)
        {
            return commandLine.Split(new string[] { splitWord }, StringSplitOptions.RemoveEmptyEntries);
        }

        private static bool IsThereOnlyOneWord(string commandLine)
        {
            return commandLine.IndexOf(' ') == -1;
        }
    }
}
