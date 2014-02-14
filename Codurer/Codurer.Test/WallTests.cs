namespace CodurerApp.Test
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;
    using CodurerApp.Models;
    using CodurerApp.Services;
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
            var aliceMessage = new Message(alice, aliceMessageText, DateTime.Now.AddMinutes(-5), null);
            var aliceMessages = new ReadOnlyCollection<Message>(
                            new List<Message> { aliceMessage });

            var bob = "Bob";
            var bobMessageText = "Bob message";
            var bobMessage = new Message(bob, bobMessageText, DateTime.Now.AddMinutes(-2), null);
            var bobMessages = new ReadOnlyCollection<Message>(
                            new List<Message> { bobMessage });

            userService.Setup(uService => uService.GetMessagesFrom(alice)).Returns(aliceMessages);
            userService.Setup(uService => uService.GetMessagesFromFollowingUsersFrom(alice)).Returns(bobMessages);

            codurer.Follow(alice, bob);

            IEnumerable<string> wall = codurer.GetWall(alice);

            wall.Should().HaveCount(2);
            wall.First().Should().Contain(bob);
            wall.Skip(1).Take(1).First().Should().Contain(alice);
        }
    }
}
