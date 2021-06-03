using System;
using System.IO;
using System.Collections.Generic;
using Entities;
using System.Linq;
namespace EXERCISE_01___LINQ_LAMBDA_PROPOSE{
    class Program {
        static void Main(string[] args) {
            Console.Write("Enter full file path: "); //Comando para digitar caminho do arquivo.
            string path = Console.ReadLine();

            List<Product> list = new List<Product>();

            using (StreamReader sr = File.OpenText(path)) {
                while (!sr.EndOfStream) {
                    string[] fields = sr.ReadLine().Split(',');
                    string name = fields[0];
                    double price = double.Parse(fields[1]);
                    list.Add(new Product(name, price));
                }
            }

            var avg = list.Select(p => p.Price).DefaultIfEmpty(0.0).Average();
            Console.WriteLine("Average price = " +avg.ToString("F2"));

            var names = list.Where(p => p.Price < avg).OrderByDescending(p => p.Name).Select(p => p.Name);
            foreach (string name in names) {
                Console.WriteLine(name);
            }
        }
    }
}
