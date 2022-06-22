namespace Sigma1
{
    public class Program
    {
        static void Main(string[] args)
        {
            Storage storage = new Storage();
            AdminRoot.Dialogue(ref storage);
        }
    }
}