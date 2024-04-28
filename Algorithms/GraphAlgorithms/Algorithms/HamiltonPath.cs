namespace GraphAlgorithms
{
	/// <summary>
	/// Task: Design a program for finding the Hamiltonian path between two user-specified vertices of an arbitrary undirected graph described by its adjacency matrix
	/// </summary>
	public class HamiltonPath
	{
		/// <summary>
		/// Finds a Hamiltonian path or cycle in the given graph.
		/// </summary>
		/// <param name="graph">The adjacency matrix representation of the graph.</param>
		/// <param name="startVertex">The starting vertex for the path or cycle.</param>
		/// <param name="endVertex">The ending vertex for the path or cycle (only applicable if finding a cycle).</param>
		/// <returns>
		/// A list containing the vertices in the Hamiltonian path or cycle,
		/// or null if no Hamiltonian path or cycle is found.
		/// </returns>
		public List<int> FindHamiltonPathOrCycle(int[,] graph, int startVertex, int endVertex)
		{
			var size = (int)Math.Sqrt(graph.Length);
			var isFindCycle = startVertex == endVertex;
			var path = new List<int>();
			var visited = new HashSet<int>();

			path.Add(startVertex);
			visited.Add(startVertex);

			if (isFindCycle && CountEdge(graph, visited, endVertex) == 1)
			{
				return null;
			}

			for (var i = 1; i < size; i++)
			{
				var nextVertex = GetNextVertex(graph, path, visited, endVertex, i);
				if (nextVertex == -1)
				{
					return null;
				}
				path.Add(nextVertex);
				visited.Add(nextVertex);
			}

			if (isFindCycle)
			{
				var lastVertex = path[size - 1];
				if (graph[lastVertex, startVertex] == 0)
				{
					return null;
				}
				path.Add(endVertex);
			}

			return path;
		}

		/// <summary>
		/// Retrieves the next vertex in the path.
		/// </summary>
		/// <param name="graph">The adjacency matrix representation of the graph.</param>
		/// <param name="path">The current path being constructed.</param>
		/// <param name="visited">The set of visited vertices.</param>
		/// <param name="endVertex">The ending vertex for the path or cycle.</param>
		/// <param name="currentVertexIndex">The index of the current vertex in the path.</param>
		/// <returns>The next vertex in the path, or -1 if no such vertex is found.</returns>
		private int GetNextVertex(int[,] graph, List<int> path, HashSet<int> visited, int endVertex, int currentVertexIndex)
		{
			var size = (int)Math.Sqrt(graph.Length);
			var minCountEdge = int.MaxValue;
			var nextVertex = -1;
			var verticesLeft = size - visited.Count;

			for (var k = 0; k < size; k++)
			{
				if (k == endVertex && verticesLeft != 1)
				{
					continue;
				}
				if (!visited.Contains(k) && graph[path[currentVertexIndex - 1], k] == 1)
				{
					var countEdge = CountEdge(graph, visited, k);
					if (countEdge < minCountEdge)
					{
						minCountEdge = countEdge;
						nextVertex = k;
					}
				}
			}

			return nextVertex;
		}

		/// <summary>
		/// Retrieves the number of unvisited edges for a vertex.
		/// </summary>
		/// <param name="graph">The adjacency matrix representation of the graph.</param>
		/// <param name="visited">The set of visited vertices.</param>
		/// <param name="vertex">The vertex to count unvisited edges for.</param>
		/// <returns>The number of unvisited edges for the vertex.</returns>
		private int CountEdge(int[,] graph, HashSet<int> visited, int vertex)
		{
			var size = (int)Math.Sqrt(graph.Length);
			return Enumerable.Range(0, size).Count(i => graph[vertex, i] != 0 && !visited.Contains(i));
		}
	}
}