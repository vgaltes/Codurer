namespace CodurerApp.Test
{
    using CodurerApp.Commands;
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;

    [TestClass]
    public class CommandFactoryTests
    {
        Mock<UserService> userService;
        Codurer codurer;

        [TestInitialize]
        public void TestInitialize()
        {
            userService = new Mock<UserService>();
            codurer = new Codurer(userService.Object);
        }

        [TestMethod]
        public void GetPostCommand()
        {
            string commandLine = "Alice -> new message";            

            Command command = CommandFactory.GetCommand(commandLine, codurer);

            command.Should().BeOfType<PostCommand>();
        }

        [TestMethod]
        public void GetTimelineCommand()
        {
            string commandLine = "Alice";

            Command command = CommandFactory.GetCommand(commandLine, codurer);

            command.Should().BeOfType<TimelineCommand>();
        }

        [TestMethod]
        public void GetFollowCommand()
        {
            string commandLine = "Alice follows Bob";

            Command command = CommandFactory.GetCommand(commandLine, codurer);

            command.Should().BeOfType<FollowCommand>();
        }
    }
}
