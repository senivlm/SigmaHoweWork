namespace HomeWork13
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                TimeCordinator time = new TimeCordinator();
                List<Cassa> cassas = new List<Cassa>() { new Cassa(0), new Cassa(2), new Cassa(5) };
                Writer.WritePersons(PersonGenerator.Generate(15), "persons.txt");
                List<string> res = time.Cordinate(cassas, "persons.txt");
                Console.WriteLine("--end--");
                foreach (var item in res)
                {
                    Console.WriteLine(item);
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Some problems!!!");
            }
        }
    }
}