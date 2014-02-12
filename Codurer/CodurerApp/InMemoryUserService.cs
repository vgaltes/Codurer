namespace CodurerApp
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using CodurerApp.FormatRules;

    public class InMemoryUserService : UserService
    {
        private readonly List<User> users;
        private readonly List<FormatRule> formatRules;
        public InMemoryUserService()
        {
            users = new List<User>();
            formatRules = new List<FormatRule>
            {
                new NowFormatRule(),
                new SecondsFormatRule(),
                new MinutesFormatRule()
            };
        }

        public IEnumerable<User> Users
        {
            get
            {
                return users;
            }
        }

        public void AddUser(string userName)
        {
            if (Exists(userName))
                return;

            var newUser = new User { Name = userName };
            users.Add(newUser);
        }

        private bool Exists(string userName)
        {
            return users.Any(user => user.Name == userName);
        }

        public void Post(string message, string userName, DateTime postingTime)
        {
            var currentUser = users.First(user => user.Name == userName);
            currentUser.AddMessage(new Message(message, postingTime, formatRules));
        }

        public void Post(string message, string userName)
        {
            Post(message, userName, DateTime.Now);
        }

        public IEnumerable<string> GetMessagesFrom(string userName)
        {
            var currentUser = users.First(user => user.Name == userName);
            return currentUser.Messages
                .OrderByDescending(message => message.postingTime)
                .Select(message => message.Format());
        }
        public void Follow(string follower, string followed)
        {
            throw new NotImplementedException();
        }        
    }
}