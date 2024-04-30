using Strings;

namespace Tests
{
	[TestFixture]
	public class StringsTests
	{
		[Test]
		[TestCase("Hello world!", "!dlrow olleH")]
		[TestCase("String Reverse Test", "tseT esreveR gnirtS")]
		public void StringReverseTest(string message, string expected)
		{
			var actual = StringReverse.Reverse(message);

			Assert.That(actual, Is.EqualTo(expected));
		}

		[Test]
		[TestCase("abcbada", 4)]
		[TestCase("axbxcxd", 3)]
		[TestCase("aaaaaaa", 1)]
		[TestCase("abcdefg", 7)]
		public void LongestSubstringTest(string message, int expected)
		{
			var actual = Substrings.LongestSubstring(message);

			Assert.That(actual, Is.EqualTo(expected));
		}
	}
}