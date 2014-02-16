namespace CodurerApp.CommandDescriptors
{
    using System;
    using System.Linq;
    using CodurerApp.Commands;

    public class TimelineCommandDescriptor : CommandDescriptor
    {
        public bool CanHandle(string commandLine)
        {
            return commandLine
                .Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                .Count() == 1;
        }

        public Command GetCommand(Codurer codurer, string commandLine)
        {
            string user = commandLine;
            return new TimelineCommand(codurer, user);
        }
    }
}