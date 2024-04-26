using System.Text;

namespace Strings
{
	public static class StringReverse
	{
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