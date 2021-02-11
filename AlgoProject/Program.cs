using System;
using System.IO;
using CommandLine;
using Otus.AlgoLabs.Algorithms.Lab1;
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
                        
                        var tester = new AlgoTester();

                        switch (inputParameters.Algorithm)
                        {
                            case Algorithm.StringLength:
                                tester.PerformMultipleChecks(inputParameters.TestsFolder, StringLengthCalculator.Calculate);
                                break;

                            case Algorithm.SequentialLuckyTicket:
                                tester.PerformMultipleChecks(inputParameters.TestsFolder, n => new SequentialLuckyTicketCalculator(2 * n).CalculateTicketCount());
                                break;

                            case Algorithm.CombinatorialLuckyTicket:
                                tester.PerformMultipleChecks(inputParameters.TestsFolder, n => new CombinatorialLuckyTicketCalculator(2 * n).CalculateTicketCount());
                                break;
                        }

                        Console.WriteLine("Please, press any key.");
                        Console.ReadKey();
                    });
        }
    }
}
