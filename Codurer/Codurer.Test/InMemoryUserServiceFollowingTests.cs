namespace CodurerApp.Test
{
    using System.Linq;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using FluentAssertions;

    [TestClass]
    public class InMemoryUserServiceFollowingTests
    {
        [TestMethod]
        public void WhenFollowingAUser_UserIsAddedToFollowingList()
        {
            var userService = new InMemoryUserService();
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
