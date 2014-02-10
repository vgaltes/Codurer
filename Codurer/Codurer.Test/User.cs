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

        public ReadOnlyCollection<string> Messages
        {
            get
            {
                return new ReadOnlyCollection<string>(messages);
            }
        }

        internal void AddMessage(string message)
        {
            messages.Add(message);
        }
    }
}
