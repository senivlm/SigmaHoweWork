using System.Collections.Generic;

namespace HomeWork9
{
    internal static class MenuService
    {
        static public bool TryGetMenuSum(Menu menu, PriceKurant priceKurant, out double generalSum)
        {
            generalSum = default;
            for (int i = 0; i < menu.Length; i++)
            {
                if (TryGetDishPrice(menu[i], priceKurant, out double sumPrice))
                {
                    return false;
                }
                generalSum += sumPrice;
            }
            return true;
        }
        static public bool TryGetDishPrice(Dish dish, PriceKurant priceKurant, out double sum)
        {
            sum = 0;
            foreach (var key in dish.Keys)
            {
                if (!priceKurant.TryGetPrice(key, out double productPrice))
                {
                    return false;
                }
                sum += productPrice * dish[key];

            }
            return true;

        }
        static public List<(string, double)> GetAllIngredients(Menu menu)
        {
            List<(string, double)> ingrs = new List<(string, double)>();
            for (int i = 0; i < menu.Length; i++)
            {
                foreach (var item in menu[i].Keys)
                {
                    ingrs.Add((item, menu[i][item]));
                }
            }
            return ingrs;
        }
        static public List<string> GetAllIngredientNames(Menu menu)
        {
            HashSet<string> set = new();
            for (int i = 0; i < menu.Length; i++)
            {
                foreach (var item in menu[i].Keys)
                {
                    set.Add(item);
                }
            }
            return new List<string>(set);
        }
        static public Dictionary<string, double> GetWeight(Menu menu)
        {
            List<(string, double)> ingrs = MenuService.GetAllIngredients(menu);
            List<string> names = MenuService.GetAllIngredientNames(menu);
            Dictionary<string, double> result = new();
            foreach (var item in names)
            {
                result.Add(item, 0);
            }
            foreach (var name in names)
            {
                foreach (var namePrice in ingrs)
                {
                    if (name == namePrice.Item1)
                    {
                        result[name] += namePrice.Item2;
                    }
                }
            }
            return result;
        }
    }
}
