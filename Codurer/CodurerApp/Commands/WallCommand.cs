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

        public WallCommand(Codurer codurer, string[] parameters)
        {
            this.codurer = codurer;
            this.user = parameters[0];
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
