namespace GraphAlgorithms
{
	/// <summary>
	/// Class implementing Prim's algorithm to find a minimum spanning tree in a graph.
	/// </summary>
	public class PrimsAlgorithm
	{
		/// <summary>
		///     <para>
		///         Finds a minimum spanning tree in the given graph using Prim's algorithm.
		///     </para>
		///     <para>
		///         Time Complexity: O(n^2), where n is the number of vertices in the graph.
		///     </para>
		///     <para>
		///         Space Complexity: O(n), where n is the number of vertices in the graph.
		///     </para>
		/// </summary>
		/// <param name="graph">The adjacency matrix representation of the graph.</param>
		/// <returns>A HashSet containing the vertices forming the minimum spanning tree.</returns>
		public HashSet<int> FindSpanningTree(int[,] graph)
		{
			var size = graph.GetLength(0);
			var tree = new HashSet<int> { 0 };
			var priorityQueue = new PriorityQueue<int, int>();

			while (tree.Count < size)
			{
				var vertex = tree.Last();

				for (var i = 0; i < size; i++)
				{
					if (graph[vertex, i] != 0 && !tree.Contains(i))
					{
						priorityQueue.Enqueue(i, graph[vertex, i]);
					}
				}

				while (tree.Contains(vertex))
				{
					vertex = priorityQueue.Dequeue();
				}

				tree.Add(vertex);
			}

			return tree;
		}
	}
}