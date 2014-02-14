namespace CodurerApp.Test
{
    using System;
    using System.Linq;
    using CodurerApp.Services;
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class InMemoryUserServiceWallTests
    {
        [TestMethod]
        public void GivenBobAndAliceHavePostedMessagesAndBobFollowsAlice_WhenRetrievingMessagesFromPeopleBobFollows_TheMessagesFromBothAreReturedInInverseChronologicalOrder()
        {
            var userService = new InMemoryUserService();
            var bob = "Bob";
            userService.AddUser(bob);
            var alice = "Alice";
            userService.AddUser(alice);
            var bobMessage = "Bob message";
            var aliceMessage = "Alice message";

            userService.Post(bobMessage, bob, DateTime.Now.AddMinutes(-2));
            userService.Post(aliceMessage, alice, DateTime.Now.AddMinutes(-1));
            userService.Follow(alice, bob);

            var messages = userService.GetMessagesFromFollowingUsersFrom(alice);
            messages.Should().HaveCount(1);
            messages.First().Format().Should().StartWith(bobMessage);
        }
    }
}