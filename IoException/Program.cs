using System;
using System.IO;
using System.Globalization;
using System.Collections.Generic;
using IoException.Entities;
using IoException.Entities.MyExceptions;

namespace IoException
{
    class Program
    {
        static void Main(string[] args)
        {
            //C:\Users\crist\OneDrive\Área de trabalho\Origem\File.csv
            try
            {

                List<Product> products = new List<Product>();
                Console.Write("Enter the file path: ");
                FileInfo fl = new FileInfo(Console.ReadLine());
                string[] lines = null;
                Directory.CreateDirectory(Path.Combine(fl.DirectoryName, "newFolderAux"));

                if (fl.Exists)
                {
                    using (StreamReader reader = fl.OpenText())
                    {
                        lines = reader.ReadToEnd().Split('\n');
                    }
                    foreach (string line in lines)
                    {
                        string[] data = line.Split(',');
                        string name = data[0];
                        double price = double.Parse(data[1], CultureInfo.InvariantCulture);
                        int quantity = int.Parse(data[2]);
                        Product p = new Product(name, price, quantity);
                        products.Add(p);
                    }

                    string targetPath = Path.Combine(fl.DirectoryName, "newFolderAux", "Summary.csv");

                    using (StreamWriter sw = File.CreateText(targetPath))
                    {
                        foreach (Product p in products)
                        {
                            double totalValue = p.TotalValue();
                            sw.WriteLine(p);
                            sw.WriteLine();
                        }
                    }

                    Console.WriteLine("File created successfully");
                    Console.ReadKey();
                }
                else
                {
                    Console.WriteLine("File path not fount");
                }

            }
            catch(ProductExceptions e)
            {
                Console.WriteLine("An error occurred:");
                Console.WriteLine(e.Message);
            }
            catch (FormatException e)
            {
                Console.WriteLine("An error occurred:");
                Console.WriteLine(e.Message);
            }
            catch (IOException e)
            {
                Console.WriteLine("An error occurred:");
                Console.WriteLine(e.Message);
            }
            catch (SystemException e)
            {
                Console.WriteLine("An error occurred:");
                Console.WriteLine(e.Message);
            }
        }
    }
}
