using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2024.Solutions._2024
{
    public class SolutionDay9 : SolutionBase
    {
        public override string ExecuteSolutionPartOne(string[] lines)
        {
            var disk = ParseInput(lines);

            var occupiedCount = disk.Where(x => x != -1).Count();

            for (int i = disk.Length - 1; i >= occupiedCount; i--)
            {
                var value = disk[i];
                if (value == -1)
                {
                    continue;
                }

                for (int j = 0; j < disk.Length; j++)
                {
                    if (disk[j] == -1)
                    {
                        disk[j] = value;
                        break;
                    }
                }

                disk[i] = -1;
            }

            return CalculateChecksum(disk).ToString();
        }

        public override string ExecuteSolutionPartTwo(string[] lines)
        {
            var diskMap = new List<Block>();
            var isData = true;
            var numberId = 0;

            foreach(var c in lines[0])
            {
                var number = Convert.ToInt32(c.ToString());

                diskMap.Add(new Block(isData ? numberId : 0, number, isData));

                if(isData)
                {
                    numberId++;
                }

                isData = !isData;
            }
            
            for (int i = diskMap.Count - 1; i >= 0; i--)
            {
                var value = diskMap[i];

                for (int j = 0; j < diskMap.Count; j++)
                {
                    if (j == i)
                    {
                        break;
                    }
                    if(!diskMap[j].IsData && diskMap[j].BlockSize == value.BlockSize)
                    {
                        diskMap[i] = diskMap[j];
                        diskMap[j] = value;
                        AddupEmptySpace(diskMap);
                        break;
                    }
                    else if (!diskMap[j].IsData && diskMap[j].BlockSize > value.BlockSize)
                    {
                        var extraSpace = diskMap[j].BlockSize - value.BlockSize;
                        diskMap[i] = diskMap[j];
                        diskMap[i].BlockSize = value.BlockSize;
                        diskMap[j] = value;
                        diskMap.Insert(j + 1, new Block(0, extraSpace, false));
                        i++;
                        AddupEmptySpace(diskMap);
                        break;
                    }
                }
            }

            var disk = new List<int>();

            foreach (var block in diskMap)
            {
                for (int i = 0; i < block.BlockSize; i++)
                {
                    disk.Add(block.BlockId);
                }
            }


            return CalculateChecksum(disk.ToArray()).ToString();
        }

        private int[] ParseInput(string[] lines)
        {
            var array = new List<int>();
            var data = true;
            var numberId = 0;

            foreach (var c in lines[0])
            {
                var number = Convert.ToInt32(c.ToString());

                for (var i = 0; i < number; i++)
                {
                    array.Add(data ? numberId : -1);
                }

                if(data)
                {
                    numberId++;
                }

                data = !data;
            }

            return array.ToArray();
        }

        private void AddupEmptySpace(List<Block> diskMap)
        {
            for (int i = 0; i < diskMap.Count - 1; i++)
            {
                var current = diskMap[i];
                var next = diskMap[i + 1];

                if(!current.IsData && !next.IsData)
                {
                    current.BlockSize += next.BlockSize;
                    next.BlockSize = 0;
                }
            }
        }

        private ulong CalculateChecksum(int[] disk)
        {
            ulong checksum = 0;

            for(int i = 0; i < disk.Length; i++)
            {
                if(disk[i] == -1)
                {
                    continue;
                }

                checksum += (ulong)disk[i] * (ulong)i;
            }
            return checksum;
        }

        private class Block
        {
            public Block(int blockId, int blockSize, bool isData) 
            {
                BlockId = blockId;
                BlockSize = blockSize;
                IsData = isData;
            }
            public int BlockId { get; set; }
            public int BlockSize { get; set; }
            public bool IsData { get; set; }
        }
    }
}
