namespace CodurerApp.Commands
{
    using System;
    using System.Linq;

    public class WallCommandDescriptor : AbstractCommandDescriptor<WallCommand>
    {
        public override bool CanHandle(string commandLine)
        {
            return commandLine.Contains("wall");
        }

        protected override WallCommand BuildCommand(Codurer codurer, string commandLine)
        {
            string[] parameters = commandLine
                    .Split(new string[] { "wall" }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(parameter => parameter.Trim())
                    .ToArray<string>();

            return new WallCommand(codurer, parameters);
        }
    }
}