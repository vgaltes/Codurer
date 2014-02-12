namespace CodurerApp.Commands
{
    using System;
    using System.Collections.Generic;

    public class TimelineCommand : Command
    {
        Codurer codurer;
        string user;

        public TimelineCommand(Codurer codurer, string user)
        {
            this.codurer = codurer;
            this.user = user;
        }

        public IEnumerable<string> Execute()
        {
            return codurer.GetTimeline(user);
        }
        public IEnumerable<string> Execute(DateTime postingTime)
        {
            return codurer.GetTimeline(user);
        }
    }
}
