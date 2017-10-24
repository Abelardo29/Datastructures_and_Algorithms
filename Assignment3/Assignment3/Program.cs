using System;

namespace Assignment3 {
    class Program {        
        static void Main(string[] args) {

            RobberV2 npcRobber = new RobberV2();
            Cop npcCop = new Cop(50, npcRobber);

            npcRobber.GetNextScreen(npcRobber.start);
            npcCop.GetNextScreen(npcCop.start);

            do {
                System.Threading.Thread.Sleep(1000);
                npcRobber.GetNextScreen(npcRobber.currentState);
                System.Threading.Thread.Sleep(1000);
                npcCop.GetNextScreen(npcCop.currentState);

            } while (npcRobber.currentState != RobberV2.STATE.CAUGHT  || npcCop.currentState != Cop.STATE.CAUGHT_ROBBER);

            Console.ReadLine();
        }

    }
}
