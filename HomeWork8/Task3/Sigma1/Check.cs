using System;
using System.Collections.Generic;

namespace Sigma1
{
    public static class Check
    {
        public static void ShowInfo(Buy buy)
        {
            for (int i = 0; i < buy.ProductsAmount; i++)
            {
                Console.WriteLine("{0} grn, {1} kg, {2} name", buy.AllProducts[i].Price,
                    buy.AllProducts[i].Weight, buy.AllProducts[i].Name);
            }
            Console.WriteLine("Total price: {0}", buy.TotalPrice);
        }
        public static string Info(Buy buy)
        {
            string str = "";
            for (int i = 0; i < buy.ProductsAmount; i++)
            {
                str += $"Price: {buy.AllProducts[i].Price}, Weight: {buy.AllProducts[i].Weight}, Name: {buy.AllProducts[i].Name}\n";
            }
            str += $"Total Price: {buy.TotalPrice}";
            return str;
        }
        public static void PrintProducts(HashSet<Product> products)
        {
            foreach (var item in products)
            {
                Console.WriteLine(item);
            }
        }
    }

    //public class NewCheck : IPrint
    //{
    //    public void Print()
    //    {
    //        Console.WriteLine("Check");
    //    }

    //    public void VeiwerBuy(Buy buy)
    //    {
    //        Console.WriteLine(buy);
    //    }
    //}
}