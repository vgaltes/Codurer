namespace CodurerApp.Commands
{
    using System;
    using System.Collections.Generic;

    public interface Command
    {
        CommandResult Execute();

        CommandResult Execute(DateTime postingTime);
    }
}