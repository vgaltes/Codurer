namespace CodurerApp.FormatRules
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
            var minutesAgo = (now - postingTime).Minutes;
            var minutesWord = "minutes";

            if (minutesAgo == 1)
                minutesWord = "minute";

            return string.Format("{0} ({1} {2} ago)", messageText, minutesAgo, minutesWord);
        }
    }
}