using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Assignment2 {
    class Program {
                
        static void Main(string[] args) {

            /*Stopwatch stackStopwatch = new Stopwatch();
            Stopwatch queueStopwatch = new Stopwatch();

            List<long> stackTimes = new List<long>();
            List<long> queueTimes = new List<long>();

            int amountOfTimes = 100000000;

            Console.WriteLine("Starting stack!");

            for (int i = 0; i < amountOfTimes; i++) {
                stackStopwatch.Start();
                AutoStack(6);
                stackStopwatch.Stop();
                stackTimes.Add(stackStopwatch.ElapsedMilliseconds);
            }

            Console.WriteLine("Stack done, starting queue!");

            for (int i = 0; i < amountOfTimes; i++) {
                queueStopwatch.Start();
                AutoQueue(20, 6);
                queueStopwatch.Stop();
                queueTimes.Add(stackStopwatch.ElapsedMilliseconds);
            }

            Console.WriteLine("Queue done!");

            //En hier printen we de output!
            int counter = 0;
            long total = 0;
            Console.WriteLine("Program finished!");
            Console.WriteLine("Displaying time results from stack:");
            foreach (long current in stackTimes) {
                Console.WriteLine("StopWatch Number: " + ++counter + " With time: " + current);
                total += current;
                if (counter > 100)
                    break;
            }
            Console.WriteLine("Average time: " + (total / amountOfTimes));

            total = 0;
            counter = 0;

            Console.WriteLine("\nDisplaying time results from queue:");
            foreach (long current in queueTimes) {
                Console.WriteLine("StopWatch Number: " + ++counter + " With time: " + current);
                total += current;
                if (counter > 100)
                    break;
            }
            Console.WriteLine("Average time: " + (total / amountOfTimes));*/

            QueueThings(20);

            Console.ReadLine();
        }

        public static void AutoStack(int wordAmount) {
            List<string> listings = new List<string>();
            for (int i = 0; i < wordAmount; i++)
                listings.Add("Woord " + i);

            CustomStack printStack = new CustomStack(listings.Count);

            foreach (string current in listings) {
                printStack.Push(current);
            }
            /*while (!printStack.IsEmpty()) {
                Console.WriteLine(printStack.Pop());
            }*/
            
            
            //Console.WriteLine("Stacking Program finished.");
        }

        public static void AutoQueue(int arraySize, int wordAmount) {
            Queue thisQueue = new Queue(arraySize);

            for (int i = 0; i < wordAmount; i++)
                thisQueue.Enqueue("Woord " + i);

            //thisQueue.printQueue();
            //Console.WriteLine("Queue Program finished.");
        }

        public static void QueueThings(int arraySize) {
            Queue thisQueue = new Queue(arraySize);
            Console.WriteLine("Welcome to our queue program! Write a line to add it to the queue. Write nothing to see the contents!");

            while (true) {

                string userInput = Console.ReadLine();

                if (userInput == "" || userInput == null || userInput == " ") {

                    break;
                }
                thisQueue.ReverseQueue(userInput);

                Console.WriteLine("Adding " + userInput + " to queue!\n");                
                Console.WriteLine();
            }
            thisQueue.PrintQueue();
            //thisQueue.PrintRecursive2(thisQueue._front);
            Console.WriteLine("Queue Program finished.");
            Console.ReadLine();
        }
        
                
            
        public static void StackThings() {
        List<string> listings = new List<string>();

        Console.WriteLine("Welcome to our stacking program! Write a line to add it to the card stackers. Write nothing to see the contents!");

        while (true) {

            string userInput = Console.ReadLine();

            if (userInput == "" || userInput == null || userInput == " ") {

                break;
            }
            Console.WriteLine("Adding "+ userInput +" to stack!\n");
            listings.Add(userInput);
        }

        CustomStack printStack = new CustomStack(listings.Count);

        foreach (string current in listings) {
                if (current.Contains(" "))
                    printStack.PushMultiple(current);
                else printStack.Push(current);
        }

        while (!printStack.IsEmpty()) {
            Console.WriteLine(printStack.Pop());
        }
        Console.WriteLine("Stacking Program finished.");
        Console.ReadLine();
        }
    }
}
