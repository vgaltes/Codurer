namespace CodurerApp.Test
{
    using System.Collections.Generic;
    using CodurerApp.Commands;
    using CodurerApp.Services;
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;

    [TestClass]
    public class CommandFactoryTests
    {
        Mock<UserService> userService;
        Codurer codurer;
        CommandFactory commandFactory;

        [TestInitialize]
        public void TestInitialize()
        {
            userService = new Mock<UserService>();
            codurer = new Codurer(userService.Object);
            InitializeCommandFactory();
        }

        [TestMethod]
        public void GetPostCommand()
        {
            string commandLine = "Alice -> new message";            

            Command command = commandFactory.GetCommand(commandLine, codurer);

            command.Should().BeOfType<PostCommand>();
        }

        [TestMethod]
        public void GetTimelineCommand()
        {
            string commandLine = "Alice";

            Command command = commandFactory.GetCommand(commandLine, codurer);

            command.Should().BeOfType<TimelineCommand>();
        }

        [TestMethod]
        public void GetFollowCommand()
        {
            string commandLine = "Alice follows Bob";

            Command command = commandFactory.GetCommand(commandLine, codurer);

            command.Should().BeOfType<FollowCommand>();
        }

        private void InitializeCommandFactory()
        {
            var codurer = new Codurer(new InMemoryUserService());
            
            var commandDescriptors = new List<CommandDescriptor>
            {
                CommandDescriptorFactory.GetPostCommandDescriptor(),
                CommandDescriptorFactory.GetTimelineCommandDescriptor(),
                CommandDescriptorFactory.GetFollowingCommandDescriptor(),
                CommandDescriptorFactory.GetWallCommandDescriptor()
            };

            commandFactory = new CommandFactory(commandDescriptors);
        }
    }
}
