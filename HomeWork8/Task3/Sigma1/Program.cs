using System;
using System.Collections.Generic;

namespace Sigma1
{
    public class Program
    {
        static void Main(string[] args)
        {
            #region Old Task
            //Storage storage = new Storage();
            //AdminRoot.Dialogue(ref storage); 
            #endregion
            Product p1 = new Product("Q", 1, 1);
            Product p2 = new Product("W", 1, 1);
            Product p3 = new Product("E", 1, 1);
            Product p4 = new Product("R", 1, 1);
            Product p5 = new Product("T", 1, 1);
            Product p6 = new Product("Y", 1, 1);
            Product p7 = new Product("U", 1, 1);
            Storage storage1 = new Storage(p1, p2, p3, p4);
            Storage storage2 = new Storage(p4, p5, p6, p7);
            StorageComparer.ProductInFirst(storage1, storage2);
            StorageComparer.ProductInBoth(storage1, storage2);
        }
    }
}