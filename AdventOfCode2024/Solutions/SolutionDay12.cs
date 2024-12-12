using AdventOfCode2024.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2024.Solutions
{
    public class SolutionDay12 : SolutionBase
    {
        public override string ExecuteSolutionPartOne(string[] lines)
        {
            var plantGroups = GetAreaCoords(lines);

            return plantGroups.Sum(x => x.PerimiterLength * x.Area).ToString();
        }

        public override string ExecuteSolutionPartTwo(string[] lines)
        {
            throw new NotImplementedException();
        }



        private List<PlantArea> GetAreaCoords(string[] lines)
        {
            var outputList = new List<PlantArea>();

            for (var i = 0; i < lines.Length; i++)
            {
                for (var j = 0; j < lines[i].Length; j++)
                {
                    if (outputList.Any(x => x.Plants.Any(x => x == (i, j))))
                    {
                        continue;
                    }
                    outputList.Add(GetCoordsForOneArea(lines, i, j, lines[i][j]));
                }
            }
            
            return outputList;
        }

        private PlantArea GetCoordsForOneArea(string[] lines, int i, int j, char plant)
        {
            var area = new PlantArea();
            area.Plants.Add((i, j));

            var queue = new Queue<(int, int)>();
            queue.Enqueue((i, j));
            var searched = new HashSet<(int, int)>();
            while (queue.Any())
            {
                var point = queue.Dequeue();
                foreach(var direction in Helper.Transform.Select(x => x.Value))
                {
                    if(searched.Contains((point.Item1 + direction.Item1, point.Item2 + direction.Item2)) || queue.Contains((point.Item1 + direction.Item1, point.Item2 + direction.Item2)))
                    {
                        continue;
                    }
                    try
                    {
                        if(lines[point.Item1 + direction.Item1][point.Item2 + direction.Item2] == plant)
                        {
                            queue.Enqueue((point.Item1 + direction.Item1, point.Item2 + direction.Item2));
                            area.Plants.Add((point.Item1 + direction.Item1, point.Item2 + direction.Item2));
                        } 
                        else
                        {
                            area.PerimiterLength++;
                        }
                    } 
                    catch 
                    {
                        area.PerimiterLength++; 
                    }
                }

                searched.Add(point);
            }

            return area;
        }

        private class PlantArea
        {
            public PlantArea()
            {
                Plants = new HashSet<(int, int)>();
                PerimiterLength = 0;
            }
            public HashSet<(int, int)> Plants { get; set; }
            public int PerimiterLength { get; set; }
            public int Area { get { return Plants.Count; } }
        }
    }
}
