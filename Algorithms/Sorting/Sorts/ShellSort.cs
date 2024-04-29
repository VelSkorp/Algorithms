namespace Sorting
{
	/// <summary>
	/// Class implementing the shell sort algorithm for sorting elements.
	/// </summary>
	public class ShellSort : ISort
	{
		/// <summary>
		///     <para>
		///         Sorts the elements in the provided list using the shell sort algorithm.
		///     </para>
		///     <para>
		///         Time Complexity: O(n log n), where n is the number of elements in the array.
		///     </para>
		///     <para>
		///         Space Complexity: O(1), sort “in place” by changing the order of elements in the passed array, rather than creating a new array.
		///     </para>
		/// </summary>
		/// <typeparam name="T">The type of elements in the list, implementing the IComparable interface.</typeparam>
		/// <param name="array">The list of elements to be sorted.</param>
		/// <param name="order">The order (ascending or descending) in which to sort the elements.</param>
		/// <returns>A list containing the sorted elements.</returns>
		public IList<T> Sort<T>(IList<T> array, SortOrder order)
			where T : IComparable<T>
		{
			var elementsCount = array.Count;
			for (var gap = elementsCount / 2; gap > 0; gap /= 2)
			{
				for (var i = gap; i < elementsCount; i++)
				{
					for (var j = i - gap; j >= 0 && ConditionUtility.GetCondition(array[j], array[j + gap], order); j -= gap)
					{
						(array[j + gap], array[j]) = (array[j], array[j + gap]);
					}
				}
			}
			return array;
		}
	}
}