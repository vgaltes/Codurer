namespace CodurerApp.Commands
{
    using System;
    using System.Collections.Generic;

    public class PostCommand : Command
    {
        Codurer codurer;

        public PostCommand(Codurer codurer)
        {
            this.codurer = codurer;
        }

        public IEnumerable<string> Execute()
        {
            throw new NotImplementedException();
        }
    }
}
