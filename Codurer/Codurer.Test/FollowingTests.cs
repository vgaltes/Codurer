namespace CodurerApp.Test
{
    using CodurerApp.Services;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;

    [TestClass]
    public class FollowingTests
    {
        [TestMethod]
        public void WhenFollowingAUser_TheFollowerIsAddedToUsersFollowers()
        {
            var userService = new Mock<UserService>();
            var codurer = new Codurer(userService.Object);
            var follower = "Alice";
            var followed = "Bob";

            codurer.Follow(follower, followed);

            userService.Verify(uService => uService.Follow(follower, followed));
        }
    }
}
