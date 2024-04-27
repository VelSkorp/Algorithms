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
			var maximumFlow = new MaximumFlow();
			return maximumFlow.FindMaxFlowAndSaturatedEdges(graph);
		}

		[Test]
		[TestCaseSource(typeof(GraphsDataClass), nameof(GraphsDataClass.EulerPathTestCases))]
		public (bool, string) EulerPathTest(int[,] graph)
		{
			var eulerPath = new EulerPath();
			var isPath = eulerPath.IsEulerPath(graph, out var startVertex);
			var path = isPath ? eulerPath.FindEulerPathOrCycle(graph, startVertex) : eulerPath.FindEulerPathOrCycle(graph, 0);
			return (isPath, string.Join(" ", path));
		}
	}
}