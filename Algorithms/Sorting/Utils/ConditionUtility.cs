namespace Sorting
{
	public static class ConditionUtility
	{
		public static bool GetCondition<T>(T element1, T element2, SortOrder order) 
			where T : IComparable<T>
		{
			return order.Equals(SortOrder.Ascending) ? element1.CompareTo(element2) > 0 : element1.CompareTo(element2) < 0;
		}
	}
}