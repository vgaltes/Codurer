namespace CodurerApp.Test.CommandDescriptors
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System;
    using CodurerApp.Commands;
    using FluentAssertions;

    [TestClass]
    public class PostCommandDescriptorTest
    {
        CommandDescriptor<PostCommand> postCommandDescriptor = new CommandDescriptor<PostCommand>(
                commandLine => commandLine.Contains("->"),
                commandLine => commandLine.Split(new string[] { "->" }, StringSplitOptions.RemoveEmptyEntries));

        [TestMethod]
        public void WhenPostingAMessage_EvaluatingTheCommandReturnsTrue()
        {
            var isPostCommand = postCommandDescriptor.IsCommand("Alice -> new message");
            isPostCommand.Should().BeTrue();
        }

        [TestMethod]
        public void WhenPostingAMessage_ReturnsNewPostCommand()
        {
            var postCommand = postCommandDescriptor.GetCommand();

            postCommand.Should().BeOfType<PostCommand>();
        }
    }
}
