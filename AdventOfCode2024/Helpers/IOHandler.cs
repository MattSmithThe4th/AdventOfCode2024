
namespace AdventOfCode2024.Helpers
{
    public static class IOHandler
    {

        public static string[] GetInput(string year, string filename)
        {
            return File.ReadLines($"Input/{year}/{filename}.txt").ToArray();
        }
    }
}
