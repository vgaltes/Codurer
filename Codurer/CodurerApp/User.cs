namespace CodurerApp
{
    using System.Collections.Generic;
    using System.Collections.ObjectModel;

    public class User
    {
        private List<Message> messages;

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

        internal void AddMessage(Message message)
        {
            messages.Add(message);
        }
    }
}