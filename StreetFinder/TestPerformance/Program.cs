using System;
using System.Diagnostics;
using System.IO;
using AproximativeSearchImpl;

namespace TestPerformance
{
    class Program
    {
        static void Main(string[] args)
        {
            // LoadAllStreets();

            SearchForStreet("89359", "An");
        }

        public static void SearchForStreet(string zipcode, string street)
        {
            var addressService = new AddressService();
            var watch = new Stopwatch();
            watch.Start();
            var results = addressService.Search(zipcode, street);
            foreach (var result in results)
            {
                Console.WriteLine(result);
            }
            watch.Stop();

            Console.WriteLine("Results calculation took {0} Milliseconds", watch.ElapsedMilliseconds);
            Console.ReadKey();
        }

        public static void LoadAllStreets()
        {
            var file = new StreamReader(@"c:\temp\TestStreets.csv", System.Text.Encoding.Default);
            string line;
            var addressService = new AddressService();

            var watch = new Stopwatch();
            watch.Start();

            var count = 0;
            while ((line = file.ReadLine()) != null)
            {
                var tokens = line.Split(';');
                addressService.Insert(tokens[0], tokens[1]);
                count++;
            }
            
            watch.Stop();

            Console.WriteLine("{0} were inserted", count);

            long min = (watch.ElapsedMilliseconds/1000)/60;

            Console.WriteLine("Indexing took {0} Milliseconds", watch.ElapsedMilliseconds);
            Console.WriteLine("Indexing took {0} Min", min);            

            Console.ReadKey();
        }
    }
}
