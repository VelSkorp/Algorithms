namespace Sorting
{
	/// <summary>
	/// Class implementing the quick sort algorithm for sorting elements.
	/// </summary>
	public class QuickSort : ISort
	{
		/// <summary>
		///     <para>
		///         Sorts the elements in the provided list using the quick sort algorithm.
		///     </para>
		///     <para>
		///         Time Complexity: Worst O(n^2), average and best O(n log n), where n is the number of elements in the array.
		///     </para>
		///     <para>
		///         Space Complexity: O(log n), where n is the number of elements in the array, due to recursive calls.
		///     </para>
		/// </summary>
		/// <typeparam name="T">The type of elements in the list, implementing the IComparable interface.</typeparam>
		/// <param name="array">The list of elements to be sorted.</param>
		/// <param name="order">The order (ascending or descending) in which to sort the elements.</param>
		/// <returns>A list containing the sorted elements.</returns>
		public IList<T> Sort<T>(IList<T> array, SortOrder order)
			where T : IComparable<T>
		{
			return QuickSortImpl(array, 0, array.Count - 1, order);
		}

		/// <summary>
		///     <para>
		///         Internal method to implement the quick sort algorithm recursively.
		///     </para>
		///     <para>
		///         Time Complexity: Worst O(n^2), average and best O(n log n), where n is the number of elements in the array.
		///     </para>
		///     <para>
		///         Space Complexity: O(log n), where n is the number of elements in the array, due to recursive calls.
		///     </para>
		/// </summary>
		/// <typeparam name="T">The type of elements in the list, implementing the IComparable interface.</typeparam>
		/// <param name="array">The list of elements to be sorted.</param>
		/// <param name="left">The left index of the sub-array to be sorted.</param>
		/// <param name="right">The right index of the sub-array to be sorted.</param>
		/// <param name="order">The order (ascending or descending) in which to sort the elements.</param>
		/// <returns>A list containing the sorted elements.</returns>
		private IList<T> QuickSortImpl<T>(IList<T> array, int left, int right, SortOrder order)
			where T : IComparable<T>
		{
			if (left < right)
			{
				var q = Partition(array, left, right, order);
				QuickSortImpl(array, left, q - 1, order);
				QuickSortImpl(array, q + 1, right, order);
			}
			return array;
		}

		/// <summary>
		///     <para>
		///         Method to partition the array and return the pivot index.
		///     </para>
		///     <para>
		///         Time Complexity: O(n), where n is the number of elements in the array.
		///     </para>
		///     <para>
		///         Space Complexity: O(1), does not create additional data structures.
		///     </para>
		/// </summary>
		/// <typeparam name="T">The type of elements in the list, implementing the IComparable interface.</typeparam>
		/// <param name="array">The list of elements to be sorted.</param>
		/// <param name="left">The left index of the sub-array to be partitioned.</param>
		/// <param name="right">The right index of the sub-array to be partitioned.</param>
		/// <param name="order">The order (ascending or descending) in which to sort the elements.</param>
		/// <returns>The pivot index.</returns>
		private int Partition<T>(IList<T> array, int left, int right, SortOrder order)
			where T : IComparable<T>
		{
			var x = array[right];
			var less = left;

			for (var i = left; i < right; i++)
			{
				if (ConditionUtility.GetCondition(x, array[i], order))
				{
					(array[less], array[i]) = (array[i], array[less]);
					less++;
				}
			}
			(array[right], array[less]) = (array[less], array[right]);
			return less;
		}
	}
}