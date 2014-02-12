namespace CodurerApp
{
    using System.Collections.Generic;
    using System.Collections.ObjectModel;

    public class User
    {
        private List<Message> messages;
        private List<User> followers;

        public User()
        {
            messages = new List<Message>();
        }

        public string Name { get; set; }

        public IEnumerable<Message> Messages
        {
            get
            {
                return messages;
            }
        }

        public IEnumerable<User> Followers
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
    }
}