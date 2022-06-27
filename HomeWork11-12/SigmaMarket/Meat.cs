using System;

namespace SigmaMarket
{
    public class Meat : Product, IExpireable
    {

        private int _timeToExpire;
        public Meat() : this(default, default, default, default, default, default)
        {

        }
        public Meat(string name, double price, double weight, int timeToExpire, MeatCategory meatCategory, MeatSpecies meatSpecies) : base(name, price, weight)
        {
            TimeToExpire = timeToExpire;
            Category = meatCategory;
            Species = meatSpecies;
        }
        public MeatCategory Category { get; private set; }
        public MeatSpecies Species { get; private set; }
        public static new Meat Parse(string str)
        {
            if (str == null)
            {
                throw new ArgumentNullException();
            }
            try
            {
                string[] arrayString = str.Split(' ');
                string Name = arrayString[0];
                double Price = Convert.ToDouble(arrayString[1]);
                double Weight = Convert.ToDouble(arrayString[2]);
                int TimeToExpire = Convert.ToInt32(arrayString[3]);
                MeatCategory Category = (MeatCategory)Enum.Parse(typeof(MeatCategory), arrayString[4]);
                MeatSpecies Species = (MeatSpecies)Enum.Parse(typeof(MeatSpecies), arrayString[5]);

                return new Meat(Name, Price, Weight, TimeToExpire, Category, Species);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public override string ToString()
        {
            return base.ToString() + $" -- {Category} -- {Species} -- {TimeToExpire}";
        }
        public override bool Equals(object meat)
        {
            return base.Equals(meat) && this.TimeToExpire == (meat as Meat).TimeToExpire && this.Category == (meat as Meat).Category && this.Species == (meat as Meat).Species;
        }
        public override int GetHashCode()
        {
            return base.GetHashCode() ^ TimeToExpire.GetHashCode();
        }
        public static bool operator ==(Meat meat1, Meat meat2)
        {
            return meat1.Equals(meat2);
        }
        public static bool operator !=(Meat meat1, Meat meat2)
        {
            return !meat1.Equals(meat2);
        }
        public int TimeToExpire
        {
            get => _timeToExpire;
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException();
                }
                _timeToExpire = value;
            }
        }
        public bool IsExpired => TimeToExpire < 5;
    }
}
