namespace CodurerApp
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

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
            throw new NotImplementedException();
        }
    }
}