using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2024.Solutions
{
    public class SolutionDay8 : SolutionBase
    {
        public override string ExecuteSolutionPartOne(string[] lines)
        {
            var resultHash = new HashSet<(int, int)>();

            var parsedInput = ParseInput(lines);

            foreach (var charSet in parsedInput)
            {
                HandleSetPartOne(charSet, resultHash);
            }

            return resultHash.Where(x => x.Item1 < lines.Length && x.Item2 < lines[0].Length && x.Item1 >= 0 && x.Item2 >= 0).Count().ToString();
        }

        public override string ExecuteSolutionPartTwo(string[] lines)
        {
            var resultHash = new HashSet<(int, int)>();
            var parsedInput = ParseInput(lines);

            foreach(var coordinate in parsedInput.SelectMany(x => x.Value.Select(x => (x.Item1, x.Item2))))
            {
                resultHash.Add((coordinate.Item1, coordinate.Item2));
            }

            foreach(var charSet in parsedInput)
            {
                HandleSetPartTwo(charSet, resultHash, lines.Length, lines[0].Length);
            }

            return resultHash.Where(x => x.Item1 < lines.Length && x.Item2 < lines[0].Length && x.Item1 >= 0 && x.Item2 >= 0).Count().ToString();
        }

        private Dictionary<char, List<(int, int)>> ParseInput(string[] lines)
        {
            var parsedInput = new Dictionary<char, List<(int, int)>>();

            for(int i = 0; i < lines.Length; i++)
            {
                for(int j = 0; j < lines[i].Length; j++)
                {
                    if(lines[i][j] != '.')
                    {
                        if(parsedInput.ContainsKey(lines[i][j]))
                        {
                            parsedInput[lines[i][j]].Add((i, j));
                        } 
                        else
                        {
                            parsedInput.Add(lines[i][j], new List<(int, int)> { (i, j) });
                        }
                    }
                }
            }
            return parsedInput;
        }

        private void HandleSetPartOne(KeyValuePair<char, List<(int, int)>> charSet, HashSet<(int, int)> resultHash)
        {
            foreach (var primaryCoordinate in charSet.Value)
            {
                foreach(var secondaryCoordinate in charSet.Value.Where(x => x.Item1 != primaryCoordinate.Item1 && x.Item2 != primaryCoordinate.Item2))
                {
                    var vector = (primaryCoordinate.Item1 - secondaryCoordinate.Item1, primaryCoordinate.Item2 - secondaryCoordinate.Item2);
                    resultHash.Add((primaryCoordinate.Item1 + vector.Item1, primaryCoordinate.Item2 + vector.Item2));
                }
            }
        }

        private void HandleSetPartTwo(KeyValuePair<char, List<(int, int)>> charSet, HashSet<(int, int)> resultHash, int i, int j)
        {
            foreach(var primaryCoordinate in charSet.Value)
            {
                foreach(var secondaryCoordinate in charSet.Value.Where(x => x.Item1 != primaryCoordinate.Item1 && x.Item2 != primaryCoordinate.Item2))
                {
                    var vector = (primaryCoordinate.Item1 - secondaryCoordinate.Item1, primaryCoordinate.Item2 - secondaryCoordinate.Item2);

                    var resonantLocation = (primaryCoordinate.Item1 + vector.Item1, primaryCoordinate.Item2 + vector.Item2);

                    while (resonantLocation.Item1 < i && resonantLocation.Item2 < j && resonantLocation.Item1 >= 0 && resonantLocation.Item2 >= 0)
                    {
                        resultHash.Add(resonantLocation);
                        resonantLocation = (resonantLocation.Item1 + vector.Item1, resonantLocation.Item2 + vector.Item2);
                    }
                }
            }
        }
    }
}
