namespace CodurerApp.Services
{
    using System.Collections.Generic;
    using CodurerApp.FormatRules;
    
    public static class UserServiceFactory
    {
        public static InMemoryUserService GetInMemoryUserService()
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