namespace CodurerApp.CommandDescriptors
{
    using System;
    using System.Linq;
    using CodurerApp.Commands;

    public class WallCommandDescriptor : AbstractCommandDescriptor<WallCommand>
    {
        public override bool CanHandle(string commandLine)
        {
            return commandLine.Contains("wall");
        }

        protected override WallCommand BuildCommand(Codurer codurer, string commandLine)
        {
            string user = commandLine
                    .Split(new string[] { "wall" }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(parameter => parameter.Trim())
                    .First();

            return new WallCommand(codurer, user);
        }
    }
}