using System;
using System.Collections.Concurrent;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AproximativeSearchImpl;
using FluentAssertions;
using StreetFinder;
using Tests.UnitTests;

namespace TestPerformance
{
    class Program
    {
        static void Main(string[] args)
        {

            var tokens = AnalyzerTestHelper.TokensFromAnalysis(new StreetAnalyzer(Lucene.Net.Util.Version.LUCENE_30), "Doktor.-Schweninger-Str.");
            var listTokens = tokens.ToList();

            // Assert
            foreach (var token in listTokens)
            {
                Console.WriteLine(token);
            }

            Console.ReadKey();
            //LoadAllStreets();

            //SearchForStreet("86476", "St");
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
            var addressService = new AddressService();

            var watch = new Stopwatch();
            watch.Start();

            var count = 0;
            var lines = File.ReadLines(@"c:\temp\TestStreets.csv", System.Text.Encoding.Default);

            var collection = new BlockingCollection<string>();

            foreach (var line in lines)
            {
                collection.Add(line);
            }

            Parallel.ForEach(collection.GetConsumingEnumerable(), c =>
                {
                    var tokens = c.Split(';');
                    addressService.Insert(tokens[0], tokens[1]);
                    count++;                                    
                });
            
            watch.Stop();

            Console.WriteLine("{0} were inserted", count);

            long min = (watch.ElapsedMilliseconds/1000)/60;

            Console.WriteLine("Indexing took {0} Milliseconds", watch.ElapsedMilliseconds);
            Console.WriteLine("Indexing took {0} Min", min);            

            Console.ReadKey();
        }
    }
}
