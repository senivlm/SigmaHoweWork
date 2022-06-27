namespace SigmaMarket
{
    public interface IExpireable
    {
        public int TimeToExpire { get; set; }
        public bool IsExpired { get; }
    }
}
