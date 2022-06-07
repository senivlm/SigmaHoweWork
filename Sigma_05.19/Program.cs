using System;

namespace Sigma_05._19
{
    class Program
    {//Ваш номер 9
        static void Main(string[] args)
        {
            Vector vector = new Vector(15);
            vector.InitRandom(1, 10);
            Console.WriteLine(vector);
            vector.QuickSort(SupportingElement.Middle);
            Console.WriteLine(vector);

            //Vector vector = new Vector(100000);
            //vector.InitRandom(1, 20);
            //var now = DateTime.Now;
            //vector.QuickSort(SupportingElement.First);
            //Console.WriteLine($"First:{DateTime.Now - now}");


            //Vector vector1 = new Vector(100000);
            //vector1.InitRandom(1, 20);
            //now = DateTime.Now;
            //vector.QuickSort(SupportingElement.Middle);
            //Console.WriteLine($"\nMid:{DateTime.Now - now}");


            //Vector vector2 = new Vector(100000);
            //vector1.InitRandom(1, 20);
            //now = DateTime.Now;
            //vector.QuickSort(SupportingElement.Last);
            //Console.WriteLine($"\nLast:{DateTime.Now - now}");

        }
    }
}
