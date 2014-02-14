namespace CodurerApp
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using CodurerApp.Models;
    using CodurerApp.Services;

    public class Codurer
    {
        private readonly UserService userService;

        public Codurer(UserService userService)
        {
            this.userService = userService;
        }
        
        public void Post(string message, string user)
        {
            DateTime postingTime = DateTime.Now;

            Post(message, user, postingTime);
        }

        public void Post(string message, string user, DateTime postingTime)
        {
            userService.AddUser(user);
            userService.Post(message, user, postingTime);
        }

        public IEnumerable<string> GetTimeline(string user)
        {
            return userService.GetMessagesFormattedFrom(user);
        }

        public void Follow(string follower, string followed)
        {
            userService.Follow(follower, followed);
        }

        public IEnumerable<string> GetWall(string user)
        {
            var currentUserTimeline = userService.GetMessagesFrom(user);
            var followingTimeline = userService.GetMessagesFromFollowingUsersFrom(user);

            var wall = currentUserTimeline.Union(followingTimeline);

            return wall
                .OrderByDescending(message => message.PostingTime)
                .Select(message => FormatMessageForWall(message));
        }

        private static string FormatMessageForWall(Message message)
        {
            return string.Format("{0} - {1}", message.UserName, message.Format());
        }
    }
}