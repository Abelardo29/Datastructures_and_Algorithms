using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment3 {
    class StateManager {

        public enum STATE {
            ROBBING_BANK,
            HAVING_GOOD_TIME,
            FLEEING,
            LAYINGLOW
        }

        private string
            whileRobbing = "I'm robbing banks and getting loads of money! Pew pew!",
            whileHavingGoodTime = "I'm having a good time spending my money",
            whileFleeing = "RUN FOREST RUN",
            whileLayingLow = "No one will find me now!",
            getRich = "I'm rich enough to have a good time.",
            spotCop = "I see a cop, so I have to start running",
            feelSafe = "Fuck da police! I'm safe!",
            getTired = "I'm getting very tired, so I better lay low for a while";

        public StateManager() {
            string
            robbingBank = getRich + "/" + spotCop + "," +  +,
            havingGoodTime =,
            fleeing =,
            layingLow = ;
        }
        
        
        

        List<string> optionList = new List<string>();
        List<string> responseList = new List<string>();

        private STATE start = STATE.ROBBING_BANK;
        private int moneyCurrent = 0;

        public void GetNextScreen(STATE currentState) {
            switch (currentState) {
                case STATE.ROBBING_BANK:
                    Console.WriteLine("I'm robbing banks and getting loads of money! Pew pew!");
                    RobBank();
                    break;

                case STATE.HAVING_GOOD_TIME:
                    Console.WriteLine("I'm having a good time spending my money");
                    HaveGoodTime();
                    break;

                case STATE.FLEEING:
                    break;

                case STATE.LAYINGLOW:
                    break;
            }
        }

        private void RobBank() {
            Console.WriteLine("What should i do next?");
            Console.WriteLine("(get rich or spot cop)");
            switch (Console.ReadLine()) {//hier vragen we de speler input aan.
                case "get rich"://cases zoals gewoonlijk.
                    Console.WriteLine("I'm rich enough to have a good time");
                    GetNextScreen(STATE.HAVING_GOOD_TIME);
                    break;
                case "spot cop":
                    Console.WriteLine("I see a cop, so I have to start running");
                    GetNextScreen(STATE.FLEEING);
                    break;
            }
        }

        private void HaveGoodTime() {

        }

    }
}
