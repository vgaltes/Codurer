namespace CodurerApp.Test
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;

    [TestClass]
    public class PostingTests
    {
        [TestMethod]
        public void WhenANewUserPostAMessage_TheUserIsCreated()
        {
            var userService = new Mock<IUserService>();
            var codurer = new Codurer(userService.Object);

            var command = "Alice -> new message";
            codurer.Send(command);

            userService.Verify(uService => uService.AddUser("Alice"));
        }
    }
}
