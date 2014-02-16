namespace CodurerApp.Test.CommandDescriptors
{
    using CodurerApp.Commands;
    using CodurerApp.Services;
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;

    [TestClass]
    public class FollowCommandDescriptorTest
    {
        CommandDescriptor followCommandDescriptor =
            (CommandDescriptor) new FollowCommandDescriptor();

        string commandLine = "Alice follows Bob";

        [TestMethod]
        public void WhenFollowing_EvaluatingTheCommandReturnsTrue()
        {
            var isFollowCommand = followCommandDescriptor.CanHandle(commandLine);
            isFollowCommand.Should().BeTrue();
        }

        [TestMethod]
        public void WhenFollowing_ReturnsNewFollowCommand()
        {
            var codurer = new Codurer(new Mock<UserService>().Object);
            var postCommand = followCommandDescriptor.GetCommand(codurer, commandLine);

            postCommand.Should().BeOfType<FollowCommand>();
        }
    }
}