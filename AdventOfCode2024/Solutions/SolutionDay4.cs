using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2024.Solutions
{
    public class SolutionDay4 : SolutionBase
    {
        public override string ExecuteSolutionPartOne(string[] lines)
        {
            var totalFound = 0;


            for (int x = 0; x < lines.Length; x++)
            {
                for (int y = 0; y < lines[x].Length; y++)
                {
                    if (lines[x][y] == 'X')
                    {
                        totalFound += FindXMAS(lines, x, y);
                    }
                }
            }

            return totalFound.ToString();
        }

        public override string ExecuteSolutionPartTwo(string[] lines)
        {
            var totalFound = 0;


            for(int x = 0; x < lines.Length; x++)
            {
                for(int y = 0; y < lines[x].Length; y++)
                {
                    if(lines[x][y] == 'A')
                    {
                        totalFound += FindCrossedMAS(lines, x, y);
                    }
                }
            }

            return totalFound.ToString();
        }

        private int FindCrossedMAS(string[] lines, int x, int y)
        {
            var xmasCount = 0;
            var dict = GetSurrounding(lines, x, y);
            if (dict.Count != 8)
            {
                return 0;
            }

            if(IsCrossedMas(dict))
            {
                return 1;
            }

            return 0;
        }

        private bool IsCrossedMas(Dictionary<int, char> dict)
        {
            if(dict[1] == 'S' && dict[3] == 'S' && dict[6] == 'M' && dict[8] == 'M')
            {
                return true;
            }
            if(dict[1] == 'M' && dict[3] == 'M' && dict[6] == 'S' && dict[8] == 'S')
            {
                return true;
            }
            if(dict[1] == 'S' && dict[3] == 'M' && dict[6] == 'S' && dict[8] == 'M')
            {
                return true;
            }
            if(dict[1] == 'M' && dict[3] == 'S' && dict[6] == 'M' && dict[8] == 'S')
            {
                return true;
            }

            return false;
        }


        private int FindXMAS(string[] lines, int x, int y)
        {
            var dict = GetSurrounding(lines, x, y);
            if (!dict.Any(x => x.Value == 'M'))
            {
                return 0;
            }

            var xmasCount = 0;

            foreach (var kvp in dict.Where(x => x.Value == 'M'))
            {
                if (GetWord(lines, x, y, kvp.Key) == "XMAS")
                {
                    xmasCount++;
                }
            }

            return xmasCount;
        }

        private string GetWord(string[] lines, int x, int y, int direction)
        {
            var value = "XM";
            for (int i = 1; i <= 2; i++)
            {
                x += Transform[direction].Item1;
                y += Transform[direction].Item2;
                var dict = GetSurrounding(lines, x, y);
                if(!dict.ContainsKey(direction))
                {
                    return value;
                }
                value += dict[direction];
            }

            return value;
        }


        private Dictionary<int, char> GetSurrounding(string[] lines, int x, int y)
        {
            var dict = new Dictionary<int, char>();

            foreach (var kvp in Transform)
            {
                try
                {
                    dict.Add(kvp.Key, lines[x + kvp.Value.Item1][y + kvp.Value.Item2]);
                }
                catch (Exception e)
                {
                    //intentionally empty
                }
            }

            return dict;
        }

        private Dictionary<int, (int, int)> Transform = new Dictionary<int, (int, int)>
        {
            {1, (-1, -1) },
            {2, (-1, 0)},
            {3, (-1, +1)},
            {4, (0, -1)},
            {5, (0, +1)},
            {6, (+1, -1)},
            {7, (+1, 0)},
            {8, (+1, +1)}
        };
    }
}
