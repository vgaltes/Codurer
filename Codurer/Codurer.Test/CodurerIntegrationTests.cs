namespace CodurerApp.Test
{
    using System;
    using System.Linq;
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

            codurer.Post("Alice", "First message", now.AddMinutes(-5));
            codurer.Post("Alice", "Second message", now.AddMinutes(-4));
            codurer.Post("Alice", "Third message", now.AddMinutes(-1));
            codurer.Post("Bob", "First message", now.AddSeconds(-30));
            codurer.Post("Bob", "Second message", now);

            var aliceWall = codurer.GetTimeline("Alice");
            var bobWall = codurer.GetTimeline("Bob");

            aliceWall.Should().HaveCount(3);
            aliceWall.First().Should().Be("Third message (1 minute ago)");
            aliceWall.Skip(1).Take(1).First().Should().Be("Second message (4 minutes ago)");
            aliceWall.Skip(2).Take(1).First().Should().Be("First message (5 minutes ago)");
        }
    }
}
