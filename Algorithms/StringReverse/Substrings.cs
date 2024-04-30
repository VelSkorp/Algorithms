namespace Strings
{
	/// <summary>
	/// Provides methods for working with substrings.
	/// </summary>
	public static class Substrings
	{
		/// <summary>
		///     <para>
		///         Finds the length of the longest substring without repeating characters in a given string.
		///     </para>
		///     <para>
		///         Time Complexity: O(n), where n is the length of the string.
		///     </para>
		///     <para>
		///         Space Complexity: O(n), where n is the length of the string.
		///     </para>
		/// </summary>
		/// <param name="message">The input string.</param>
		/// <returns>The length of the longest substring without repeating characters.</returns>
		public static int LongestSubstring(string message)
		{
			var result = 0;
			var left = 0;
			var right = 0;
			var substring = new HashSet<char>();

			while (right < message.Length)
			{
				if (substring.Contains(message[right]))
				{
					substring.Remove(message[left++]);
					continue;
				}

				substring.Add(message[right++]);
				result = int.Max(result, substring.Count);
			}

			return result;
		}
	}
}