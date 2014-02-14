namespace CodurerApp.Test
{
    using System;
    using CodurerApp.Services;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;

    [TestClass]
    public class PostingTests
    {
        private Mock<UserService> userService;
        private Codurer codurer;
        string user = "Alice";
        string message = "new message";

        [TestInitialize]
        public void TestInitialize()
        {
            userService = new Mock<UserService>();
            codurer = new Codurer(userService.Object);
        }

        [TestMethod]
        public void WhenANewUserPostAMessage_TheUserIsCreated()
        {            
            codurer.Post(message, user);

            userService.Verify(uService => uService.AddUser("Alice"));
        }

        [TestMethod]
        public void WhenAUserPostAMessage_TheMessageIsAddedToHim()
        {
            codurer.Post(message, user);

            userService.Verify(uService => uService.Post(message, user, It.IsAny<DateTime>()));
        }
    }
}