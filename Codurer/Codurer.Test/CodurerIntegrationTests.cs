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
        [TestMethod]
        public void PostingAndReading()
        {
            var codurer = new Codurer(new InMemoryUserService());
            var now = DateTime.Now;

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

            var aliceWallCommand = CommandFactory.GetCommand("Alice", codurer);
            var aliceWall = aliceWallCommand.Execute();

            var bobWallCommand = CommandFactory.GetCommand("Bob", codurer);
            var bobWall = bobWallCommand.Execute();

            aliceWall.Items.Should().HaveCount(3);
            aliceWall.Items.First().Should().Be("Third message (30 seconds ago)");
            aliceWall.Items.Skip(1).Take(1).First().Should().Be("Second message (1 minute ago)");
            aliceWall.Items.Skip(2).Take(1).First().Should().Be("First message (5 minutes ago)");

            bobWall.Items.Should().HaveCount(2);
            bobWall.Items.First().Should().Be("Second message (now)");
            bobWall.Items.Skip(1).Take(1).First().Should().Be("First message (4 minutes ago)");
        }
    }
}