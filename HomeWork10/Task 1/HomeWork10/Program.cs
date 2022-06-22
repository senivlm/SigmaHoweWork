using System;
using System.Collections.Generic;

namespace HomeWork10
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Translator translator = new("text.txt", "dict.txt");
                string str = translator.ChangeWords();
                Writer.WriteToFile("result.txt", str);
            }
            catch (Exception)
            {
                Console.WriteLine("Something went wrong!");
            }
        }
    }
}
