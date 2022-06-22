using System;

namespace HomeWork10
{
    public class WordDoesntFoundExeption : Exception
    {
        public WordDoesntFoundExeption() : base()
        {

        }
        public WordDoesntFoundExeption(string message) : base(message)
        {

        }
    }
}
