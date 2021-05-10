using System;

namespace FranciscoExer3.DataStructures
{
    /// <summary>
    /// Implementation of the Dictionary data structure using a Binary Search Tree. The Dictionary is used to keep information in the form of key-value pairs.
    /// </summary>
    public class Dictionary <TKey, TValue> where TKey : IComparable<TKey>
    {
        private ListNode<TKey, TValue> Root;

        public Dictionary(TKey[] keys)
        {
            foreach (TKey key in keys)
            {
                this[key] = default;
            }
        }

        // Get => Returns the value of the given key
        // Set => Updates the value of a given key
        public TValue this[TKey key]
        {
            get => GetValue(Root, key);
            set => SetValue(ref Root, key, value);
        }

        // Returns the adjacency list of a given vertex in a specified subtree
        // Root - root of subtree
        // Vertex - vertex whose adjacency list is requested
        private TValue GetValue(ListNode<TKey, TValue> root, TKey key)
        {
            int? orderValue = root?.Key.CompareTo(key);
            // orderValue < 0       if vertex > root.Key
            // orderValue == 0      if vertex == root.Key
            // orderValue > 0       if vertex < root.Key
            // ordeValue == null    if root == null

            if (orderValue == null)
            {
                throw new ArgumentOutOfRangeException($"Key {key} does not have a value.");
            }
            else if (orderValue > 0)
            {
                return GetValue(root.Left, key);
            }
            else if (orderValue < 0)
            {
                return GetValue(root.Right, key);
            }
            else
            {
                return root.Value;
            }
        }

        // Sets the adjacency list of a given vertex in a specified subtree
        // Root - root of subtree
        // Vertex - vertex whose adjacency list will be set to adjacencyList
        private void SetValue(ref ListNode<TKey, TValue> root, TKey key, TValue value)
        {
            // Find the relative order of root.Key to given key
            int? orderValue = root?.Key.CompareTo(key);
            // orderValue < 0       if key > root.Key
            // orderValue == 0      if key == root.Key
            // orderValue > 0       if key < root.Key
            // ordeValue == null    if root == null

            // Cases: Vertex does not exist in the tree, or Vertex is already in the tree
            if (orderValue == null)
            {
                // Add new ListNode to this position
                root = new ListNode<TKey, TValue>(key, value);
                return;
            }
            else if (orderValue == 0)
            {
                // Update existing ListNode to new value
                root.Value = value;
                return;
            }
            // Traverse the Binary Search Tree
            else if (orderValue > 0)
            {
                SetValue(ref root.Left, key, value);
            }
            else if (orderValue < 0)
            {
                SetValue(ref root.Right, key, value);
            }
        }

        private class ListNode<U, V>
        {
            public U Key;
            public V Value;
            public ListNode<U, V> Left;
            public ListNode<U, V> Right;

            public ListNode(U key, V value)
            {
                Key = key;
                Value = value;
            }
        }
    }
}
