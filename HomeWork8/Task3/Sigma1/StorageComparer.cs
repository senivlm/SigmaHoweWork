using System;
using System.Collections.Generic;

namespace Sigma1
{
    public static class StorageComparer
    {
        public static void ProductInFirst(Storage first, Storage second)
        {
            HashSet<Product> products = new HashSet<Product>(first.productsInStock);
            products.ExceptWith(second.productsInStock);
            if (products.Count > 0)
            {
                Console.WriteLine("Only in first storage:");
                Check.PrintProducts(products);
            }
        }
        public static void ProductInBoth(Storage first, Storage second)
        {
            HashSet<Product> products = new HashSet<Product>(first.productsInStock);
            products.UnionWith(second.productsInStock);
            if (products.Count > 0)
            {
                Console.WriteLine("In both storages:");
                Check.PrintProducts(products);
            }
        }
    }
}