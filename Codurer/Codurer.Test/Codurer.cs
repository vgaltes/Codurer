namespace CodurerApp.Test
{
    using System;

    class Codurer
    {
        private readonly UserService userService;

        public Codurer(UserService userService)
        {
            this.userService = userService;
        }

        internal string Send(string command, DateTime timeSended)
        {
            var userName = GetUserNameFromCommand(command);
            userService.AddUser(userName);

            var message = GetMessageFromCommand(command);
            userService.Post(message, userName);

            return string.Empty;
        }

        internal string Send(string command)
        {
            return Send(command, DateTime.Now);
        }

        private static string GetUserNameFromCommand(string command)
        {
            var userName =
                command.Split(new string[] { "->" }, StringSplitOptions.RemoveEmptyEntries)[0].Trim();
            return userName;
        }

        private static string GetMessageFromCommand(string command)
        {
            var message =
                command.Split(new string[] { "->" }, StringSplitOptions.RemoveEmptyEntries)[1].Trim();
            return message;
        }
    }
}