using System;

namespace SigmaMarket
{
    public class Product : Goods
    {
        public Product() : this(default, default, default)
        {

        }
        public Product(string name, double price, double weight)
        {
            Name = name;
            Price = price;
            Weight = weight;
        }
        public override void ChangePrice(int percentage)
        {
            if (percentage <= -100 || percentage == 0)
            {
                return;
            }
            Price += Price * percentage / 100;
        }
        public static Product Parse(string str)
        {
            if (str == null)
            {
                throw new ArgumentNullException();
            }
            string[] arrayString = str.Split(' ');
            try
            {
                return new(arrayString[0], Convert.ToDouble(arrayString[1]), Convert.ToDouble(arrayString[2]));
            }
            catch (Exception)
            {
                throw;
            }

        }
        public override string ToString()
        {
            return $"{Name} -- {Price} -- {Weight}";
        }
        public override bool Equals(object product)
        {
            if (product == null)
            {
                return false;
            }
            else if (!(product is Product))
            {
                return false;
            }
            return this.Name == (product as Product).Name && this.Price == (product as Product).Price && this.Weight == (product as Product).Weight;
        }
        public override int GetHashCode()
        {
            return Price.GetHashCode() ^ Name.GetHashCode() ^ Weight.GetHashCode();
        }
        public static bool operator ==(Product product1, Product product2)
        {
            return product1.Equals(product2);
        }
        public static bool operator !=(Product product1, Product product2)
        {
            return !product1.Equals(product2);
        }
    }
}
