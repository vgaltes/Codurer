namespace CodurerApp.Test
{
    using System;

    public class Message
    {
        private string text;
        public DateTime postingTime;

        public Message(string text, DateTime postingTime)
        {
            this.text = text;
            this.postingTime = postingTime;
        }

        internal string Format()
        {
            return this.text;
        }
    }
}