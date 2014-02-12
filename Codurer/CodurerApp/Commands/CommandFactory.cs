namespace CodurerApp.Commands
{
    using System;
    public class CommandFactory
    {
        public static Command GetCommand(string commandLine)
        {
            if (commandLine.Contains("->"))
                return new PostCommand();
            else if (commandLine.Split(new string[] { "->" }, StringSplitOptions.RemoveEmptyEntries).Length == 1)
                return new TimelineCommand();

            throw new ArgumentException("The command line contains no valid command.");
        }
    }
}