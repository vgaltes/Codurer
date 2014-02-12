namespace CodurerApp
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Codurer
    {
        private readonly UserService userService;

        public Codurer(UserService userService)
        {
            this.userService = userService;
        }

        /*public IEnumerable<string> Send(string command, DateTime postingTime)
        {
            var userName = GetUserNameFromCommand(command);
            userService.AddUser(userName);

            var message = GetMessageFromCommand(command);
            if (message != string.Empty)
                userService.Post(message, userName, postingTime);
            else
                return userService.GetMessagesFrom(userName);

            return new List<string>();
        }

        public IEnumerable<string> Send(string command)
        {
            return Send(command, DateTime.Now);
        }*/

        public void Post(string message, string user)
        {
            DateTime postingTime = DateTime.Now;

            userService.AddUser(user);            
            userService.Post(message, user, postingTime);
        }

        public void Post(string message, string user, DateTime postingTime)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<string> GetTimeline(string user)
        {
            return userService.GetMessagesFrom(user);
        }

        private static string GetUserNameFromCommand(string command)
        {
            var userName =
                command.Split(new string[] { "->" }, StringSplitOptions.RemoveEmptyEntries)[0].Trim();
            return userName;
        }

        private static string GetMessageFromCommand(string command)
        {
            var message = string.Empty;
            var messageSplitted =
                command.Split(new string[] { "->" }, StringSplitOptions.RemoveEmptyEntries);

            if (messageSplitted.Count() > 1)
                message = messageSplitted[1].Trim();

            return message;
        }
    }
}