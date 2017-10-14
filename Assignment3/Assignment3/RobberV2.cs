using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment3 {
    class RobberV2 {

        Random r = new Random();

        public enum STATE {
            ROBBING_BANK,
            HAVING_GOOD_TIME,
            FLEEING,
            LAYINGLOW,
            CAUGHT
        }

        public STATE currentState;

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

        const string
            robbingBank = "Robbing a bank",
            havingGoodTime = "Having a good time",
            fleeing = "Fleeing",
            layingLow = "Laying low";



        public int
            wealth = 0,
            distanceToCop,
            strength = 150;
        public STATE start = STATE.ROBBING_BANK;//note dat het startsein in de program class wordt gegeven.

        //Hierdoor switched de statemanager van state, je geeft hem een nieuwe state, 
        //en dan gaat ie de situatie uitvoeren met de correcte state en voert daarna meteen deze methode opnieuw uit.
        //Hoera voor (semi) recursiveness!
        public void GetNextScreen(STATE currentState) {
            if (this.currentState != STATE.CAUGHT) {
                this.currentState = currentState;
            }
            Console.WriteLine();
            switch (this.currentState) {
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
                case STATE.CAUGHT:
                    Console.WriteLine(":(");
                    break;
            }
        }

        private STATE Situation(string input) {
             distanceToCop = r.Next(100);

            Console.WriteLine("I am now this rich: " + wealth);

            switch (input) {
                case robbingBank:
                    Console.WriteLine("I am now this strong: " + strength);
                    if (copClose()) {
                        Console.WriteLine(spotCopText);
                        return GetEnum(spotCop);

                    }
                    else if (strength > 50) {

                        strength -= 50;
                        int plunder = 100 + r.Next(200);
                        Console.WriteLine("I just stole " + plunder + "!"
                            + "\n And i'm still feeling pretty safe!");
                        wealth += plunder;
                        return GetEnum(feelSafe);

                    }
                    else if (wealth > 200) {

                        Console.WriteLine("Too tired to rob more banks. :(");
                        return GetEnum(getRich);

                    }
                    else {

                        Console.WriteLine("Too tired to rob banks properly..");
                        return GetEnum(GetTired);
                    }

                case havingGoodTime:
                    wealth -= 100;

                    if (copClose()) {
                        Console.WriteLine(spotCopText);
                        return GetEnum(spotCop);

                    }
                    else if (wealth > 100) {

                        return GetEnum(getRich);

                    }
                    else {

                        Console.WriteLine("I ran out of money!");
                        return GetEnum(GetTired);
                    }
                case fleeing:

                    if (copClose()) {
                        Console.WriteLine(spotCopText);
                        return GetEnum(spotCop);

                    }
                    else if (wealth > 200) {

                        Console.Write("I escaped. " + getRichText);
                        return GetEnum(getRich);

                    }
                    else {

                        Console.WriteLine(getTiredText);
                        return GetEnum(GetTired);
                    }
                case layingLow:
                    int recovery = 20 + r.Next(100);
                    Console.WriteLine("I've recovered " + recovery + " strength!");
                    strength += recovery;
                    Console.WriteLine("I am now this strong: " + strength);

                    if(copClose()) {
                        Console.WriteLine(spotCopText);
                        return GetEnum(spotCop);

                    }
                    else if (strength > 80) {

                        return GetEnum(feelSafe);

                    }
                    else {

                        Console.WriteLine(getTiredText);
                        return GetEnum(GetTired);
                    }

                default:
                    Console.WriteLine("Unrecognized String in state switch. Fix it.");
                    return GetEnum(GetTired);
            }

        }

        private STATE GetEnum(string stringToEnum) {
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
                    Console.WriteLine("Enum conversion has gone seriously wrong, fix it.");
                    return start;
            }
        }

        public bool copClose() {
            return distanceToCop < 10;
        }

    }
}