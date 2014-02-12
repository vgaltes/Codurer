namespace CodurerApp.Test
{
    using System.Linq;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using FluentAssertions;

    [TestClass]
    public class InMemoryUserServiceFollowingTests
    {
        [TestMethod]
        public void WhenFollowingAUser_UserIsAddedToFollowersList()
        {
            var userService = new InMemoryUserService();
            var follower = "Alice";
            var followed = "Bob";

            userService.AddUser(followed);
            userService.AddUser(follower);

            userService.Follow(follower, followed);

            userService.Users.First(user => user.Name == followed).Followers.Should().HaveCount(1);
            userService.Users.First(user => user.Name == followed).Followers.First().Should().Be(follower);
        }
    }
}
