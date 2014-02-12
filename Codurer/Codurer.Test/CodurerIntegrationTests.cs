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

            codurer.Send("Alice -> First message", now.AddMinutes(-5));
            codurer.Send("Alice -> Second message", now.AddMinutes(-4));
            codurer.Send("Alice -> Third message", now.AddMinutes(-1));
            codurer.Send("Bob -> First message", now.AddSeconds(-30));
            codurer.Send("Bob -> Second message", now);

            var aliceWall = codurer.Send("Alice");
            var bobWall = codurer.Send("Bob");

            aliceWall.Should().HaveCount(3);
            aliceWall.First().Should().Be("Third message (1 minute ago)");
            aliceWall.Skip(1).Take(1).First().Should().Be("Second message (4 minutes ago)");
            aliceWall.Skip(2).Take(1).First().Should().Be("First message (5 minutes ago)");
        }
    }
}
