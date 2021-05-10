using Xunit;
using FranciscoExer3.DataStructures;
// TODO: Repalce with own implementation of collections
using System.Collections.Generic;

namespace FranciscoExer3.Tests
{
    public class GraphTests
    {
        [Fact]
        public void InstantiateGraph_Success()
        {
            int[] vertices = { 1, 2, 3 };

            Graph<int> graph = new Graph<int>(vertices);

            Assert.NotNull(graph);
        }

        [Fact]
        public void PerformDepthFirstTraversal_Success()
        {
            Graph<int> graph = LoadSampleGraph();

            int[] resultOfDFSTraversal = graph.PerformDepthFirstTraversal();

            Assert.Equal(new int[] { 1, 3, 5, 6, 4, 2 }, resultOfDFSTraversal);
        }

        [Fact]
        public void PerformBreadthFirstTraversal_Success()
        {
            Graph<int> graph = LoadSampleGraph();

            int[] resultOfBFSTraversal = graph.PerformBreadthFirstTraversal();

            Assert.Equal(new int[] { 1, 2, 3, 4, 5, 6 }, resultOfBFSTraversal);
        }

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        [InlineData(4)]
        [InlineData(5)]
        [InlineData(6)]
        public void DepthFirstSearch_Success(int value)
        {
            Graph<int> graph = LoadSampleGraph();
            bool result = graph.SearchDepthFirst(value);
            Assert.True(result);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(7)]
        public void DepthFirstSeach_Failure(int value)
        {
            Graph<int> graph = LoadSampleGraph();
            bool result = graph.SearchDepthFirst(value);
            Assert.False(result);
        }

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        [InlineData(4)]
        [InlineData(5)]
        [InlineData(6)]
        public void BreadthFirstSearch_Success(int value)
        {
            Graph<int> graph = LoadSampleGraph();
            bool result = graph.SearchBreadthFirst(value);
            Assert.True(result);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(7)]
        public void BreadthFirstSeach_Failure(int value)
        {
            Graph<int> graph = LoadSampleGraph();
            bool result = graph.SearchBreadthFirst(value);
            Assert.False(result);
        }

        // Test Helper Methods
        private Graph<int> LoadSampleGraph()
        {
            // Based on the example graph in the book
            int[] vertexValues = { 1, 2, 3, 4, 5, 6 };
            Graph<int> sampleGraph = new Graph<int>(vertexValues);

            // Setup adjacency lists for each vertex 
            sampleGraph.AdjacencyLists[1] = new LinkedList<int>(new int[] { 2, 3 });
            sampleGraph.AdjacencyLists[2] = new LinkedList<int>(new int[] { 1, 3, 4 });
            sampleGraph.AdjacencyLists[3] = new LinkedList<int>(new int[] { 1, 2, 5 });
            sampleGraph.AdjacencyLists[4] = new LinkedList<int>(new int[] { 2, 5, 6 });
            sampleGraph.AdjacencyLists[5] = new LinkedList<int>(new int[] { 3, 4, 6, });
            sampleGraph.AdjacencyLists[6] = new LinkedList<int>(new int[] { 4, 5 });

            return sampleGraph;
        }
    }
}
