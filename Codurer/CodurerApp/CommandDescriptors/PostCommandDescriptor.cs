namespace CodurerApp.CommandDescriptors
{
    using System;
    using System.Linq;
    using CodurerApp.Commands;

    public class PostCommandDescriptor : CommandDescriptor
    {
        public bool CanHandle(string commandLine)
        {
            return commandLine.Contains("->");
        }  

        public Command GetCommand(Codurer codurer, string commandLine)
        {
            string[] parameters = commandLine.Split(new string[] { "->" }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(parameter => parameter.Trim())
                    .ToArray<string>();

            string user = parameters[0];
            string message = parameters[1];

            return new PostCommand(codurer, user, message);
        }
    }
}