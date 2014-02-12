namespace CodurerApp.FormatRules
{
    using System;

    public class SecondsFormatRule : FormatRule
    {
        public bool IsSatisfied(DateTime now, DateTime postingTime)
        {
            return IsPostedMoreThanOneSecondAgo(now, postingTime) && IsPostedLessThanOneMinuteAgo(now, postingTime);
        }

        private static bool IsPostedLessThanOneMinuteAgo(DateTime now, DateTime postingTime)
        {
            return now - postingTime < TimeSpan.FromMinutes(1);
        }

        private static bool IsPostedMoreThanOneSecondAgo(DateTime now, DateTime postingTime)
        {
            return now - postingTime >= TimeSpan.FromSeconds(1);
        }

        public string Format(string messageText, DateTime now, DateTime postingTime)
        {
            return string.Format("{0} ({1} seconds ago)", messageText, (now - postingTime).Seconds);
        }
    }
}