using AdventOfCode2024.Helpers;
using AdventOfCode2024.Solutions;
using System.Diagnostics;

namespace AdventOfCode
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Write the number of day to get the solution of\n");
            var day = Console.ReadLine();

            if (day == "all")
            {
                RunAllDays();
            }
            else
            {
                RunSingleDay(day);
            }
        }

        private static void RunAllDays()
        {
            for (int i = 1; i <= 25; i++)
            {
                RunSingleDay(i.ToString());
            }
        }

        private static void RunSingleDay(string day)
        {
            SolutionBase solutionExecutor;
            try
            {
                solutionExecutor = SolutionFactory.GetInstance(day);
            } catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return;
            }


            var input = IOHandler.GetInput("Day" + day);

            try
            {
                var stopwatch = Stopwatch.StartNew();
                var answer1 = solutionExecutor.ExecuteSolutionPartOne(input);
                stopwatch.Stop();
                Console.WriteLine($"Day {day} part one: {answer1} in a time of {stopwatch.ElapsedMilliseconds}ms");
            } 
            catch(Exception e)
            {
                Console.WriteLine("Error was thrown for implementation 1 with message: " + e.Message);
            }
            try
            {
                var stopwatch = Stopwatch.StartNew();
                var answer2 = solutionExecutor.ExecuteSolutionPartTwo(input);
                stopwatch.Stop();
                Console.WriteLine($"Day {day} part two: {answer2} in a time of {stopwatch.ElapsedMilliseconds}ms");
            } 
            catch(Exception e)
            {
                Console.WriteLine("Error was thrown for implementation 2 with message: " + e.Message);
            }
            Console.WriteLine();
        }

    }
}