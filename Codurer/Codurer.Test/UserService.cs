namespace CodurerApp.Test
{
    using System.Collections.Generic;

    public interface UserService
    {
        void AddUser(string userName);

        void Post(string message, string userName);

        IEnumerable<string> GetMessagesFrom(string userName);
    }
}