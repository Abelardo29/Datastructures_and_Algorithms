using System;
using System.Diagnostics;

namespace ConsoleApplication1
{
    class Highscores
    {
        int dub = 0, amountOfTimes;
        Random r = new Random();
        Stopwatch stopwatch = new Stopwatch();

        public Highscores(int amountOfTimes)
        {
            this.amountOfTimes = amountOfTimes;
        }

        public void Run()
        {
            stopwatch.Start();

            for (int i = 0; i < amountOfTimes; i++)
                Calculate();

            stopwatch.Stop();

            Results();
        }

        public void Calculate()
        {
            int[] highscore = new int[100];
            

            for (int i = 0; i < highscore.Length; i++)
            {
                highscore[i] = r.Next(0, 10000);
                //Console.WriteLine("This is spot = " + (i + 1) + " met nummer " + highscore[i]);
            }
                for (int i = 0; i < highscore.Length; i++)
                {
                    for (int j = i + 1; j < highscore.Length; j++)
                    {
                        if (i != j && highscore[i] == highscore[j] && highscore[i] != 0)
                        {//Zoals ik het atm zie hoeven we niet te checken op meerdere dubbelen, gewoon als ie 1 keer een dubbele find meteen met loopen stoppen en rapporteren dus.
                         //Console.WriteLine("Same score! " + highscore[i] + " spot " + (i + 1) + " spot " + (j + 1));
                        dub++;
                        Console.WriteLine("no");
                        return;
                        }
                    }
                }

            Console.WriteLine("yes");              
        }

        public void Results()
        {
            Console.WriteLine("Amount of double = " + dub);
            Console.WriteLine("Time elapsed: {0}", stopwatch.Elapsed);            
        }
    }
}
