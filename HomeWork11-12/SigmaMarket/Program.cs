using System;
using System.Collections.Generic;

namespace SigmaMarket
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {// Потрібно ще подію адаптувати до нашого сервісу зчитування з файлу. А це складніша проблема. Ви зараз її обійшли. А треба таки спробувати зробити це.
                List<Goods> products = new() { new Product("p1", 2, 1), new Product("p2", 1, 1), new Meat("m3", 3, 3, 1, MeatCategory.Sort1, MeatSpecies.Mutton) };
                Storage<Goods> storage = new Storage<Goods>(products);
                AdminRoot.Dialogue(ref storage);
            }
            catch (Exception)
            {
                Console.WriteLine("Some unexpected exeption!!");
            }
        }
        //m4 1 1 1 Sort1 Pork
    }
}
