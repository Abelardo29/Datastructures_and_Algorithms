using System;
namespace Assignment2 {
    class Queue {

        private int maxSize;
        private string[] queueArray;
        private int front = -1;
        private int rear ;
        //private int nItems;

        public Queue(int arraySize) {
        maxSize = arraySize;
        queueArray = new string[maxSize];
        }

        public int _rear
        {
            get { return this.rear - 1; }
        }

        public int _front
        {
            get { return this.front + 1; }
        }

        public void Enqueue(string param) {
            queueArray[rear++] = param;
        }
        public string Dequeue() {
            return queueArray[front++];
        }
        public string Front() {
            return queueArray[front];
        }
        public bool IsEmpty() {
            return front == rear;
        }
        public int Size() {
            return rear - front;
        }

        public void printQueue() {
            for (int i = 0; i < rear; i++) {
                if (i == front)
                    Console.WriteLine("QUEUE STARTS HERE, IF THERE'S ANYTHING BEFORE IT THEN THAT IS ALREADY DONE");
                Console.WriteLine("Spot: " + i + " With contents: " + queueArray[i]);
            }
            Console.WriteLine();
        }

        public void printRecursive(int i)
        {
            if(i == front)
            {
                Console.WriteLine("QUEUE STARTS HERE, IF THERE'S ANYTHING BEFORE IT THEN THAT IS ALREADY DONE");
            }
            else
            {
                Console.WriteLine("Spot: " + i + " With contents: " + queueArray[i]);
                printRecursive(--i);
            }
        }

        public void printRecursive2(int i , int recursionCounter = 0)
        {
            Console.WriteLine(i + " i/rc " + recursionCounter);
            if (i == rear)
            {
                Console.WriteLine("QUEUE STARTS HERE, IF THERE'S ANYTHING BEFORE IT THEN THAT IS ALREADY DONE");
            }
            else
            {
                Console.WriteLine("Spot: " + i + " With contents: " + queueArray[i]);
                printRecursive2(++i, ++recursionCounter);
            }
        }
    }
}
