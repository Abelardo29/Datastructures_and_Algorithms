using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2 {
    class Program {
        static void Main(string[] args) {

            //StackThings();

            QueueThings(20);

        }

        public static void QueueThings(int arraySize) {
            Queue thisQueue = new Queue(arraySize);
            Console.WriteLine("Welcome to our queue program! Write a line to add it to the queue. Write nothing to see the contents!");

            while (true) {

                string userInput = Console.ReadLine();

                if (userInput == "" || userInput == null || userInput == " ") {

                    break;
                }
                thisQueue.Enqueue(userInput);

                Console.WriteLine("Adding " + userInput + " to queue!\n");
                thisQueue.printQueue();
                Console.WriteLine();
            }

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
                printStack.Push(current);
            }

            while (!printStack.IsEmpty()) {
                Console.WriteLine(printStack.Pop());
            }
            Console.WriteLine("Stacking Program finished.");
            Console.ReadLine();
        }
    }
}
