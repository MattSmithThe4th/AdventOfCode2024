using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2024.Helpers
{
    public static class IOHandler
    {

        public static string[] GetInput(string filename)
        {
            return File.ReadLines("Input/" + filename + ".txt").ToArray();
        }
    }
}
