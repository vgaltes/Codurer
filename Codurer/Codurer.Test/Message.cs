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
            var secondsFormatRule = new SecondsFormatRule();
            var minutesFormatRule = new MinutesFormatRule();

            if (nowFormatRule.IsSatisfied(now, postingTime))
                return nowFormatRule.Format(text, now, postingTime);
            else if (secondsFormatRule.IsSatisfied(now, postingTime))
                return secondsFormatRule.Format(text, now, postingTime);
            else if (minutesFormatRule.IsSatisfied(now, postingTime))
                return minutesFormatRule.Format(text, now, postingTime);

            return this.text;
        }
    }
}