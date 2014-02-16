namespace CodurerApp.Test
{
    using System;
    using System.Linq;
    using CodurerApp.Services;
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class InMemoryUserServiceReadingTests : InMemoryUserServiceTest
    {
        [TestMethod]
        public void GivenBobHasPostedTwoMessages_WhenRetrievingMessages_TheMessagesAreReturedInInverseChronologicalOrder()
        {
            var userService = GetUserService();
            userService.AddUser("Bob");
            var message1 = "message1";
            var message2 = "message2";
            userService.Post(message1, "Bob", DateTime.Now.AddMinutes(-2));
            userService.Post(message2, "Bob", DateTime.Now.AddMinutes(-1));

            var messages = userService.GetMessagesFormattedFrom("Bob");
            messages.Should().HaveCount(2);
            messages.First().Should().StartWith(message2);
            messages.Skip(1).Take(1).First().Should().StartWith(message1);
        }
    }
}