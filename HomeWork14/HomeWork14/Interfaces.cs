namespace HomeWork14
{
    #region Interfaces
    internal interface IProduct
    {
        string Name { get; set; }
        double Price { get; set; }
    }
    internal interface IExpirableProduct
    {
        DateTime timeToExpire { get; set; }
        bool isExpired { get; }
    }
    internal interface IMeatProduct
    {
        MeatCategory meatCategory { get; set; }
        MeatSpecies meatSpecies { get; set; }
    }
    internal interface IPhisicalProduct
    {
        double Weight { get; set; }
    }
    internal interface IAbstractFactory
    {
        IProduct CreateProduct();
    }
    #endregion
}