using AdventOfCode2024.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2024.Solutions._2024
{
    public class SolutionDay7 : SolutionBase
    {
        public override string ExecuteSolutionPartOne(string[] lines)
        {
            ulong answer = 0;
            foreach (var line in lines)
            {
                var result = Convert.ToUInt64(line.Split(':')[0]);
                var operands = line.Split(":")[1].Split(' ').Where(x => !x.IsNullOrWhitespace()).Select(x => Convert.ToUInt64(x)).ToList();

                var operatorsList = GetAllOperatorPermutations(operands.Count - 1, false);

                foreach (var operators in operatorsList)
                {
                    var calculationResult = Calculate(new List<ulong>(operands), operators);
                    if (calculationResult == result)
                    {
                        answer += calculationResult;
                        break;
                    }
                }
            }

            return answer.ToString();
        }

        private List<List<char>> GetAllOperatorPermutations(int numberOfOperators, bool allThree)
        {
            var result = new List<List<char>>();
            if (allThree)
            {
                GeneratePermutationsTwo(new List<char>(), numberOfOperators, result);
            } 
            else 
            {
                GeneratePermutationsOne(new List<char>(), numberOfOperators, result);
            }
            return result;
        }

        private void GeneratePermutationsOne(List<char> current, int remainingLength, List<List<char>> result)
        {
            if(remainingLength == 0)
            {
                result.Add(new List<char>(current));
                return;
            }

            current.Add('+');
            GeneratePermutationsOne(current, remainingLength - 1, result);
            current.RemoveAt(current.Count - 1);

            current.Add('*');
            GeneratePermutationsOne(current, remainingLength - 1, result);
            current.RemoveAt(current.Count - 1);
        }

        private void GeneratePermutationsTwo(List<char> current, int remainingLength, List<List<char>> result)
        {
            if(remainingLength == 0)
            {
                result.Add(new List<char>(current));
                return;
            }

            current.Add('+');
            GeneratePermutationsTwo(current, remainingLength - 1, result);
            current.RemoveAt(current.Count - 1);

            current.Add('*');
            GeneratePermutationsTwo(current, remainingLength - 1, result);
            current.RemoveAt(current.Count - 1);

            current.Add('|');
            GeneratePermutationsTwo(current, remainingLength - 1, result);
            current.RemoveAt(current.Count - 1);
        }

        private ulong Calculate(List<ulong> operands, List<char> operators)
        {
            operands.Reverse();

            foreach (var op in operators)
            {
                var num1 = operands[operands.Count - 1];
                operands.RemoveAt(operands.Count - 1);
                var num2 = operands[operands.Count - 1];
                operands.RemoveAt(operands.Count - 1);

                var result = op switch
                {
                    '+' => num1 + num2,
                    '*' => num1 * num2,
                    '|' => Convert.ToUInt64($"{num1}{num2}"),
                    _ => throw new ArgumentException("Illegal operator in calculate: " + op)
                };

                operands.Add(result);
            }

            return operands.First();
        }

        public override string ExecuteSolutionPartTwo(string[] lines)
        {
            ulong answer = 0;
            foreach(var line in lines)
            {
                var result = Convert.ToUInt64(line.Split(':')[0]);
                var operands = line.Split(":")[1].Split(' ').Where(x => !x.IsNullOrWhitespace()).Select(x => Convert.ToUInt64(x)).ToList();

                var operatorsList = GetAllOperatorPermutations(operands.Count - 1, true);

                foreach(var operators in operatorsList)
                {
                    var calculationResult = Calculate(new List<ulong>(operands), operators);
                    if(calculationResult == result)
                    {
                        answer += calculationResult;
                        break;
                    }
                }
            }

            return answer.ToString();
        }
    }
}
