namespace CodurerApp.Services
{
    using System;
    using System.Collections.Generic;
    using CodurerApp.Models;

    public interface UserService
    {
        void AddUser(string userName);

        void Post(string message, string userName, DateTime postingTime);

        void Post(string message, string userName);

        IEnumerable<string> GetMessagesFormattedFrom(string userName);

        IEnumerable<Message> GetMessagesFrom(string userName);

        void Follow(string follower, string followed);

        IEnumerable<Message> GetMessagesFromFollowingUsersFrom(string user);
    }
}