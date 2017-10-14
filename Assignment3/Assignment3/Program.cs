using System;
using System.Diagnostics;

namespace Assignment3 {
    class Program {
        static RobberV2 npc = new RobberV2();
        static void Main(string[] args) {
            Stopwatch npcStopwatch = new Stopwatch();
            npcStopwatch.Start();
            float startTime = npcStopwatch.ElapsedMilliseconds;
            npc.GetNextScreen(npc.start);

            while (true) {
                if (npcStopwatch.ElapsedMilliseconds > startTime + 1000) {
                    npc = new RobberV2();
                    break;
                }
            }

            Console.ReadLine();
        }

    }
}
