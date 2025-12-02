using AdventOfCode2024.Solutions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Helpers
{
    internal interface ISolutionFactory
    {
        SolutionBase GetInstance(string day);
    }
}
