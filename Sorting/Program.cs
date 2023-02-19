using System;

namespace Sorting
{
	public class Program
	{
		public static void Main()
		{
			int[] array = { 8, 5, 3, 7, 1, 2, 6, 4, 9 };

			QuickSort.Sort(array, SortOrder.Descending);

			foreach (var item in array)
			{
				Console.WriteLine(item); 
			}
		}
	}
}