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
		public (bool, Stack<int>) EulerPathTest(int[,] graph)
		{
			var eulerPath = new EulerPath();
			var isPath = eulerPath.IsEulerPath(graph, out var startVertex);
			var path = isPath ? eulerPath.FindEulerPathOrCycle(graph, startVertex) : eulerPath.FindEulerPathOrCycle(graph, 0);
			return (isPath, path);
		}

		[Test]
		[TestCaseSource(typeof(GraphsDataClass), nameof(GraphsDataClass.HamiltonPathTestCases))]
		public List<int> HamiltonPathTest(int[,] graph, int from, int to)
		{
			var hamiltonPath = new HamiltonPath();
			return hamiltonPath.FindHamiltonPathOrCycle(graph, from, to);
		}

		[Test]
		[TestCaseSource(typeof(GraphsDataClass), nameof(GraphsDataClass.PrimsAlgorithmTestCases))]
		public HashSet<int> PrimsAlgorithmTest(int[,] graph)
		{
			var primaAlgorithm = new PrimsAlgorithm();
			return primaAlgorithm.FindSpanningTree(graph);
		}
	}
}