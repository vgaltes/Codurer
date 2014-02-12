namespace CodurerApp.Test
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;

    [TestClass]
    public class PostingTests
    {
        private Mock<UserService> userService;
        private Codurer codurer;

        [TestInitialize]
        public void TestInitialize()
        {
            userService = new Mock<UserService>();
            codurer = new Codurer(userService.Object);
        }

        [TestMethod]
        public void WhenANewUserPostAMessage_TheUserIsCreated()
        {
            var user = "Alice";
            var message = "new message";
            codurer.Post(message, user);

            userService.Verify(uService => uService.AddUser("Alice"));
        }

        [TestMethod]
        public void WhenAUserPostAMessage_TheMessageIsAddedToHim()
        {
            var command = "Alice -> new message";
            codurer.Send(command);

            userService.Verify(uService => uService.Post("new message", "Alice", It.IsAny<DateTime>()));
        }
    }
}