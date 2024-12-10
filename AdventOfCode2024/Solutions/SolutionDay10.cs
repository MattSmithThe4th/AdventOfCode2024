using AdventOfCode2024.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2024.Solutions
{
    public class SolutionDay10 : SolutionBase
    {
        public override string ExecuteSolutionPartOne(string[] lines)
        {
            var startingLocations = GetStartingLocations(lines);
            var totalTrailheads = 0;

            foreach (var location in startingLocations)
            {
                totalTrailheads += GetNumberOfTrailheads(lines, location);
            }

            return totalTrailheads.ToString();
        }

        public override string ExecuteSolutionPartTwo(string[] lines)
        {
            var startingLocations = GetStartingLocations(lines);
            var trailScore = 0;

            foreach(var location in startingLocations)
            {
                trailScore += GetTrailScore(lines, location);
            }

            return trailScore.ToString();
        }

        private int GetTrailScore(string[] lines, (int, int) start)
        {
            var trailheads = new List<(int, int)>();

            RecursiveFindTrailhead(lines, start, 1, trailheads);

            return trailheads.Count;
        }

        private int GetNumberOfTrailheads(string[] lines, (int, int) start)
        {
            var trailheads = new List<(int, int)>();

            RecursiveFindTrailhead(lines, start, 1, trailheads);

            return trailheads.ToHashSet().Count;
        }

        private void RecursiveFindTrailhead(string[] lines, (int, int) location, int lookFor, List<(int,int)> trailheads)
        {
            if (lookFor == 10)
            {
                trailheads.Add(location);
                return;
            }

            foreach (var vector in Helper.Transform)
            {
                var newLocation = (location.Item1 + vector.Value.Item1, location.Item2 + vector.Value.Item2);
                try
                {
                    if(Convert.ToInt32(lines[newLocation.Item1][newLocation.Item2].ToString()) == lookFor)
                    {
                        RecursiveFindTrailhead(lines, newLocation, lookFor + 1, trailheads);
                    }
                } 
                catch
                {

                }
            }
        }

        private HashSet<(int, int)> GetStartingLocations(string[] lines)
        {
            var startingLocations = new HashSet<(int, int)>();

            for (int i = 0; i < lines.Length; i++)
            {
                for (int j = 0; j < lines[i].Length; j++)
                {
                    if (lines[i][j] == '0')
                    {
                        startingLocations.Add((i, j));
                    }
                }
            }

            return startingLocations;
        }
    }
}
