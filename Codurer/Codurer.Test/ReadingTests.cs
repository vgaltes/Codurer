namespace CodurerApp.Test
{
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;
    using CodurerApp.Services;
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;

    [TestClass]
    public class ReadingTests
    {
        [TestMethod]
        public void GivenThatAliceHasPostedAMessage_WhenBobReadsAlice_TheMessageAppears()
        {
            var userService = new Mock<UserService>();
            var codurer = new Codurer(userService.Object);
            var userName = "Alice";
            var message = "new command (5 minutes ago)";
            var messages = new ReadOnlyCollection<string>(
                            new List<string>{ message });

            userService.Setup(uService => uService.GetMessagesFormattedFrom(userName)).Returns(messages);

            IEnumerable<string> timeline = codurer.GetTimeline(userName);

            timeline.Should().HaveCount(1);
            timeline.First().Should().Be(message);
        }
    }
}
