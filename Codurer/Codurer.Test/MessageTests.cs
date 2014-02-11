namespace CodurerApp.Test
{
    using FluentAssertions;
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class MessageTests
    {
        [TestMethod]
        public void GivenAMessagePostedLessThanOneSecondAgo_FormatReturnsTheMessagePlusNow()
        {
            var messageText = "message text";
            var message = new Message(messageText, DateTime.Now);

            var result = message.Format();

            result.Should().Be(messageText + " (now)");
        }
    }
}