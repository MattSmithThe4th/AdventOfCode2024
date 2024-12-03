using AdventOfCode2024.Solutions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2024.Helpers
{
    public static class SolutionFactory
    {
        public static SolutionBase GetInstance(string day)
        {
            return day switch
            {
                "1" => new SolutionDay1(),
                "2" => new SolutionDay2(),
                "3" => new SolutionDay3(),
                _ => throw new NotImplementedException($"Day '{day}' has not been implemented")
            };
        }
    }
}
