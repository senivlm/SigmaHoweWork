using System;

namespace SigmaMarket
{
    public abstract class Goods
    {
        private double _price;
        private double _weight;
        private string _name;

        public double Price
        {
            get
            {
                return _price;
            }
            set
            {
                if (value < 0)
                    throw new ArgumentException();
                _price = value;
            }
        }
        public string Name
        {
            get => _name;
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException();
                }
                if (Char.IsLower(value[0]))
                {
                    value = value.Replace(value[0], Char.ToUpper(value[0]));
                }
                _name = value;
            }
        }
        public double Weight
        {
            get => _weight;
            set
            {
                if (value < 0)
                {
                    throw new ArgumentNullException();
                }
                _weight = value;
            }
        }

        public abstract void ChangePrice(int percentage);
    }
}
