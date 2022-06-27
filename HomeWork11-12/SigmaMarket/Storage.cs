using System;
using System.Collections.Generic;

namespace SigmaMarket
{
    delegate void ItemExpiredDelegate(IExpireable product);
    public class Storage<T>
    {
        private List<T> productsInStock;
        private event ItemExpiredDelegate OnExpiredItem;
        public Storage()
        {
            productsInStock = new();
            OnExpiredItem = Messages.ExpiredItem;
        }
        public Storage(params T[] products) : this()
        {
            foreach (var item in products)
            {
                this.productsInStock.Add(item);
            }
        }
        public Storage(List<T> goods)
        {
            productsInStock = new(goods);
            OnExpiredItem = Messages.ExpiredItem;
        }

        public int Count { get => productsInStock.Count; }
        public T this[int i]
        {
            get
            {
                return productsInStock[i];
            }
        }

        public void AddProduct(T product)
        {
            //OnExpiredItem = Messages.ExpiredItem;
            try
            {
                if (product is IExpireable)
                {
                    if ((product as IExpireable).IsExpired)
                    {
                        OnExpiredItem((IExpireable)product);
                        return;
                    }
                }
                productsInStock.Add(product);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public void RemoveProduct(int number)
        {
            if (Count >= number)
            {
                productsInStock.RemoveAt(number - 1);
            }
        }
        public void Sort(IComparer<T> comparer)
        {
            productsInStock.Sort(comparer);
        }
    }
    public class CompareByPrice : IComparer<Goods>
    {
        public int Compare(Goods x, Goods y)
        {
            return x.Price.CompareTo(y.Price);
        }
    }
    public class CompareByName : IComparer<Goods>
    {
        public int Compare(Goods x, Goods y)
        {
            return x.Name.CompareTo(y.Name);
        }
    }
    public class CompareByWeight : IComparer<Goods>
    {
        public int Compare(Goods x, Goods y)
        {
            return x.Weight.CompareTo(y.Weight);
        }
    }
}
