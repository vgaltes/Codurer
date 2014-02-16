namespace CodurerApp.Test.CommandDescriptors
{
    using System;
    using System.Linq;
    using CodurerApp.Commands;
    using CodurerApp.Services;
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;

    //[TestClass]
    //public class WallCommandDescriptorTest
    //{
    //    CommandDescriptor wallCommandDescriptor = new CommandDescriptor(typeof(WallCommand),
    //            commandLine => commandLine.Contains("wall"),
    //            commandLine => commandLine
    //                .Split(new string[] { "wall" }, StringSplitOptions.RemoveEmptyEntries)
    //                .Select(parameter => parameter.Trim())
    //                .ToArray<string>());

    //    string commandLine = "Alice wall";

    //    [TestMethod]
    //    public void WhenRetrievingTheWall_EvaluatingTheCommandReturnsTrue()
    //    {
    //        var isWallCommand = wallCommandDescriptor.IsCommand(commandLine);
    //        isWallCommand.Should().BeTrue();
    //    }

    //    [TestMethod]
    //    public void WhenRetrievingTheWall_ReturnsNewWallCommand()
    //    {
    //        var codurer = new Codurer(new Mock<UserService>().Object);
    //        var postCommand = wallCommandDescriptor.GetCommand(codurer, commandLine);

    //        postCommand.Should().BeOfType<WallCommand>();
    //    }
    //}
}