using System;
using System.IO;

namespace SigmaMarket
{
    public static class Reader
    {
        public static bool TryReadFileName(out string fileName)
        {
            Console.WriteLine("Enter file name:");
            fileName = Console.ReadLine();
            int count = 0;
            while (!File.Exists(fileName))
            {
                if (count == 3)
                {
                    Console.WriteLine("Try again later!");
                    return false;
                }
                count++;
                Console.WriteLine($"File {fileName} doesn't exist!\nEnter again:");
                fileName = Console.ReadLine();
            }
            return true;
        }
    }
}
