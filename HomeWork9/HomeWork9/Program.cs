using System;

namespace HomeWork9
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Menu menu = Reader.ReadMenu("Menu.txt");
                Console.WriteLine("Which currancy?\n" +
                    "UAH\\EUR\\USD");
                var choise = Console.ReadLine();
                Currency.SetCourse("Course.txt");
                double course = 0;
                switch (choise)
                {
                    case "UAH":
                        course = Currency.UAH;
                        break;
                    case "EUR":
                        course = Currency.EUR;
                        break;
                    case "USD":
                        course = Currency.USD;
                        break;
                    default:
                        Console.WriteLine("Wrong data!!\n" +
                            "Result in UAH");
                        break;
                }
                Writer.WriteResult("result.txt", menu, course);
            }
            catch (Exception)
            {
                Console.WriteLine("Something went wrong");
            }
        }
    }
}
