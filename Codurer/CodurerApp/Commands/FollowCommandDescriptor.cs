namespace CodurerApp.Commands
{
    using System;
    using System.Linq;

    public class FollowCommandDescriptor : AbstractCommandDescriptor<FollowCommand>
    {
        public override bool CanHandle(string commandLine)
        {
            return commandLine.Contains("follows");
        }

        protected override FollowCommand BuildCommand(Codurer codurer, string commandLine)
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