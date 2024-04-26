using GraphAlgorithms;

namespace Tests
{
	[TestFixture]
	public class Graphs
	{
		[Test]
		[TestCaseSource(typeof(GraphsDataClass), nameof(GraphsDataClass.MaximumFlowTestCases))]
		public (string, string) MaximumFlowTest(string[,] graph)
		{
			var maximumFlow = new MaximumFlow(graph);
			return maximumFlow.FindMaxFlowAndSaturatedEdges();
		}
	}
}