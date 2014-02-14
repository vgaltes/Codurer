namespace CodurerApp.Test.CommandDescriptors
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System;
    using System.Linq;
    using CodurerApp.Commands;
    using FluentAssertions;

    [TestClass]
    public class TimelineCommandDescriptorTest
    {
        CommandDescriptor<TimelineCommand> timelineCommandDescriptor = new CommandDescriptor<TimelineCommand>(
                commandLine => commandLine.Split(new string[]{" "}, StringSplitOptions.RemoveEmptyEntries).Count() == 1,
                commandLine => new string[] { commandLine });

        string commandLine = "Alice";

        [TestMethod]
        public void WhenRetrievingTheTimeline_EvaluatingTheCommandReturnsTrue()
        {
            var isPostCommand = timelineCommandDescriptor.IsCommand(commandLine);
            isPostCommand.Should().BeTrue();
        }
    }
}
