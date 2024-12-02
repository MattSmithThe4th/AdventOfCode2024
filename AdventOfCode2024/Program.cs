using AdventOfCode2024.Helpers;
using System;

namespace AdventOfCode
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Write the number of day to get the solution of\n");
            var day = Console.ReadLine();
            var solutionExecutor = SolutionFactory.GetInstance(day);
            var input = IOHandler.GetInput("Day" + day);

            var answer1 = solutionExecutor.ExecuteSolutionPartOne(input);
            var answer2 = solutionExecutor.ExecuteSolutionPartTwo(input);

            Console.WriteLine("The answer to part one is: " + answer1);
            Console.WriteLine("The answer to part two is: " + answer2);
        }
    }
}