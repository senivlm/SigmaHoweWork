namespace HomeWork14
{
    #region Products
    [Serializable]
    internal class Product : IProduct, IPhisicalProduct
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public double Weight { get; set; }
    }
    [Serializable]
    internal class Meat : IProduct, IPhisicalProduct, IExpirableProduct, IMeatProduct
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public double Weight { get; set; }
        public MeatCategory meatCategory { get; set; }
        public MeatSpecies meatSpecies { get; set; }
        public DateTime timeToExpire { get; set; }
        public bool isExpired { get => DateTime.Today < timeToExpire; }
    }
    #endregion
}