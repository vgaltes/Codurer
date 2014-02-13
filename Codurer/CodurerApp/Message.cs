namespace CodurerApp
{
    using System;
    using System.Collections.Generic;
    using CodurerApp.FormatRules;

    public class Message
    {
        private string text;
        private List<FormatRule> formatRules;

        public DateTime PostingTime {get; private set;}
        public string UserName { get; private set; }

        public Message(string userName, string text, DateTime postingTime, List<FormatRule> formatRules)
        {
            this.UserName = userName;
            this.text = text;
            this.PostingTime = postingTime;
            this.formatRules = formatRules == null ? new List<FormatRule>() : formatRules;
        }

        public string Format()
        {
            var message = string.Empty;
            var now = DateTime.Now;

            foreach (FormatRule formatRule in formatRules)
            {
                if (formatRule.IsSatisfied(now, PostingTime))
                    message = formatRule.Format(text, now, PostingTime);
            }

            return message;
        }
    }
}