namespace CodurerApp.Test.FormatRules
{
    using System;

    public class MinutesFormatRule : FormatRule
    {
        public bool IsSatisfied(DateTime now, DateTime postingTime)
        {
            return IsPostedMoreThanOneMinuteAgo(now, postingTime) && IsPostedLessThanOneHourAgo(now, postingTime);
        }

        private static bool IsPostedLessThanOneHourAgo(DateTime now, DateTime postingTime)
        {
            return now - postingTime < TimeSpan.FromHours(1);
        }

        private static bool IsPostedMoreThanOneMinuteAgo(DateTime now, DateTime postingTime)
        {
            return now - postingTime >= TimeSpan.FromMinutes(1);
        }

        public string Format(string messageText, DateTime now, DateTime postingTime)
        {
            return string.Format("{0} ({1} minutes ago)", messageText, (now - postingTime).Minutes);
        }
    }
}