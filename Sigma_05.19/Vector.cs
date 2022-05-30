using System;

namespace Sigma_05._19
{
    public enum SupportingElement
    {
        First,
        Middle,
        Last
    }
    public class Vector
    {
        public int[] array;

        public int this[int i]
        {
            get
            {
                if (i < 0 || i >= array.Length)
                {
                    throw new IndexOutOfRangeException();
                }
                else
                {
                    return array[i];
                }

            }
            set
            {
                array[i] = value;
            }
        }
        public Vector(int n)
        {
            array = new int[n];
        }
        public void InitRandom(int a, int b)
        {
            Random random = new Random();
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = random.Next(a, b);
            }
        }
        public void InitShuffle()
        {
            int r;
            Random random = new Random();
            for (int i = 0; i < array.Length; i++)
            {
                do
                {
                    r = random.Next(1, array.Length + 1);
                } while (Array.Exists(array, number => number == r));
                array[i] = r;
            }

            //for (int i = 0; i < array.Length; i++)
            //{
            //    while (true)
            //    {
            //        r = random.Next(1, array.Length + 1);
            //        bool isexist = false;
            //        for (int j = 0; j < i; j++)
            //        {
            //            if (array[j] == r)
            //            {
            //                isexist = true;
            //                break;
            //            }
            //        }
            //        if (!isexist)
            //        {
            //            array[i] = r;
            //            break;
            //        }
            //    }
            //}
        }
        public Pair[] CalculateFreq()
        {
            Pair[] pairs = new Pair[array.Length];

            for (int i = 0; i < array.Length; i++)
            {
                pairs[i] = new Pair(0, 0);
            }
            int countDifference = 0;
            for (int i = 0; i < array.Length; i++)
            {
                bool isElement = false;
                for (int j = 0 /*i + 1*/; j < countDifference; j++)
                {

                    if (array[i] == pairs[j].Number)
                    {
                        pairs[j].Freq++;
                        isElement = true;
                        break;
                    }

                }
                if (!isElement)
                {
                    pairs[countDifference].Number = array[i];
                    pairs[countDifference].Freq++;
                    countDifference++;

                }
            }

            Pair[] result = new Pair[countDifference];
            for (int i = 0; i < countDifference; i++)
            {
                result[i] = new Pair(pairs[i].Number, pairs[i].Freq);
                //result[i].Number = pairs[i].Number;
                //result[i].Freq = pairs[i].Freq;
            }
            return result;

        }
        public bool IsPalidrome()
        {
            bool isPalidrome = true;
            for (int i = 0; i < array.Length / 2; i++)
            {
                if (array[i] != array[array.Length - i - 1])
                {
                    isPalidrome = false;
                    // І треба перервати цикл, а не продовжувати його.
                }
            }
            return isPalidrome;
        }
        public void MyReverse()
        {
            int num;
            for (int i = 0; i < array.Length / 2; i++)
            {// можна обмін через кортеджі
                num = array[i];
                array[i] = array[array.Length - i - 1];
                array[array.Length - i - 1] = num;
            }
        }
        public Pair LongestSequence()
        {
            Pair longestSequence;
            int frequence = 1;
            int number = array[0];
            int logestFrequence = 1;

            for (int i = 1; i < array.Length; i++)
            {
                if (array[i] != array[i - 1])
                {
                    frequence = 0;
                }
                frequence++;
                if (frequence > logestFrequence)
                {
                    logestFrequence = frequence;
                    number = array[i];
                }
            }
            longestSequence = new Pair(number, logestFrequence);
            return longestSequence;
        }
        public override string ToString()
        {
            string line = "";
            foreach (var item in array)
            {
                line += item + " ";
            }
            return line;
        }
        public void QuickSort(SupportingElement supporting)
        {
            QuickSort(0, array.Length - 1, supporting);
        }
        private void QuickSort(int leftBorder, int rightBorder, SupportingElement supporting)
        {
            int leftPointer = leftBorder;
            int rightPointer = rightBorder;
            int supportingElement = 0;

            switch (supporting)
            {
                case SupportingElement.First:
                    supportingElement = array[leftBorder];
                    break;
                case SupportingElement.Middle:
                    if (leftBorder >= rightBorder)
                    {// Ділення у цьому випадку дає цілочисельний результат, тому приведення зайве.
                        supportingElement = array[(int)(rightBorder / 2)];
                    }
                    else
                    {
                        supportingElement = array[leftBorder];
                    }

                    break;
                case SupportingElement.Last:
                    supportingElement = array[rightBorder];
                    break;
            }

            while (leftPointer <= rightPointer)
            {
                while (array[leftPointer] < supportingElement)
                {
                    leftPointer++;
                }
                while (array[rightPointer] > supportingElement)
                {
                    rightPointer--;
                }
                if (leftPointer <= rightPointer)
                {
                    int temp = array[leftPointer];
                    array[leftPointer] = array[rightPointer];
                    array[rightPointer] = temp;
                    leftPointer++;
                    rightPointer--;
                }
            }
            if (leftBorder>=rightBorder)
            {
                return;
            }
            if (leftBorder < rightPointer)
            {
                QuickSort(leftBorder, rightPointer, supporting);
            }
            // Навіщо двічі?
            if (leftPointer < rightBorder)
            {
                QuickSort(leftPointer, rightBorder, supporting);
            }
        }
    }
}
