namespace CodurerApp.Commands
{
    using System;
    using System.Linq;

    public static class CommandDescriptorFactory
    {
        public static CommandDescriptor GetPostCommandDescriptor()
        {
            return new CommandDescriptor(typeof(PostCommand),
                cLine => cLine.Contains("->"),
                cLine => cLine
                    .Split(new string[] { "->" }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(parameter => parameter.Trim())
                    .ToArray<string>());
        }

        public static CommandDescriptor GetTimelineCommandDescriptor()
        {
            return new CommandDescriptor(typeof(TimelineCommand),
                cLine => cLine.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries).Count() == 1,
                cLine => new string[] { cLine });
        }

        public static CommandDescriptor GetFollowingCommandDescriptor()
        {
            return new CommandDescriptor(typeof(FollowCommand),
                cLine => cLine.Contains("follows"),
                cLine => cLine
                    .Split(new string[] { "follows" }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(parameter => parameter.Trim())
                    .ToArray<string>());
        }

        public static CommandDescriptor GetWallCommandDescriptor()
        {
            return new CommandDescriptor(typeof(WallCommand),
                cLine => cLine.Contains("wall"),
                cLine => cLine
                    .Split(new string[] { "wall" }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(parameter => parameter.Trim())
                    .ToArray<string>());
        }
    }
}
