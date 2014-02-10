namespace CodurerApp.Test
{
    public interface IUserService
    {
        void AddUser(string userName);

        void Post(string message, string userName);
    }
}
