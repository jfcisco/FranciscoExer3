using Xunit;
using FranciscoExer3.DataStructures;
using System;
using System.Collections.Generic;

namespace FranciscoExer3.Tests
{
    public class GraphAdjacencyListsTests
    {
        [Fact]
        public void CanInstantiateGraphAdjacencyLists()
        {
            GraphAdjacencyLists<int> adjacencyListsInt= new GraphAdjacencyLists<int>(new int[] { 1, 2, 3 });

            GraphAdjacencyLists<char> adjacencyListsChar = new GraphAdjacencyLists<char>(new char[] { 'A', 'B', 'c' });

            Assert.NotNull(adjacencyListsInt);
            Assert.NotNull(adjacencyListsChar);
        }

        [Theory]
        [InlineData('A', new char[] { 'B', 'C' })]
        [InlineData('B', new char[] { 'A' })]
        [InlineData('C', new char[] { 'D' })]
        public void CanSetAndGetAdjacencyList(char vertex, char[] adjacentVertices)
        {
            GraphAdjacencyLists<char> testLists = new GraphAdjacencyLists<char>(new char[] { 'A', 'B', 'C' });

            LinkedList<char> testAdjacencyList = new LinkedList<char>(adjacentVertices);

            testLists[vertex] = testAdjacencyList;
            Assert.Equal(testAdjacencyList, testLists[vertex]);
        }

        [Fact]
        public void CanUpdateAKey()
        {
            GraphAdjacencyLists<int> testList  = new GraphAdjacencyLists<int>(new int[] { 1, 2, 3 });

            testList[1] = new LinkedList<int>(new int[] { 2, 3 });
            testList[2] = new LinkedList<int>(new int[] { 1 });
            testList[3] = new LinkedList<int>(new int[] { 1 });

            testList[1] = new LinkedList<int>();

            Assert.Equal(new LinkedList<int>(), testList[1]);
            Assert.Equal(new LinkedList<int>(new int[] { 1 }), testList[2]);
            Assert.Equal(new LinkedList<int>(new int[] { 1 }), testList[3]);
        }

        [Theory]
        [InlineData(new int[] { 1, 2, 3, 5 }, 6)]
        [InlineData(new int[] { 1, 2, 3, 5 }, 0)]
        [InlineData(new int[] { 1, 2, 3, 5 }, 4)]
        public void CannotGetAdjacencyListOfNonexistingVertex(int[] vertices, int missingVertex)
        {
            GraphAdjacencyLists<int> testLists = new GraphAdjacencyLists<int>(vertices);
            Assert.Throws<ArgumentOutOfRangeException>(() => testLists[missingVertex]);
        }
    }
}
