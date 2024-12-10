using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2024.Helpers
{
    public static class Helper
    {
        public static Dictionary<Direction, (int, int)> Transform = new Dictionary<Direction, (int, int)>
        {
            {Direction.Up, (-1, 0)},
            {Direction.Right, (0, +1)},
            {Direction.Down, (+1, 0)},
            {Direction.Left, (0, -1)}
        };
    }

    public enum Direction
    {
        Up,
        Right,
        Down,
        Left
    }
}
