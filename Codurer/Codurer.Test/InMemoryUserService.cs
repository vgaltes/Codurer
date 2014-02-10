namespace CodurerApp.Test
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;

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
            var newUser = new User { Name = userName };
            users.Add(newUser);
        }

        public void Post(string message, string userName)
        {
            throw new NotImplementedException();
        }
    }
}
