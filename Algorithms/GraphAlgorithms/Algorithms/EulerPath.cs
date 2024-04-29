namespace GraphAlgorithms
{
	/// <summary>
	/// Class for finding Euler paths or cycles in a graph represented by an adjacency matrix.
	/// </summary>
	public class EulerPath
	{
		/// <summary>
		///     <para>
		///         Finds an Euler path or cycle starting from a specified vertex in a given graph represented as an adjacency matrix.
		///     </para>
		///     <para>
		///         Time Complexity: O(n^2), where n is the number of vertices in the graph.
		///     </para>
		///     <para>
		///         Space Complexity: O(n), where n is the number of vertices in the graph.
		///     </para>
		/// </summary>
		/// <param name="graph">Adjacency matrix representing the graph.</param>
		/// <param name="currVertex">The current vertex to start the path from.</param>
		/// <returns>A stack containing the vertices of the Euler path or cycle.</returns>
		public Stack<int> FindEulerPathOrCycle(int[,] graph, int currVertex)
		{
			var size = graph.GetLength(0);
			var stack = new Stack<int>();
			var path = new Stack<int>();

			stack.Push(currVertex);

			while (stack.Count != 0)
			{
				currVertex = stack.Peek();

				var nextVertex = 0;

				while (nextVertex < size)
				{
					if (graph[currVertex, nextVertex] == 1)
					{
						break;
					}
					nextVertex++;
				}

				if (nextVertex < size)
				{
					stack.Push(nextVertex);

					graph[currVertex, nextVertex] = 0;
					graph[nextVertex, currVertex] = 0;
				}
				else
				{
					path.Push(stack.Pop());
				}
			}

			return path;
		}

		/// <summary>
		///     <para>
		///         Checks if there exists an Euler path in the given graph and identifies the odd vertex, if any.
		///     </para>
		///     <para>
		///         Time Complexity: O(n^2), where n is the number of vertices in the graph.
		///     </para>
		///     <para>
		///         Space Complexity: O(1), doesn't create additional data structures.
		///     </para>
		/// </summary>
		/// <param name="graph">Adjacency matrix representing the graph.</param>
		/// <param name="oddVertex">Output parameter to store the odd vertex if an Euler path exists.</param>
		/// <returns>True if an Euler path exists, otherwise false.</returns>
		public bool IsEulerPath(int[,] graph, out int oddVertex)
		{
			var size = graph.GetLength(0);
			var vertexOddEdges = 0;

			oddVertex = -1;

			for (var i = 0; i < size; i++)
			{
				var countEdge = 0;
				for (var j = 0; j < size; j++)
				{
					if (graph[i, j] != 0)
					{
						countEdge++;
					}
				}

				if (countEdge % 2 != 0)
				{
					vertexOddEdges++;
					oddVertex = i;
				}
			}

			return vertexOddEdges == 2;
		}
	}
}