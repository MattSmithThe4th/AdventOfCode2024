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

            var answer = solutionExecutor.ExecuteSolution(input);

            Console.WriteLine("The answer is: " + answer);
        }
    }
}