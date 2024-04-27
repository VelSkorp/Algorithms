﻿namespace Tests
{
	public class GraphsDataClass
	{
		public static IEnumerable<TestCaseData> MaximumFlowTestCases
		{
			get
			{
				yield return new TestCaseData(new string[,]
				{
					{ "0/0", "8/0", "0/0", "0/0", "4/0", "7/0", "0/0" },
					{ "8/0", "0/0", "4/0", "0/0", "0/0", "4/0", "0/0" },
					{ "0/0", "4/0", "0/0", "0/0", "0/0", "0/0", "7/0" },
					{ "0/0", "0/0", "0/0", "0/0", "9/0", "0/0", "5/0" },
					{ "4/0", "0/0", "0/0", "9/0", "0/0", "6/0", "0/0" },
					{ "7/0", "4/0", "0/0", "0/0", "6/0", "0/0", "9/0" },
					{ "0/0", "0/0", "7/0", "5/0", "0/0", "9/0", "0/0" },
				}).Returns(("7 + 4 + 7 = 4 + 5 + 9 = 18", "1-5, 1-6, 2-3, 4-7, 6-7"));
				yield return new TestCaseData(new string[,]
				{
					{ "0/0", "0/0", "0/0", "0/0", "0/0", "0/0", "0/0" },
					{ "0/0", "0/0", "0/0", "0/0", "0/0", "0/0", "0/0" },
					{ "0/0", "0/0", "0/0", "0/0", "0/0", "0/0", "0/0" },
					{ "0/0", "0/0", "0/0", "0/0", "0/0", "0/0", "0/0" },
					{ "0/0", "0/0", "0/0", "0/0", "0/0", "0/0", "0/0" },
					{ "0/0", "0/0", "0/0", "0/0", "0/0", "0/0", "0/0" },
					{ "0/0", "0/0", "0/0", "0/0", "0/0", "0/0", "0/0" },
				}).Returns(("0 = 0 = 0", string.Empty));
				yield return new TestCaseData(new string[,]
				{
					{ "0/0", "9/0", "0/0", "0/0", "0/0" },
					{ "9/0", "0/0", "5/0", "8/0", "0/0" },
					{ "0/0", "5/0", "0/0", "9/0", "5/0" },
					{ "0/0", "8/0", "9/0", "0/0", "7/0" },
					{ "0/0", "0/0", "5/0", "7/0", "0/0" }
				}).Returns(("9 = 4 + 5 = 9", "1-2, 2-3"));
			}
		}

		public static IEnumerable<TestCaseData> EulerPathTestCases
		{
			get
			{
				yield return new TestCaseData(new int[,]
				{
					{ 0, 1, 1, 0, 0, 1, 1, },
					{ 1, 0, 1, 0, 0, 0, 0, },
					{ 1, 1, 0, 1, 1, 0, 0, },
					{ 0, 0, 1, 0, 1, 1, 0, },
					{ 0, 0, 1, 1, 0, 1, 1, },
					{ 1, 0, 0, 1, 1, 0, 0, },
					{ 1, 0, 0, 0, 1, 0, 0, },
				}).Returns((true, "5 0 1 2 0 6 4 2 3 4 5 3"));
				yield return new TestCaseData(new int[,]
				{
					{ 0, 1, 0, 0, 0, 1 },
					{ 1, 0, 1, 1, 1, 0 },
					{ 0, 1, 0, 1, 1, 1 },
					{ 0, 1, 1, 0, 1, 1 },
					{ 0, 1, 1, 1, 0, 1 },
					{ 1, 0, 1, 1, 1, 0 }
				}).Returns((false, "0 1 2 3 1 4 2 5 3 4 5 0"));

			}
		}
	}
}