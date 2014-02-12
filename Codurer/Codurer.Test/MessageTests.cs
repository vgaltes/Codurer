namespace CodurerApp.Test
{
    using FluentAssertions;
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System.Collections.Generic;
    using CodurerApp.Test.FormatRules;

    [TestClass]
    public class MessageTests
    {
        List<FormatRule> formatRules = new List<FormatRule>
            {
                new NowFormatRule(),
                new SecondsFormatRule(),
                new MinutesFormatRule()
            };

        [TestMethod]
        public void GivenAMessagePostedLessThanOneSecondAgo_FormatReturnsTheMessagePlusNow()
        {
            var messageText = "message text";
            var message = new Message(messageText, DateTime.Now, formatRules);

            var result = message.Format();

            result.Should().Be(messageText + " (now)");
        }

        [TestMethod]
        public void GivenAMessagePostedMoreThanOneSecondAgoAndLessThanOneMinuteAgo_FormatReturnsTheMessagePlusSeconds()
        {
            var messageText = "message text";
            var message = new Message(messageText, DateTime.Now.AddSeconds(-2), formatRules);

            var result = message.Format();

            result.Should().Be(messageText + " (2 seconds ago)");
        }

        [TestMethod]
        public void GivenAMessagePostedMoreThanOneMinutesAgoAndLessThanOneHourAgo_FormatReturnsTheMessagePlusMinutes()
        {
            var messageText = "message text";
            var message = new Message(messageText, DateTime.Now.AddMinutes(-2), formatRules);

            var result = message.Format();

            result.Should().Be(messageText + " (2 minutes ago)");
        }
    }
}