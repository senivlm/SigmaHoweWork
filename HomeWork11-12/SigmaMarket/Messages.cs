using System;

namespace SigmaMarket
{
    public static class Messages
    {
        public static void ExpiredItem(IExpireable product)
        {
            Console.WriteLine("Tried to add expired or almost expired product!!\n" +
                $"Product \"{product}\" was not added!");
        }
    }
}
