﻿using System;

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

            foreach(T value in DepthFirst)
            {
                verticesInOrderVisited[numberOfVerticesVisited] = value;
                numberOfVerticesVisited++;
            }

            return verticesInOrderVisited;
        }

        public T[] PerformBreadthFirstTraversal()
        {
            // Declare a variable to keep track of the order the vertices were visited.
            T[] verticesInOrderVisited = new T[Order];
            int numberOfVerticesVisited = 0;

            foreach(T vertex in BreadthFirst)
            {
                verticesInOrderVisited[numberOfVerticesVisited] = vertex;
                numberOfVerticesVisited++;
            }

            return verticesInOrderVisited;
        }

        public bool SearchDepthFirst(T value)
        {
            foreach (T vertex in DepthFirst)
            {
                // value.CompareTo(vertex) is 0 if both values are the same
                if (value.CompareTo(vertex) == 0)
                {
                    return true;
                }
            }

            // If no matches are found, return false
            return false;
        }

        public bool SearchBreadthFirst(T value)
        {
            foreach(T vertex in BreadthFirst)
            {
                // value.CompareTo(vertex) is 0 if both values are the same
                if (vertex.CompareTo(value) == 0)
                {
                    return true;
                }
            }

            // Reached when no matches are found
            return false;
        }

        /// <summary>
        /// Enumerates the Graph's vertices in a depth-first traversal manner.
        /// </summary>
        private System.Collections.Generic.IEnumerable<T> DepthFirst
        {
            get
            {
                // Initialize all vertices to "not visited" status
                Dictionary<T, bool> visited = new Dictionary<T, bool>(Vertices);

                foreach (T vertex in Vertices)
                {
                    visited[vertex] = false;
                }

                Stack<T> stack = new Stack<T>();
                stack.Push(Vertices[0]);

                while (stack.Count > 0)
                {
                    T currentVertex = stack.Peek();

                    // Determines if the traversal can go deeper (i.e., current vertex is adjacent to at least 1 unvisited vertex).
                    bool CanGoDeeper = false;

                    if (!visited[currentVertex])
                    {
                        // Enumerate the vertex and mark as visited
                        yield return currentVertex;
                        visited[currentVertex] = true;
                    }

                    // Push the first adjacent, unvisited vertex to the stack
                    foreach (T adjacentVertex in AdjacencyLists[currentVertex])
                    {
                        if (!visited[adjacentVertex])
                        {
                            stack.Push(adjacentVertex);
                            CanGoDeeper = true;
                            break;
                        }
                    }

                    // If no adjacent vertices can be visited, pop the stack to go back
                    if (!CanGoDeeper) { stack.Pop(); }
                }
            }
        }


        /// <summary>
        /// Enumerates the Graph's vertices in a breadth-first traversal manner.
        /// </summary>
        private System.Collections.Generic.IEnumerable<T> BreadthFirst
        {
            get
            {
                // Initialize all vertices to "not visited" status
                Dictionary<T, bool> visited = new Dictionary<T, bool>(Vertices);

                foreach (T vertex in Vertices)
                {
                    visited[vertex] = false;
                }

                Queue<T> queue = new Queue<T>();
                queue.Enqueue(Vertices[0]);

                while (queue.Count > 0)
                {
                    T vertex = queue.Dequeue();

                    // Skip visited vertices
                    if (visited[vertex]) { continue; }

                    // Enumerate the vertex
                    yield return vertex;
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
        }
    }
}
