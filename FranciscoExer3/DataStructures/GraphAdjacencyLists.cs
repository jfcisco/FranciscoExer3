using System;
using System.Collections.Generic;
using System.Text;

namespace FranciscoExer3.DataStructures
{
    /// <summary>
    /// Defines an adjacency list data structure that is capable holding a list of adjacent vertices for a given vertex.
    /// </summary>
    /// <remarks>Implemented as a binary search tree.</remarks>
    /// <typeparam name="T">Type of the graph's vertex</typeparam>
    public class GraphAdjacencyLists<T> : Dictionary<T, LinkedList<T>> where T : IComparable<T>
    {
        public GraphAdjacencyLists(T[] vertices) : base(vertices) { }
    }
}
