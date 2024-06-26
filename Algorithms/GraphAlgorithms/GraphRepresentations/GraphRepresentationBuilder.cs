﻿namespace GraphAlgorithms
{
	/// <summary>
	/// Class for constructing various graph representations from an adjacency matrix.
	/// </summary>
	public class GraphRepresentationBuilder
	{
		/// <summary>
		///     <para>
		///         Builds an adjacency list representation of the graph from its adjacency matrix.
		///     </para>
		///     <para>
		///         Time Complexity: O(n^2), where n is the number of vertices in the graph.
		///     </para>
		///     <para>
		///         Space Complexity: O(n + m), where n is the number of vertices in the graph, m is the number of edges.
		///     </para>
		/// </summary>
		/// <param name="graph">The adjacency matrix representation of the graph.</param>
		/// <returns>An array of arrays representing the adjacency list for each vertex.</returns>
		public int[][] BuildAdjacencyList(int[,] graph)
		{
			var size = graph.GetLength(0);
			var adjacencyList = new int[size][];

			for (var i = 0; i < size; i++)
			{
				var neighbors = new List<int>();
				for (var j = 0; j < size; j++)
				{
					if (graph[i, j] != 0)
					{
						neighbors.Add(j);
					}
				}
				adjacencyList[i] = neighbors.ToArray();
			}
			return adjacencyList;
		}

		/// <summary>
		///     <para>
		///         Finds the incident edges of the graph from its adjacency list.
		///     </para>
		///     <para>
		///         Time Complexity: O(n * m), where n is the number of vertices in the graph, m is the average number of edges incident to each vertex.
		///     </para>
		///     <para>
		///         Space Complexity: O(n + m), where n is the number of vertices in the graph, m is the number of incident edges.
		///     </para>
		/// </summary>
		/// <param name="adjacencyList">The adjacency list representation of the graph.</param>
		/// <returns>A HashSet containing tuples representing incident edges.</returns>
		public HashSet<(int, int)> FindIncidentEdges(int[][] adjacencyList)
		{
			var incidentEdges = new HashSet<(int, int)>();
			for (var i = 0; i < adjacencyList.Length; i++)
			{
				for (var j = 0; j < adjacencyList[i].Length; j++)
				{
					var edge = (i, adjacencyList[i][j]);
					var reverseEdge = (adjacencyList[i][j], i);

					if (!incidentEdges.Contains(reverseEdge))
					{
						incidentEdges.Add(edge);
					}
				}
			}
			return incidentEdges;
		}

		/// <summary>
		///     <para>
		///         Builds an incidence matrix representation of the graph from its adjacency matrix and incident edges.
		///     </para>
		///     <para>
		///         Time Complexity: O(m), where m is the number of incident edges in the graph.
		///     </para>
		///     <para>
		///         Space Complexity: O(n * m), where n is the number of vertices in the graph, m is the number of incident edges.
		///     </para>
		/// </summary>
		/// <param name="graph">The adjacency matrix representation of the graph.</param>
		/// <param name="incidentEdges">The set of incident edges of the graph.</param>
		/// <returns>A 2D array representing the incidence matrix of the graph.</returns>
		public int[,] BuildIncidenceMatrix(int[,] graph, HashSet<(int, int)> incidentEdges)
		{
			var verticesCount = graph.GetLength(0);
			var edgesCount = incidentEdges.Count;
			var incidenceMatrix = new int[verticesCount, edgesCount];

			for (var edgeIndex = 0; edgeIndex < edgesCount; edgeIndex++)
			{
				var edge = incidentEdges.ElementAt(edgeIndex);
				var startVertex = edge.Item1;
				var endVertex = edge.Item2;
				incidenceMatrix[startVertex, edgeIndex] = graph[startVertex, endVertex] == 1 ? 1 : -1;
				incidenceMatrix[endVertex, edgeIndex] = graph[endVertex, startVertex] == 1 ? 1 : -1;
			}

			return incidenceMatrix;
		}
	}
}