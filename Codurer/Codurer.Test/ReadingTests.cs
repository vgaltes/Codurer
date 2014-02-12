namespace CodurerApp.Test
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;
    using FluentAssertions;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Collections.ObjectModel;

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
