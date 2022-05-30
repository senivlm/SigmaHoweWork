using System;
using System.Collections.Generic;

namespace Sigma1
{
    public class Storage
    {
        protected List<Product> productsInStock { get; private set; } = new List<Product>();
        public Storage(params Product[] products)
        {
            foreach (var item in products)
            {
                this.productsInStock.Add(item);
            }
        }
        public Product this[int i]
        {
            get
            {
                return productsInStock[i];
            }
        }
        // метод діалогу має бути не в цьому класі. Тут достатньо мати метод, який вміє додавати до колекції товар.
        public void Dialogue()
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
                    "7) Exit\n");
                var variant = Console.ReadLine();
                switch (variant)
                {
                    case "1":
                        ChecAllkProducts();
                        Console.WriteLine();
                        break;
                    case "2":
                        Console.WriteLine("Ender product data");
                        try
                        {
                            Product product = new Product("temp", 1 ,1);
                            product.Parse(Console.ReadLine());
                            AddProduct(product);
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
                            AddProduct(meatProduct);
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
                        RemoveProduct(index);
                        Console.WriteLine();
                        break;
                    case "5":
                        FindAllMeat();
                        Console.WriteLine();
                        break;
                    case "6":
                        Console.WriteLine("How much do you want to change price(in %)");
                        int percentage = Convert.ToInt32(Console.ReadLine());
                        ChangePriceOfAllProducts(percentage);
                        Console.WriteLine();
                        break;
                    case "7":
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Wrong Variant\n");
                        break;
                }
            }
        }
        // Метод мав би повертати колекцію шуканих об'єктів, а не друкувати інформацію про них. Це функція іншого класу.
        public void FindAllMeat()
        {
            int index = 0;
            foreach (var item in productsInStock)
            {
                index++;
                if (item is Meat)
                {
                    Console.WriteLine($"Meat named {item.Name} was found. Index in storage: {index}");
                }
            }
        }

        public void AddProduct(Product product)
        {
            try
            {
                productsInStock.Add(product);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        public void RemoveProduct(int index)
        {
            try
            {
                productsInStock.RemoveAt(index - 1);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        public void ChecAllkProducts()
        {
            int index = 0;
            foreach (var item in productsInStock)
            {
                Console.WriteLine($"{++index}) {item}");
            }
        }
        public void ChangePriceOfAllProducts(int percentage)
        {
            foreach (var item in productsInStock)
            {
                item.ChangePrice(percentage);
            }
        }

    }
}
