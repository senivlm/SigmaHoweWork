using System;
using System.Collections.Generic;
using System.IO;

namespace SigmaMarket
{
    public static class AdminRoot
    {
        static List<ExeptionData> exeptionsData = new List<ExeptionData>();
        static public void Dialogue(ref Storage<Goods> storage)
        {
            while (true)
            {
                Console.WriteLine("What you want to do?");
                Console.WriteLine("1) Check all products in stock\n" +
                    "2) Add product\n" +
                    "3) Add meat\n" +
                    "4) Remove product\n" +
                    "5) Find all meat\n" +
                    "6) Change price of all products\n" +
                    "7) Input products data from file\n" +
                    "8) To correct exeptions\n" +
                    "9) Sort\n" +
                    "0) Exit\n");
                switch (Console.ReadLine())
                {
                    case "1":
                        ChecAllkProducts(storage);
                        Console.WriteLine();
                        break;
                    case "2":
                        Console.WriteLine("Ender product data\n" +
                            "Name-Price-Weight\n");
                        try
                        {
                            Product product = Product.Parse(Console.ReadLine());
                            storage.AddProduct(product);
                        }
                        catch (Exception)
                        {
                            Console.WriteLine("Cant add product!");
                        }
                        break;
                    case "3":
                        Console.WriteLine("Ender meat data\n" +
                            "Name-Price-Weight-Time to expire-Category-Species\n");
                        try
                        {
                            Meat meat = Meat.Parse(Console.ReadLine());
                            storage.AddProduct(meat);
                        }
                        catch (Exception)
                        {
                            Console.WriteLine("Cant add product!");
                        }
                        break;
                    case "4":
                        Console.WriteLine("Which protuct you want to remove?");
                        storage.RemoveProduct(Convert.ToInt32(Console.ReadLine()));
                        Console.WriteLine();
                        break;
                    case "5":
                        CheckAllMeat(FindAllMeat(storage));
                        Console.WriteLine();
                        break;
                    case "6":
                        Console.WriteLine("How much do you want to change price(in %)");
                        ChangePriceOfAllProducts(Convert.ToInt32(Console.ReadLine()), ref storage);
                        Console.WriteLine();
                        break;
                    case "7":
                        if (Reader.TryReadFileName(out string fileName))
                        {
                            InputDataFromFile(fileName, ref storage);
                        }
                        break;
                    case "8":
                        if (exeptionsData.Count == 0)
                        {
                            Console.WriteLine("No exeptioins!");
                            break;
                        }
                        if (TryCorrectExeption(ref storage))
                        {
                            Console.WriteLine("Product added! Exeption deleted!");
                        }
                        break;
                    case "9":
                        Sort(ref storage);
                        break;
                    case "0":
                        return;
                    default:
                        Console.WriteLine("Wrong Variant\n");
                        break;
                }
            }
        }
        static private void Sort(ref Storage<Goods> storage)
        {
            Console.WriteLine("How do you want to sort storage?(1-3)");
            Console.WriteLine("1) By name!\n" +
                "2) By price!\n" +
                "3) By weight!\n" +
                "0) Exit\n");
            while (true)
            {
                switch (Console.ReadLine())
                {
                    case "1":
                        storage.Sort(new CompareByName());
                        break;
                    case "2":
                        storage.Sort(new CompareByPrice());
                        break;
                    case "3":
                        storage.Sort(new CompareByWeight());
                        break;
                    case "0":
                        return;
                    default:
                        Console.WriteLine("Wrong Variant\n");
                        break;
                }
            }
        }
        static private Meat[] FindAllMeat(Storage<Goods> storage)
        {
            List<Meat> foundedMeat = new List<Meat>();
            for (int i = 0; i < storage.Count; i++)
            {
                if (storage[i] is Meat)
                {
                    foundedMeat.Add((Meat)storage[i]);
                }
            }
            return foundedMeat.ToArray();
        }
        static private void CheckAllMeat(Meat[] meats)
        {
            if (meats == null)
            {
                Console.WriteLine("No meat founded");
            }
            foreach (var item in meats)
            {
                Console.WriteLine($"{item.Name} is in stock!");
            }
        }
        static private void ChecAllkProducts(Storage<Goods> storage)
        {
            for (int i = 0; i < storage.Count; i++)
            {
                Console.WriteLine($"{i+1}) {storage[i]}");
            }
        }
        static private void ChangePriceOfAllProducts(int percentage, ref Storage<Goods> storage)
        {
            for (int i = 0; i < storage.Count; i++)
            {
                storage[i].ChangePrice(percentage);
            }
        }
        static private void InputDataFromFile(string fileName, ref Storage<Goods> storage)
        {
            int numLine = 0;
            using (StreamReader reader = new StreamReader(fileName))
            {
                while (!reader.EndOfStream)
                {
                    try
                    {
                        string line = reader.ReadLine();
                        numLine++;
                        if (line.Split(' ').Length == 3)
                        {
                            try
                            {
                                //Product product = Product.Parse(line);
                                //if (Char.IsLower(product.Name[0]))
                                //{
                                //    product.Name = product.Name.Replace(product.Name[0], Char.ToUpper(product.Name[0]));
                                //}
                                //storage.AddProduct(product);

                                storage.AddProduct(Product.Parse(line));
                            }
                            catch (Exception)
                            {
                                exeptionsData.Add(new ExeptionData("wrong data", numLine, line, DateTime.Now));
                            }
                        }
                        else if (line.Split(' ').Length == 6)
                        {
                            try
                            {
                                //Meat meatProduct = Meat.Parse(line);
                                //if (Char.IsLower(meatProduct.Name[0]))
                                //{
                                //    meatProduct.Name = meatProduct.Name.Replace(meatProduct.Name[0], Char.ToUpper(meatProduct.Name[0]));
                                //}
                                //storage.AddProduct(meatProduct);

                                storage.AddProduct(Meat.Parse(line));
                            }
                            catch (Exception)
                            {
                                exeptionsData.Add(new ExeptionData("wrong data", numLine, line, DateTime.Now));
                            }
                        }
                        else
                        {
                            exeptionsData.Add(new ExeptionData("wrong format", numLine, line, DateTime.Now));
                        }
                    }
                    catch (FormatException e)
                    {
                        exeptionsData.Add(new ExeptionData("wrong format", numLine, e.Message, DateTime.Now));
                    }
                    catch (Exception e)
                    {
                        exeptionsData.Add(new ExeptionData("something went wrong", numLine, e.Message, DateTime.Now));
                    }
                }
                if (exeptionsData.Count != 0)
                {
                    Console.WriteLine();
                    foreach (var item in exeptionsData)
                    {
                        Console.WriteLine(item);
                    }
                    Console.WriteLine();
                }
            }
        }
        static private bool TryCorrectExeption(ref Storage<Goods> storage)
        {
            Console.WriteLine("Which exeption do you want to correct?");
            int i = 1;
            foreach (var item in exeptionsData)
            {
                Console.WriteLine($"{i++}) {item}");
            }
            int eIndex = int.Parse(Console.ReadLine());
            if (eIndex < 0 || eIndex > exeptionsData.Count)
            {
                Console.WriteLine("No such exeptions");
                return false;
            }
            Console.WriteLine("Enter correct product data:");
            string line = Console.ReadLine();
            if (line.Split(' ').Length == 3)
            {
                try
                {
                    Product product = Product.Parse(line);
                    storage.AddProduct(product);
                    exeptionsData.RemoveAt(eIndex - 1);
                    return true;
                }
                catch (Exception)
                {
                    Console.WriteLine("Wrong data!");
                    return false;
                }
            }
            else if (line.Split(' ').Length == 6)
            {
                try
                {
                    Meat meatProduct = Meat.Parse(line);
                    storage.AddProduct(meatProduct);
                    exeptionsData.RemoveAt(eIndex - 1);
                    return true;
                }
                catch (Exception)
                {
                    Console.WriteLine("Wrong data!");
                    return false;
                }
            }
            else
            {
                Console.WriteLine("Wrong format!");
                return false;
            }
        }
    }
}
