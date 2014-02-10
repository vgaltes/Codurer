using System;
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
            var userName = 
                command.Split(new string[] { "->" }, StringSplitOptions.RemoveEmptyEntries)[0].Trim();

            userService.AddUser(userName);
        }
    }
}