namespace CodurerApp.Commands
{
    using System;
    using System.Collections.Generic;

    public interface Command
    {
        IEnumerable<string> Execute();

        IEnumerable<string> Execute(DateTime postingTime);
    }
}