namespace CodurerApp.Test
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using FluentAssertions;
    using System.Linq;

    [TestClass]
    public class InMemoryUserServicePostingTests
    {
        [TestMethod]
        public void WhenAddingAUser_ANewUserIsAddedToCollection()
        {
            var userService = new InMemoryUserService();
            var userName = "Alice";

            userService.AddUser(userName);

            userService.Users.Should().HaveCount(1);
            userService.Users.First().Name.Should().Be(userName);
        }

        [TestMethod]
        public void WhenAddingAnExistingUser_TheUserIsNotAddedToCollection()
        {
            var userService = new InMemoryUserService();
            var userName = "Alice";

            userService.AddUser(userName);
            userService.AddUser(userName);

            userService.Users.Should().HaveCount(1);
            userService.Users.First().Name.Should().Be(userName);
        }
    }
}
