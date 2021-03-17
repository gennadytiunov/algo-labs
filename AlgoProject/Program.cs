using System;
using System.IO;
using CommandLine;
using Otus.AlgoLabs.Algorithms.Lab1;
using Otus.AlgoLabs.Algorithms.Lab5;
using Otus.AlgoLabs.Configuration;

namespace Otus.AlgoLabs
{
    class Program
    {
        static void Main(string[] args)
        {
            Parser.Default.ParseArguments<InputParameters>(args)
                .WithParsed(
                    inputParameters =>
                    {
                        if (!Directory.Exists(inputParameters.TestsFolder))
                        {
                            Console.WriteLine($"Folder '{inputParameters.TestsFolder}' not found.");
                            Environment.Exit(1);
                        }
                        
                        switch (inputParameters.Algorithm)
                        {
                            case Algorithm.StringLength:
                                new AlgoTester().PerformMultipleChecks(inputParameters.TestsFolder, StringLengthCalculator.Calculate);
                                break;

                            case Algorithm.SequentialLuckyTicket:
                                new AlgoTester().PerformMultipleChecks(inputParameters.TestsFolder, n => new SequentialLuckyTicketCalculator(2 * n).CalculateTicketCount());
                                break;

                            case Algorithm.CombinatorialLuckyTicket:
                                new AlgoTester().PerformMultipleChecks(inputParameters.TestsFolder, n => new CombinatorialLuckyTicketCalculator(2 * n).CalculateTicketCount());
                                break;

                            case Algorithm.InsertionSorting:
                                new SortingTester().PerformMultipleChecks(inputParameters.TestsFolder, array => new InsertionSorter(array).Sort());
                                break;

                            case Algorithm.SelectionSorting:
                                new SortingTester().PerformMultipleChecks(inputParameters.TestsFolder, array => new SelectionSorter(array).Sort());
                                break;

                            case Algorithm.ShellSortingClassic:
                            case Algorithm.ShellSortingKnuth:
                            case Algorithm.ShellSortingCiura:
                                new SortingTester().PerformMultipleChecks(inputParameters.TestsFolder, array => new ShellSorter(array, new ShellGapGenerator(inputParameters.Algorithm, array.Length).Generate()).Sort());
                                break;

                            case Algorithm.HeapSorting:
                                new SortingTester().PerformMultipleChecks(inputParameters.TestsFolder, array => new HeapSorter(array).Sort());
                                break;
                        }

                        Console.WriteLine("Please, press any key.");
                        Console.ReadKey();
                    });
        }
    }
}
