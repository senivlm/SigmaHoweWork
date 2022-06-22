using System.Collections.Generic;

namespace HomeWork9
{
    public class Dish
    {
        private Dictionary<string, double> _ingredients;
        public int Length => _ingredients.Count;
        public double this[string key]
        {
            get
            {
                try
                {
                    return _ingredients[key];
                }
                catch (KeyNotFoundException)
                {
                    throw;
                }
            }
        }
        public IEnumerable<string> Keys => _ingredients.Keys;
        public Dish()
        {
            _ingredients = new Dictionary<string, double>();
        }
        public Dish(Dictionary<string, double> ingrs) : this()
        {
            _ingredients = ingrs;
        }

    }
}
