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
    public class GraphAdjacencyLists<T> where T : IComparable<T>
    {
        private ListNode<T> Root;

        // Get => Returns the adjacencyList of the given vertex
        // Set => Updates the adjacencyList of the given vertex
        public LinkedList<T> this[T vertex]
        {
            get => GetAdjacencyList(Root, vertex);
            set => SetAdjacencyList(ref Root, vertex, value);
        }

        // Returns the adjacency list of a given vertex in a specified subtree
        // Root - root of subtree
        // Vertex - vertex whose adjacency list is requested
        private LinkedList<T> GetAdjacencyList(ListNode<T> root, T vertex)
        {
            if (root == null)
            {
                throw new ArgumentOutOfRangeException($"Vertex {vertex} does not have an adjacency list.");
            }

            // Traverse the Binary Search Tree
            int orderValue = root.Key.CompareTo(vertex);
            if (orderValue < 0)
            {
                return GetAdjacencyList(root.Left, vertex);
            }
            else if (orderValue > 0)
            {
                return GetAdjacencyList(root.Right, vertex);
            }
            else
            {
                return root.AdjacencyList;
            }
        }

        // Sets the adjacency list of a given vertex in a specified subtree
        // Root - root of subtree
        // Vertex - vertex whose adjacency list will be set to adjacencyList
        private void SetAdjacencyList(ref ListNode<T> root, T vertex, LinkedList<T> adjacencyList)
        {
            // Find the order of root.Key compared to vertex
            int? orderValue = root?.Key.CompareTo(vertex);

            if (orderValue == null || orderValue == 0)
            {
                // Add new ListNode to this position
                root = new ListNode<T> 
                { 
                    Key = vertex, 
                    AdjacencyList = adjacencyList
                };
                return;
            }
            // Traverse the Binary Search Tree
            else if (orderValue < 0)
            {
                SetAdjacencyList(ref root.Left, vertex, adjacencyList);
            }
            else if (orderValue > 0)
            {
                SetAdjacencyList(ref root.Right, vertex, adjacencyList);
            }
        }

        private void Add(ref ListNode<T> node, T vertex, T adjacentVertex)
        {

        }

        private class ListNode<T>
        {
            public T Key;
            public LinkedList<T> AdjacencyList;
            public ListNode<T> Left;
            public ListNode<T> Right;
        }
    }
}
