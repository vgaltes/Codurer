namespace CodurerApp.Commands
{
    using System;
    using System.Collections.Generic;

    public class PostCommand : Command
    {
        Codurer codurer;
        string message;
        string user;

        public PostCommand(Codurer codurer, string message, string user)
        {
            this.codurer = codurer;
            this.message = message;
            this.user = user;
        }

        public CommandResult Execute()
        {
            codurer.Post(message, user);
            return new CommandResult();
        }

        public CommandResult Execute(DateTime postingTime)
        {
            codurer.Post(message, user, postingTime);
            return new CommandResult();
        }
    }
}
