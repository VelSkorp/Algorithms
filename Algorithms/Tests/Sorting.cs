using Sorting;

namespace Tests
{
	[TestFixture]
	[TestFixtureSource(typeof(SortingDataClass), nameof(SortingDataClass.FixtureParams))]
	public class SortingTests
	{
		private readonly ISort sort;

		public SortingTests(ISort sortType)
		{
			sort = sortType;
		}

		[Test]
		[TestCaseSource(typeof(SortingDataClass), nameof(SortingDataClass.TestCases))]
		public IList<T> SortTest<T>(IList<T> array, SortOrder sortOrder)
			where T : IComparable<T>
		{
			return sort.Sort(array, sortOrder);
		}
	}
}