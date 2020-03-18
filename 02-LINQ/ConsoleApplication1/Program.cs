using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Xml.Linq;
using TSD.Linq.Cars;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Task2:\n");
            Task2();

            Console.WriteLine("\n\nTask3:\n");
            Task3();

            Console.ReadLine();
        }

        static void Task2()
        {
            CarSalesBook carSalesBook = new CarSalesBook();

            var cars = carSalesBook.ReadCarsFromFile();

            Console.WriteLine("Which are TOP 3 makes whose sales with regard to the amount of sold cars in 2014?");
            PrintMakes(cars.OrderBy(car => -car.Sales2014).Take(3));

            Console.WriteLine("\nThe sales of which makes increased by at least 50% in 2015 comparing to 2014?");
            PrintMakes(cars.Where(car => car.Sales2015 >= 1.5 * car.Sales2014));

            Console.WriteLine("\nWhich 3 makes opens the second ten of the sales ranking in 2015");
            PrintMakes(cars.OrderBy(car => -car.Sales2015).Skip(10).Take(3));

            Console.WriteLine("\nWhat are the totals of sold cars in 2014 and 2015");
            Console.WriteLine("Total 2014: " + cars.Sum(n => n.Sales2014));
            Console.WriteLine("Total 2015: " + cars.Sum(n => n.Sales2015));
            Console.WriteLine("Total 2014 and 2015: " + (cars.Sum(n => n.Sales2014) + cars.Sum(n => n.Sales2015)));

            Console.WriteLine("\nCreate a list that contains TOP10 and LAST 10 cars with respect to sales in 2015.");
            IEnumerable<Car> result = cars.OrderBy(car => -car.Sales2015).Take(10).Union(
                cars.OrderBy(car => -car.Sales2015).Reverse().Take(10).Reverse());
            PrintMakes(result);

            string path = @"..\..\cars.xml";

            SaveToXML(result, path);
            Console.WriteLine("\nSaved results from previous query to XML.");

            Console.WriteLine("\nLoaded cars from XML:");
            List<Car> loadedCars = ReadFromXML(path);
            PrintMakes(loadedCars);
        }

        static void PrintMakes(IEnumerable<Car> results)
        {
            foreach (var result in results)
            {
                Console.WriteLine(result.Make);
            }
        }

        static void SaveToXML(IEnumerable<Car> list, string path)
        {
            XDocument xDoc = new XDocument();
            XElement cars = new XElement("cars");
            foreach (var car in list)
            {
                cars.Add(new XElement("make", car.Make)); 
            }
            xDoc.Add(cars);
            xDoc.Declaration = new XDeclaration("1.0", "utf-8", "yes");
            xDoc.Save(path);
        }

        static List<Car> ReadFromXML(string path)
        {
            return XDocument.Load(path).Element("cars")?.Elements("make").Select(car => new Car(car.Value)).ToList();
        }

        static void Task3()
        {
            Console.WriteLine("Memory used by processes: " + Process.GetProcesses().CalculateMemory() + " bytes");

            bool LeapYear(int year) => (year % 4 == 0);
            Console.WriteLine("\nIs year 2013 a leap year? Answer: " + LeapYear(2513));
            Console.WriteLine("Is year 2020 a leap year? Answer: " + LeapYear(2020));

            RandomList<int> myGenericList = new RandomList<int>();
            Console.WriteLine("\nList is empty: " + myGenericList.IsEmpty());
            myGenericList.Add(3);
            myGenericList.Add(7);
            myGenericList.Add(1);
            Console.WriteLine("List is empty: " + myGenericList.IsEmpty());
            Console.WriteLine("Randomized gets:");
            Console.WriteLine(myGenericList.Get(0));
            Console.WriteLine(myGenericList.Get(1));
            Console.WriteLine(myGenericList.Get(2));
        }
    }
}
