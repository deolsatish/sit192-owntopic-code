using System;

namespace DjikstraNewCode
{
	class GFG
	{

		static int V = 9;


		void printSolution(int[] dist)
		{
			Console.Write("Vertex \t\t Distance "
						+ "from Source\n");
			for (int i = 0; i < V; i++)
				Console.Write(i + " \t\t " + dist[i] + "\n");
		}

		int ExtractMin(int[] dist, bool[] minSet) //This our extractMin operation which will return the nearest vertex
		{
			int min = int.MaxValue;
			int min_index = -1;

			for (int v = 0; v < V; v++)
				if (minSet[v] == false && dist[v] <= min)
				{
					min = dist[v];
					min_index = v;
				}

			return min_index;
		}

		void dijkstra(int[,] graph, int src) //Our Djikstra functionor Algorithm
		{
			int[] dist = new int[V];    //Basically inserting all vertices in this list
			bool[] minSet = new bool[V];

			for (int i = 0; i < V; i++) //Initializing vertices with infinity and setting the shortest path found as false
			{
				dist[i] = int.MaxValue;
				minSet[i] = false;
			}

			dist[src] = 0; //setting initial src dist a zero

			for (int count = 0; count < V - 1; count++)
			{
				Console.WriteLine("Current Vertex: " + (count).ToString());

				int u = ExtractMin(dist, minSet); // Extracting the minimum distance from queue or list dist

				minSet[u] = true; 

				for (int v = 0; v < V; v++) //Testing every Vertex for Shortest Path
				{

					if (!minSet[v] && graph[u, v] != 0 && dist[u] != int.MaxValue && dist[u] + graph[u, v] < dist[v])
					{
						dist[v] = dist[u] + graph[u, v]; // this is basically relaxation
						Console.WriteLine("Adding " + v.ToString() + " to path which has min distance " + dist[v].ToString());
					}

				}
			} //There are V vertices, and we are accessing the wiegths and dist values of these vertices in the If directly.

			Console.WriteLine();
			Console.WriteLine("------------------------------------------------");
			Console.WriteLine();
			printSolution(dist);
		}

		public static void Main()
		{
			int[,] graph = new int[,] { { 0, 4, 0, 0, 0, 0, 0, 8, 0 },
									{ 4, 0, 8, 0, 0, 0, 0, 11, 0 },
									{ 0, 8, 0, 7, 0, 4, 0, 0, 2 },
									{ 0, 0, 7, 0, 9, 14, 0, 0, 0 },
									{ 0, 0, 0, 9, 0, 10, 0, 0, 0 },
									{ 0, 0, 4, 14, 10, 0, 2, 0, 0 },
									{ 0, 0, 0, 0, 0, 2, 0, 1, 6 },
									{ 8, 11, 0, 0, 0, 0, 1, 0, 7 },
									{ 0, 0, 2, 0, 0, 0, 6, 7, 0 } }; //This is our Adjacency Matrix to store our Graph
			GFG gfg = new GFG();
			gfg.dijkstra(graph, 0); //Running Djikstra algorithm with vertex 0 as source
		}
	}
}
