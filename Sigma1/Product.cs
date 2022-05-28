using System;

namespace Sigma1
{
    public class Product
    {
        private int price;
        private double weight;
        private string name;
        public int Price
        {
            get
            {
                return price;
            }
            set
            {
                if (price < 0)
                    throw new ArgumentException();
                price = value;
            }
        }

        public string Name
        {
            get => name;
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException();
                }
                name = value;
            }
        }
        public double Weight
        {
            get => weight;
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentNullException();
                }
                weight = value;
            }
        }

        public Product() : this(default, default, default)
        {

        }

        public Product(string name, int price, double weight)
        {
            if (price < 0 || weight < 0)
                throw new ArgumentException();
            Name = name;
            Price = price;
            Weight = weight;
        }

        public virtual void ChangePrice(int percentage)
        {
            if (percentage == 0) return;
            Price = (int)(Price * (percentage / 100d));
        }


        public void Parse(string str)
        {
            if (str == null)
            {
                throw new ArgumentNullException();
            }
            string[] arrayString = str.Split(' ');
            this.Name = arrayString[0];
            this.Price = Convert.ToInt32(arrayString[1]);
            this.Weight = Convert.ToDouble(arrayString[2]);

        }
        public override string ToString()
        {
            return string.Format("Name: {0}, Price: {1}, Weight: {2}", name, price, weight);
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
            return this.Price == ((Product)product).Price && this.Name == ((Product)product).Name && this.Weight == ((Product)product).Weight;
        }
        public override int GetHashCode()
        {
            return Price.GetHashCode() ^ Name.GetHashCode() ^ Weight.GetHashCode();
        }
    }
}