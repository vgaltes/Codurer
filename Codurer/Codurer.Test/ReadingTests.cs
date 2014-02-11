namespace CodurerApp.Test
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;
    using FluentAssertions;
    using System;

    [TestClass]
    public class ReadingTests
    {
        [TestMethod]
        public void GivenThatAliceHasPostedAMessage_WhenBobReadsAlice_TheMessageAppears()
        {
            var userService = new Mock<UserService>();
            var codurer = new Codurer(userService.Object);

            var postCommand = "Alice -> new command";
            codurer.Send(postCommand, DateTime.Now.AddMinutes(-5));

            var readCommand = "Alice";
            string wall = codurer.Send(readCommand, DateTime.Now);

            wall.Should().Be("new command (5 minutes ago)");
        }
    }
}
