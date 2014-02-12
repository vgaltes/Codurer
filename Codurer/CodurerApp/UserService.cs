namespace CodurerApp
{
    using System;
    using System.Collections.Generic;

    public interface UserService
    {
        void AddUser(string userName);

        void Post(string message, string userName, DateTime postingTime);

        void Post(string message, string userName);

        IEnumerable<string> GetMessagesFrom(string userName);

        void Follow(string follower, string followed);
    }
}