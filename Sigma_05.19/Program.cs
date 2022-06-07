using System;

namespace Sigma_05._19
{
    class Program
    {
        static void Main(string[] args)
        {// якщо статичний, то вже краще в іншому класі-сервісі
            Vector.FileSplitMergeSort("file1.txt", "file2.txt");
        }
    }
}
