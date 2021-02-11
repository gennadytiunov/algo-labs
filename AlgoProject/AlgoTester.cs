using System;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace Otus.AlgoLabs
{
    public class AlgoTester
    {
        public bool PerformSingleCheck(string inFilePath, string outFilePath, Func<string, int> algorithm)
        {
            Console.Write($"Running algorithm for file '{inFilePath}' and '{outFilePath}': ");
            
            var inFileText = File.ReadLines(inFilePath).First();
            var outFileText = File.ReadAllText(outFilePath);

            var expectedResult = int.Parse(outFileText);

            var watch = new Stopwatch();
            watch.Start();
            var actualResult = algorithm(inFileText);
            watch.Stop();
            var result = expectedResult == actualResult;

            Console.WriteLine($"{(result ? "Success" : "Failure")} (Input: '{inFileText}'.Actual Result: '{actualResult}'. Expected Result: '{expectedResult}'). Time: {watch.ElapsedMilliseconds}ms.");

            return result;
        }

        public bool PerformSingleCheck(string inFilePath, string outFilePath, Func<int, long> algorithm)
        {
            Console.Write($"Running algorithm for file '{inFilePath}' and '{outFilePath}': ");

            var inFileText = File.ReadLines(inFilePath).First();
            var outFileText = File.ReadAllText(outFilePath);

            var expectedResult = long.Parse(outFileText);

            var inputValue = int.Parse(inFileText);

            var watch = new Stopwatch();
            watch.Start();
            var actualResult = algorithm(inputValue);
            watch.Stop();

            var result = expectedResult == actualResult;

            Console.WriteLine($"{(result ? "Success" : "Failure")} (Input: '{inputValue}'. Actual Result: '{actualResult}'. Expected Result: '{expectedResult}'). Time: {watch.ElapsedMilliseconds}ms.");

            return result;
        }

        public bool PerformMultipleChecks(string inFolderPath, Func<string, int> algorithm)
        {
            Console.WriteLine($"Running algorithm for folder '{inFolderPath}'.");

            var cumulativeResult = true;

            var inFilePaths = Directory.GetFiles(inFolderPath, "*in");
            foreach (var inFile in inFilePaths)
            {
                var inFileName = Path.GetFileName(inFile);

                var inFilePath = Path.Combine(inFolderPath, inFileName);
                var outFilePath = Path.Combine(inFolderPath, $"{Path.GetFileNameWithoutExtension(inFileName)}.out");

                cumulativeResult = PerformSingleCheck(inFilePath, outFilePath, algorithm) && cumulativeResult;
            }

            Console.WriteLine($"Cumulative Result: {(cumulativeResult ? "Success" : "Failure")}.");

            return cumulativeResult;
        }

        public bool PerformMultipleChecks(string inFolderPath, Func<int, long> algorithm)
        {
            Console.WriteLine($"Running algorithm for folder '{inFolderPath}'.");

            var cumulativeResult = true;

            var inFilePaths = Directory.GetFiles(inFolderPath, "*in");
            foreach (var inFile in inFilePaths)
            {
                var inFileName = Path.GetFileName(inFile);

                var inFilePath = Path.Combine(inFolderPath, inFileName);
                var outFilePath = Path.Combine(inFolderPath, $"{Path.GetFileNameWithoutExtension(inFileName)}.out");

                cumulativeResult = PerformSingleCheck(inFilePath, outFilePath, algorithm) && cumulativeResult;
            }

            Console.WriteLine($"Cumulative Result: {(cumulativeResult ? "Success" : "Failure")}.");

            return cumulativeResult;
        }
    }
}
