
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
