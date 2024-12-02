using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2024.Helpers
{
    public static class StringExtension
    {
        public static bool IsNullOrWhitespace(this string value)
        {
            if(value == null) return true;
            if(value.Length == 0) return true;
            if(value.Trim().Length == 0) return true;
            return false;
        }
    }
}
