namespace Sorting
{
	public interface ISort
	{
		public IList<T> Sort<T>(IList<T> array, SortOrder order)
			where T : IComparable<T>;
	}
}
