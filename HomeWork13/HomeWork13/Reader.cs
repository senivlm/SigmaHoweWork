namespace HomeWork13
{
    internal static class Reader
    {
        static public List<Person> ReadPersons(string path)
        {
            if (!File.Exists(path))
            {
                Console.WriteLine("No such file!!!");
                return new List<Person>();
            }
            List<Person> res = new List<Person>();
            using (StreamReader reader = new(path))
            {
                while (!reader.EndOfStream)
                {
                    res.Add(Person.Parse(reader.ReadLine()));
                }
            }
            return res;
        }
    }
}