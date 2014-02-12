namespace CodurerApp.Commands
{
    using System.Collections.Generic;

    public interface Command
    {
        IEnumerable<string> Execute();
    }
}