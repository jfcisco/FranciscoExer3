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

        public GraphAdjacencyLists() { }

        public GraphAdjacencyLists(T[] vertices)
        {
            foreach(T vertex in vertices)
            {
                this[vertex] = new LinkedList<T>();
            }
        }

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
            int? orderValue = root?.Key.CompareTo(vertex);
            // orderValue < 0       if vertex > root.Key
            // orderValue == 0      if vertex == root.Key
            // orderValue > 0       if vertex < root.Key
            // ordeValue == null    if root == null

            if (orderValue == null)
            {
                throw new ArgumentOutOfRangeException($"Vertex {vertex} does not have an adjacency list.");
            }
            else if (orderValue > 0)
            {
                return GetAdjacencyList(root.Left, vertex);
            }
            else if (orderValue < 0)
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
            // Find the relative order of root.Key to vertex
            int? orderValue = root?.Key.CompareTo(vertex);
            // orderValue < 0       if vertex > root.Key
            // orderValue == 0      if vertex == root.Key
            // orderValue > 0       if vertex < root.Key
            // ordeValue == null    if root == null

            // Cases: Vertex does not exist in the tree, or Vertex is already in the tree
            if (orderValue == null || orderValue == 0)
            {
                // Add new ListNode to this position
                root = new ListNode<T>(vertex)
                { 
                    AdjacencyList = adjacencyList
                };
                return;
            }
            // Traverse the Binary Search Tree
            else if (orderValue > 0)
            {
                SetAdjacencyList(ref root.Left, vertex, adjacencyList);
            }
            else if (orderValue < 0)
            {
                SetAdjacencyList(ref root.Right, vertex, adjacencyList);
            }
        }

        private class ListNode<U>
        {
            public U Key;
            public LinkedList<U> AdjacencyList;
            public ListNode<U> Left;
            public ListNode<U> Right;

            public ListNode(U key)
            {
                Key = key;
            }
        }
    }
}
