namespace CodurerApp.Test
{
    using System.Collections.Generic;

    public class User
    {
        public User()
        {
            Messages = new List<string>();
        }

        public string Name { get; set; }

        public List<string> Messages { get; set; }

        internal void AddMessage(string message)
        {
            Messages.Add(message);
        }
    }
}
