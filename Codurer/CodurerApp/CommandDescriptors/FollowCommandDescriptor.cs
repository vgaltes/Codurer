namespace CodurerApp.CommandDescriptors
{
    using System;
    using System.Linq;
    using CodurerApp.Commands;

    public class FollowCommandDescriptor : CommandDescriptor
    {
        public bool CanHandle(string commandLine)
        {
            return commandLine.Contains("follows");
        }

        public Command GetCommand(Codurer codurer, string commandLine)
        {
            string[] parameters = commandLine
                    .Split(new string[] { "follows" }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(parameter => parameter.Trim())
                    .ToArray<string>();

            string user = parameters[0];
            string following = parameters[1];

            return new FollowCommand(codurer, user, following);
        }
    }
}