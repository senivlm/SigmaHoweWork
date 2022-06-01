using System;
using System.IO;

namespace Sigma_05._19
{
    enum Direction
    {
        Up,
        Down
    }
    class Matrix
    {
        private int[,] _matrix;
        public void DiagonalSnake(int n, Direction direction)
        {
            _matrix = new int[n, n];
            int i = 0;
            int j = 0;
            int number = 1;
            bool isUp = default;

            switch (direction)
            {
                case Direction.Up:
                    isUp = true;
                    break;

                case Direction.Down:
                    isUp = false;
                    break;

                default:
                    break;
            }

            for (int k = 0; k < n * n;)
            {
                if (isUp)
                {
                    for (; i >= 0 && j < n; j++, i--)
                    {
                        _matrix[i, j] = number++;
                        k++;
                    }

                    if (i < 0 && j <= n - 1)
                    {
                        i = 0;
                    }
                    if (j == n)
                    {
                        i += 2;
                        j--;
                    }
                }
                else
                {
                    for (; j >= 0 && i < n; i++, j--)
                    {
                        _matrix[i, j] = number++;
                        k++;
                    }

                    if (j < 0 && i <= n - 1)
                    {
                        j = 0;
                    }
                    if (i == n)
                    {
                        j += 2;
                        i--;
                    }
                }
                isUp = !isUp;
            }
        }
        public void WriteMatrix(int size)
        {

            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    Console.Write($"{_matrix[i, j]}   ");
                }
                Console.WriteLine();
            }
        }
        public void ReadMatrixFromFile(StreamReader reader)
        {
            string line = reader.ReadLine();
            string[] sizes = line.Split(' ');

            int rows = int.Parse(sizes[0]);
            int columns = int.Parse(sizes[1]);

            _matrix = new int[rows, columns];
            for (int i = 0; i < rows; i++)
            {
                string[] items = reader.ReadLine().Split(' ');
                for (int j = 0; j < columns; j++)
                {
                    _matrix[i, j] = int.Parse(items[j]);
                }
            }
        }
    }
}