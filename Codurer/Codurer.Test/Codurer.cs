namespace CodurerApp.Test
{
    using System;

    class Codurer
    {
        private readonly IUserService userService;

        public Codurer(IUserService userService)
        {
            this.userService = userService;
        }

        internal void Send(string command)
        {
            var userName = GetUserNameFromCommand(command);

            userService.AddUser(userName);
        }

        private static string GetUserNameFromCommand(string command)
        {
            var userName =
                command.Split(new string[] { "->" }, StringSplitOptions.RemoveEmptyEntries)[0].Trim();
            return userName;
        }
    }
}