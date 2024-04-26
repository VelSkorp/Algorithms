namespace Sorting
{
	public class BubbleSort : ISort
	{
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