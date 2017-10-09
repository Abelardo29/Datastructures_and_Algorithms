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

        private const string
            whileRobbing = "I'm robbing banks and getting loads of money! Pew pew!",
            whileHavingGoodTime = "I'm having a good time spending my money",
            whileFleeing = "RUN FOREST RUN",
            whileLayingLow = "No one will find me now!",
            getRich = "get rich",
            spotCop = "spot cop",
            feelSafe = "feel safe",
            GetTired = "get tired",
            getRichText = "I'm rich enough to have a good time.",
            spotCopText = "I see a cop, so I have to start running",
            feelSafeText = "Fuck da police! I'm safe!",
            getTiredText = "I'm getting very tired, so I better lay low for a while";

        string robbingBank, havingGoodTime, fleeing, layingLow;

        public StateManager() {
            robbingBank = getRich + "/" + spotCop + "*" + getRichText + "/" + spotCopText;
            havingGoodTime = spotCop + "/" + GetTired + "*" + spotCopText + "/" + getTiredText;
            fleeing = feelSafe + "/" + GetTired + "/" + GetTired + "+" + getRich + "*" 
                + feelSafeText + "/" + getTiredText + "/" + getTiredText + " and " + getRichText;
            layingLow = spotCop + "/" + feelSafe + "*" + spotCopText + "/" + feelSafeText;
        }




        List<string> optionList = new List<string>();
        List<string> responseList = new List<string>();

        public STATE start = STATE.ROBBING_BANK;
        private int moneyCurrent = 0;

        public void GetNextScreen(STATE currentState) {
            switch (currentState) {
                case STATE.ROBBING_BANK:
                    Console.WriteLine(whileRobbing);
                    GetNextScreen(Situation(robbingBank));
                    break;

                case STATE.HAVING_GOOD_TIME:
                    Console.WriteLine(whileHavingGoodTime);
                    GetNextScreen(Situation(havingGoodTime));
                    break;

                case STATE.FLEEING:
                    Console.WriteLine(whileFleeing);
                    GetNextScreen(Situation(fleeing));
                    break;

                case STATE.LAYINGLOW:
                    Console.WriteLine(whileLayingLow);
                    GetNextScreen(Situation(layingLow));
                    break;
            }
        }

        private STATE Situation(string input) {
            string[] seperate = input.Split('*');
            string[] options = seperate[0].Split('/');
            string[] dialogue = seperate[1].Split('/');

            Console.WriteLine("....What should I do? \n");
            Console.Write("I can do nothing");

            for (int i = 0; i < options.Length; i++) {
                Console.Write(" or " + options[i]);
            }

            Console.WriteLine();

            while (true) {
                string userInput = Console.ReadLine();
                Console.WriteLine();
                for (int i = 0; i < options.Length; i++) {
                    if (userInput.Equals(options[i])) {
                        Console.WriteLine(dialogue[i]);
                        return GetEnum(options[i]);
                    }
                }
                Console.WriteLine("Doing nothin' since I appearently got no command.");
            }

        }

        private STATE GetEnum (string stringToEnum) {
            switch (stringToEnum) {
                case getRich:
                    return STATE.HAVING_GOOD_TIME;
                case spotCop:
                    return STATE.FLEEING;
                case feelSafe:
                    return STATE.ROBBING_BANK;
                case GetTired:
                    return STATE.LAYINGLOW;
                case GetTired + "+" + getRich:
                    return STATE.HAVING_GOOD_TIME;
                default:
                    return start;
            }
        }

    }
}
