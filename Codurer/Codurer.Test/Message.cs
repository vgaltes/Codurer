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
            var now = DateTime.Now;

            if (now - postingTime < TimeSpan.FromSeconds(1))
                return string.Format("{0} (now)", this.text);
            else if (now - postingTime < TimeSpan.FromMinutes(1))
                return string.Format("{0} ({1} seconds ago)", this.text, (now - postingTime).Seconds);

            return this.text;
        }
    }
}