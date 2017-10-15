using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment3
{
    class Cop
    {

        public enum STATE
        {
            OFF_DUTY,
            ON_STAKE_OUT,
            CHASING,
            CAUGHT
        }

        public STATE currentState;

        private const string
            whileOnDuty = "I should look for some robbers to arrest",
            whileNotOnDuty = "I am done for today, lets go home",
            chasingRobber = "Hold it right there!",
            lostRobber = "Awww man he escaped :(";

        const string
            offDuty = "Off duty",
            onStakeOut = "On stake out",
            chasing = "chasing";

        public int
            dutyTime = 100,
            distanceToCop;
        public STATE start = STATE.ON_STAKE_OUT;//note dat het startsein in de program class wordt gegeven.

        public void GetNextScreen(STATE currentState)
        {
            if (this.currentState != STATE.CAUGHT)
            {
                this.currentState = currentState;
            }

            Console.WriteLine();
            switch (this.currentState)
            {
                case STATE.ON_STAKE_OUT:
                    Console.WriteLine(whileOnDuty);
                    GetNextScreen(Situation(onStakeOut));
                    break;

                case STATE.CHASING:
                    Console.WriteLine(chasingRobber);
                    GetNextScreen(Situation(chasing));
                    break;

                case STATE.OFF_DUTY:
                    Console.WriteLine(whileNotOnDuty);
                    GetNextScreen(Situation(offDuty));
                    break;

                case STATE.CAUGHT:
                    Console.WriteLine(":)");
                    break;
            }
        }

        private STATE GetEnum(string stringToEnum)
        {
            switch (stringToEnum)
            {
                case whileOnDuty:
                    return STATE.ON_STAKE_OUT;
                case whileNotOnDuty:
                    return STATE.OFF_DUTY;
                case chasing:
                    return STATE.CHASING;
                default:
                    Console.WriteLine("Enum conversion has gone seriously wrong, fix it.");
                    return start;
            }
        }

    }
}
