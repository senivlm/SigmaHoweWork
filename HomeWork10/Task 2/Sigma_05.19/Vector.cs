using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

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
        private int[] _array;
        public int Length { get => _array.Length; }
        public int this[int i]
        {
            get
            {
                if (i < 0 || i >= _array.Length)
                {
                    throw new IndexOutOfRangeException();
                }
                else
                {
                    return _array[i];
                }

            }
            set
            {
                if (i < 0 || i >= _array.Length)
                {
                    throw new IndexOutOfRangeException();
                }
                else
                {
                    _array[i] = value;
                }
            }
        }
        public Vector(int n)
        {
            _array = new int[n];
        }
        public Vector(IEnumerable<int> array)
        {
            int[] arr = array.ToArray();
            _array = new int[arr.Length];
            for (int i = 0; i < arr.Length; i++)
            {
                _array[i] = arr[i];
            }
        }
        public void InitRandom(int a, int b)
        {
            Random random = new Random();
            for (int i = 0; i < _array.Length; i++)
            {
                _array[i] = random.Next(a, b);
            }
        }
        public void InitShuffle()
        {
            int r;
            Random random = new Random();
            for (int i = 0; i < _array.Length; i++)
            {
                do
                {
                    r = random.Next(1, _array.Length + 1);
                } while (Array.Exists(_array, number => number == r));
                _array[i] = r;
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
            Pair[] pairs = new Pair[_array.Length];

            for (int i = 0; i < _array.Length; i++)
            {
                pairs[i] = new Pair(0, 0);
            }
            int countDifference = 0;
            for (int i = 0; i < _array.Length; i++)
            {
                bool isElement = false;
                for (int j = 0 /*i + 1*/; j < countDifference; j++)
                {

                    if (_array[i] == pairs[j].Number)
                    {
                        pairs[j].Freq++;
                        isElement = true;
                        break;
                    }

                }
                if (!isElement)
                {
                    pairs[countDifference].Number = _array[i];
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
            for (int i = 0; i < _array.Length / 2; i++)
            {
                if (_array[i] != _array[_array.Length - i - 1])
                {
                    isPalidrome = false;
                }
            }
            return isPalidrome;
        }
        public void MyReverse()
        {
            int num;
            for (int i = 0; i < _array.Length / 2; i++)
            {
                num = _array[i];
                _array[i] = _array[_array.Length - i - 1];
                _array[_array.Length - i - 1] = num;
            }
        }
        public Pair LongestSequence()
        {
            Pair longestSequence;
            int frequence = 1;
            int number = _array[0];
            int logestFrequence = 1;

            for (int i = 1; i < _array.Length; i++)
            {
                if (_array[i] != _array[i - 1])
                {
                    frequence = 0;
                }
                frequence++;
                if (frequence > logestFrequence)
                {
                    logestFrequence = frequence;
                    number = _array[i];
                }
            }
            longestSequence = new Pair(number, logestFrequence);
            return longestSequence;
        }
        public override string ToString()
        {
            string line = "";
            foreach (var item in _array)
            {
                line += item + " ";
            }
            return line;
        }

        private void QuickSort(int leftBorder, int rightBorder, SupportingElement supporting)
        {
            int leftPointer = leftBorder;
            int rightPointer = rightBorder;
            int supportingElement = 0;

            switch (supporting)
            {
                case SupportingElement.First:
                    supportingElement = _array[leftBorder];
                    break;
                case SupportingElement.Middle:
                    if (leftBorder >= rightBorder)
                    {
                        supportingElement = _array[(int)(rightBorder / 2)];
                    }
                    else
                    {
                        supportingElement = _array[leftBorder];
                    }
                    break;
                case SupportingElement.Last:
                    supportingElement = _array[rightBorder];
                    break;
            }
            while (leftPointer <= rightPointer)
            {
                while (_array[leftPointer] < supportingElement)
                {
                    leftPointer++;
                }
                while (_array[rightPointer] > supportingElement)
                {
                    rightPointer--;
                }
                if (leftPointer <= rightPointer)
                {
                    int temp = _array[leftPointer];
                    _array[leftPointer] = _array[rightPointer];
                    _array[rightPointer] = temp;
                    leftPointer++;
                    rightPointer--;
                }
            }
            if (leftBorder >= rightBorder)
            {
                return;
            }
            if (leftBorder < rightPointer)
            {
                QuickSort(leftBorder, rightPointer, supporting);
            }
            if (leftPointer < rightBorder)
            {
                QuickSort(leftPointer, rightBorder, supporting);
            }
        }
        public void QuickSort(SupportingElement supporting)
        {
            QuickSort(0, _array.Length - 1, supporting);
        }


        private void Merge(int leftIndex, int middleIndex, int rightIndex)
        {
            int leftPointer = leftIndex;
            int middlePointer = middleIndex;
            int[] tempArray = new int[rightIndex - leftIndex];
            int index = 0;
            while (leftPointer < middleIndex && middlePointer < rightIndex)
            {
                if (this._array[leftPointer] <= this._array[middlePointer])
                {
                    tempArray[index] = this._array[leftPointer];
                    leftPointer++;
                }
                else
                {
                    tempArray[index] = this._array[middlePointer];
                    middlePointer++;
                }
                index++;

            }
            if (leftPointer == middleIndex)
            {
                for (int i = middlePointer; i < rightIndex; i++)
                {
                    tempArray[index++] = this._array[i];
                }
            }
            else
            {
                while (leftPointer < middleIndex)
                {
                    tempArray[index++] = this._array[leftPointer++];
                }
            }
            for (int i = 0; i < tempArray.Length; i++)
            {
                _array[i + leftIndex] = tempArray[i];
            }
        }
        private void SplitMargeSort(int start, int end)
        {
            if (end - start <= 1)
            {
                return;
            }
            int middle = (start + end) / 2;
            SplitMargeSort(start, middle);
            SplitMargeSort(middle, end);
            Merge(start, middle, end);
        }
        public void SplitMargeSort()
        {
            SplitMargeSort(0, _array.Length);
        }

        public void HeapSort()
        {
            for (int i = _array.Length / 2 - 1; i >= 0; i--)
                Heapify(_array.Length, i);

            for (int i = _array.Length - 1; i >= 0; i--)
            {

                int temp = _array[0];
                _array[0] = _array[i];
                _array[i] = temp;
                Heapify(i, 0);
            }
        }
        private void Heapify(int n, int i)
        {
            int max;
            int left = 2 * i;
            int right = 2 * i + 1;

            if (left < n && _array[left] > _array[i])
            {
                max = left;
            }
            else
            {
                max = i;
            }

            if (right < n && _array[right] > _array[max])
            {
                max = right;
            }

            if (max != i)
            {
                int temp = _array[i];
                _array[i] = _array[max];
                _array[max] = temp;
                Heapify(n, max);
            }
        }

        static public void FileSplitMergeSort(string fileNameToRead, string fileNameToWrite)
        {
            StreamReader rd = new StreamReader(fileNameToRead);
            string[] stringArray = rd.ReadToEnd().Split(' ');
            int[] dataArray = new int[stringArray.Length];
            for (int i = 0; i < stringArray.Length; i++)
            {
                dataArray[i] = int.Parse(stringArray[i]);
            }

            List<int> firstPiece = new List<int>();
            List<int> secondPiece = new List<int>();

            for (int i = 0; i < dataArray.Length / 2; i++)
            {
                firstPiece.Add(dataArray[i]);
            }
            for (int i = dataArray.Length / 2; i < dataArray.Length; i++)
            {
                secondPiece.Add(dataArray[i]);
            }

            Vector firstVector = new Vector(firstPiece);
            Vector secondtVector = new Vector(secondPiece);


            firstVector.SplitMargeSort();
            secondtVector.SplitMargeSort();

            MergeWriteToFile(firstVector, secondtVector, fileNameToWrite);
        }
        static private void MergeWriteToFile(Vector firsVector, Vector secondVector, string Path)
        {
            int i = 0;
            int j = 0;
            using (StreamWriter reader = new StreamWriter(Path))
            {

                while (i < firsVector.Length && j < secondVector.Length)
                {

                    if (firsVector[i] < secondVector[j])
                    {
                        reader.Write(firsVector[i++] + " ");
                    }
                    else
                    {
                        reader.Write(secondVector[j++] + " ");
                    }

                }
                if (i == firsVector.Length)
                {
                    while (j < secondVector.Length)
                    {
                        reader.Write(secondVector[j++] + " ");
                    }
                }
                else
                {
                    while (i < firsVector.Length)
                    {
                        reader.Write(firsVector[i++] + " ");
                    }
                }
            }

        }

        public static Vector operator +(Vector a, Vector b)
        {
            if (a.Length > b.Length)
            {
                (a, b) = (b, a);
            }
            Vector toReturn = new Vector(b.Length);

            for (int i = 0; i < a.Length; i++)
            {
                toReturn[i] = a[i] + b[i];
            }
            for (int i = a.Length; i < b.Length; i++)
            {
                toReturn[i] = b[i];
            }

            //for (int i = 0; i < a.Length; i++)
            //{
            //    toReturn[i] += a[i];
            //}
            //for (int i = 0; i < b.Length; i++)
            //{
            //    toReturn[i] += b[i];
            //}


            return toReturn;
        }
        public static Vector operator +(Vector a, int b)
        {
            Vector toReturn = new Vector(a.Length);
            for (int i = 0; i < a.Length; i++)
            {
                toReturn[i] = a[i] + b;
            }
            return toReturn;
        }

        public static bool operator >(Vector a, Vector b)
        {
            return a.Length > b.Length;
        }
        public static bool operator <(Vector a, Vector b)
        {
            return b.Length > a.Length;
        }
        
        public static implicit operator int(Vector a)
        {
            return a[0];
        }
        public static implicit operator Vector(int a)
        {
            Vector toReturn = new Vector(1);
            toReturn[0] = a;
            return toReturn;
        }
        public static implicit operator Vector((int, int) a)
        {
            Vector toReturn = new Vector(a.Item1);
            for (int i = 0; i < toReturn.Length; i++)
            {
                toReturn[i] = a.Item2;
            }
            return toReturn;
        }
    }
}
