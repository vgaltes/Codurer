namespace CodurerApp
{
    using System;

    public static class CommandLineParser
    {
        public static string GetMessageFrom(string commandLine)
        {
            return SplitCommandLine(commandLine)[1].Trim();
        }

        public static string GetUserFrom(string commandLine)
        {
            return SplitCommandLine(commandLine)[0].Trim();
        }

        public static bool IsPostCommand(string commandLine)
        {
            return commandLine.Contains("->");
        }

        public static bool IsTimelineCommand(string commandLine)
        {
            return IsThereOnlyOneWord(commandLine);
        }

        private static string[] SplitCommandLine(string commandLine)
        {
            return commandLine.Split(new string[] { "->" }, StringSplitOptions.RemoveEmptyEntries);
        }       

        private static bool IsThereOnlyOneWord(string commandLine)
        {
            return commandLine.IndexOf(' ') == -1;
        }                
    }
}
