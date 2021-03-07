using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;

namespace Otus.AlgoLabs
{
    public class SortingTester
    {
        public bool PerformSingleCheck(string inFilePath, string outFilePath, Func<int[], int[]> algorithm)
        {
            Console.WriteLine($"\r\nPerforming algorithm for files '{inFilePath}' and '{outFilePath}'. ");

            var inputArrayLength = File.ReadLines(inFilePath).First();
            var inputArrayString = File.ReadLines(inFilePath).Skip(1).Single();
            var inputArray = inputArrayString.Split(' ').Select(int.Parse).ToArray();

            var outputArrayString = File.ReadAllText(outFilePath);
            var expectedResult = outputArrayString.Split(' ').Select(int.Parse);

            Console.Write($"Starting to sort {inputArrayLength} element(s). ");
            var watch = new Stopwatch();
            watch.Start();
            var actualResult = algorithm(inputArray);
            watch.Stop();

            Console.WriteLine($"Sorted in {watch.ElapsedMilliseconds}ms.");

            Console.Write("Validating results: ");
            var result = expectedResult.SequenceEqual(actualResult);

            Console.WriteLine($"{(result ? "Success" : "Failure")}.");

            var folderPath = Path.GetFullPath(inFilePath).Replace(Path.GetFileName(inFilePath), string.Empty);
            var resultFileName = Path.Combine(folderPath, $"{Path.GetFileNameWithoutExtension(inFilePath)}.res");

            Console.WriteLine($"Saving result to file '{resultFileName}'.");
            File.WriteAllText(resultFileName, string.Join(' ', actualResult), Encoding.UTF8);

            return result;
        }

        public bool PerformMultipleChecks(string inFolderPath, Func<int[], int[]> algorithm)
        {
            Console.WriteLine($"Performing algorithm for folder '{inFolderPath}'.");

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
