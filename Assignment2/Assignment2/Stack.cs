using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2 {
    class CustomStack {
        public int top = -1, maxSize;
        protected string[] stackName;

        public CustomStack(int maxSize) {
            this.maxSize = maxSize;
            stackName = new string[maxSize];            
        }

        public void Push(string content) {
            if (!IsFull()) {
                top++;
                stackName[top] = content;                
            }
        }

        public string Pop() {
            return stackName[top--];
        }

        public string Peek() {
            if (!IsEmpty())
                return stackName[top];
            else return "no cards left!";
        }

        public bool IsEmpty() {
            return top == -1;
        }

        public int Size() {
            return stackName.Length;
        }

        public bool IsFull() {
            return top == maxSize - 1;
        }
    }   
}
