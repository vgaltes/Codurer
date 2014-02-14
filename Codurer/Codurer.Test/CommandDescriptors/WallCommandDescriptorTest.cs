﻿namespace CodurerApp.Test.CommandDescriptors
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System;
    using System.Linq;
    using CodurerApp.Commands;
    using FluentAssertions;
    using Moq;

    [TestClass]
    public class WallCommandDescriptorTest
    {
        CommandDescriptor<WallCommand> wallCommandDescriptor = new CommandDescriptor<WallCommand>(
                commandLine => commandLine.Contains("wall"),
                commandLine => commandLine
                    .Split(new string[] { "wall" }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(parameter => parameter.Trim())
                    .ToArray<string>());

        string commandLine = "Alice wall";

        [TestMethod]
        public void WhenRetrievingTheWall_EvaluatingTheCommandReturnsTrue()
        {
            var isWallCommand = wallCommandDescriptor.IsCommand(commandLine);
            isWallCommand.Should().BeTrue();
        }
    }
}
