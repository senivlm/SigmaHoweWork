using System.IO;

namespace HomeWork10
{
    public static class Writer
    {
        public static void WriteToFile(string path, string text)
        {
            using (StreamWriter writer = new(path))
            {
                writer.WriteLine(text);
            }
        }
    }
}
