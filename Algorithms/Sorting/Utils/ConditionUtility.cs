namespace Sorting
{
	/// <summary>
	/// Static class providing utility methods for handling conditions based on sorting order.
	/// </summary>
	public static class ConditionUtility
	{
		/// <summary>
		/// Determines the condition based on the sorting order for two comparable elements.
		/// </summary>
		/// <typeparam name="T">The type of elements being compared, implementing the IComparable interface.</typeparam>
		/// <param name="element1">The first element to compare.</param>
		/// <param name="element2">The second element to compare.</param>
		/// <param name="order">The sorting order (ascending or descending).</param>
		/// <returns>True if the condition is satisfied based on the sorting order; otherwise, false.</returns>
		public static bool GetCondition<T>(T element1, T element2, SortOrder order)
			where T : IComparable<T>
		{
			return order.Equals(SortOrder.Ascending) ? element1.CompareTo(element2) > 0 : element1.CompareTo(element2) < 0;
		}
	}
}