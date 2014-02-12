namespace CodurerApp.FormatRules
{
    using System;

    public class NowFormatRule : FormatRule
    {
        public bool IsSatisfied(DateTime now, DateTime postingTime)
        {
            return IsPostedLessThanOneSecondAgo(now, postingTime);
        }

        private static bool IsPostedLessThanOneSecondAgo(DateTime now, DateTime postingTime)
        {
            return now - postingTime < TimeSpan.FromSeconds(1);
        }

        public string Format(string messageText, DateTime now, DateTime postingTime)
        {
            return string.Format("{0} (now)", messageText);
        }
    }
}