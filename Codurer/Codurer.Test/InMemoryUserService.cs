namespace CodurerApp.Test
{
    using System;
    using System.Collections.Generic;

    public class InMemoryUserService : UserService
    {
        public InMemoryUserService()
        {
            Users = new List<User>();
        }

        public IList<User> Users
        {
            get;
            set;
        }

        public void AddUser(string userName)
        {
            var newUser = new User { Name = userName };
            Users.Add(newUser);
        }

        public void Post(string message, string userName)
        {
            throw new NotImplementedException();
        }
    }
}
