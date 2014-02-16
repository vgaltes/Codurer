namespace CodurerApp.Test
{
    using System;
    using System.Linq;
    using CodurerApp.Commands;
    using CodurerApp.Services;
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class CodurerIntegrationTests
    {
        Codurer codurer;
        DateTime now;
        CommandExecutor commandExecutor;

        [TestInitialize]
        public void TestInitialize()
        {
            codurer = new Codurer(UserServiceFactory.GetInMemoryUserService());
            now = DateTime.Now;
            commandExecutor = 
                new CommandExecutor(codurer, CommandDescriptorFactory.GetCommandDescriptors());

            PostAliceMessages();
            PostBobMessages();
        }

        [TestMethod]
        public void PostingAndReading()
        {
            var aliceTimeline = GetTimeline("Alice");
            var bobTimeline = GetTimeline("Bob");

            AssertAliceTimelineIsCorrect(aliceTimeline);
            AssertBobTimelineIsCorrect(bobTimeline);
        }

        [TestMethod]
        public void FollowingAndWall()
        {
            AliceFollowsBob();

            var aliceWall = GetAliceWall();

            AssertAliceWallIsCorrect(aliceWall);
        }

        private void PostBobMessages()
        {
            commandExecutor.ExecuteCommand("Bob -> First message", now.AddMinutes(-4));
            commandExecutor.ExecuteCommand("Bob -> Second message", now);       
        }

        private void PostAliceMessages()
        {
            commandExecutor.ExecuteCommand("Alice -> First message", now.AddMinutes(-5));
            commandExecutor.ExecuteCommand("Alice -> Second message",now.AddMinutes(-1));
            commandExecutor.ExecuteCommand("Alice -> Third message", now.AddSeconds(-30));
        }

        private CommandResult GetTimeline(string userName)
        {
            return commandExecutor.ExecuteCommand(userName);
        }

        private static void AssertBobTimelineIsCorrect(CommandResult bobTimeline)
        {
            bobTimeline.Messages.Should().HaveCount(2);
            bobTimeline.Messages.First().Should().Be("Second message (now)");
            bobTimeline.Messages.Skip(1).Take(1).First().Should().Be("First message (4 minutes ago)");
        }

        private static void AssertAliceTimelineIsCorrect(CommandResult aliceTimeline)
        {
            aliceTimeline.Messages.Should().HaveCount(3);
            aliceTimeline.Messages.First().Should().Be("Third message (30 seconds ago)");
            aliceTimeline.Messages.Skip(1).Take(1).First().Should().Be("Second message (1 minute ago)");
            aliceTimeline.Messages.Skip(2).Take(1).First().Should().Be("First message (5 minutes ago)");
        }

        private static void AssertAliceWallIsCorrect(CommandResult aliceWall)
        {
            aliceWall.Messages.Should().HaveCount(5);
            aliceWall.Messages.First().Should().Be("Bob - Second message (now)");
            aliceWall.Messages.Skip(1).Take(1).First().Should().Be("Alice - Third message (30 seconds ago)");
            aliceWall.Messages.Skip(2).Take(1).First().Should().Be("Alice - Second message (1 minute ago)");
            aliceWall.Messages.Skip(3).Take(1).First().Should().Be("Bob - First message (4 minutes ago)");
            aliceWall.Messages.Skip(4).Take(1).First().Should().Be("Alice - First message (5 minutes ago)");
        }

        private CommandResult GetAliceWall()
        {
            return commandExecutor.ExecuteCommand("Alice wall");
        }

        private void AliceFollowsBob()
        {
            commandExecutor.ExecuteCommand("Alice follows Bob");
        }
    }
}