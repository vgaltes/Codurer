namespace CodurerApp.Test
{
    using System.Collections.Generic;
    using CodurerApp.FormatRules;
    using CodurerApp.Services;

    public class InMemoryUserServiceTest
    {
        public InMemoryUserService GetUserService()
        {
            var formatRules = new List<FormatRule>
            {
                new NowFormatRule(),
                new SecondsFormatRule(),
                new MinutesFormatRule()
            };

            var userService = new InMemoryUserService(formatRules);
            return userService;
        }
    }
}
