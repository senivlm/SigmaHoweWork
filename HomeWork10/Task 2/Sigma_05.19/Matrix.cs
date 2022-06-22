using System;
using System.Collections;
using System.IO;

namespace Sigma_05._19
{
    enum Direction
    {
        Up,
        Down
    }
    class Matrix : IEnumerable
    {
        private int[,] _matrix;
        private int size;
        public Matrix(int size)
        {
            this.size = size;
            _matrix = new int[size, size];
        }
        public void GenerateDefolt()
        {
            _matrix = new int[size, size];
            int k = 0;
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    _matrix[i, j] = ++k;
                }
            }
        }
        public void DiagonalSnake(Direction direction)
        {
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

            for (int k = 0; k < size * size;)
            {
                if (isUp)
                {
                    for (; i >= 0 && j < size; j++, i--)
                    {
                        _matrix[i, j] = number++;
                        k++;
                    }

                    if (i < 0 && j <= size - 1)
                    {
                        i = 0;
                    }
                    if (j == size)
                    {
                        i += 2;
                        j--;
                    }
                }
                else
                {
                    for (; j >= 0 && i < size; i++, j--)
                    {
                        _matrix[i, j] = number++;
                        k++;
                    }

                    if (j < 0 && i <= size - 1)
                    {
                        j = 0;
                    }
                    if (i == size)
                    {
                        j += 2;
                        i--;
                    }
                }
                isUp = !isUp;
            }
        }
        public void WriteMatrix()
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

        //public IEnumerator GetEnumerator()
        //{
        //    for (int i = 0; i < size; i++)
        //    {
        //        for (int j = 0; j < size; j++)
        //        {
        //            yield return _matrix[i, j];
        //        }
        //    }
        //}
        public IEnumerator GetEnumerator()
        {
            int i = 0;
            int j = 0;
            bool isUp = default;

            for (int k = 0; k < size * size;)
            {
                if (isUp)
                {
                    for (; i >= 0 && j < size; j++, i--)
                    {
                        yield return _matrix[i, j];
                        k++;
                    }

                    if (i < 0 && j <= size - 1)
                    {
                        i = 0;
                    }
                    if (j == size)
                    {
                        i += 2;
                        j--;
                    }
                }
                else
                {
                    for (; j >= 0 && i < size; i++, j--)
                    {
                        yield return _matrix[i, j];
                        k++;
                    }

                    if (j < 0 && i <= size - 1)
                    {
                        j = 0;
                    }
                    if (i == size)
                    {
                        j += 2;
                        i--;
                    }
                }
                isUp = !isUp;
            }
        }
    }
}