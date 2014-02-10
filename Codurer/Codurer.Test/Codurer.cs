namespace CodurerApp.Test
{
    class Codurer
    {
        private readonly IUserService userService;

        public Codurer(IUserService userService)
        {
            this.userService = userService;
        }

        internal void Send(string command)
        {
            throw new System.NotImplementedException();
        }
    }
}
