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
					{ 0, 1, 1, 0, 0, 1, 1 },
					{ 1, 0, 1, 0, 0, 0, 0 },
					{ 1, 1, 0, 1, 1, 0, 0 },
					{ 0, 0, 1, 0, 1, 1, 0 },
					{ 0, 0, 1, 1, 0, 1, 1 },
					{ 1, 0, 0, 1, 1, 0, 0 },
					{ 1, 0, 0, 0, 1, 0, 0 },
				}).Returns((true, new Stack<int>([3, 5, 4, 3, 2, 4, 6, 0, 2, 1, 0, 5])));
				yield return new TestCaseData(new int[,]
				{
					{ 0, 1, 0, 0, 0, 1 },
					{ 1, 0, 1, 1, 1, 0 },
					{ 0, 1, 0, 1, 1, 1 },
					{ 0, 1, 1, 0, 1, 1 },
					{ 0, 1, 1, 1, 0, 1 },
					{ 1, 0, 1, 1, 1, 0 }
				}).Returns((false, new Stack<int>([0, 5, 4, 3, 5, 2, 4, 1, 3, 2, 1, 0])));
			}
		}

		public static IEnumerable<TestCaseData> HamiltonPathTestCases
		{
			get
			{
				yield return new TestCaseData(new int[,]
				{
					{ 0, 1, 1, 0, 0, 1, 1 },
					{ 1, 0, 1, 0, 0, 0, 0 },
					{ 1, 1, 0, 1, 1, 0, 0 },
					{ 0, 0, 1, 0, 1, 1, 0 },
					{ 0, 0, 1, 1, 0, 1, 1 },
					{ 1, 0, 0, 1, 1, 0, 0 },
					{ 1, 0, 0, 0, 1, 0, 0 },
				}, 0, 0).Returns(new HashSet<int> { 0, 1, 2, 3, 5, 4, 6, 0 });
				yield return new TestCaseData(new int[,]
				{
					{ 0, 1, 1, 1, 1, 0 },
					{ 1, 0, 0, 0, 0, 0 },
					{ 1, 0, 0, 1, 1, 1 },
					{ 1, 0, 1, 0, 1, 1 },
					{ 1, 0, 1, 1, 0, 1 },
					{ 0, 0, 1, 1, 1, 0 }
				}, 1, 1).Returns(null);
				yield return new TestCaseData(new int[,]
				{
					{ 0, 1, 1, 0, 0, 1, 1 },
					{ 1, 0, 1, 0, 0, 0, 0 },
					{ 1, 1, 0, 1, 1, 0, 0 },
					{ 0, 0, 1, 0, 1, 1, 1 },
					{ 0, 0, 1, 1, 0, 1, 1 },
					{ 1, 0, 0, 1, 1, 0, 0 },
					{ 1, 0, 0, 1, 1, 0, 0 },
				}, 2, 2).Returns(null);
				yield return new TestCaseData(new int[,]
				{
					{ 0, 1, 1, 1, 1, 0 },
					{ 1, 0, 0, 0, 0, 0 },
					{ 1, 0, 0, 1, 1, 1 },
					{ 1, 0, 1, 0, 1, 1 },
					{ 1, 0, 1, 1, 0, 1 },
					{ 0, 0, 1, 1, 1, 0 }
				}, 1, 5).Returns(new HashSet<int> { 1, 0, 2, 3, 4, 5 });
				yield return new TestCaseData(new int[,]
				{
					{ 0, 1, 0, 0, 0, 1 },
					{ 1, 0, 1, 1, 1, 0 },
					{ 0, 1, 0, 1, 1, 1 },
					{ 0, 1, 1, 0, 1, 1 },
					{ 0, 1, 1, 1, 0, 1 },
					{ 1, 0, 1, 1, 1, 0 }
				}, 1, 5).Returns(null);
				yield return new TestCaseData(new int[,]
				{
					{ 0, 1, 0, 0, 0, 1 },
					{ 1, 0, 1, 1, 1, 0 },
					{ 0, 1, 0, 1, 1, 1 },
					{ 0, 1, 1, 0, 1, 1 },
					{ 0, 1, 1, 1, 0, 1 },
					{ 1, 0, 1, 1, 1, 0 }
				}, 0, 5).Returns(new HashSet<int> { 0, 1, 2, 3, 4, 5 });
				yield return new TestCaseData(new int[,]
				{
					{ 0, 1, 0, 0, 0, 1 },
					{ 1, 0, 1, 1, 1, 0 },
					{ 0, 1, 0, 1, 1, 1 },
					{ 0, 1, 1, 0, 1, 1 },
					{ 0, 1, 1, 1, 0, 1 },
					{ 1, 0, 1, 1, 1, 0 }
				}, 1, 3).Returns(new HashSet<int> { 1, 0, 5, 2, 4, 3 });
			}
		}

		public static IEnumerable<TestCaseData> PrimsAlgorithmTestCases
		{
			get
			{
				yield return new TestCaseData(new int[,]
				{
					{ 0, 6, 1, 5, 0, 0 },
					{ 6, 0, 5, 0, 3, 0 },
					{ 1, 5, 0, 5, 6, 4 },
					{ 5, 0, 5, 0, 0, 2 },
					{ 0, 3, 6, 0, 0, 6 },
					{ 0, 0, 4, 2, 6, 0 },
				}).Returns(new HashSet<int> { 0, 2, 5, 3, 1, 4 });
				yield return new TestCaseData(new int[,]
				{
					{ 0, 5 },
					{ 5, 0 }
				}).Returns(new HashSet<int> { 0, 1 });
				yield return new TestCaseData(new int[,]
				{
					{ 0, 1, 2, 0 },
					{ 1, 0, 0, 1 },
					{ 2, 0, 0, 3 },
					{ 0, 1, 3, 0 }
				}).Returns(new HashSet<int> { 0, 1, 3, 2 });
				yield return new TestCaseData(new int[,]
				{
					{ 0, 2, 3, 0, 0 },
					{ 2, 0, 0, 1, 0 },
					{ 3, 0, 0, 4, 0 },
					{ 0, 1, 4, 0, 5 },
					{ 0, 0, 0, 5, 0 }
				}).Returns(new HashSet<int> { 0, 1, 3, 2, 4 });
			}
		}

		public static IEnumerable<TestCaseData> GraphRepresentationBuilderTestCases
		{
			get
			{
				yield return new TestCaseData(new int[,]
				{
					{ 0, 1, 1, 1 },
					{ 1, 0, 1, 1 },
					{ 1, 1, 0, 1 },
					{ 1, 1, 1, 0 }
				}).Returns(
					(
						new int[][]
						{
							[1, 2, 3],
							[0, 2, 3],
							[0, 1, 3],
							[0, 1, 2]
						},
						new HashSet<(int, int)>
						{
							( 0, 1 ),
							( 0, 2 ),
							( 0, 3 ),
							( 1, 2 ),
							( 1, 3 ),
							( 2, 3 )
						},
						new int[,]
						{
							{ 1, 1, 1, 0, 0, 0 },
							{ 1, 0, 0, 1, 1, 0 },
							{ 0, 1, 0, 1, 0, 1 },
							{ 0, 0, 1, 0, 1, 1 }
						}
					));
				yield return new TestCaseData(new int[,]
				{
					{ 0, 1, 0, 0, 0 },
					{ 0, 0, 0, 0, 1 },
					{ 1, 0, 0, 0, 0 },
					{ 0, 0, 1, 0, 0 },
					{ 0, 0, 0, 1, 0 }
				}).Returns(
					(
						new int[][]
						{
							[1],
							[4],
							[0],
							[2],
							[3]
						},
						new HashSet<(int, int)>
						{
							( 0, 1 ),
							( 1, 4 ),
							( 2, 0 ),
							( 3, 2 ),
							( 4, 3 )
						},
						new int[,]
						{
							{ 1, 0, -1, 0, 0 },
							{ -1, 1, 0, 0, 0 },
							{ 0, 0, 1, -1, 0 },
							{ 0, 0, 0, 1, -1 },
							{ 0, -1, 0, 0, 1 }
						}
					));
				yield return new TestCaseData(new int[,]
				{
					{ 0, 0, 1, 0, 1 },
					{ 0, 0, 1, 1, 0 },
					{ 1, 1, 0, 1, 1 },
					{ 1, 1, 0, 0, 0 },
					{ 0, 0, 1, 0, 0 }
				}).Returns(
					(
						new int[][]
						{
							[2, 4],
							[2, 3],
							[0, 1, 3, 4],
							[0, 1],
							[2]
						},
						new HashSet<(int, int)>
						{
							( 0, 2 ),
							( 0, 4 ),
							( 1, 2 ),
							( 1, 3 ),
							( 2, 3 ),
							( 2, 4 ),
							( 3, 0 )
						},
						new int[,]
						{
							{ 1, 1, 0, 0, 0, 0, -1 },
							{ 0, 0, 1, 1, 0, 0, 0 },
							{ 1, 0, 1, 0, 1, 1, 0 },
							{ 0, 0, 0, 1, -1, 0, 1 },
							{ 0, -1, 0, 0, 0, 1, 0 }
						}
					));
			}
		}

		public static IEnumerable<TestCaseData> ReachabilityMatrixPathFinderTestCases
		{
			get
			{
				yield return new TestCaseData(new int[,]
				{
					{ 0, 1, 0, 0, 1, 0, 0 },
					{ 0, 1, 0, 1, 0, 0, 0 },
					{ 0, 0, 0, 1, 0, 0, 0 },
					{ 0, 0, 0, 0, 1, 0, 0 },
					{ 0, 0, 0, 0, 1, 0, 0 },
					{ 0, 0, 1, 0, 0, 0, 1 },
					{ 0, 0, 0, 1, 0, 1, 0 },
				}, 1, 6).Returns(
					(
						new int[,]
						{
							{ 0, 1, 0, 1, 1, 0, 0 },
							{ 0, 1, 0, 1, 1, 0, 0 },
							{ 0, 0, 0, 1, 1, 0, 0 },
							{ 0, 0, 0, 0, 1, 0, 0 },
							{ 0, 0, 0, 0, 1, 0, 0 },
							{ 0, 0, 1, 1, 1, 1, 1 },
							{ 0, 0, 1, 1, 1, 1, 1 }
						}, false
					));
				yield return new TestCaseData(new int[,]
				{
					{ 0, 1, 1, 0 },
					{ 0, 0, 0, 0 },
					{ 0, 1, 0, 1 },
					{ 0, 0, 1, 0 }
				}, 0, 3).Returns(
					(
						new int[,]
						{
							{ 0, 1, 1, 1 },
							{ 0, 0, 0, 0 },
							{ 0, 1, 1, 1 },
							{ 0, 1, 1, 1 }
						}, true
					));
				yield return new TestCaseData(new int[,]
				{
					{ 0, 1, 0, 0, 0 },
					{ 0, 0, 0, 1, 0 },
					{ 0, 1, 0, 0, 0 },
					{ 0, 0, 1, 0, 0 },
					{ 1, 0, 1, 1, 0 }
				}, 0, 4).Returns(
					(
						new int[,]
						{
							{ 0, 1, 1, 1, 0 },
							{ 0, 1, 1, 1, 0 },
							{ 0, 1, 1, 1, 0 },
							{ 0, 1, 1, 1, 0 },
							{ 1, 1, 1, 1, 0 }
						}, false
					));
			}
		}

		public static IEnumerable<TestCaseData> TransposedReachabilityMatrixPathFinderTestCases
		{
			get
			{
				yield return new TestCaseData(new int[,]
				{
					{ 0, 1, 0, 0, 1, 0, 0 },
					{ 0, 1, 0, 1, 0, 0, 0 },
					{ 0, 0, 0, 1, 0, 0, 0 },
					{ 0, 0, 0, 0, 1, 0, 0 },
					{ 0, 0, 0, 0, 1, 0, 0 },
					{ 0, 0, 1, 0, 0, 0, 1 },
					{ 0, 0, 0, 1, 0, 1, 0 },
				}, 1, 6).Returns(
					(
						new int[,]
						{
							{ 0, 0, 0, 0, 0, 0, 0 },
							{ 1, 1, 0, 0, 0, 0, 0 },
							{ 0, 0, 0, 0, 0, 1, 1 },
							{ 1, 1, 1, 0, 0, 1, 1 },
							{ 1, 1, 1, 1, 1, 1, 1 },
							{ 0, 0, 0, 0, 0, 1, 1 },
							{ 0, 0, 0, 0, 0, 1, 1 }
						}, false
					));
				yield return new TestCaseData(new int[,]
				{
					{ 0, 1, 1, 0 },
					{ 0, 0, 0, 0 },
					{ 0, 1, 0, 1 },
					{ 0, 0, 1, 0 }
				}, 0, 3).Returns(
					(
						new int[,]
						{
							{ 0, 0, 0, 0 },
							{ 1, 0, 1, 1 },
							{ 1, 0, 1, 1 },
							{ 1, 0, 1, 1 }
						}, false
					));
				yield return new TestCaseData(new int[,]
				{
					{ 0, 1, 0, 0, 0 },
					{ 0, 0, 0, 1, 0 },
					{ 0, 1, 0, 0, 0 },
					{ 0, 0, 1, 0, 0 },
					{ 1, 0, 1, 1, 0 }
				}, 0, 4).Returns(
					(
						new int[,]
						{
							{ 0, 0, 0, 0, 1 },
							{ 1, 1, 1, 1, 1 },
							{ 1, 1, 1, 1, 1 },
							{ 1, 1, 1, 1, 1 },
							{ 0, 0, 0, 0, 0 }
						}, true
					));
			}
		}
	}
}