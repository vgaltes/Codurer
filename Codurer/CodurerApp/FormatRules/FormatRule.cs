namespace CodurerApp.FormatRules
{
    using System;

    public interface FormatRule
    {
        bool IsSatisfied(DateTime now, DateTime postingTime);

        string Format(string messageText, DateTime now, DateTime postingTime);
    }
}
