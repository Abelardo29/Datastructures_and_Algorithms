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

    }
}
