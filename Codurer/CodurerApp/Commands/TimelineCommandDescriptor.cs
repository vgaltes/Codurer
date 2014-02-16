using System;
using System.Linq;

namespace CodurerApp.Commands
{
    public class TimelineCommandDescriptor : AbstractCommandDescriptor<TimelineCommand>
    {
        public override bool CanHandle(string commandLine)
        {
            return commandLine
                .Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                .Count() == 1;
        }

        protected override TimelineCommand BuildCommand(Codurer codurer, string commandLine)
        {
            string[] parameters = new string[] { commandLine };
            return new TimelineCommand(codurer, parameters);
        }
    }
}