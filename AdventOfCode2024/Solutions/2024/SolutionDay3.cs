using System.Text.RegularExpressions;

namespace AdventOfCode2024.Solutions._2024
{
    public class SolutionDay3 : SolutionBase
    {

        public override string ExecuteSolutionPartOne(string[] lines)
        {
            return RegexSolutionPartOne(lines);
        }

        public override string ExecuteSolutionPartTwo(string[] lines)
        {
            var regex = new Regex(@"mul\((\d+),(\d+)\)|do\(\)|don\'t\(\)");
            var doRead = true;
            var answer = 0;

            foreach (var line in lines)
            {
                var match = regex.Match(line);
                while(match.Success)
                {
                    if (match.Value == "do()")
                    {
                        doRead = true;
                    }
                    else if (match.Value == "don't()")
                    {
                        doRead = false;
                    }
                    else if(doRead)
                    {
                        answer += Convert.ToInt32(match.Groups[1].Value) * Convert.ToInt32(match.Groups[2].Value);
                    }
                    match = match.NextMatch();
                }
            }


            return answer.ToString();
        }



        private string RegexSolutionPartOne(string[] lines)
        {
            var regex = new Regex(@"mul\((\d+),(\d+)\)");
            var results = new List<Match>();
            var answer = 0;

            foreach (var line in lines)
            {
                var result = regex.Matches(line);

                results.AddRange(result.ToList());
            }

            foreach (var match in results)
            {
                answer += Convert.ToInt32(match.Groups[1].Value) * Convert.ToInt32(match.Groups[2].Value);
            }


            return answer.ToString();
        }
    }
}
