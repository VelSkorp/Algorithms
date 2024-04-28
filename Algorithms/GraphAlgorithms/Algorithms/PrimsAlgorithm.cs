namespace GraphAlgorithms
{
	/// <summary>
	/// Task: Perform a software implementation of finding the minimum spanning tree using the Prim's algorithm.
	/// </summary>
	public class PrimsAlgorithm
	{
		/// <summary>
		/// Finds a minimum spanning tree in the given graph using Prim's algorithm.
		/// </summary>
		/// <param name="graph">The adjacency matrix representation of the graph.</param>
		/// <returns>
		/// A HashSet containing the vertices forming the minimum spanning tree.
		/// </returns>
		public HashSet<int> FindSpanningTree(int[,] graph)
		{
			var size = (int)Math.Sqrt(graph.Length);
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