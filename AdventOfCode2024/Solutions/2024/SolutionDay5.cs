using AdventOfCode2024.Helpers;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2024.Solutions._2024
{
    public class SolutionDay5 : SolutionBase
    {
        public override string ExecuteSolutionPartOne(string[] lines)
        {
            var rulesList = GetRulesList(lines);

            // Gets the starting index of the page order lines
            var i = lines.ToList().IndexOf(string.Empty) + 1;

            var result = 0;

            // Do some calculation stuff i guess
            for (; i < lines.Length; i++)
            {
                var splitLine = lines[i].Split(',');
                result += ProcessLine(lines, rulesList, splitLine);
            }

            return result.ToString();
        }

        public override string ExecuteSolutionPartTwo(string[] lines)
        {
            var rulesList = GetRulesList(lines);

            // Gets the starting index of the page order lines
            var i = lines.ToList().IndexOf(string.Empty) + 1;

            var wrongLines = new List<string>();

            for(; i < lines.Length; i++)
            {
                var splitLine = lines[i].Split(',');
                if (ProcessLine(lines, rulesList, splitLine) == 0)
                {
                    wrongLines.Add(lines[i]);
                }
            }
            var result = 0;

            foreach (var line in wrongLines)
            {
                var pages = new HashSet<string>(line.Split(","));
                var resultList = new List<string>();

                while (pages.Count > 1)
                {
                    var relevantRules = rulesList.Where(x => pages.Contains(x.Item1) && pages.Contains(x.Item2)).ToList();
                    var endRule = relevantRules.Where(x => !relevantRules.Select(x => x.Item2).Contains(x.Item1)).FirstOrDefault();
                    resultList.Add(endRule.Item1);
                    pages.Remove(endRule.Item1);
                }

                resultList.Add(pages.First());

                result += Convert.ToInt32(resultList[resultList.Count() / 2]);
            }

            return result.ToString();
        }

        private List<(string, string)> GetRulesList(string[] lines)
        {
            var rulesList = new List<(string, string)>();
            var i = 0;
            var line = lines[i];

            while(!line.IsNullOrWhitespace())
            {
                var splitLine = line.Split('|');
                rulesList.Add((splitLine[0], splitLine[1]));

                i++;
                line = lines[i];
            }

            return rulesList;
        }

        private int ProcessLine(string[] lines, List<(string, string)> rulesList, string[] splitLine)
        {
            var passed = new HashSet<string>();
            for(int i = 0; i < splitLine.Length; i++)
            {
                var current = splitLine[i];
                passed.Add(current);
                var applicapleRules = rulesList.Where(x => x.Item1 == current).ToList();
                if(!applicapleRules.Any())
                {
                    continue;
                }
                if (applicapleRules.Any(x => passed.Contains(x.Item2)))
                {
                    return 0;
                }
            }

            return Convert.ToInt32(splitLine[splitLine.Length / 2]);
        }
    }
}
