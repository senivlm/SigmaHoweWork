using System;
using System.Collections.Generic;
using System.IO;

namespace HomeWork10
{
    class Reader
    {
        public static string ReadText(string filePath)
        {
            if (!File.Exists(filePath))
            {
                throw new FileNotFoundException("File not found!");
            }
            string text = "";
            using (StreamReader reader = new(filePath))
            {
                text = reader.ReadToEnd();
            }
            return text;
        }
        public static Dictionary<string, string> ReadDiction(string filePath)
        {
            Dictionary<string, string> result = new Dictionary<string, string>();
            if (!File.Exists(filePath))
            {
                throw new FileNotFoundException("File not found!");
            }
            using (StreamReader reader = new StreamReader(filePath))
            {
                while (!reader.EndOfStream)
                {
                    string temp = reader.ReadLine();
                    try
                    {
                        var str = temp.Split('-');
                        if (str.Length != 2)
                        {
                            throw new ArgumentException("Incorrect pair");
                        }
                        result.Add(str[0], str[1]);
                    }
                    catch (ArgumentException)
                    {
                        throw;
                    }
                }
            }
            return result;
        }
        public static void WriteToDictionary(string key, string value, string filePath)
        {
            File.AppendAllText(filePath, $"\n{key}-{value}");
        }
    }
}
