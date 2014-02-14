namespace CodurerApp.Test.CommandDescriptors
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System;
    using System.Linq;
    using CodurerApp.Commands;
    using FluentAssertions;
    using Moq;

    [TestClass]
    public class FollowCommandDescriptorTest
    {
        CommandDescriptor followCommandDescriptor = new CommandDescriptor(typeof(FollowCommand),
                commandLine => commandLine.Contains("follows"),
                commandLine => commandLine
                    .Split(new string[] { "follows" }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(parameter => parameter.Trim())
                    .ToArray<string>());

        string commandLine = "Alice follows Bob";

        [TestMethod]
        public void WhenFollowing_EvaluatingTheCommandReturnsTrue()
        {
            var isFollowCommand = followCommandDescriptor.IsCommand(commandLine);
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