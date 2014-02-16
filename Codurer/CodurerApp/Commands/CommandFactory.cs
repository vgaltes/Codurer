namespace CodurerApp.Commands
{
    using System.Collections.Generic;

    public static class CommandDescriptorFactory
    {
        public static List<CommandDescriptor> GetCommandDescriptors()
        {
            return new List<CommandDescriptor>
            {
                new PostCommandDescriptor(),
                new TimelineCommandDescriptor(),
                new FollowCommandDescriptor(),
                new WallCommandDescriptor()
            };
        }
    }
}