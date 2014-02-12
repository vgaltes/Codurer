namespace CodurerApp.Test
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;

    [TestClass]
    public class WallTests
    {
        [TestMethod]
        public void GivenThatAliceAndBobHavePostedAMessage_WhenBobSeeHisWall_BothMessagesAppears()
        {
            var userService = new Mock<UserService>();
            var codurer = new Codurer(userService.Object);
            var alice = "Alice";
            var aliceMessageText = "AliceMessage";
            var aliceMessage = new Message(aliceMessageText, DateTime.Now.AddMinutes(-5), null);
            var aliceMessages = new ReadOnlyCollection<Message>(
                            new List<Message> { aliceMessage });

            var bob = "Bob";
            var bobMessageText = "Bob message";
            var bobMessage = new Message(bobMessageText, DateTime.Now.AddMinutes(-2), null);
            var bobMessages = new ReadOnlyCollection<Message>(
                            new List<Message> { bobMessage });

            userService.Setup(uService => uService.GetMessagesFrom(alice)).Returns(aliceMessages);
            userService.Setup(uService => uService.GetMessagesFrom(bob)).Returns(bobMessages);

            IEnumerable<string> wall = codurer.GetWall(bob);

            wall.Should().HaveCount(2);
            wall.First().Should().Contain(bobMessageText);
            wall.Skip(1).Take(1).First().Should().Contain(aliceMessageText);
        }
    }
}
