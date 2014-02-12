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

        public Message(string text, DateTime postingTime, List<FormatRule> formatRules)
        {
            this.text = text;
            this.postingTime = postingTime;
            this.formatRules = formatRules;
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