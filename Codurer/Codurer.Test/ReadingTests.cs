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
            var userName = "Alice";
            var message = "new command (5 minutes ago)";

            userService.Setup(uService => uService.GetMessagesFrom(userName)).Returns(message);

            var readCommand = userName;
            string wall = codurer.Send(readCommand, DateTime.Now);

            wall.Should().Be(message);
        }
    }
}
