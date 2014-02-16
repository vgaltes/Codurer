namespace CodurerApp.CommandDescriptors
{
    using CodurerApp.Commands;

    public abstract class AbstractCommandDescriptor<TCommand> :
        CommandDescriptor where TCommand : Command
    {
        public abstract bool CanHandle(string commandLine);

        public Command GetCommand(Codurer codurer, string commandLine)
        {
            return this.BuildCommand(codurer, commandLine);
        }

        protected abstract TCommand BuildCommand(Codurer codurer, string commandLine);
    }
}