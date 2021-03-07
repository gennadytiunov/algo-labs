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
					   "\r\n - SelectionSorting")]
		public Algorithm Algorithm { get; set; }

		[Option(
			"tests-folder",
			Required = true,
			HelpText = "Name of folder name with test files")]
		public string TestsFolder { get; set; }
	}
}