using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;

namespace FroggerGameConsole
{
    class Program
    {
        internal static void Main(string[] args)
        {
            Game hra = new Game(16, 20);
            hra.Run();
        }
    }
}
