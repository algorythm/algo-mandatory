using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Algo_Mandatory_WK06
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Generating random arrays...");
            var lists1 = new List<List<int>>();
            var lists2 = new List<List<int>>();

            TypeElapsedTime(() =>
            {
                lists1.Add(RandomNums(5000));
                lists1.Add(RandomNums(10000));
                lists1.Add(RandomNums(15000));
                lists1.Add(RandomNums(20000));
                Console.WriteLine("First list generated.");

                lists2.Add(RandomNums(10000000));
                lists2.Add(RandomNums(20000000));
                lists2.Add(RandomNums(30000000));
                lists2.Add(RandomNums(40000000));
                Console.WriteLine("Second list generated.");
            });

            Console.WriteLine("==== Insertion Sort ====");
            foreach (var list in lists1)
                TypeElapsedTime(() => InsertionSort(list), list);

            Console.WriteLine();

            Console.WriteLine("==== List.Sort ====");
            foreach (var list in lists2)
                TypeElapsedTime(() => list.Sort(), list);

            Console.WriteLine("Press any key to exit...");
            Console.ReadLine();
        }

        private static void TypeElapsedTime(Action method, ICollection<int> list = null)
        {
            if (list != null)
                Console.WriteLine("Length      : {0}", list.Count);
            Console.WriteLine("Time elapsed: {0}ms", GetTimeOfMethod(method));
        }

        private static void TypeElapsedTime(Action method, ICollection<int> list, int averageCount)
        {
            Console.WriteLine("Length      : {0}", list.Count);
            long timeElapsed = 0;

            Console.Write("(");
            for (var i = 0; i < averageCount; i++)
            {
                if (i < averageCount)
                    Console.Write("{0} + ", i);
                else
                    Console.WriteLine("{0})", i);
                timeElapsed += GetTimeOfMethod(method);
            }

            Console.WriteLine("Time elapsed: {0}ms", timeElapsed);
            
        }

        private static void InsertionSort(IList<int> list)
        {
            for (var i = 1; i < list.Count; i++)
            {
                var j = i;
                while (j > 0)
                    if (list[j - 1] > list[j])
                    {
                        var tmp = list[j - 1];
                        list[j - 1] = list[j];
                        list[j] = tmp;
                        j--;
                    }
                    else
                    {
                        break;
                    }
            }
        }

        private static List<int> RandomNums(int count)
        {
            var list = new List<int>();
            var rnd = new Random();
            for (var i = 0; i < count; i++)
                list.Add(rnd.Next(1, 100));
            return list;
        }

        private static long GetTimeOfMethod(Action method)
        {
            var watch = Stopwatch.StartNew();

            method();

            watch.Stop();
            return watch.ElapsedMilliseconds;
        }
    }
}