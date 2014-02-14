namespace CodurerApp.Test.CommandDescriptors
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System;
    using CodurerApp.Commands;
    using FluentAssertions;
    using Moq;

    [TestClass]
    public class PostCommandDescriptorTest
    {
        CommandDescriptor<PostCommand> postCommandDescriptor = new CommandDescriptor<PostCommand>(
                commandLine => commandLine.Contains("->"),
                commandLine => commandLine.Split(new string[] { "->" }, StringSplitOptions.RemoveEmptyEntries));

        string commandLine = "Alice -> new message";

        [TestMethod]
        public void WhenPostingAMessage_EvaluatingTheCommandReturnsTrue()
        {
            var isPostCommand = postCommandDescriptor.IsCommand(commandLine);
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
