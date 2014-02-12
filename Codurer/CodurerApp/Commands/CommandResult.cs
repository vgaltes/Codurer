namespace CodurerApp.Commands
{
    using System.Collections.Generic;

    public class CommandResult
    {
        public CommandResult()
        {
            Items = new List<string>();
        }

        public IEnumerable<string> Items {get;set;}
    }
}