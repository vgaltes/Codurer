namespace CodurerApp.Commands
{
    using System;
    using System.Collections.Generic;

    public class TimelineCommand : Command
    {
        Codurer codurer;
        string user;

        public TimelineCommand(Codurer codurer, string[] parameters)
        {
            this.codurer = codurer;
            this.user = parameters[0];
        }

        public CommandResult Execute()
        {
            return new CommandResult
            {
                Items = codurer.GetTimeline(user)
            };
        }
        public CommandResult Execute(DateTime postingTime)
        {
            return Execute();
        }
    }
}
