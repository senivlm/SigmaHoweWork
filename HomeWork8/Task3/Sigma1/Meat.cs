using System;

namespace Sigma1
{
    public class Meat : DairyProducts
    {
        public Category MeatCategory { get; set; }
        public Species MeatSpecies { get; set; }

        public Meat(string name, int price, double weight, int date, Category meatCategory, Species meatSpecies) : base(name, price, weight, date)
        {
            MeatCategory = meatCategory;
            MeatSpecies = meatSpecies;
        }
        public Meat() : this(default, default, default, default, default, default)
        {

        }
        public override void ChangePrice(int percentage)
        {
            if (percentage == 0) return;
            switch (MeatCategory)
            {
                case Category.HighSort1:
                    percentage += 25;
                    break;
                case Category.Sort2:
                    percentage += 10;
                    break;
                default:
                    break;
            }
            if (IsExpired())
            {
                percentage = percentage > 40 ? percentage - 30 : percentage;
            }
            Price = (int)((double)Price * (percentage / 100d));
        }
        public new void Parse(string str)
        {
            if (str == null)
            {
                throw new ArgumentNullException();
            }
            try
            {
                string[] arrayString = str.Split(' ');
                Name = arrayString[0];
                Price = Convert.ToInt32(arrayString[1]);
                Weight = Convert.ToDouble(arrayString[2]);
                timeToExpire = Convert.ToInt32(arrayString[3]);
                MeatCategory = (Category)Enum.Parse(typeof(Category), arrayString[4]);
                MeatSpecies = (Species)Enum.Parse(typeof(Species), arrayString[5]);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        public override string ToString()
        {
            return base.ToString() + $",  MeatCategory: {MeatCategory},  MeatSpecies: {MeatSpecies}";
        }
        public override bool Equals(object meat)
        {
            return base.Equals(meat) && this.MeatCategory == ((Meat)meat).MeatCategory && this.MeatSpecies == ((Meat)meat).MeatSpecies;
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}