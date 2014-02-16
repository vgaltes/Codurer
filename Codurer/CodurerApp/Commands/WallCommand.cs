using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodurerApp.Commands
{
    public class WallCommand : Command
    {
        private Codurer codurer;
        private string user;

        public WallCommand(Codurer codurer, string user)
        {
            this.codurer = codurer;
            this.user = user;
        }

        public CommandResult Execute()
        {
            return new CommandResult
            {
                Messages = codurer.GetWall(user)
            };
        }

        public CommandResult Execute(DateTime postingTime)
        {
            return Execute();
        }
    }
}
