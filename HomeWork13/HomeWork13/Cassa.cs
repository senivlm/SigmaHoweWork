namespace HomeWork13
{
    internal class Cassa
    {
        double cordinate;
        PriorityQueue<Person, string> queuePersons;

        public Cassa()
        {
            queuePersons = new();
            cordinate = 0;
        }

        public Cassa(double cordinate)
        {
            queuePersons = new();
            this.cordinate = cordinate;
        }

        public bool IsEmpty
        {
            get => queuePersons.Count == 0;
        }
        public int Count
        {
            get => queuePersons.Count;
        }
        public double Cordinate { get => cordinate; }

        public void Enqueue(Person person)
        {
            queuePersons.Enqueue(person, $"{person.Status}{person.Age}");
        }

        public Person Dequeue()
        {
            return queuePersons.Dequeue();
        }

        public Person Peek()
        {
            return queuePersons.Peek();
        }

    }
}