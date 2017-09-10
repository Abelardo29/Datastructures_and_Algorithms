using System;
using System.Diagnostics;

namespace Assignment1
{
    class Program
    {
        static int dub = 0, dub2 = 0, higher = 0;
        static Random r = new Random();
        // test
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

                if (CalculateDoubles(highscore))
                    dub++;
            }
            stopwatch1.Stop();

            Results(dub, stopwatch1);

            //timer van opdracht 3en 4 start hier.
            stopwatch2.Start();
            for (int i = 0; i < amountOfTimes; i++)//dit WORD opdracht 3 + 4
            {
                int[] elements = new int[10000];

                if (AddRandomNumbers(elements, 100))
                {
                    Console.WriteLine("Number higher than 1");
                    higher++;
                }
                    
                if (CalculateDoubles(elements))
                    dub2++;
            }
            stopwatch2.Stop();

            Results(dub2, stopwatch2);
            Console.WriteLine("This one is for how many numbers are higher than 1");
            Results(higher, stopwatch2);

            Console.ReadLine();
        }




        public static bool CalculateDoubles(int[] currentArray)
        {
            

            for (int i = 0; i < currentArray.Length; i++)
            {
                for (int j = i + 1; j < currentArray.Length; j++)
                {
                    if (i != j && currentArray[i] == currentArray[j] && currentArray[i] != 0)
                    {//Zoals ik het atm zie hoeven we niet te checken op meerdere dubbelen, gewoon als ie 1 keer een dubbele find meteen de loop stoppen en rapporteren dus, bespaart tijd
                     //Console.WriteLine("Same score! " + currentArray[i] + " spot " + (i + 1) + " spot " + (j + 1));
                        Console.WriteLine("no");
                        return true;
                    }
                }
            }

            Console.WriteLine("yes");
            return false;
        }

        public static void Results(int doubles, Stopwatch currentStopwatch)
        {
            Console.WriteLine("Amount = " + doubles);
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

