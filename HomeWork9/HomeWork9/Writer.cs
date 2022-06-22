using System;
using System.Collections.Generic;
using System.IO;

namespace HomeWork9
{
    public static class Writer
    {
        public static void WriteResult(string path, Menu menu, double course)
        {
            if (!File.Exists(path))
            {
                throw new FileNotFoundException("File not found");
            }
            StreamWriter writer = new(path);
            PriceKurant prices = Reader.ReadPriceKurant("Prices.txt");
            Dictionary<string, double> d = MenuService.GetWeight(menu);
            foreach (var item in d)
            {
                string line = $"{item.Key} | {item.Value}";
                double price = 0;
                try
                {
                    prices.TryGetPrice(item.Key, out price);
                }
                catch (Exception)
                {
                    Console.WriteLine($"Enter price for {item.Key}");
                    if (!double.TryParse(Console.ReadLine(), out price))
                    {
                        Console.WriteLine("Wrong data");
                        Environment.Exit(0);
                    }
                }
                line += $" | {(price * item.Value / 1000)/course}";
                writer.WriteLine(line);
            }
            writer.Close();
        }
    }
}
