using System;
using System.Collections.Generic;
using System.Linq;

namespace BFSCODE
{
    class Program
    {
        class Graph
        {
            private int V;
            String str;

            //Array of Adjacency Linnked list- Each vertex has a linkedlist
            //Adjacency list
            LinkedList<int>[] adjlist;
            String[] color;
            int[] d;
            int[] p;

            //public Graph(int v)
            //{
            //    adjlist = new LinkedList<int>[v];
            //    for(int i=0;i< adjlist.Length;i++ )
            //    {
            //        adjlist[i] = new LinkedList<int>();
            //    }
            //    V = v;
            //}

            public Graph(int v)
            {
                d = new int[v];
                p = new int[v];
                color = new string[v];
                adjlist = new LinkedList<int>[v];
                for (int i = 0; i < adjlist.Length; i++)
                {
                    adjlist[i] = new LinkedList<int>();
                }
                V = v;
                str = "";
            }
            public void addEdge(LinkedList<int>[] g, int v, int w)
            {
                g[v].AddLast(w);
                g[w].AddLast(v);
            }

            public void AddEdge(int v, int w)
            {
                adjlist[v].AddLast(w);
                adjlist[w].AddLast(v);

            }

            

            public void BFSSingleSource(LinkedList<int>[] g, int u)
            {
                if (g is null)
                {
                    throw new ArgumentNullException(nameof(g));
                }

                LinkedList<int> queue = new LinkedList<int>(); //This is our Queue to store vertices

                queue.AddLast(u);  //Adding start vertex

                d[u] = 0;   //Start vertex distance to itself will be zero
                color[u] = "gray"; // we have discovered start vertex yet to discover all of its neighbour vertices
                while(queue.Any())
                {
                    u = queue.First();
                    str = str+ u + " " + "-> ";
                    Console.WriteLine(u + " " + "-> ");
                    queue.RemoveFirst();


                    LinkedList<int> list = g[u]; //Contains list of nieghbouring vertices of u

                    foreach (var val in list) //This for loop goes thourgh all the neighbouring vertices
                    {
                        Console.WriteLine("For loop for discovering neighbouring vertices");
                        if (color[val]=="white")
                        {
                            color[val] = "gray";
                            d[val] = d[u] + 1;
                            p[val] = u;
                            Console.WriteLine("Add " + val.ToString() + " to queue");
                            queue.AddLast(val);
                        }
                    }
                    //After discovering all its vertices, it's color needs to be changed to black as it has been fully discovered
                    color[u] = "black";
                    Console.WriteLine("-------------------------------------");
                    Console.WriteLine("chossing a new vertext to discover its neighbours");

                }
            }

            public void BFSFull(LinkedList<int>[] g, int n)
            {
                str = "";
                for(int i=0;i<n;i++) //initialising all vertices with initial values
                {
                    color[i] = "white";
                    d[i] = int.MaxValue; //Basically infinity
                    p[i] = -1; //All vertices start from 0 index, thus -1 is a non-existent vertex.

                }
                for (int i = 0; i < 1; i++) // This run the BFSSinglesource code for all vertices n or you can change it to a specific vertex as well as done here for vertex 0 as source
                {
                    if(color[i]=="white")
                    {
                        BFSSingleSource(g, i);
                    }

                }
                Console.WriteLine("BFS Output: " + str);

            }
            //public void print_path()
            //{
            //    for (int i = 0; i < p.Length; i++)
            //    {
            //        Console.WriteLine("p["+i+"] " + "= "+p[i]);

            //    }

            //}

            //public void BFS(int s)
            //{
            //    //Initialising all vertices.
            //    bool[] visited = new bool[V];
            //    for (int i = 0; i < V; i++)
            //        visited[i] = false;
                
            //    //This is our Priority Queue
            //    LinkedList<int> queue = new LinkedList<int>();

            //    //We are visiting s source vertex first
            //    visited[s] = true;

            //    //We are adding it to the queue
            //    queue.AddLast(s);

            //    while (queue.Any()) // as long as queue contains some element
            //    {
            //        s = queue.First();
            //        Console.Write(s + " " +"-> ");
            //        queue.RemoveFirst();

            //        LinkedList<int> list = adjlist[s];

            //        foreach (var val in list)
            //        {
            //            if (!visited[val])
            //            {
            //                visited[val] = true;
            //                queue.AddLast(val);
            //            }
            //        }
            //    }
            //}
            public void DFSrecursive(int v, bool[] visited)
            {
                //v is current vertex
                visited[v] = true;
                Console.Write(v + " " + "-> ");

                LinkedList<int> vList = adjlist[v];
                foreach (var n in vList)
                {
                    if (!visited[n])
                        DFSrecursive(n, visited);
                }

            }
            public void DFS(int v)
            {
                bool[] visited = new bool[V];
                DFSrecursive(v, visited);
            }


        }

        static void Main(string[] args)
        {
            int n = 7;

            Graph graph1 = new Graph(7);

            LinkedList<int>[] g;
            g = new LinkedList<int>[n];
            for (int i = 0; i < g.Length; i++)
            {
                g[i] = new LinkedList<int>();
            }


            //g.AddEdge( 0, 1);
            //g.AddEdge( 0, 2);
            //g.AddEdge( 1, 3);
            //g.AddEdge( 1, 4);
            //g.AddEdge( 2, 5);
            //g.AddEdge( 2, 6);


            graph1.addEdge(g, 0, 1);
            graph1.addEdge(g, 0, 2);
            graph1.addEdge(g, 1, 3);
            graph1.addEdge(g, 1, 4);
            graph1.addEdge(g, 2, 5);
            graph1.addEdge(g, 2, 6);

            Console.WriteLine();
            Console.WriteLine("New Graph. Using new BFS algorithm ");

            graph1.BFSFull(g, n);

            Console.WriteLine();

            //graph1.print_path();
            //Console.WriteLine("Using BFSSIngleSource");
            //graph1.BFSSingleSource(g, 2);

        
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("*_*_*_*_*_*_*_*_*_*_*_*_*_*_*_*_*_*_*_*_*__*_*_*_*_*_*_*_*_*_*_*__*_*_*_*_*_*_");
            Console.WriteLine("New Graph for DFS code testing");
            Graph graph = new Graph(4);
            graph.AddEdge(0, 1);
            graph.AddEdge(0, 2);
            graph.AddEdge(1, 2);
            graph.AddEdge(2, 0);
            graph.AddEdge(2, 3);
            graph.AddEdge(3, 3);


            //Console.WriteLine();

            //Console.WriteLine("We now use BFS and print out the priority Queue :");

            //graph.BFS(2); // 2 is index of source vertex

            Console.WriteLine();
            Console.WriteLine("We are now using DFS strating from 2");
            graph.DFS(2);

           

            

        }
    }
}
