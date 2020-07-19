using System;

namespace Sorting
{
	public class Program
	{
		public static void Main(string[] args)
		{
			int[] v = { 9, 8, 7, 6, 5, 4, 3, 2, 1 };

			ShellSort.Sort(v, v.Length);
			
			for (var i = 0; i < v.Length; i++)
			{
				Console.WriteLine(v[i]);
			}
		}
	}
}