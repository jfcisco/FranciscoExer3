using Xunit;
using FranciscoExer3.DataStructures;
// TODO: Repalce with own implementation of collections
using System.Collections.Generic;

namespace FranciscoExer3.Tests
{
    public class GraphTests
    {
        [Fact]
        public void CanInstantiateGraph()
        {
            int[] vertices = { 1, 2, 3 };

            Graph<int> graph = new Graph<int>(vertices);

            Assert.NotNull(graph);
        }

        [Fact]
        public void DepthFirstTraversalIsCorrect()
        {
            // Use example graph in the book
            Graph<int> graph = LoadSampleGraph();

            int[] resultOfDFSTraversal = graph.PerformDepthFirstTraversal();

            Assert.Equal(new int[] { 1, 3, 5, 6, 4, 2 }, resultOfDFSTraversal);
        }

        //    [Fact]
        //    public void BreadthFirstTraversalIsCorrect()
        //    {
        //        // Use example graph in the book
        //        int[] vertices = { 1, 2, 3, 4, 5, 6 };

        //        // Manually setup adjacency list 
        //        byte[][] adjacencyMatrix =
        //        {           //   1  2  3  4  5  6
        //            new byte[] { 0, 1, 1, 0, 0, 0 },
        //            new byte[] { 1, 0, 1, 1, 0, 0 },
        //            new byte[] { 1, 1, 0, 0, 1, 0 },
        //            new byte[] { 0, 1, 0, 0, 1, 1 },
        //            new byte[] { 0, 0, 1, 1, 0, 1 },
        //            new byte[] { 0, 0, 0, 1, 1, 0 }
        //        };

        //        Graph<int> graph = new Graph<int>(vertices) { AdjacencyMatrix = adjacencyMatrix };

        //        int[] resultOfBFSTraversal = graph.PerformBreadthFirstTraversal();

        //        Assert.Equal(new int[] { 1, 2, 3, 4, 5, 6 }, resultOfBFSTraversal);
        //    }


        // Test Helper Methods
        private Graph<int> LoadSampleGraph()
        {
            // Based on the example graph in the book
            int[] vertexValues = { 1, 2, 3, 4, 5, 6 };
            Graph<int> sampleGraph = new Graph<int>(vertexValues);

            // Setup adjacency lists for each vertex 
            sampleGraph.AdjacencyLists[1] = new LinkedList<int>(new int[] { 0, 1, 1, 0, 0, 0 });
            sampleGraph.AdjacencyLists[2] = new LinkedList<int>(new int[] { 1, 0, 1, 1, 0, 0 });
            sampleGraph.AdjacencyLists[3] = new LinkedList<int>(new int[] { 1, 1, 0, 0, 1, 0 });
            sampleGraph.AdjacencyLists[4] = new LinkedList<int>(new int[] { 0, 1, 0, 0, 1, 1 });
            sampleGraph.AdjacencyLists[5] = new LinkedList<int>(new int[] { 0, 0, 1, 1, 0, 1 });
            sampleGraph.AdjacencyLists[6] = new LinkedList<int>(new int[] { 0, 0, 0, 1, 1, 0 });

            return sampleGraph;
        }
    }
}
