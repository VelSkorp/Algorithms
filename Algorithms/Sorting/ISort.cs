namespace Sorting
{
	/// <summary>
	/// Interface defining a sorting operation contract.
	/// </summary>
	public interface ISort
	{
		/// <summary>
		/// Sorts the elements in the provided list in the specified order.
		/// </summary>
		/// <typeparam name="T">The type of elements in the list, implementing the IComparable interface.</typeparam>
		/// <param name="array">The list of elements to be sorted.</param>
		/// <param name="order">The order (ascending or descending) in which to sort the elements.</param>
		/// <returns>A list containing the sorted elements.</returns>
		public IList<T> Sort<T>(IList<T> array, SortOrder order)
			where T : IComparable<T>;
	}
}