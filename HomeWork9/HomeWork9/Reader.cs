using System.Collections.Generic;
using System.IO;

namespace HomeWork9
{
    public static class Reader
    {
        static public Menu ReadMenu(string path)
        {
            if (!File.Exists(path))
            {
                throw new FileNotFoundException("No such file");
            }
            List<Dish> dishes = new List<Dish>();
            using (StreamReader reader = new StreamReader(path))
            {
                string line;
                while (!reader.EndOfStream)
                {
                    line = reader.ReadLine();
                    Dictionary<string, double> ingrs = new();
                    while (true)
                    {
                        line = reader.ReadLine();
                        if (line == null || line == "")
                        {
                            break;
                        }
                        ingrs.Add(line.Split(' ')[0], double.Parse(line.Split(' ')[1]));
                    }
                    Dish d = new(ingrs);
                    dishes.Add(d);
                }
            }
            Menu menu = new(dishes);
            return menu;
        }
        static public PriceKurant ReadPriceKurant(string path)
        {
            if (!File.Exists(path))
            {
                throw new FileNotFoundException("File not found");
            }
            Dictionary<string, double> prices = new Dictionary<string, double>();
            using (StreamReader reader = new StreamReader(path))
            {
                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();
                    if (line == "" || line == null)
                    {
                        continue;
                    }
                    prices.Add(line.Split(' ')[0], double.Parse(line.Split(' ')[1]));
                }
            }
            return new PriceKurant(prices);
        }
    }
}
