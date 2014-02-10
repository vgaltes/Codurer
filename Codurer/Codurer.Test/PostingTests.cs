namespace CodurerApp.Test
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;

    [TestClass]
    public class PostingTests
    {
        private Mock<IUserService> userService;
        private Codurer codurer;

        [TestInitialize]
        public void TestInitialize()
        {
            userService = new Mock<IUserService>();
            codurer = new Codurer(userService.Object);
        }

        [TestMethod]
        public void WhenANewUserPostAMessage_TheUserIsCreated()
        {
            var command = "Alice -> new message";
            codurer.Send(command);

            userService.Verify(uService => uService.AddUser("Alice"));
        }

        [TestMethod]
        public void WhenAUserPostAMessage_TheMessageIsAddedToHim()
        {
            var command = "Alice -> new message";
            codurer.Send(command);

            userService.Verify(uService => uService.Post("new message", "Alice"));
        }

        [TestMethod]
        public void WhenAnExistingUserPostAMessage_TheUserIsNotCreatedAgain()
        {
            var firstCommand = "Alice -> first message";
            var secondCommand = "Alice -> new message";

            codurer.Send(firstCommand);
            codurer.Send(secondCommand);

            userService.Verify(uService => uService.AddUser("Alice"), Times.Once());
        }
    }
}
