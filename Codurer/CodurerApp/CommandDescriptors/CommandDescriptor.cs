namespace CodurerApp.CommandDescriptors
{
    using CodurerApp.Commands;

    public interface CommandDescriptor
    {
        bool CanHandle(string commandLine);

        Command GetCommand(Codurer codurer, string commandLine);
    }
}