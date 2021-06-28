using System;
using System.Collections.Generic;
using System.Linq;

namespace LINQ_Test
{
    class Program
    {
        static void Main()
        {
            RandomList(out var list, size:10, start:1, end:10);
            PrintList(list);

            var max = list.Max();
            var min = list.Min();
            
            Console.WriteLine($"min = {min}");
            Console.WriteLine($"max = {max}");

            var select = from item in list 
                                        where item > 5 
                                        select item;
            PrintList(select);
        }

        static void RandomList(out List<int> list, in int size, in int start, in int end)
        {
            list = new List<int>();
            var random = new Random();
            for (int i = 0; i < size; i++)
            {
                list.Add(random.Next(start, end));
            }
        }

        static void PrintList(IEnumerable<int> list)
        {
            foreach (var item in list)
            {
                Console.Write($"{item}\t");
            }
            Console.WriteLine();
        }
    }
}