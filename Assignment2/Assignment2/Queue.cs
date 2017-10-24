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

        public void ReverseQueue (string param) {
            for (int i = rear++ - 1; i >= 0; i--) 
                queueArray[i + 1] = queueArray[i];

            queueArray[front + 1] = param;
            
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

        public void PrintQueue() {
            for (int i = 0; i < rear; i++) {
                if (i == front)
                    Console.WriteLine("QUEUE STARTS HERE, IF THERE'S ANYTHING BEFORE IT THEN THAT IS ALREADY DONE");
                Console.WriteLine("Spot: " + i + " With contents: " + queueArray[i]);
            }
            Console.WriteLine();
        }

        public void PrintRecursive(int i)
        {
            if(i == front)
            {
                Console.WriteLine("QUEUE STARTS HERE, IF THERE'S ANYTHING BEFORE IT THEN THAT IS ALREADY DONE");
            }
            else
            {
                Console.WriteLine("Spot: " + i + " With contents: " + queueArray[i]);
                PrintRecursive(--i);
            }
        }

        public void PrintRecursive2(int i , int recursionCounter = 0)
        {
            Console.WriteLine(i + " i/rc " + recursionCounter);
            if (i == rear)
            {
                Console.WriteLine("QUEUE STARTS HERE, IF THERE'S ANYTHING BEFORE IT THEN THAT IS ALREADY DONE");
            }
            else
            {
                Console.WriteLine("Spot: " + i + " With contents: " + queueArray[i]);
                PrintRecursive2(++i, ++recursionCounter);
            }
        }
    }
}
