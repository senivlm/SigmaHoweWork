using System;
using System.Collections.Generic;
using System.IO;

namespace Sigma1
{
    static public class AdminRoot
    {
        static List<ExeptionData> exeptionsData = new List<ExeptionData>();
        // мені здаєть що метод діалог дуже великий, зможете шось порадити щоб зробити його кращим?)
        static public void Dialogue(ref Storage storage)
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
                    "8) To correct exeptins\n" +
                    "9) Exit\n");
                var variant = Console.ReadLine();
                switch (variant)
                {
                    case "1":
                        ChecAllkProducts(storage);
                        Console.WriteLine();
                        break;
                    case "2":
                        Console.WriteLine("Ender product data");
                        try
                        {
                            Product product = new Product("temp", 1, 1);
                            product.Parse(Console.ReadLine());
                            storage.AddProduct(product);
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }
                        Console.WriteLine();
                        break;
                    case "3":
                        Console.WriteLine("Ender meat data");
                        try
                        {
                            Meat meatProduct = new Meat("temp", 1, 1, 1, default, default);
                            meatProduct.Parse(Console.ReadLine());
                            storage.AddProduct(meatProduct);
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }
                        Console.WriteLine();
                        break;
                    case "4":
                        Console.WriteLine("Which protuct you want to remove?");
                        int index = Convert.ToInt32(Console.ReadLine());
                        storage.RemoveProduct(index);
                        Console.WriteLine();
                        break;
                    case "5":
                        Meat[] meats = FindAllMeat(storage);
                        CheckAllMeat(meats);
                        Console.WriteLine();
                        break;
                    case "6":
                        Console.WriteLine("How much do you want to change price(in %)");
                        int percentage = Convert.ToInt32(Console.ReadLine());
                        ChangePriceOfAllProducts(percentage, ref storage);
                        Console.WriteLine();
                        break;
                    case "7":
                        Console.WriteLine("Enter file name:");
                        string fileName = Console.ReadLine();
                        int count = 0;
                        while (!File.Exists(fileName))
                        {
                            if (count == 3)
                            {
                                Console.WriteLine("Try again later!");
                                break;
                            }
                            count++;
                            Console.WriteLine($"File {fileName} doesn't exist!\nEnter again:");
                            fileName = Console.ReadLine();
                        }
                        if (File.Exists(fileName))
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
                            break;
                        }
                        Console.WriteLine("Enter correct product data:");
                        string line = Console.ReadLine();
                        if (line.Split(' ').Length == 3)
                        {
                            try
                            {
                                Product product = new Product("temp", 1, 1);
                                product.Parse(line);
                                storage.AddProduct(product);

                            }
                            catch (Exception)
                            {
                                Console.WriteLine("Wrong data!");
                                break;
                            }
                        }
                        else if (line.Split(' ').Length == 6)
                        {
                            try
                            {
                                Meat meatProduct = new Meat("temp", 1, 1, 1, default, default);
                                meatProduct.Parse(line);
                                storage.AddProduct(meatProduct);
                            }
                            catch (Exception)
                            {
                                Console.WriteLine("Wrong data!");
                                break;
                            }
                        }
                        else
                        {
                            Console.WriteLine("Wrong format!");
                            break;
                        }
                        Console.WriteLine("Product added! Exeption deleted!");
                        exeptionsData.RemoveAt(eIndex-1);
                        break;
                    case "9":
                        return;
                    default:
                        Console.WriteLine("Wrong Variant\n");
                        break;
                }
            }
        }
        static private Meat[] FindAllMeat(Storage storage)
        {
            int index = 0;
            List<Meat> foundedMeat = new List<Meat>();
            foreach (var item in storage.productsInStock)
            {
                index++;
                if (item is Meat)
                {
                    foundedMeat.Add((Meat)item);
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
        static private void ChecAllkProducts(Storage storage)
        {
            int index = 0;
            foreach (var item in storage.productsInStock)
            {
                Console.WriteLine($"{++index}) {item}");
            }
        }
        static private void ChangePriceOfAllProducts(int percentage, ref Storage storage)
        {
            foreach (var item in storage.productsInStock)
            {
                item.ChangePrice(percentage);
            }
        }
        static private void InputDataFromFile(string fileName, ref Storage storage)
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
                                Product product = new Product("temp", 1, 1);
                                product.Parse(line);
                                if (Char.IsLower(product.Name[0]))
                                {
                                    product.Name = product.Name.Replace(product.Name[0], Char.ToUpper(product.Name[0]));
                                }
                                storage.AddProduct(product);
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
                                Meat meatProduct = new Meat("temp", 1, 1, 1, default, default);
                                meatProduct.Parse(line);
                                if (Char.IsLower(meatProduct.Name[0]))
                                {
                                    meatProduct.Name = meatProduct.Name.Replace(meatProduct.Name[0], Char.ToUpper(meatProduct.Name[0]));
                                }
                                storage.AddProduct(meatProduct);
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
    }
}
