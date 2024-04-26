namespace Sorting
{
	public class QuickSort : ISort
	{
		public IList<T> Sort<T>(IList<T> array, SortOrder order)
			where T : IComparable<T>
		{
			return QuickSortImpl(array, 0, array.Count - 1, order);
		}

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