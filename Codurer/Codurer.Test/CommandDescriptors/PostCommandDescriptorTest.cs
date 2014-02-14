namespace CodurerApp.Test.CommandDescriptors
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System;
    using CodurerApp.Commands;
    using FluentAssertions;

    [TestClass]
    public class PostCommandDescriptorTest
    {
        [TestMethod]
        public void WhenPostingAMessage_EvaluatingTheCommandReturnsTrue()
        {
            var postCommandDescriptor = new CommandDescriptor<PostCommand>(
                commandLine => commandLine.Contains("->"),
                commandLine => commandLine.Split(new string[] { "->" }, StringSplitOptions.RemoveEmptyEntries));

            var isPostCommand = postCommandDescriptor.IsCommand("Alice -> new message");
            isPostCommand.Should().BeTrue();
        }
    }
}
