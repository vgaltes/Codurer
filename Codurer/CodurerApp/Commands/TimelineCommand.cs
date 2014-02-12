namespace CodurerApp.Commands
{
    using System.Collections.Generic;

    public class TimelineCommand : Command
    {
        Codurer codurer;

        public TimelineCommand(Codurer codurer)
        {
            this.codurer = codurer;
        }

        public IEnumerable<string> Execute()
        {
            throw new System.NotImplementedException();
        }
    }
}
