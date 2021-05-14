using System;
using System.Collections.Generic;
using System.Text;

namespace FranciscoExer3.DataStructures
{
    /// <summary>
    /// Implements the Stack data structure using arrays
    /// </summary>
    /// <typeparam name="T">Type of stack elements</typeparam>
    internal class Stack<T>
    {
        private int Size = 1;
        private T[] Data = new T[1];
        private int Head = 0;

        public Stack() { }

        /// <summary>
        /// Counts how many items are currently in the stack
        /// </summary>
        public int Count => Head;

        /// <summary>
        /// Pushes an item to the stack
        /// </summary>
        /// <param name="item">Item to be pushed</param>
        public void Push(T item)
        {
            if (Head == Size)
            {
                // No more space in the stack
                int newSize = Size * 2;
                Data = GrowArray(newSize);
                Size = newSize;
            }

            Data[Head] = item;
            Head++;
        }

        /// <summary>
        /// Helper method to grow the Data array to avoid overflowing the stack.
        /// </summary>
        /// <param name="newSize"></param>
        /// <returns>The Data array resized to newSize</returns>
        private T[] GrowArray(int newSize)
        {
            T[] newArray = new T[newSize];

            // Copy Data elements to bigger array
            for (int i = 0; i < Size; i++)
            {
                newArray[i] = Data[i];
            }

            return newArray;
        }

        /// <summary>
        /// Returns and "deletes" the last pushed item from the stack
        /// </summary>
        /// <returns>The last pushed item from the stack</returns>
        public T Pop()
        {
            if (Head == 0)
            {
                throw new Exception("Stack underflow error!");
            }

            Head--;
            return Data[Head];        
        }
    }
}
