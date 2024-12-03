using AdventOfCode2024.Helpers;

namespace AdventOfCode2024.Solutions
{
    public class SolutionDay2 : SolutionBase
    {
        public override string ExecuteSolutionPartOne(string[] lines)
        {
            var result = 0;
            foreach (var line in lines)
            {
                var splitLine = line.Split(' ').Where(x => !x.IsNullOrWhitespace()).Select(x => Convert.ToInt32(x)).ToArray();
                if(RecursiveSafetyCheck(splitLine, 0, splitLine[0] < splitLine[1]))
                {
                    result++;
                }
            }

            return result.ToString();
        }

        public override string ExecuteSolutionPartTwo(string[] lines)
        {
            var result = 0;
            foreach(var line in lines)
            {
                var splitLine = line.Split(' ').Where(x => !x.IsNullOrWhitespace()).Select(x => Convert.ToInt32(x)).ToArray();
                if(RecursiveSafetyCheck(splitLine, 0, splitLine[0] < splitLine[1]))
                {
                    result++;
                }
                else if(AreEnoughVersionsSafe(splitLine))
                {
                    result++;
                }
            }

            return result.ToString();
        }


        private bool RecursiveSafetyCheck(int[] splitLine, int currentIndex, bool ascending)
        {
            if(currentIndex == splitLine.Length - 1)
            {
                return true;
            }
            var currentValue = splitLine[currentIndex];
            var nextValue = splitLine[currentIndex + 1];

            if (currentValue == nextValue)
            {
                return false;
            }
            if ((ascending && currentValue > nextValue) || (!ascending && currentValue < nextValue))
            {
                return false;
            }
            if (Math.Abs(currentValue - nextValue) > 3)
            {
                return false;
            }
            
            return RecursiveSafetyCheck(splitLine, currentIndex + 1, ascending);
        }

        private bool AreEnoughVersionsSafe(int[] splitLine)
        {
            var success = 0;
            for (int i = 0; i < splitLine.Length; i++)
            {
                var asList = splitLine.ToList();
                asList.RemoveAt(i);
                if (RecursiveSafetyCheck(asList.ToArray(), 0, asList[0] < asList[1]))
                {
                    success++;
                }
            }
            return success != 0;
        }
    }
}
