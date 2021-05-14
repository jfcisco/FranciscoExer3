using System;
using System.Collections.Generic;
using System.Text;

namespace FranciscoExer3.DataStructures
{
    /// <summary>
    /// Queue data structure implemented using an array that can be resized when needed.
    /// </summary>
    public class Queue<T>
    {
        public T[] Data { get; set; } = new T[1];
        private int Head = 0; // Size - 1
        private int Tail = 0; // Size - 1
        private int Size = 1;

        public int Count { get; private set; } = 0;

        public Queue() { }

        /// <summary>
        /// Inserts an item at the back of the queue.
        /// </summary>
        /// <param name="dataToInsert"></param>
        public void Enqueue(T dataToEnqueue)
        {
            // Check if the Queue is already full
            if (Count == Size)
            {
                GrowArray();
            }

            // Insert at the index where Tail is currently pointing to
            Data[Tail] = dataToEnqueue;
            Count++;

            // Circle back when end of array is reached
            if (Tail == Size - 1)
            {
                Tail = 0;
            }
            else
            {
                Tail++;
            }
        }

        /// <summary>
        /// Returns and removes the item at the front of the queue.
        /// </summary>
        public T Dequeue()
        {
            if (Count == 0)
            {
                throw new Exception("Queue underflow.");
            }

            // Temporarily store data to be returned later on, then set Data at Head to default value
            T dataAtHead = Data[Head];
            Data[Head] = default;

            // Move head to next item
            if (Head == Size - 1)
            {
                Head = 0;
            }
            else
            {
                Head++;
            }

            Count--;
            return dataAtHead;

        }

        /// <summary>
        /// Procedure that increases the size of the queue when the Data array is already full.
        /// </summary>
        /// <param name="newSize"></param>
        private void GrowArray()
        {
            // Create a bigger data array
            T[] newArray = new T[Size * 2];

            // Copy the contents from the old array to the new array
            // Case 1 & 2: Array is empty or only partially filled (GrowArray should never be called in these cases)
            // Case 3: Array is filled (i.e. Head = Tail)

            int counter = 0;
            // Copy all elements from Head to end of Data array
            for (var i = 0; i < Size - Head; i++)
            {
                // Data[Head...Size - 1] => newArray[0...Size - 1 - Head]
                newArray[i] = Data[i + Head];
                counter++;
            }

            // Copy all elements from 0 to Tail
            for (var j = 0; j < Tail; j++)
            {
                // Data[0...Tail] => newArray[counter...counter + Tail]
                newArray[j + counter] = Data[j];
                counter++;
            }

            // Update the Queue properties to the newArray
            Size *= 2;
            Data = newArray;
            Head = 0; // Item at the first inserted item
            Tail = counter; // Index of the next empty spot
        }
    }
}
