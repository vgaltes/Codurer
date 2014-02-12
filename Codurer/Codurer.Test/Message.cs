namespace CodurerApp.Test
{
    using System;
using System.Collections.Generic;
using CodurerApp.Test.FormatRules;

    public class Message
    {
        private string text;
        public DateTime postingTime;
        private List<FormatRule> formatRules;

        public Message(string text, DateTime postingTime)
        {
            this.text = text;
            this.postingTime = postingTime;
            formatRules = new List<FormatRule>
            {
                new NowFormatRule(),
                new SecondsFormatRule(),
                new MinutesFormatRule()
            };
        }

        internal string Format()
        {
            var message = string.Empty;
            var now = DateTime.Now;

            foreach( FormatRule formatRule in formatRules)
            {
                if (formatRule.IsSatisfied(now, postingTime))
                    message = formatRule.Format(text, now, postingTime);
            }

            return message;
        }
    }
}