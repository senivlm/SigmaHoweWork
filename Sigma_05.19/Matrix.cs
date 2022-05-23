using System;

namespace Sigma_05._19
{
    enum Direction
    {
        Up,
        Down
    }
    class Matrix
    {
        private int[,] array;
        public void DiagonalSnake(int n, Direction direction)
        {
            array = new int[n, n];
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
                        array[i, j] = number++;
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
                        array[i, j] = number++;
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

            for (i = 0; i < n; i++)
            {
                for (j = 0; j < n; j++)
                {
                    Console.Write($"{array[i, j]}   ");
                }
                Console.WriteLine();
            }
        }
    }
}