﻿using AdventOfCode2024.Solutions;

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
                "4" => new SolutionDay4(),
                "5" => new SolutionDay5(),
                "6" => new SolutionDay6(),
                "7" => new SolutionDay7(),
                "8" => new SolutionDay8(),
                "9" => new SolutionDay9(),
                "10" => new SolutionDay10(),
                "11" => new SolutionDay11(),
                "12" => new SolutionDay12(),
                _ => throw new NotImplementedException($"Day '{day}' has not been implemented")
            };
        }
    }
}
