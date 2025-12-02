using AdventOfCode.Helpers;
using AdventOfCode2024.Helpers;
using AdventOfCode2024.Solutions;
using System.Diagnostics;

namespace AdventOfCode
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Write the number of day to get the solution of: ");
            var day = Console.ReadLine();
            var year = DateTime.Now.Year.ToString();

            if (args.Length > 0)
            {
                year = args[0];
            }

            if (day == "all")
            {
                RunAllDays(year);
            }
            else if (day == "test")
            {
                Console.WriteLine("Running test code");
                CodeTest.Test();
                Console.WriteLine("Finished test code");
            }
            else
            {
                RunSingleDay(year, day);
            }
            Console.WriteLine("Program finished. Press any key to exit");
            Console.ReadKey(true);
        }

        private static void RunAllDays(string year)
        {
            for (int i = 1; i <= 25; i++)
            {
                RunSingleDay(year, i.ToString());
            }
        }

        private static void RunSingleDay(string year, string day)
        {
            SolutionBase solutionExecutor;
            ISolutionFactory solutionFactory = year switch
            {
                "2024" => new SolutionFactory2024(),
                "2025" => new SolutionFactory2025(),
                _ => throw new NotImplementedException()
            };

            try
            {
                solutionExecutor = solutionFactory.GetInstance(day);
            } 
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return;
            }


            var input = IOHandler.GetInput(year, "Day" + day);

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