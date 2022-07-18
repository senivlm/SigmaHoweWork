namespace HomeWork14
{
    #region Storage (Singleton)
    [Serializable]
    internal class Storage
    {
        private Storage()
        {
            productsInStock = new List<IProduct>();
        }

        private static Storage _instance;
        internal static Storage GetInstance()
        {
            if (_instance == null)
            {
                _instance = new Storage();
            }
            return _instance;
        }


        private List<IProduct> productsInStock;

        internal int Count { get => productsInStock.Count; }

        internal IProduct this[int i]
        {
            get
            {
                return productsInStock[i];
            }
        }

        internal bool Contains(IProduct product)
        {
            return productsInStock.Contains(product);
        }
        internal void AddProduct(IProduct product)
        {

            try
            {
                if (product is IExpirableProduct && (product as IExpirableProduct).isExpired)
                {
                    return;
                }
                productsInStock.Add(product);
            }
            catch (Exception)
            {
                throw;
            }
        }
        internal void RemoveProduct(int number)
        {
            if (Count >= number)
            {
                productsInStock.RemoveAt(number - 1);
            }
        }
    }
    #endregion
}