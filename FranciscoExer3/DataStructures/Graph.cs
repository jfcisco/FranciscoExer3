using System;
using System.Collections.Generic;
using System.Text;

namespace FranciscoExer3.DataStructures
{
    /// <summary>
    /// Graph data structure implemented using an adjacency list
    /// </summary>
    public class Graph<T> where T : IComparable<T>
    {
        public readonly T[] Vertices;
        // Replace with HashTable implementation
        public readonly GraphAdjacencyLists<T> AdjacencyLists;
        private readonly int Order;

        // Initializes a Graph with a given array of its vertices
        public Graph(T[] vertices)
        {
            Vertices = vertices;
            Order = vertices.Length;
            AdjacencyLists = new GraphAdjacencyLists<T>();
        }

        public T[] PerformDepthFirstTraversal()
        {
            // Declare a variable to keep track of vertices that were already visited

            // int variable in the tuple represents the order which the vertex was visited.
            // For example, 0 = not yet visited
            //              1 = first to be visited
            (T, int)[] verticesInScope = new (T, int)[Order];
            int countOfVerticesVisited = 0;

            // Setup verticesInscope with initial values
            for (var i = 0; i < Order; i++)
            {
                verticesInScope[i] = (Vertices[i], 0);
            }

            // TODO: Use own stack implementation
            // Stack<GraphVertex<T>> stack = stack.Push()




            throw new NotImplementedException();
        }

        public T[] PerformBreadthFirstTraversal()
        {
            throw new NotImplementedException();
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
