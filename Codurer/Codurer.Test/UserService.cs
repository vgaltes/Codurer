namespace CodurerApp.Test
{
    public interface UserService
    {
        void AddUser(string userName);

        void Post(string message, string userName);

        string GetMessagesFrom(string userName);
    }
}
