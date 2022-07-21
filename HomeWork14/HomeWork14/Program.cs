using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace HomeWork14
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Storage storage = Storage.GetInstance();
            Storage storage1 = Storage.GetInstance();
            Console.WriteLine(storage == storage1);

            storage.AddProduct(new ConcreteProductFactory().CreateProduct());
            storage1.AddProduct(new ConcreteMeatFactory().CreateProduct());
            Console.WriteLine(storage.Count);


            //Serialization
            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream("serialize.txt", FileMode.Create, FileAccess.Write);
            formatter.Serialize(stream, storage);
            stream.Close();

            //Deserialization
            stream = new FileStream("serialize.txt", FileMode.Open, FileAccess.Read);
            Storage storage2 = formatter.Deserialize(stream) as Storage;
            stream.Close();
            //Це тільки один вид серіалізації

        }
    }
}
