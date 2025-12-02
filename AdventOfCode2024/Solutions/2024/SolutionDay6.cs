using AdventOfCode2024.Helpers;
using System;

namespace AdventOfCode2024.Solutions._2024
{
    public class SolutionDay6 : SolutionBase
    {
        public override string ExecuteSolutionPartOne(string[] lines)
        {
            var guard = GetStartingPosition(lines);
            var passed = new HashSet<(int, int)>();

            while(true)
            {
                passed.Add((guard.X, guard.Y));
                char nextPosition;
                try
                {
                    nextPosition = ReadNext(lines, guard);
                } 
                catch
                {
                    break;
                }

                if (nextPosition == '#')
                {
                    guard.Rotate();
                } 
                else
                {
                    guard.Move();
                }
            }
            
            return passed.Count.ToString();
        }

        public override string ExecuteSolutionPartTwo(string[] lines)
        {
            var result = 0;
            var toCheck = GetCoordinatesCheck(lines);

            for (int i = 0; i < lines.Length; i++)
            {
                for (int j = 0; j < lines[i].Length; j++)
                {
                    if (lines[i][j] == '#' || lines[i][j] == '^' || !toCheck.Contains((i, j)))
                    {
                        continue;
                    }
                    var guard = GetStartingPosition(lines);
                    var passed = new HashSet<(int, int, Direction)>();

                    var newLine = lines[i].ToList();
                    newLine[j] = '#';
                    lines[i] = string.Join(string.Empty, newLine);
                    while(true)
                    {
                        if (passed.Contains(((guard.X, guard.Y, guard.Direction))))
                        {
                            result++;
                            break;
                        }
                        passed.Add((guard.X, guard.Y, guard.Direction));
                        char nextPosition;
                        try
                        {
                            nextPosition = ReadNext(lines, guard);
                        } 
                        catch
                        {
                            break;
                        }

                        if(nextPosition == '#')
                        {
                            guard.Rotate();
                        } 
                        else
                        {
                            guard.Move();
                        }
                    }
                    newLine = lines[i].ToList();
                    newLine[j] = '.';
                    lines[i] = string.Join(string.Empty, newLine);
                }
            }

            return result.ToString();
        }

        private HashSet<(int, int)> GetCoordinatesCheck(string[] lines)
        {
            var guard = GetStartingPosition(lines);
            var passed = new HashSet<(int, int)>();

            while(true)
            {
                passed.Add((guard.X, guard.Y));
                char nextPosition;
                try
                {
                    nextPosition = ReadNext(lines, guard);
                } catch
                {
                    break;
                }

                if(nextPosition == '#')
                {
                    guard.Rotate();
                } else
                {
                    guard.Move();
                }
            }

            return passed;
        }

        private Guard GetStartingPosition(string[] lines)
        {
            int i = 0;
            while (true)
            {
                if(lines[i].Contains('^'))
                {
                    return new Guard(i, lines[i].ToArray().ToList().IndexOf('^'));
                }
                i++;
            }
        }

        private char ReadNext(string[] lines, Guard guard)
        {
            return lines[guard.X + Helper.Transform[guard.Direction].Item1][guard.Y + Helper.Transform[guard.Direction].Item2];
        }

        private class Guard
        {
            public Guard(int x, int y) 
            {
                X = x;
                Y = y;
                Direction = Direction.Up;
            }
            public int X { get; set; }
            public int Y { get; set; }
            public Direction Direction { get; set; }

            public void Rotate()
            {
                Direction = Direction switch
                {
                    Direction.Up => Direction.Right,
                    Direction.Right => Direction.Down,
                    Direction.Down => Direction.Left,
                    Direction.Left => Direction.Up,
                    _ => throw new ArgumentOutOfRangeException()
                };
            }

            public void Move()
            {
                X = X + Helper.Transform[Direction].Item1;
                Y = Y + Helper.Transform[Direction].Item2;
            }
        }
    }
}
