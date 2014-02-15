namespace CodurerApp.Commands
{
    using System.Collections.Generic;

    public class CommandResult
    {
        public CommandResult()
        {
            Messages = new List<string>();
        }

        public IEnumerable<string> Messages {get;set;}
    }
}