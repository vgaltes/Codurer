namespace CodurerApp.Test
{
    using System;
    using CodurerApp.Test.FormatRules;

    public class Message
    {
        private string text;
        public DateTime postingTime;

        public Message(string text, DateTime postingTime)
        {
            this.text = text;
            this.postingTime = postingTime;
        }

        internal string Format()
        {
            var now = DateTime.Now;
            var nowFormatRule = new NowFormatRule();

            if (nowFormatRule.IsSatisfied(now, postingTime))
                return nowFormatRule.Format(text, now, postingTime);
            else if (now - postingTime < TimeSpan.FromMinutes(1))
                return string.Format("{0} ({1} seconds ago)", this.text, (now - postingTime).Seconds);
            else if (now - postingTime < TimeSpan.FromHours(1))
                return string.Format("{0} ({1} minutes ago)", this.text, (now - postingTime).Minutes);

            return this.text;
        }
    }
}