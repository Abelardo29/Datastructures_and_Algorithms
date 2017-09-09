using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {        
        static void Main(string[] args)
        {
            Highscores highscore = new Highscores(5000);
            highscore.Run();



            Console.ReadLine();
        }
    }
}
