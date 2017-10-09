using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment3 {
    class Program {
        static void Main(string[] args) {
            StateManager robbingState = new StateManager();
            robbingState.GetNextScreen(robbingState.start);
                Console.ReadLine();
        }
    }
}
