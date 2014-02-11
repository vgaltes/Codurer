namespace CodurerApp.Test
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;

    public class InMemoryUserService : UserService
    {
        private readonly List<User> users;
        public InMemoryUserService()
        {
            users = new List<User>();
        }

        public ReadOnlyCollection<User> Users
        {
            get
            {
                return new ReadOnlyCollection<User>(users);
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

        public void Post(string message, string userName)
        {
            var currentUser = users.First(user => user.Name == userName);
            currentUser.AddMessage(message);
        }
        
        public string GetMessagesFrom(string userName)
        {
            var currentUser = users.First(user => user.Name == userName);
            return currentUser.Messages.First();
        }
    }
}
