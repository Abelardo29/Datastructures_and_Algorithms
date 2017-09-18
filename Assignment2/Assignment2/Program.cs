using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2 {
    class Program {
        static void Main(string[] args) {
            List<string> listings = new List<string>();
            bool running = true;

            Console.WriteLine("Welcome to our stacking program! Write a line to add it to the card stackers. Write nothing to see the contents!");
            //while (true) { var input = Console.ReadLine(); if (input == null || input == "") break; listings.Add(input); }

            while (running) {

                string userInput = Console.ReadLine();

                if (userInput == "" || userInput == " ") {

                    CustomStack printStack = new CustomStack(listings.Count);
                    foreach (string current in listings) {
                        printStack.Push(current);
                    }
                    while (!printStack.IsEmpty()) {
                        printStack.Pop();
                    }

                    running = false;
                } else {

                    listings.Add(userInput);
                }
            }

            Console.ReadLine();
        }
    }
}
