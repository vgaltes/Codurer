namespace CodurerApp.Test.CommandDescriptors
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System;
    using System.Linq;
    using CodurerApp.Commands;
    using FluentAssertions;

    [TestClass]
    public class FollowCommandDescriptorTest
    {
        CommandDescriptor<FollowCommand> followCommandDescriptor = new CommandDescriptor<FollowCommand>(
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
    }
}
