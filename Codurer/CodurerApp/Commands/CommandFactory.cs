namespace CodurerApp.Commands
{
    using System;
    public class CommandFactory
    {
        public static Command GetCommand(string commandLine)
        {
            if (commandLine.Contains("->"))
                return new PostCommand();

            throw new ArgumentException("The command line contains no valid command.");
        }
    }
}