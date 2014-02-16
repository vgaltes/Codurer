namespace CodurerApp.Test.CommandDescriptors
{
    using CodurerApp.CommandDescriptors;
    using CodurerApp.Commands;
    using CodurerApp.Services;
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;

    [TestClass]
    public class PostCommandDescriptorTest
    {
        CommandDescriptor postCommandDescriptor = (CommandDescriptor) new PostCommandDescriptor();

        string commandLine = "Alice -> new message";

        [TestMethod]
        public void WhenPostingAMessage_EvaluatingTheCommandReturnsTrue()
        {
            var isPostCommand = postCommandDescriptor.CanHandle(commandLine);
            isPostCommand.Should().BeTrue();
        }

        [TestMethod]
        public void WhenPostingAMessage_ReturnsNewPostCommand()
        {
            var codurer = new Codurer(new Mock<UserService>().Object);
            var postCommand = postCommandDescriptor.GetCommand(codurer, commandLine);

            postCommand.Should().BeOfType<PostCommand>();
        }
    }
}
