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
	}
}