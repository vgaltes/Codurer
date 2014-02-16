namespace CodurerApp.Test.CommandDescriptors
{
    using CodurerApp.CommandDescriptors;
    using CodurerApp.Commands;
    using CodurerApp.Services;
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;

    [TestClass]
    public class TimelineCommandDescriptorTest
    {
        CommandDescriptor timelineCommandDescriptor =
            (CommandDescriptor)new TimelineCommandDescriptor();

        string commandLine = "Alice";

        [TestMethod]
        public void WhenRetrievingTheTimeline_EvaluatingTheCommandReturnsTrue()
        {
            var isPostCommand = timelineCommandDescriptor.CanHandle(commandLine);
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