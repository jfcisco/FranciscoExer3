using System;
// TODO: Remove dependence on .NET Generic Collections
using System.Collections.Generic;

namespace FranciscoExer3.DataStructures
{
    /// <summary>
    /// Graph data structure implemented using an adjacency list
    /// </summary>
    public class Graph<T> where T : IComparable<T>
    {
        public readonly T[] Vertices;
        public readonly GraphAdjacencyLists<T> AdjacencyLists;
        private readonly int Order;

        // Initializes a Graph with a given array of its vertices
        public Graph(T[] vertices)
        {
            Vertices = vertices;
            Order = vertices.Length;
            AdjacencyLists = new GraphAdjacencyLists<T>(vertices);
        }

        public T[] PerformDepthFirstTraversal()
        {
            // Declare a variable to keep track of the order the vertices were visited.
            T[] verticesInOrderVisited = new T[Order];
            int numberOfVerticesVisited = 0;

            // Initialize all vertices to "not visited" status
            Dictionary<T, bool> visited = new Dictionary<T, bool>(Vertices);

            foreach (T vertex in Vertices)
            {
                visited[vertex] = false;
            }

            // TODO: Use own stack implementation
            Stack<T> stack = new Stack<T>();
            stack.Push(Vertices[0]);

            while (stack.Count > 0)
            {
                T vertex = stack.Pop();

                if (!visited[vertex])
                {
                    // Visit the vertex
                    verticesInOrderVisited[numberOfVerticesVisited] = vertex;
                    numberOfVerticesVisited++;
                    visited[vertex] = true;

                    // Push adjacent, unvisited vertices to the stack
                    foreach (T adjacentVertex in AdjacencyLists[vertex])
                    {
                        if (!visited[adjacentVertex])
                        {
                            // Push adjacentVertex to the stack
                            stack.Push(adjacentVertex);
                        }
                    }
                }
            }

            return verticesInOrderVisited;
        }

        public T[] PerformBreadthFirstTraversal()
        {
            // Declare a variable to keep track of the order the vertices were visited.
            T[] verticesInOrderVisited = new T[Order];
            int numberOfVerticesVisited = 0;

            // Initialize all vertices to "not visited" status
            Dictionary<T, bool> visited = new Dictionary<T, bool>(Vertices);

            foreach (T vertex in Vertices)
            {
                visited[vertex] = false;
            }

            // TODO: Use own queue implementation
            Queue<T> queue = new Queue<T>();
            queue.Enqueue(Vertices[0]);

            while (queue.Count > 0)
            {
                T vertex = queue.Dequeue();

                if (!visited[vertex])
                {
                    // Visit the vertex
                    verticesInOrderVisited[numberOfVerticesVisited] = vertex;
                    numberOfVerticesVisited++;
                    visited[vertex] = true;

                    // Push adjacent, unvisited vertices to the stack
                    foreach (T adjacentVertex in AdjacencyLists[vertex])
                    {
                        if (!visited[adjacentVertex])
                        {
                            // Push adjacentVertex to the stack
                            queue.Enqueue(adjacentVertex);
                        }
                    }
                }
            }

            return verticesInOrderVisited;
        }

        public bool SearchDepthFirst(T value)
        {
            throw new NotImplementedException();
        }

        public bool SearchBreadthFirst(T value)
        {
            throw new NotImplementedException();
        }
    }
}
