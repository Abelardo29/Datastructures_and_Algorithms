using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment3 {
    class Program {
        static void Main(string[] args) {
            Robber npc = new Robber();
            npc.GetNextScreen(npc.start);

            do {

                //something

            } while (npc.currentState != Robber.STATE.CAUGHT);

            Console.ReadLine();
        }
    }
}
