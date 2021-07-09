using System;
using System.Diagnostics;

namespace Otus.AlgoLabs.Algorithms.Lab8
{
	public class HashTableTestHelper
	{
		public static void AddElements(
			HashTable<string, string> table,
			int n,
			Random random)
		{
			Console.WriteLine($"Starting to add {n} random elements.");
			
			var watch = new Stopwatch();
			watch.Start();

			for (int i = 0; i < n - 1; i++)
			{
				var element = random.Next(0, n - 1).ToString();
				table.Put(element, element);
			}

			watch.Stop();

			Console.WriteLine($"Adding {n} random elements completed in {watch.ElapsedMilliseconds}ms.");
		}

		public static void SearchElements(
			HashTable<string, string> table,
			int n,
			Random random)
		{
			Console.WriteLine($"Starting to search {n} random elements.");

			var watch = new Stopwatch();
			watch.Start();

			for (int i = 0; i < n - 1; i++)
			{
				var element = random.Next(0, n - 1).ToString();
				table.Get(element);
			}

			watch.Stop();

			Console.WriteLine($"Searching {n} random elements completed in {watch.ElapsedMilliseconds}ms.");
		}

		public static void DeleteElements(
			HashTable<string, string> table,
			int n,
			Random random)
		{
			Console.WriteLine($"Starting to delete {n} random elements.");

			var watch = new Stopwatch();
			watch.Start();

			var elementsToRemoved = n / 10;
			for (int i = 0; i < elementsToRemoved; i++)
			{
				var element = random.Next(0, n - 1).ToString();
				table.Delete(element);
			}

			watch.Stop();

			Console.WriteLine($"Deleting {n} random elements completed in {watch.ElapsedMilliseconds}ms.");
		}
	}
}