using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodurerApp.Commands
{
    public class PostCommandDescriptor : AbstractCommandDescriptor<PostCommand>
    {

        public override bool CanHandle(string commandLine)
        {
            return commandLine.Contains("->");
        }  

        protected override PostCommand BuildCommand(Codurer codurer, string commandLine)
        {
            string[] parameters = commandLine.Split(new string[] { "->" }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(parameter => parameter.Trim())
                    .ToArray<string>();

            string user = parameters[0];
            string message = parameters[1];

            return new PostCommand(codurer, parameters);
        }
    }
}
