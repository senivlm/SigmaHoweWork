using System;
using System.Collections.Generic;

namespace HomeWork10
{
    class Translator
    {
        private Dictionary<string, string> _vocabulary;
        private string _text;
        private string _pathToText;
        private string _pathToDict;

        public Translator() : this("text.txt", "dict.txt")
        {

        }
        public Translator(string pathToText, string pathToDict)
        {
            _vocabulary = new Dictionary<string, string>();
            _text = "";
            _pathToDict = pathToDict;
            _pathToText = pathToText;
        }
        public Translator(Dictionary<string, string> vocabulary, string text, string pathToText, string parhToDict)
        {
            this._vocabulary = vocabulary;
            this._text = text;
        }


        public void AddText(string text)
        {
            _text += text;
        }

        public void AddDictionary(Dictionary<string, string> dict)
        {
            _vocabulary = dict;
        }

        private void AddToDictionary(string word)
        {
            Console.WriteLine($"Enter new word for {word}");
            string value = Console.ReadLine();
            _vocabulary.Add(word, value);
            Reader.WriteToDictionary(word, value, "dict.txt");
        }

        public string ChangeWords()
        {
            _text = Reader.ReadText(_pathToText);
            _vocabulary = Reader.ReadDiction(_pathToDict);
            string[] words = _text.Split(' ', '\r', '\n');
            string resultText = "";
            foreach (string item in words)
            {
                if (item == "" || item == " ")
                {
                    resultText += " ";
                    continue;
                }
                string wordToChange;
                char c = ' ';
                if (Char.IsPunctuation(item[item.Length - 1]))
                {
                    wordToChange = item[0..^1];
                    c = item[item.Length - 1];
                }
                else
                {
                    wordToChange = item;
                }
                if (_vocabulary.ContainsKey(wordToChange))
                {
                    resultText += _vocabulary[wordToChange] + c;
                }
                else
                {
                    int count = 3;
                    string str = "";
                    Console.WriteLine($"Enter tranlation for {wordToChange}");
                    while (count > 0)
                    {
                        str = Console.ReadLine();
                        if (str != "" && str != " ")
                        {
                            break;
                        }
                        count--;
                    }
                    if (str == "" || str == " ")
                    {
                        Console.WriteLine("New word is \"Word\"");
                        _vocabulary.Add(wordToChange, "Word");
                        Reader.WriteToDictionary(wordToChange, "Word", _pathToDict);
                    }
                    else
                    {
                        _vocabulary.Add(wordToChange, str);
                    }
                    resultText += _vocabulary[wordToChange] + c;
                }
            }
            return resultText;
        }
    }
}
