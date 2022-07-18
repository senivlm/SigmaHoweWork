namespace HomeWork14
{
    #region Factories
    internal class ConcreteProductFactory : IAbstractFactory
    {
        public IProduct CreateProduct()
        {
            return new Product();
        }
    }
    internal class ConcreteMeatFactory : IAbstractFactory
    {
        public IProduct CreateProduct()
        {
            return new Meat();
        }
    }
    #endregion
}