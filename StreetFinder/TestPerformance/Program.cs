using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Resources;
using System.Threading.Tasks;
using AproximativeSearchImpl;
using Lucene.Net.Support;
using NUnit.Framework;

namespace TestPerformance
{
    class Program
    {
        static void Main(string[] args)
        {
            //LoadStreetsInBlock();

            LoadAllStreets();

            //SearchForStreet("89619", "Nisch");
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

            var collection = new List<string>();

            foreach (var line in lines)
            {
                collection.Add(line);
            }

            Parallel.ForEach(collection, c =>
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

        public static void LoadStreetsInBlock()
        {
            var addressService = new AddressService();

            var watch = new Stopwatch();
            watch.Start();

            var count = 0;

            // Get list of all PObox
            var poBoxes = new List<string>();
            var allLines = File.ReadLines(@"c:\temp\TestStreets.csv", System.Text.Encoding.Default);
            var lastPoBox = string.Empty;
            foreach (var line in allLines)
            {
                var tokens = line.Split(';');
                if (!tokens[0].Equals(lastPoBox))
                {
                    poBoxes.Add(tokens[0]);
                    lastPoBox = tokens[0];
                }
            }


            Parallel.ForEach(poBoxes, (c, state) =>
            {
                Console.WriteLine("Indexing " + c);
                var lines = File.ReadLines(@"c:\temp\TestStreets.csv", System.Text.Encoding.Default);
                var streetNames =  new HashSet<string>();
                var wasFound = false;
                foreach (var line in lines)
                {
                   var tokens = line.Split(';');
                    if (tokens[0].Equals(c))
                    {
                        streetNames.Add(tokens[1]);
                        wasFound = true;
                        count++;
                    }
                    else
                    {
                        if (wasFound)
                        {
                            break;
                        }
                    }
                }

                Console.WriteLine("Finished indexing " + count);
                addressService.Insert(c, streetNames);
                
            });

            watch.Stop();

            Console.WriteLine("{0} were inserted", count);

            long min = (watch.ElapsedMilliseconds / 1000) / 60;

            Console.WriteLine("Indexing took {0} Milliseconds", watch.ElapsedMilliseconds);
            Console.WriteLine("Indexing took {0} Min", min);

            Console.ReadKey();
        }

    }
}
