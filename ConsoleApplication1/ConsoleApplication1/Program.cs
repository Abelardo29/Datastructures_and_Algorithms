using System;
using System.Diagnostics;

namespace ConsoleApplication1
{
    class Program
    {
        static int dub = 0;
        static Random r = new Random();

        static void Main(string[] args)
        {
            int amountOfTimes = 5000;
            Stopwatch stopwatch1 = new Stopwatch(), stopwatch2 = new Stopwatch();//ik heb alvast dit toegevoegd om correct tijd te berekenen, aangezien het toch niet zoveel moeite was.

            
            stopwatch1.Start();
            for (int i = 0; i < amountOfTimes; i++)//dit is opdracht 1 + 2
            {
                int[] highscore = new int[100];
                for (int j = 0; j < highscore.Length; j++)
                {
                    highscore[j] = r.Next(0, 10000);
                    //Console.WriteLine("This is spot = " + (j + 1) + " met nummer " + highscore[i]);
                }

                CalculateDoubles(highscore);
            }
            stopwatch1.Stop();

            Results(dub, stopwatch1);

            //timer van opdracht 3en 4 start hier.
            stopwatch2.Start();
            for (int i = 0; i < amountOfTimes; i++)//dit WORD opdracht 3 + 4
            {
                int[] elements = new int[10000];

                if (AddRandomNumbers(elements, 100))
                    dub++;//dit is nog niet opdracht 4 proper, hier returned ie inplaats van duplicates het aantal keren dat ie boven de 1 komt met die random getallen optellen.
            }
            stopwatch2.Stop();

            Results(dub, stopwatch2);

            Console.ReadLine();
        }

        public static void CalculateDoubles(int[] currentArray)
        {
            

            for (int i = 0; i < currentArray.Length; i++)
            {
                for (int j = i + 1; j < currentArray.Length; j++)
                {
                    if (i != j && currentArray[i] == currentArray[j] && currentArray[i] != 0)
                    {//Zoals ik het atm zie hoeven we niet te checken op meerdere dubbelen, gewoon als ie 1 keer een dubbele find meteen de loop stoppen en rapporteren dus, bespaart tijd
                     //Console.WriteLine("Same score! " + currentArray[i] + " spot " + (i + 1) + " spot " + (j + 1));
                        dub++;
                        Console.WriteLine("no");
                        return;
                    }
                }
            }

            Console.WriteLine("yes");
        }

        public static void Results(int doubles, Stopwatch currentStopwatch)
        {
            Console.WriteLine("Amount of double = " + doubles);
            Console.WriteLine("Time elapsed: {0}", currentStopwatch.Elapsed);
        }

        public static bool AddRandomNumbers(int[] currentArray, int addMultiplier)
        {
            for (int i = 1; i < addMultiplier; i++)
                currentArray[r.Next(currentArray.Length)]++;

            for (int i = 1; i < currentArray.Length; i++)
                if (currentArray[i] > 1)
                    return true;

            return false;
        }
    }
}

