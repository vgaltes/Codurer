namespace CodurerApp.Test
{
    using System.Collections.Generic;
    using System.Collections.ObjectModel;

    public class User
    {
        private List<string> messages;

        public User()
        {
            messages = new List<string>();
        }

        public string Name { get; set; }

        public IEnumerable<string> Messages
        {
            get
            {
                return messages;
            }
        }

        internal void AddMessage(string message)
        {
            messages.Add(message);
        }
    }
}
