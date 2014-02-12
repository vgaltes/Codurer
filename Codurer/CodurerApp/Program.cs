using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodurerApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var codurer = new Codurer(new InMemoryUserService());
            var quitString = "!q";

            string line = Console.ReadLine();
                                   
            while (line != quitString)
            {
                var wall = codurer.Send(line);
                foreach ( string wallMessage in wall)
                {
                    Console.WriteLine(wallMessage);
                }

                line = Console.ReadLine();
            }
        }
    }
}
