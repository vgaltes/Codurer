namespace CodurerApp.Test.FormatRules
{
    using System;

    public class SecondsFormatRule : FormatRule
    {
        public bool IsSatisfied(DateTime now, DateTime postingTime)
        {
            return now - postingTime < TimeSpan.FromMinutes(1);
        }

        public string Format(string messageText, DateTime now, DateTime postingTime)
        {
            return string.Format("{0} ({1} seconds ago)", messageText, (now - postingTime).Seconds);
        }
    }
}