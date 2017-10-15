using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment3
{
    class Cop
    {
        Random r = new Random();
        RobberV2 target;

        public enum STATE
        {
            OFF_DUTY,
            ON_STAKE_OUT,
            CHASING,
            CAUGHT_ROBBER
        }

        public STATE currentState;

        private const string
            whileOnDuty = "I should look for some robbers to arrest",
            whileNotOnDuty = "Relaxing on the sofa, watching Crime Scene Investigation",
            offDutyText = "I am done for today, lets go home",
            chasingRobber = "Hold it right there!",
            lostRobber = "Awww man he escaped :(";

        const string
            offDuty = "Off duty",
            onStakeOut = "On stake out",
            chasing = "chasing",
            caughtRobber = "caught!";

        public int
            dutyTime = 0,
            distanceToRobber,
            distanceVar;

        public Cop (int givenActions, RobberV2 target) {
            distanceToRobber = r.Next(6, 100);
            this.target = target;
        }

        public STATE start = STATE.ON_STAKE_OUT;//note dat het startsein in de program class wordt gegeven.

        public void GetNextScreen(STATE currentState)
        {

            //this.currentState = currentState;
            
            Console.WriteLine();
                switch (currentState) {
                    case STATE.ON_STAKE_OUT:
                        Say(whileOnDuty);
                        this.currentState = (Situation(onStakeOut));
                        break;

                    case STATE.CHASING:
                        Say(chasingRobber);
                        this.currentState = (Situation(chasing));
                        break;

                    case STATE.OFF_DUTY:
                        Say(whileNotOnDuty);
                        this.currentState = (Situation(offDuty));
                        break;

                    case STATE.CAUGHT_ROBBER:
                        Say(":)");
                        this.currentState = STATE.CAUGHT_ROBBER;
                        break;
                default:
                    Say("Something has gone seriously wrong");
                    break;

                }
            
        }

        private STATE Situation(string input) {                

            Say("Current dutyTime: " + dutyTime);

            switch (input) {

                case offDuty:
                    dutyTime -= 20;
                    if (FullyRested) {
                        Say("Going back to work!");
                        return GetEnum(onStakeOut);
                    }
                    else {
                        return GetEnum(offDuty);
                    }

                case onStakeOut:
                    if (RobberClose) {//chasing behaviour.
                        Say("My current distance to that guy is " + distanceToRobber + " meters.");
                        int chase = r.Next(-2, 3);
                        if (chase >= 0)
                            Say("I lost: " + chase + " meters!");
                        else Say("I gained: " + Math.Abs(chase) + " meters!");
                        distanceToRobber += chase;
                        target.distanceToCop += chase;
                    }

                    else {
                        distanceVar = r.Next(6, 100);
                        distanceToRobber = distanceVar;
                        target.distanceToCop = distanceVar;
                    }

                    dutyTime += 10;
                    if (DoneWorking) {
                        Say(offDutyText);
                        Say("Special");
                        return GetEnum(offDuty);
                    }
                    else if (RobberClose) {
                        return GetEnum(chasing);
                    }
                    else {
                        return GetEnum(onStakeOut);
                    }

                case chasing:
                    if (RobberClose) {//chasing behaviour.
                        Say("My current distance to that guy is " + distanceToRobber + " meters.");
                        int chase = r.Next(-2, 3);
                        if (chase >= 0)
                            Say("I lost: " + chase + " meters!");
                        else Say("I gained: " + Math.Abs(chase) + " meters!");
                        distanceToRobber += chase;
                        target.distanceToCop += chase;
                    }

                    else {
                        distanceVar = r.Next(6, 100);
                        distanceToRobber = distanceVar;
                        target.distanceToCop = distanceVar;
                    }

                    dutyTime += 10;
                    if (DoneWorking) {
                        Say(offDutyText);
                        return GetEnum(offDuty);
                    } else if (CatchRobber) {
                        Say("I actually caught a robber!");
                        target.currentState = RobberV2.STATE.CAUGHT;
                        return GetEnum(caughtRobber);
                    } else {
                        return GetEnum(chasing);
                    }

                default:
                    Say("Unrecognized String in state switch. Fix it.");
                    return GetEnum(offDuty);
            }

        }

        private STATE GetEnum(string stringToEnum)
        {
            switch (stringToEnum)
            {
                case onStakeOut:
                    //Say("Returning StakeOut.");
                    return STATE.ON_STAKE_OUT;
                case offDuty:
                    //Say("Returning offDutyState.");
                    return STATE.OFF_DUTY;
                case chasing:
                    return STATE.CHASING;
                case caughtRobber:
                    return STATE.CAUGHT_ROBBER;
                default:
                    Say("Enum conversion has gone seriously wrong, fix it.");
                    return start;
            }
        }

        private bool FullyRested {
            get { return dutyTime <= 0; }
        }

        private bool RobberClose {
            get { return distanceToRobber < 10; }
        }

        private bool DoneWorking {
            get { return dutyTime >= 100; }
        }

        private bool CatchRobber {
            get { return distanceToRobber < 6; }
        }

        public void Say(string input) {
            Console.WriteLine("Cop: " + input);
        }

    }
}