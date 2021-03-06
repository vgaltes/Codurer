﻿namespace CodurerApp.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using CodurerApp.FormatRules;
    using CodurerApp.Models;

    public class InMemoryUserService : UserService
    {
        private readonly List<User> users;
        private readonly List<FormatRule> formatRules;

        public InMemoryUserService(List<FormatRule> formatRules)
        {
            users = new List<User>();
            this.formatRules = formatRules;
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
            currentUser.AddMessage(new Message(userName, message, postingTime, formatRules));
        }

        public void Post(string message, string userName)
        {
            Post(message, userName, DateTime.Now);
        }

        public IEnumerable<string> GetMessagesFormattedFrom(string userName)
        {
            var currentUser = users.First(user => user.Name == userName);
            return currentUser.Messages
                .OrderByDescending(message => message.PostingTime)
                .Select(message => message.Format());
        }

        public IEnumerable<Message> GetMessagesFrom(string userName)
        {
            var currentUser = users.First(user => user.Name == userName);
            return currentUser.Messages;
        }

        public void Follow(string follower, string followed)
        {
            var followerUser = users.First(user => user.Name == follower);
            followerUser.AddFollowing(followed);
        }
        
        public IEnumerable<Message> GetMessagesFromFollowingUsersFrom(string userName)
        {
            var followerUser = users.First(user => user.Name == userName);
            var followingUsers = users.Where(
                user => followerUser.Following.Contains(user.Name));

            List<Message> followingUsersMessages = new List<Message>();
            foreach ( var followingUser in followingUsers)
            {
                followingUsersMessages.AddRange(followingUser.Messages);
            }

            return followingUsersMessages;
        }
    }
}