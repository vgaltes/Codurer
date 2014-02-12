namespace CodurerApp.Test
{
    using CodurerApp.Commands;
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class CommandFactoryTests
    {
        [TestMethod]
        public void GetPostCommand()
        {
            string commandLine = "Alice -> new message";

            Command command = CommandFactory.GetCommand(commandLine);

            command.Should().BeOfType<PostCommand>();
        }
    }
}
