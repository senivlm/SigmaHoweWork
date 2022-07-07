namespace HomeWork13
{
    internal static class PersonGenerator
    {
        static public List<Person> Generate(int amountToGenerate)
        {
            Random random = new();
            List<Person> persons = new List<Person>();
            for (int i = 0; i < amountToGenerate; i++)
            {
                persons.Add(new($"Status{random.Next(1, 4)}", $"Person{random.Next(1, 30)}", random.Next(18, 60), random.Next(1, 11), random.Next(1, 6)));
            }
            return persons;
        }
    }
}