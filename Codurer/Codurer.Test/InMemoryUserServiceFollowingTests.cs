namespace CodurerApp.Test
{
    using System.Linq;
    using CodurerApp.Services;
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class InMemoryUserServiceFollowingTests : InMemoryUserServiceTest
    {
        [TestMethod]
        public void WhenFollowingAUser_UserIsAddedToFollowingList()
        {
            var userService = GetUserService();
            var follower = "Alice";
            var followed = "Bob";

            userService.AddUser(followed);
            userService.AddUser(follower);

            userService.Follow(follower, followed);

            userService.Users.First(user => user.Name == follower).Following.Should().HaveCount(1);
            userService.Users.First(user => user.Name == follower).Following.First().Should().Be(followed);
        }
    }
}
