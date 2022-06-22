using System;
using System.Collections.Generic;

namespace HomeWork9
{
    public class Menu
    {
        private List<Dish> _dishes;
        public Dish this[int index]
        {
            get
            {

                try
                {
                    return _dishes[index];
                }
                catch (IndexOutOfRangeException)
                {
                    throw;
                }

            }
        }
        public int Length => _dishes.Count;
        public Menu()
        {
            _dishes = new();
        }
        public Menu(List<Dish> dishes) : this()
        {
            _dishes = dishes;
        }
    }
}
