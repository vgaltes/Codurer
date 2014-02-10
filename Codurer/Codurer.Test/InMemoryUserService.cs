namespace CodurerApp.Test
{
    using System;
    using System.Collections.Generic;

    public class InMemoryUserService : UserService
    {
        public IList<User> Users
        {
            get;
            set;
        }

        public void AddUser(string userName)
        {
            throw new NotImplementedException();
        }

        public void Post(string message, string userName)
        {
            throw new NotImplementedException();
        }
    }
}
