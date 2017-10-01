namespace Assignment2 {
    class CustomStack {
        public int top = -1, maxSize;
        protected string[] stackName;

        public CustomStack(int maxSize) {
            this.maxSize = maxSize;
            stackName = new string[maxSize];            
        }

        public void Push (string content) {
            if (!IsFull()) {
                top++;
                stackName[top] = content;                
            }
        }

        public void PushMultiple (string sentense) {
            if (!IsFull()) {
                
                string[] splitup = sentense.Split(' ');
                top++;
                stackName[top] = splitup[0];

                //neem de rest van de zin mee en run de method opnieuw.
                string rest = " ";
                for (int i = 1; i < splitup.Length; i++)
                    rest = rest + " " + splitup[i];
                PushMultiple(rest);
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
