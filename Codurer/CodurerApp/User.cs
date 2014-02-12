namespace CodurerApp
{
    using System.Collections.Generic;
    using System.Collections.ObjectModel;

    public class User
    {
        private List<Message> messages;
        private List<string> followers;

        public User()
        {
            messages = new List<Message>();
            followers = new List<string>();
        }

        public string Name { get; set; }

        public IEnumerable<Message> Messages
        {
            get
            {
                return messages;
            }
        }

        public IEnumerable<string> Followers
        {
            get
            {
                return followers;
            }
        }

        internal void AddMessage(Message message)
        {
            messages.Add(message);
        }

        internal void AddFollower(string follower)
        {
            followers.Add(follower);
        }
    }
}