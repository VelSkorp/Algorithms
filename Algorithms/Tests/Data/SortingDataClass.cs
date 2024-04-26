using Sorting;

namespace Tests
{
	public class SortingDataClass
	{
		public static IEnumerable<TestFixtureData> FixtureParams
		{
			get
			{
				yield return new TestFixtureData(new BubbleSort());
				yield return new TestFixtureData(new CocktailSort());
				yield return new TestFixtureData(new QuickSort());
				yield return new TestFixtureData(new ShellSort());
			}
		}

		public static IEnumerable<TestCaseData> TestCases
		{
			get
			{
				yield return new TestCaseData(new int[] { 8, 5, 3, 7, 1, 2, 6, 4, 9 }, SortOrder.Ascending).Returns(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 });
				yield return new TestCaseData(new int[] { 8, 5, 3, 7, 1, 2, 6, 4, 9 }, SortOrder.Descending).Returns(new int[] { 9, 8, 7, 6, 5, 4, 3, 2, 1 });
				yield return new TestCaseData(new string[] { "Hello", "World", "!" }, SortOrder.Ascending).Returns(new string[] { "!", "Hello", "World" });
				yield return new TestCaseData(new string[] { "Hello", "World", "!" }, SortOrder.Descending).Returns(new string[] { "World", "Hello", "!" });
			}
		}
	}
}