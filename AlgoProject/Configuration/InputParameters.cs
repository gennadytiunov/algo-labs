using CommandLine;

namespace Otus.AlgoLabs.Configuration
{
    public enum Algorithm
    {
		StringLength,
		SequentialLuckyTicket,
        CombinatorialLuckyTicket,
        InsertionSorting,
        SelectionSorting,
        ShellSortingClassic,
        ShellSortingKnuth,
        ShellSortingCiura,
        HeapSorting
    }

	public class InputParameters
	{
		[Option("algo",
            Required = true,
            HelpText = "\r\nAlgorithm:" +
                       "\r\n - StringLength - string length calculation" +
                       "\r\n - SequentialLuckyTicket - inefficient sequential lucky ticket count calculation" +
                       "\r\n - CombinatorialLuckyTicket - efficient combinatorial lucky ticket count calculation" +
                       "\r\n - InsertionSorting" +
					   "\r\n - SelectionSorting" +
                       "\r\n - ShellSortingClassic - using gap sequence by Donald Shell: N/2, N/4, N/8, ...,  1" +
                       "\r\n - ShellSortingKnuth - using gap sequence by Donald Knuth: (3^k-1)/2 < N/3 (1, 4, 13, 40, 121, ...)" +
                       "\r\n - ShellSortingCiura - using gap sequence by Marcin Ciura (1, 4, 10, 23, 57, 132, 301, 701)" +
                       "\r\n - HeapSorting"
                       )]
		public Algorithm Algorithm { get; set; }

		[Option(
			"tests-folder",
			Required = true,
			HelpText = "Name of folder name with test files")]
		public string TestsFolder { get; set; }
	}
}