using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2024.Solutions
{
    public class SolutionDay11 : SolutionBase
    {
        private Dictionary<(string, int), ulong> _AnswerDict;
        public override string ExecuteSolutionPartOne(string[] lines)
        {
            var line = lines[0].Split(' ').ToList();
            ulong total = 0;
            _AnswerDict = new();

            foreach(var input in line)
            {
                total += DepthFirstSearch(input, 1, 25);
            }

            return total.ToString();
        }

        public override string ExecuteSolutionPartTwo(string[] lines)
        {
            var line = lines[0].Split(' ').ToList();
            ulong total = 0;
            _AnswerDict = new();

            foreach (var input in line)
            {
                total += DepthFirstSearch(input, 1, 75);
            }

            return total.ToString();
        }

        private ulong DepthFirstSearch(string input, int depth, int maxDepth)
        {
            if (depth > maxDepth)
            {
                return 1;
            }
            if(_AnswerDict.ContainsKey((input, depth)))
            {
                return _AnswerDict[(input, depth)];
            }

            if (input == "0")
            {
                var result = DepthFirstSearch("1", depth + 1, maxDepth);
                _AnswerDict.Add((input, depth), result);
                return result;
            }
            else if (input.Length % 2 == 0)
            {
                var left = input.Substring(0, input.Length / 2);
                var right = input.Substring(input.Length / 2);
                if(right.All(x => x == '0'))
                {
                    right = "0";
                } 
                else
                {
                    right = right.TrimStart('0');
                }
                var result = DepthFirstSearch(left, depth + 1, maxDepth) + DepthFirstSearch(right, depth + 1, maxDepth);
                _AnswerDict.Add((input, depth), result);
                return result;
            }
            else
            {
                var result = DepthFirstSearch((Convert.ToUInt64(input) * 2024).ToString(), depth + 1, maxDepth);
                _AnswerDict.Add((input, depth), result);
                return result;
            }
        }
    }
}
