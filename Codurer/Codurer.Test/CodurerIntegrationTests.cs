namespace CodurerApp.Test
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using CodurerApp.Commands;
    using CodurerApp.FormatRules;
    using CodurerApp.Services;
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class CodurerIntegrationTests
    {
        Codurer codurer;
        DateTime now;
        CommandFactory commandFactory;

        [TestInitialize]
        public void TestInitialize()
        {
            codurer = new Codurer(UserServiceFactory.GetInMemoryUserService());
            now = DateTime.Now;

            PostAliceMessages();
            PostBobMessages();
        }

        [TestMethod]
        public void PostingAndReading()
        {
            var aliceTimeline = GetAliceTimeline();
            var bobTimeline = GetBobTimeline();

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
            var firstBobPostCommand = commandFactory.GetCommand("Bob -> First message", codurer);
            firstBobPostCommand.Execute(now.AddMinutes(-4));
            var secondBobPostCommand = commandFactory.GetCommand("Bob -> Second message", codurer);
            secondBobPostCommand.Execute(now);
        }

        private void PostAliceMessages()
        {
            var firstAlicePostCommand = commandFactory.GetCommand("Alice -> First message", codurer);
            firstAlicePostCommand.Execute(now.AddMinutes(-5));
            var secondAlicePostCommand = commandFactory.GetCommand("Alice -> Second message", codurer);
            secondAlicePostCommand.Execute(now.AddMinutes(-1));
            var thirdAlicePostCommand = commandFactory.GetCommand("Alice -> Third message", codurer);
            thirdAlicePostCommand.Execute(now.AddSeconds(-30));
        }

        private CommandResult GetBobTimeline()
        {
            var bobTimelineCommand = commandFactory.GetCommand("Bob", codurer);
            var bobTimeline = bobTimelineCommand.Execute();
            return bobTimeline;
        }

        private CommandResult GetAliceTimeline()
        {
            var aliceTimelineCommand = commandFactory.GetCommand("Alice", codurer);
            var aliceTimeline = aliceTimelineCommand.Execute();
            return aliceTimeline;
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
            var aliceWallCommand = commandFactory.GetCommand("Alice wall", codurer);
            var aliceWall = aliceWallCommand.Execute();
            return aliceWall;
        }

        private void AliceFollowsBob()
        {
            var aliceFollowBobCommand = commandFactory.GetCommand("Alice follows Bob", codurer);
            aliceFollowBobCommand.Execute();
        }
    }
}