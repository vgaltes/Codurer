namespace CodurerApp.Models
{
    using System.Collections.Generic;
    using System.Collections.ObjectModel;

    public class User
    {
        private List<Message> messages;
        private List<string> following;

        public User()
        {
            messages = new List<Message>();
            following = new List<string>();
        }

        public string Name { get; set; }

        public IEnumerable<Message> Messages
        {
            get
            {
                return messages;
            }
        }

        public IEnumerable<string> Following
        {
            get
            {
                return following;
            }
        }

        internal void AddMessage(Message message)
        {
            messages.Add(message);
        }

        internal void AddFollowing(string following)
        {
            this.following.Add(following);
        }
    }
}