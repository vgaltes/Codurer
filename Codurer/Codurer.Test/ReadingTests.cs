namespace CodurerApp.Test
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;
    using FluentAssertions;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Collections.ObjectModel;

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
            var messages = new ReadOnlyCollection<string>(
                            new List<string>{ message });

            userService.Setup(uService => uService.GetMessagesFrom(userName)).Returns(messages);

            var readCommand = userName;
            IEnumerable<string> wall = codurer.Send(readCommand, DateTime.Now);

            wall.Should().HaveCount(1);
            wall.First().Should().Be(message);
        }
    }
}
