using System;
using System.Collections.Generic;
using System.Text;

namespace PlayGround
{
    class GraphTraversals
    {
        public static void Main()
        {
            Console.WriteLine("Graph");

            var graph = new Graph(4);
            graph.AddEdge(0, 1);
            graph.AddEdge(1, 0);
            graph.AddEdge(0, 2);
            graph.AddEdge(2, 0);
            graph.AddEdge(0, 3);
            graph.AddEdge(3, 0);
            graph.AddEdge(1, 2);
            graph.AddEdge(2, 1);
            graph.AddEdge(1, 3);
            graph.AddEdge(3, 1);
            graph.AddEdge(2, 3);
            graph.AddEdge(3, 2);

            graph.PrintAdjMatrix();

            graph.DFS(0);
            graph.DFS(1);
            graph.DFS(2);

            Console.ReadLine();
        }
    }

    class Graph
    {
        public int Vertices;
        public List<int>[] AdjacencyList;

        public class Edge
        {
            public int Source;
            public int Destination;
            public int Weight;

            public Edge(int source, int destination, int weight)
            {
                this.Source = source;
                this.Destination = destination;
                this.Weight = weight;
            }
        }

        public Graph(int verticesCount)
        {
            this.Vertices = verticesCount;

            AdjacencyList = new List<int>[this.Vertices];

            for (int i = 0; i < this.Vertices; i++)
            {
                this.AdjacencyList[i] = new List<int>();
            }
        }

        public void AddEdge(int s, int d)
        {
            this.AdjacencyList[s].Add(d);
        }

        public void DFS(int s)
        {
            if (s < 0 || s > this.Vertices - 1)
            {
                Console.WriteLine("invalid vertices");
                return;
            }
            bool[] visited = new bool[this.Vertices];

            Stack<int> stack = new Stack<int>();
            visited[s] = true;
            stack.Push(s);

            while (stack.Count != 0)
            {
                s = stack.Pop();
                Console.WriteLine("next->" + s);
                foreach (int i in this.AdjacencyList[s])
                {
                    if (!visited[i])
                    {
                        visited[i] = true;
                        stack.Push(i);
                    }
                }
            }
        }

        public void PrintAdjMatrix()
        {
            for (int i = 0; i < this.Vertices; i++)
            {
                Console.Write(i + ":[");
                string s = "";
                foreach (var k in AdjacencyList[i])
                {
                    s = s + (k + ",");
                }

                s = s.Substring(0, s.Length - 1);
                s = s + "]";
                Console.Write(s);
                Console.WriteLine();
            }
        }
    }
}
