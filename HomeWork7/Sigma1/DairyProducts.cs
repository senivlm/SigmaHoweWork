using System;

namespace Sigma1
{
    public class DairyProducts : Product
    {
        public int timeToExpire { get; set; }

        public DairyProducts(string name, int price, double weight, int date) : base(name, price, weight)
        {
            if (date == 0)
                throw new ArgumentNullException();
            timeToExpire = date;
        }
        public override void ChangePrice(int percentage)
        {
            if (percentage == 0) return;
            if (IsExpired())
            {
                percentage = percentage > 40 ? percentage - 30 : percentage;
            }
            Price = (int)((double)Price * (percentage / 100d));
        }
        public bool IsExpired()
        {
            return 0 >= timeToExpire;
        }

        public override string ToString()
        {
            return base.ToString() + $",  Time to expire: {timeToExpire}";
        }
        public override bool Equals(object dairyProduct)
        {
            return base.Equals(dairyProduct) && this.timeToExpire == ((DairyProducts)dairyProduct).timeToExpire;
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}