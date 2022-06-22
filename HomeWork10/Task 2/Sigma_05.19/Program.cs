using System;

namespace Sigma_05._19
{
    class Program
    {
        static void Main(string[] args)
        {
            Matrix matrix = new Matrix(3);
            matrix.DiagonalSnake(Direction.Down);
            matrix.WriteMatrix();
            Console.WriteLine("-----------------------------");
            foreach (var item in matrix)
            {
                Console.WriteLine(item);
            }
            matrix.GenerateDefolt();
            Console.WriteLine("-----------------------------");
            matrix.WriteMatrix();
            Console.WriteLine("-----------------------------");
            foreach (var item in matrix)
            {
                Console.WriteLine(item);
            }
        }
    }
}
