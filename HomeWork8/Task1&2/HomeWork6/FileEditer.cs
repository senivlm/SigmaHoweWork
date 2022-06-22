using System;
using System.IO;

namespace HomeWork6
{
    public class FileEditer //Task 7.2
    {
        private string _path;
        private string[] text;
        public string Path
        {
            get
            {
                return _path;
            }

            private set
            {
                if (value != null)
                {
                    _path = value;
                }
                else
                {
                    throw new ArgumentNullException();
                }
            }
        }
        public FileEditer(string FileNameToRead)
        {
            _path = FileNameToRead;
        }
        public void ChangePath(string path)
        {
            Path = path;
        }
        public void GetSentences()
        {
            StreamReader streamReader = new StreamReader(Path);
            text = DeleteSpaces(streamReader.ReadToEnd().Trim(' ')).Split('.', '!', '?');
            if (text[text.Length - 1] == "")
            {
                Array.Resize(ref text, text.Length - 1);
            }
            for (int i = 0; i < text.Length; i++)
            {
                text[i] = text[i].Trim();
            }
        }
        private string DeleteSpaces(string str)
        {
            while (str.Contains("\n"))
            {
                str = str.Replace("\n", "").Replace("\r", ""); ;
            }

            while (str.Contains("  "))
            {
                str = str.Replace("  ", " ");
            }
            return str;
        }
        private string FindLongestShortestWord(string sentence)
        {
            if (sentence == null)
            {
                return "";
            }
            string longestWord = "";
            string shortestWord = sentence.Split(' ')[0];
            int longestCounter = 0;
            int shortestCounter = sentence.Split(' ')[0].Length;
            foreach (String s in sentence.Split(' '))
            {
                if (s.Length > longestCounter)
                {
                    longestWord = s;
                    longestCounter = s.Length;
                }
                if (s.Length < shortestCounter)
                {
                    shortestWord = s;
                    shortestCounter = s.Length;
                }
            }
            return $"\tLogest word: {longestWord}\tShortest word: {shortestWord}";
        }
        public void ChangeWord(string newWord, int sentence, int wordPosition)
        {
            string[] arr = text[sentence - 1].Split(' ');
            arr[wordPosition - 1] = newWord;
            text[sentence - 1] = String.Join(" ", arr);
        }
        public void PrintText()
        {
            foreach (string item in text)
            {
                Console.WriteLine($"{item}");
            }
        }
        public void PrintLongestShortest()
        {
            int i = 0;
            foreach (string item in text)
            {
                Console.WriteLine($"In {++i} sentence: {FindLongestShortestWord(item)}");
            }
        }
        public void PrintTextIntoFile()
        {
            using (StreamWriter sw = new StreamWriter("Result.txt"))
            {
                foreach (string item in text)
                {
                    sw.WriteLine($"{item}");
                }
            }
        }
    }
}
