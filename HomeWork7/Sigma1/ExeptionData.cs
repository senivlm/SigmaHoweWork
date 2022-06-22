using System;

namespace Sigma1
{
    public class ExeptionData
    {
        private string _exeption;
        private int _line;
        private string _exeptionContent;

        public string Exeption
        {
            get => _exeption;
            private set
            {
                if (value != "")
                {
                    _exeption = value; 
                }
                else
                {
                    throw new ArgumentNullException();
                }
            }
        }
        public int Line
        {
            get => _line;
            private set
            {
                if (value > 0)
                {
                    _line = value;
                }
            }
        }
        public DateTime Date { get; private set; }
        public string ExeptionContent
        {
            get => _exeptionContent; 
            private set
            {
                if (value != "")
                {
                    _exeptionContent = value;
                }
                else
                {
                    throw new ArgumentNullException();
                }
            }
        }

        public ExeptionData(string exeption, int line, string exeptionContent , DateTime date)
        {
            Exeption = exeption;
            Line = line;
            ExeptionContent = exeptionContent;
            Date = date;
        }
        public override string ToString()
        {
            return $"Exeption \"{Exeption}\" in line {Line}. Content: {ExeptionContent}";
        }
    }
}