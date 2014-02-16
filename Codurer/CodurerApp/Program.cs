namespace CodurerApp
{
    using System;
    using CodurerApp.Commands;
    using CodurerApp.Services;

    class Program
    {
        static void Main(string[] args)
        {
            var userService = UserServiceFactory.GetInMemoryUserService();
            var codurer = new Codurer(userService);
            var commandExecutor = 
                new CommandExecutor(codurer, CommandDescriptorFactory.GetCommandDescriptors());
            var quitString = "!q";

            Console.Write(">");
            string commandLine = Console.ReadLine();
                                   
            while (commandLine != quitString)
            {
                var commandResult = commandExecutor.ExecuteCommand(commandLine);
                foreach (string wallMessage in commandResult.Messages)
                {
                    Console.WriteLine(wallMessage);
                }

                Console.Write(">");
                commandLine = Console.ReadLine();
            }
        }
    }
}