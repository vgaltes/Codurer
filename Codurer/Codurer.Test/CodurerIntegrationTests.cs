namespace CodurerApp.Test
{
    using System;
    using System.Linq;
    using CodurerApp.Commands;
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class CodurerIntegrationTests
    {
        Codurer codurer;
        DateTime now;

        [TestInitialize]
        public void TestInitialize()
        {
            codurer = new Codurer(new InMemoryUserService());
            now = DateTime.Now;

            var firstAlicePostCommand = CommandFactory.GetCommand("Alice -> First message", codurer);
            firstAlicePostCommand.Execute(now.AddMinutes(-5));
            var secondAlicePostCommand = CommandFactory.GetCommand("Alice -> Second message", codurer);
            secondAlicePostCommand.Execute(now.AddMinutes(-1));
            var thirdAlicePostCommand = CommandFactory.GetCommand("Alice -> Third message", codurer);
            thirdAlicePostCommand.Execute(now.AddSeconds(-30));
            var firstBobPostCommand = CommandFactory.GetCommand("Bob -> First message", codurer);
            firstBobPostCommand.Execute(now.AddMinutes(-4));
            var secondBobPostCommand = CommandFactory.GetCommand("Bob -> Second message", codurer);
            secondBobPostCommand.Execute(now);
        }

        [TestMethod]
        public void PostingAndReading()
        {
            var aliceTimelineCommand = CommandFactory.GetCommand("Alice", codurer);
            var aliceTimeline = aliceTimelineCommand.Execute();

            var bobTimelineCommand = CommandFactory.GetCommand("Bob", codurer);
            var bobTimeline = bobTimelineCommand.Execute();

            aliceTimeline.Items.Should().HaveCount(3);
            aliceTimeline.Items.First().Should().Be("Third message (30 seconds ago)");
            aliceTimeline.Items.Skip(1).Take(1).First().Should().Be("Second message (1 minute ago)");
            aliceTimeline.Items.Skip(2).Take(1).First().Should().Be("First message (5 minutes ago)");

            bobTimeline.Items.Should().HaveCount(2);
            bobTimeline.Items.First().Should().Be("Second message (now)");
            bobTimeline.Items.Skip(1).Take(1).First().Should().Be("First message (4 minutes ago)");
        }

        [TestMethod]
        public void FollowingAndWall()
        {
            var aliceFollowBobCommand = CommandFactory.GetCommand("Alice follows Bob", codurer);
            aliceFollowBobCommand.Execute();

            var aliceWallCommand = CommandFactory.GetCommand("Alice wall", codurer);
            var aliceWall = aliceWallCommand.Execute();

            aliceWall.Items.Should().HaveCount(5);
            aliceWall.Items.First().Should().Be("Bob - Second message (now)");
            aliceWall.Items.Skip(1).Take(1).First().Should().Be("Alice - Third message (30 seconds ago)");
            aliceWall.Items.Skip(2).Take(1).First().Should().Be("Alice - Second message (1 minute ago)");
            aliceWall.Items.Skip(3).Take(1).First().Should().Be("Bob - First message (4 minutes ago)");
            aliceWall.Items.Skip(4).Take(1).First().Should().Be("Alice - First message (5 minutes ago)");
        }
    }
}