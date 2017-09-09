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
            Random r = new Random();
            int[] highscore = new int[100];
            int max = 5000;
            bool uniek = true;
            int dub = 0;

            for (int k = 0; k < max; k++)
            {
                for (int i = 0; i < highscore.Length; i++)
                {
                    highscore[i] = r.Next(0, 10000);
                }

                for (int i = 0; i < highscore.Length; i++)
                {
                    Console.WriteLine("This is spot = " + (i + 1) + " met nummer " + highscore[i]);
                }

                for (int i = 0; i < highscore.Length; i++)
                {
                    for (int j = i + 1; j < highscore.Length; j++)
                    {
                        if (i != j && highscore[i] == highscore[j] && highscore[i] != 0)
                        {
                            Console.WriteLine("Same score! " + highscore[i] + " spot " + (i + 1) + " spot " + (j + 1));
                            highscore[i] = 0;
                            highscore[j] = 0;
                            uniek = false;
                        }
                    }
                }
                if (uniek == false)
                {
                    dub++;
                }
                uniek = true;
            }
            Console.WriteLine(dub);
            Console.ReadLine();
        }
    }
}
