using System.IO;

namespace HomeWork9
{
    public static class Currency
    {
        private static double _EUR;
        private static double _USD;
        public static double EUR
        {
            get => _EUR;
            set
            {
                if (value > 0)
                {
                    _EUR = value;
                }
            }
        }
        public static double USD
        {
            get => _USD; 
            set
            {
                if (value > 0)
                {
                    _USD = value;
                }
            }
        }
        public static double UAH
        {
            get => 1;
        }

        public static void SetCourse(string path)
        {
            if (!File.Exists(path))
            {
                throw new FileNotFoundException("File not found");
            }
            using (StreamReader reader = new(path))
            {
                EUR = double.Parse(reader.ReadLine().Split(' ')[1]);
                USD = double.Parse(reader.ReadLine().Split(' ')[1]);
            }
        }
    }
}
