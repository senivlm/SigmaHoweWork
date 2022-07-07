namespace HomeWork13
{
    internal static class Writer
    {
        static public void WritePersons(List<Person> persons, string path)
        {
            using (StreamWriter writer = new(path))
            {
                foreach (var item in persons)
                {
                    writer.WriteLine(item.ToString());
                }
            }
        }
    }
}