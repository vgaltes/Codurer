using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodurerApp.Commands;

namespace CodurerApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var codurer = new Codurer(new InMemoryUserService());
            var quitString = "!q";

            Console.Write(">");
            string line = Console.ReadLine();
                                   
            while (line != quitString)
            {
                var command = CommandFactory.GetCommand(line, codurer);
                var commandResult = command.Execute();
                foreach (string wallMessage in commandResult.Items)
                {
                    Console.WriteLine(wallMessage);
                }

                Console.Write(">");
                line = Console.ReadLine();
            }
        }
    }
}
