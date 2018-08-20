using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bonjour
{
    class HelloSuperStyle
    {
        static void Main(string[] args)
        {
            Message message = new Message(9, 13, 18);
            bool stop = false;
            while (!stop)
            {
                Console.WriteLine(message.DisplayDayMessage());
                string line = Console.ReadLine();
                stop = (line == "exit");
            }
            Environment.Exit(0);

        }
    }
}
