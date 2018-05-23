using System;
using System.Collections.Generic;

namespace Binary_Puzzle_Proof
{
    
    class Program
    {
        const short puzzleSize = 12;
        static Boolean[,] puzzle = new Boolean[puzzleSize, puzzleSize];


        static void Main(string[] args)
        {
            Console.WriteLine("Number of valid binary numbers for a puzzle size of " + puzzleSize + ": " + getAllValidNumbers().Count);
            Console.ReadKey();
        }

        static string visualizeMatrix(Boolean[,] matrix)
        {
            string visual = "";
            for(int y = 0; y < puzzleSize; y++)
            {
                for(int x = 0; x < puzzleSize; x++)
                {

                    visual += Convert.ToInt32(matrix[x, y]) + " ";
                    if (x == 5)
                        visual += "\n";
                }
            }
            return visual;
        }

        static Boolean[,] GeneratePuzzle()
        {
            Boolean[,] puzzle = new Boolean[puzzleSize,puzzleSize];
            return puzzle;
        }

        static List<string> getAllValidNumbers()
        {
            List<string> validNums = new List<string>();
            for (int x = 0; x < Math.Pow(2, Convert.ToDouble(puzzleSize)); x++)
            {
                string lineToWrite = Convert.ToString(x, 2);
                if (lineToWrite.Length < puzzleSize)
                    lineToWrite = lineToWrite.PadLeft(puzzleSize, '0');
                if (validateBinaryNumberString(lineToWrite))
                    validNums.Add(lineToWrite);
            }

            return validNums;
        }

        static bool validateBinaryNumberString(string num)
        {
            if (num.Length != puzzleSize)
                throw new Exception("You sent me a string that isn't the write length for the puzzle.....");

            //check for trips
            if (num.Contains("111") || num.Contains("000"))
                return false;

            //check parity(kinda?)
            if ((num.Length - num.Replace("0", "").Length) != puzzleSize / 2 && (num.Length - num.Replace("1", "").Length) != puzzleSize / 2)
                return false;


            //check for trips
            //for (int x = 2; x < puzzleSize-1; x++)
            //{
            //    
            //    if (x < puzzleSize-2)
            //        if (num[x] == num[x + 1] && num[x] == num[x + 2])
            //            return false;
            //}

            return true;
        }
    }
}
