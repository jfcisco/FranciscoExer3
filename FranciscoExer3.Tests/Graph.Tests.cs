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
            GraphVertex<int>[] vertices = { 
                new GraphVertex<int>(1),
                new GraphVertex<int>(2), 
                new GraphVertex<int>(3) 
            };

            Graph<int> graph = new Graph<int>(vertices);

            Assert.NotNull(graph);
        }

        [Fact]
        public void DepthFirstTraversalIsCorrect()
        {
            // Use example graph in the book
            GraphVertex<int>[] vertices = LoadSampleData();

            Graph<int> graph = new Graph<int>(vertices);

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
        private GraphVertex<int>[] LoadSampleData()
        {
            GraphVertex<int>[] sampleVertices = new GraphVertex<int>[6];
            // Load vertices
            int[] vertexValues = { 1, 2, 3, 4, 5, 6 };

            for (int i = 0; i < vertexValues.Length; i++)
            {
                sampleVertices[i] = new GraphVertex<int>(vertexValues[i]);
            }

            // Setup adjacency lists for each vertex 
            // For #1
            byte[][] adjacencyMatrix =
            {           //   1  2  3  4  5  6
                new byte[] { 0, 1, 1, 0, 0, 0 },
                new byte[] { 1, 0, 1, 1, 0, 0 },
                new byte[] { 1, 1, 0, 0, 1, 0 },
                new byte[] { 0, 1, 0, 0, 1, 1 },
                new byte[] { 0, 0, 1, 1, 0, 1 },
                new byte[] { 0, 0, 0, 1, 1, 0 }
            };

            for (var i = 0; i < adjacencyMatrix.Length; i++)
            {
                for (var j = 0; j < adjacencyMatrix[i].Length; j++)
                {
                    if (adjacencyMatrix[i][j] == 1)
                    {
                        sampleVertices[i].AdjacencyList.AddLast(sampleVertices[j]);
                    }
                }
            }

            return sampleVertices;
        }
    }
}
