using System;
using System.IO;
using CommandLine;
using Otus.AlgoLabs.Algorithms.Lab1;
using Otus.AlgoLabs.Algorithms.Lab5;
using Otus.AlgoLabs.Algorithms.Lab8;
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

                            case Algorithm.HashTableChains:
								new ActionRunner().Run(() =>
								{
                                    var random = new Random();
                                    for (var n = 10; n <= Math.Pow(10, 7); n *= 10)
                                    {
	                                    var table = new HashTable<string, string>();
                                        HashTableTestHelper.AddElements(table, n, random);
	                                    HashTableTestHelper.SearchElements(table, n, random);
	                                    HashTableTestHelper.DeleteElements(table, n, random);

	                                    Console.WriteLine();
                                    }
                                });
	                            break;
                        }

                        Console.WriteLine("Please, press any key.");
                        Console.ReadKey();
                    });
        }
    }
}
