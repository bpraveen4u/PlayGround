using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace PlayGround
{
    class GraphTraversals
    {
        public static void Main()
        {
            Console.WriteLine("Graph");
            var verticesCount = 4;
            var graph = new Graph(verticesCount);
            graph.AddEdge(0, 1);
            graph.AddEdge(0, 2);

            graph.AddEdge(1, 2);
            graph.AddEdge(0, 3);

            graph.AddEdge(1, 3);
            graph.AddEdge(2, 3);

            graph.PrintAdjMatrix();
            var pathList = new List<int>();
            var startVertex = 2;
            pathList.Add(startVertex);
            Console.WriteLine("\nDFS All Paths\n");
            graph.DFSAllPaths(startVertex, new bool[verticesCount], verticesCount - 1, pathList);

            //graph.BFS(0);
            //Queue<int> queue = new Queue<int>();
            //queue.Enqueue(0);
            //graph.BFSRecursive(queue, new bool[verticesCount]);

            //Console.WriteLine("DFS");
            //graph.DFS(0);
            //Console.WriteLine("DFS Recursive");
            //graph.DFSRecursive(0, new bool[verticesCount]);
            //graph.DFS(0);
            //graph.DFS(1);
            //graph.DFS(2);

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
            this.AdjacencyList[d].Add(s); //for undirected.
        }

        public void DFSAllPaths(int startVertex, bool[] visited, int minPath, List<int> localPathList)
        {
            if (localPathList.Count >= minPath)
            {
                Console.WriteLine(string.Join("->", localPathList));
                //return; //not required as we need to print all paths from given node
            }
            visited[startVertex] = true;
            
            foreach (var adjVertex in this.AdjacencyList[startVertex])
            {
                if (!visited[adjVertex])
                {
                    localPathList.Add(adjVertex);
                    DFSAllPaths(adjVertex, visited, minPath, localPathList);
                    localPathList.Remove(adjVertex);
                }
            }
            visited[startVertex] = false;
        }

        public void BFS(int startVertex)
        {
            Console.WriteLine("Breadth First Search");
            if (startVertex < 0 || startVertex > this.Vertices)
            {
                Console.WriteLine("invalid start vertice");
                return;
            }
            bool[] visited = new bool[this.Vertices];
            Queue<int> queue = new Queue<int>();

            visited[startVertex] = true;
            queue.Enqueue(startVertex);
            while (queue.Count != 0)
            {
                startVertex = queue.Dequeue();
                Console.WriteLine("next->" + startVertex);
                foreach (var adjVertex in this.AdjacencyList[startVertex])
                {
                    if (!visited[adjVertex])
                    {
                        visited[adjVertex] = true;
                        queue.Enqueue(adjVertex);
                    }
                }
            }
        }

        public void BFSRecursive(Queue<int> queue, bool[] visited)
        {
            if (queue.Count == 0)
            {
                return;
            }
            var s = queue.Dequeue();
            visited[s] = true;
            Console.WriteLine("->" + s);
            foreach (var edge in this.AdjacencyList[s])
            {
                if (!visited[edge])
                {
                    visited[edge] = true;
                    queue.Enqueue(edge);
                }
            }

            BFSRecursive(queue, visited);
        }

        public void DFS(int s)
        {
            Console.WriteLine("Depth First Search");
            if (s < 0 || s > this.Vertices - 1)
            {
                Console.WriteLine("invalid start vertice");
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

        public void DFSRecursive(int s, bool[] visited)
        {
            if (s < 0 || s > this.Vertices)
            {
                return;
            }

            visited[s] = true;
            Console.WriteLine("->" + s);

            foreach (var edge in this.AdjacencyList[s])
            {
                if (!visited[edge])
                {
                    DFSRecursive(edge, visited);
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
