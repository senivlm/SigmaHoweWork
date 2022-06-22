using System;
using System.Collections.Generic;

namespace Sigma1
{
    public class Buy
    {
        private int _productsAmount;
        private int _totalPrice;
        private double _totalWeight;

        public int ProductsAmount { get => _productsAmount; private set => _productsAmount = value; }
        public int TotalPrice { get => _totalPrice; private set => _totalPrice = value; }
        public double TotalWeight { get => _totalWeight; private set => _totalWeight = value; }
        public List<Product> AllProducts { get; private set; }
        public Buy(params Product[] products)
        {
            ProductsAmount = products.Length;
            AllProducts = new List<Product>();
            foreach (var product in products)
            {
                TotalPrice += product.Price;
                TotalWeight += product.Weight;
                AllProducts.Add(product);
            }
        }
        public Buy() : this(null)
        {
            ProductsAmount = 0;
            AllProducts = new List<Product>(null);
            TotalPrice = 0;
            TotalWeight = 0;
        }
        public void AddProduct(Product product)
        {
            if (product != null)
            {
                AllProducts.Add(product);
                TotalPrice += product.Price;
                TotalWeight += product.Weight;
                ProductsAmount += 1;
            }
        }
        public override string ToString()
        {
            return Check.Info(this);
        }
        public override bool Equals(object buy)
        {
            if (buy == null)
            {
                return false;
            }
            else if (!(buy is Product))
            {
                return false;
            }
            for (int i = 0; i < this.AllProducts.Count; i++)
            {
                try
                {
                    if (this.AllProducts[i] != ((Buy)buy).AllProducts[i])
                    {
                        return false;
                    }
                }
                catch (IndexOutOfRangeException)
                {
                    return false;
                }
            }
            return true;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}