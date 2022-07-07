namespace HomeWork13
{
    internal class Person
    {
        public Guid Id { get; }
        string name;
        int timeServise;
        int age;
        double coordinate;
        string status;

        public int TimeServise
        {
            get => timeServise;
            set
            {
                timeServise = value;
            }
        }

        public string Status { get => status; }
        public int Age { get => age; }
        public double Coordinate { get => coordinate; }

        public Person() : this("", default, default, default, default) { }
        public Person(string status, string name, int age, double coordinate, int timeServise)
        {
            Id = Guid.NewGuid();
            this.name = name;
            this.age = age;
            this.coordinate = coordinate;
            this.status = status;
            this.timeServise = timeServise;
        }

        public static Person Parse(string str)
        {
            string[] data = str.Split(' ');
            return new Person(data[0], data[1], int.Parse(data[2]), double.Parse(data[3]), int.Parse(data[4]));
        }
        public override string ToString()
        {
            return $"{status} {name} {age} {coordinate} {timeServise}";
        }
    }
}