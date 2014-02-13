namespace CodurerApp.Test
{
    using FluentAssertions;
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System.Collections.Generic;
    using CodurerApp.FormatRules;

    [TestClass]
    public class MessageTests
    {
        List<FormatRule> formatRules = new List<FormatRule>
            {
                new NowFormatRule(),
                new SecondsFormatRule(),
                new MinutesFormatRule()
            };

        string messageText = "message text";
        string userName = "Alice";

        [TestMethod]
        public void GivenAMessagePostedLessThanOneSecondAgo_FormatReturnsTheMessagePlusNow()
        {
            var message = new Message(userName, messageText, DateTime.Now, formatRules);

            var result = message.Format();

            result.Should().Be(messageText + " (now)");
        }

        [TestMethod]
        public void GivenAMessagePostedMoreThanOneSecondAgoAndLessThanOneMinuteAgo_FormatReturnsTheMessagePlusSeconds()
        {
            var message = new Message(userName, messageText, DateTime.Now.AddSeconds(-2), formatRules);

            var result = message.Format();

            result.Should().Be(messageText + " (2 seconds ago)");
        }

        [TestMethod]
        public void GivenAMessagePostedOneSecondAgo_FormatReturnsTheMessagePlus1SecondAgo()
        {
            var message = new Message(userName, messageText, DateTime.Now.AddSeconds(-1), formatRules);

            var result = message.Format();

            result.Should().Be(messageText + " (1 second ago)");
        }

        [TestMethod]
        public void GivenAMessagePostedMoreThanOneMinutesAgoAndLessThanOneHourAgo_FormatReturnsTheMessagePlusMinutes()
        {
            var message = new Message(userName, messageText, DateTime.Now.AddMinutes(-2), formatRules);

            var result = message.Format();

            result.Should().Be(messageText + " (2 minutes ago)");
        }

        [TestMethod]
        public void GivenAMessagePostedOneMinuteAgo_FormatReturnsTheMessagePlus1MinuteAgo()
        {
            var message = new Message(userName, messageText, DateTime.Now.AddMinutes(-1), formatRules);

            var result = message.Format();

            result.Should().Be(messageText + " (1 minute ago)");
        }
    }
}