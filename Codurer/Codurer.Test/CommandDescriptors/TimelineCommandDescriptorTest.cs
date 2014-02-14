namespace CodurerApp.Test.CommandDescriptors
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System;
    using System.Linq;
    using CodurerApp.Commands;
    using FluentAssertions;
    using Moq;

    [TestClass]
    public class TimelineCommandDescriptorTest
    {
        CommandDescriptor timelineCommandDescriptor = new CommandDescriptor(typeof(TimelineCommand),
                commandLine => commandLine.Split(new string[]{" "}, StringSplitOptions.RemoveEmptyEntries).Count() == 1,
                commandLine => new string[] { commandLine });

        string commandLine = "Alice";

        [TestMethod]
        public void WhenRetrievingTheTimeline_EvaluatingTheCommandReturnsTrue()
        {
            var isPostCommand = timelineCommandDescriptor.IsCommand(commandLine);
            isPostCommand.Should().BeTrue();
        }

        [TestMethod]
        public void WhenRetrievingTheTimeline_ReturnsNewTimelineCommand()
        {
            var codurer = new Codurer(new Mock<UserService>().Object);
            var timelineCommand = timelineCommandDescriptor.GetCommand(codurer, commandLine);

            timelineCommand.Should().BeOfType<TimelineCommand>();
        }
    }
}
