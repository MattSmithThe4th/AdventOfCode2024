using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2024.Helpers
{
    public static class CodeTest
    {
        public static void Test()
        {
            var lines = File.ReadLines("Input/Day5.txt").ToArray();

            var index = lines.ToList().IndexOf(string.Empty);


            for (; index < lines.Length; index++)
            {
                var splitLine = lines[index].Split(',').ToList();

                if (splitLine.Count() != splitLine.Distinct().Count())
                {
                    Console.WriteLine("Somethings fishy");
                }

            }





        }
    }
}
