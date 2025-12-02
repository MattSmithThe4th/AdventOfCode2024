using AdventOfCode2024.Helpers;

namespace AdventOfCode2024.Solutions._2024
{
    public class SolutionDay1 : SolutionBase
    {
        public override string ExecuteSolutionPartOne(string[] lines)
        {
            var list1 = new List<int>();
            var list2 = new List<int>();
            (list1, list2) = SplitInputIntoLists(lines);
            
            list1.Sort();
            list2.Sort();

            var comparisonResultList = new List<int>();

            for (int i = 0; i < list1.Count(); i++)
            {
                var difference = Math.Abs(list1[i] - list2[i]);
                comparisonResultList.Add(difference);
            }

            var total = comparisonResultList.Sum(x => x);



            return total.ToString();
        }

        public override string ExecuteSolutionPartTwo(string[] lines)
        {
            var list1 = new List<int>();
            var list2 = new List<int>();
            (list1, list2) = SplitInputIntoLists(lines);

            var similarityscoreList = new List<int>();
            foreach (var number in list1)
            {
                var occurences = list2.Where(x => x == number).Count();
                similarityscoreList.Add(number * occurences);
            }

            var total = similarityscoreList.Sum(x => x);

            return total.ToString();
        }

        private (List<int>, List<int>) SplitInputIntoLists(string[] lines)
        {
            var list1 = new List<int>();
            var list2 = new List<int>();
            foreach(var line in lines)
            {
                var splitLine = line.Split(' ').Where(x => !x.IsNullOrWhitespace()).ToArray();
                list1.Add(Convert.ToInt32(splitLine[0]));
                list2.Add(Convert.ToInt32(splitLine[1]));
            }
            return (list1, list2);
        }
    }
}
