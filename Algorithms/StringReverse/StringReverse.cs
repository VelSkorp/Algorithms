using System.Text;

namespace Strings
{
	/// <summary>
	/// Static class for string reversal operations.
	/// </summary>
	public static class StringReverse
	{
		/// <summary>
		///     <para>
		///         Reverses the characters in a given string.
		///     </para>
		///     <para>
		///         Time Complexity: O(n), where n is the length of the string.
		///     </para>
		///     <para>
		///         Space Complexity: O(n), where n is the length of the original string.
		///     </para>
		/// </summary>
		/// <param name="message">The input string to be reversed.</param>
		/// <returns>The reversed string.</returns>
		public static string Reverse(string message)
		{
			var builder = new StringBuilder();

			for (var i = 1; i <= message.Length; i++)
			{
				builder.Append(message[^i]);
			}

			return builder.ToString();
		}
	}
}