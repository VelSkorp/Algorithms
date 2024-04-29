namespace Sorting
{
	/// <summary>
	/// Class implementing the bubble sort algorithm for sorting elements.
	/// </summary>
	public class BubbleSort : ISort
	{
		/// <summary>
		///     <para>
		///         Sorts the elements in the provided list using the bubble sort algorithm.
		///     </para>
		///     <para>
		///         Time Complexity: O(n^2), where n is the number of elements in the array.
		///     </para>
		///     <para>
		///         Space Complexity: O(1), sort “in place” by changing the order of elements in the passed array, rather than creating a new array.
		///     </para>
		/// </summary>
		/// <typeparam name="T">The type of elements in the list, implementing the IComparable interface.</typeparam>
		/// <param name="array">The list of elements to be sorted.</param>
		/// <param name="order">The order (ascending or descending) in which to sort the elements. Default is ascending.</param>
		/// <returns>A list containing the sorted elements.</returns>
		public IList<T> Sort<T>(IList<T> array, SortOrder order = SortOrder.Ascending)
			where T : IComparable<T>
		{
			for (var left = 0; left < array.Count; left++)
			{
				for (var middle = left + 1; middle < array.Count; middle++)
				{
					if (ConditionUtility.GetCondition(array[left], array[middle], order))
					{
						(array[middle], array[left]) = (array[left], array[middle]);
					}
				}
			}
			return array;
		}
	}
}