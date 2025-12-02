using AdventOfCode.Solutions._2025;
using AdventOfCode2024.Solutions;

namespace AdventOfCode.Helpers
{
    internal class SolutionFactory2025 : ISolutionFactory
    {
        public SolutionBase GetInstance(string day)
        {
            return day switch
            {
                "1" => new SolutionDay1(),
                _ => throw new NotImplementedException(),
            };
        }
    }
}
