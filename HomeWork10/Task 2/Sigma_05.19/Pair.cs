namespace Sigma_05._19
{
    public class Pair
    {
        private int number;
        private int freq;

        public Pair(int number, int freq)
        {
            this.Number = number;
            this.Freq = freq;
        }
        public int Number { get => number; set => number = value; }
        public int Freq { get => freq; set => freq = value; }
        public override string ToString()
        {
            return $"Number:{Number} - Frequency:{Freq}";
        }
        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }
            else if (!(obj is Pair))
            {
                return false;
            }
            return this.Number == ((Pair)obj).Number && this.Freq == ((Pair)obj).Freq;
        }
        static public bool operator ==(Pair pair1, Pair pair2)
        {
            return pair1.Equals(pair2);
        }
        static public bool operator !=(Pair pair1, Pair pair2)
        {
            return !pair1.Equals(pair2);
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
