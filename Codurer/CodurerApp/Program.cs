namespace CodurerApp
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using CodurerApp.Commands;
    using CodurerApp.FormatRules;
    using CodurerApp.Services;

    class Program
    {
        static void Main(string[] args)
        {
            var userService = UserServiceFactory.GetInMemoryUserService();
            var commandFactory = InitializeCommandFactory();
            var codurer = new Codurer(userService);
            var quitString = "!q";

            Console.Write(">");
            string line = Console.ReadLine();
                                   
            while (line != quitString)
            {
                var command = commandFactory.GetCommand(line, codurer);
                var commandResult = command.Execute();
                foreach (string wallMessage in commandResult.Messages)
                {
                    Console.WriteLine(wallMessage);
                }

                Console.Write(">");
                line = Console.ReadLine();
            }
        }

        private static CommandFactory InitializeCommandFactory()
        {
            var commandDescriptors = new List<CommandDescriptor>
            {
                CommandDescriptorFactory.GetPostCommandDescriptor(),
                CommandDescriptorFactory.GetTimelineCommandDescriptor(),
                CommandDescriptorFactory.GetFollowingCommandDescriptor(),
                CommandDescriptorFactory.GetWallCommandDescriptor()
            };
            var commandFactory = new CommandFactory(commandDescriptors);
            return commandFactory;
        }
    }
}
