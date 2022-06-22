using System;
using System.Collections.Generic;

namespace HomeWork9
{
    public class PriceKurant
    {
        private Dictionary<string, double> _ingredientPrice;
        public PriceKurant()
        {
            _ingredientPrice = new();
        }
        public PriceKurant(Dictionary<string, double> Price) : this()
        {
            _ingredientPrice = Price;
        }
        public bool TryGetPrice(string prodName, out double price)
        {
            if (!_ingredientPrice.TryGetValue(prodName, out double result))
            {
                throw new ArgumentException();
                return false;
            }
            price = result;
            return true;
        }
    }
}
