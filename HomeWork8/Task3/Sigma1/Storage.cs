using System;
using System.Collections.Generic;
using System.IO;

namespace Sigma1
{
    public class Storage
    {
        public List<Product> productsInStock { get; private set; } = new List<Product>();
        public Storage(params Product[] products)
        {
            foreach (var item in products)
            {
                this.productsInStock.Add(item);
            }
        }
        public Product this[int i]
        {
            get
            {
                return productsInStock[i];
            }
        }
        public void AddProduct(Product product)
        {
            try
            {
                productsInStock.Add(product);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        public void RemoveProduct(int index)
        {
            try
            {
                productsInStock.RemoveAt(index - 1);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

    }
}