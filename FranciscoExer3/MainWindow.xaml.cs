using System;
using System.Windows;
using FranciscoExer3.DataStructures;

namespace FranciscoExer3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Graph<char> Graph1;
        private Graph<int> Graph2;

        public MainWindow()
        {
            InitializeComponent();
        }

        /* === EVENT HANDLERS === */

        // Called when the application first starts
        private void InitializeApplication(object sender, RoutedEventArgs e)
        {
            // Load the graphs
            Graph1 = LoadGraph1();
            Graph2 = LoadGraph2();
        }

        private void DepthTraversalMenu_Click(object sender, RoutedEventArgs e)
        {
            // Open DFT Context Menu
            MenuDFT.IsOpen = true;
        }

        private void DepthTraversalGraph1_Click(object sender, RoutedEventArgs e)
        {
            string result = Graph1.PerformDepthFirstTraversal();
            Log($"Depth-first traversal of Graph 1: {result}");
        }

        private void DepthTraversalGraph2_Click(object sender, RoutedEventArgs e)
        {
            string result = Graph2.PerformDepthFirstTraversal();
            Log($"Depth-first traversal of Graph 2: {result}");
        }

        private void BreadthTraversalMenu_Click(object sender, RoutedEventArgs e)
        {
            // Open BFT Context Menu
            MenuBFT.IsOpen = true;
        }

        private void BreadthTraversalGraph1_Click(object sender, RoutedEventArgs e)
        {
            string result = Graph1.PerformBreadthFirstTraversal();
            Log($"Breadth-first traversal of Graph 1: {result}");
        }

        private void BreadthTraversalGraph2_Click(object sender, RoutedEventArgs e)
        {
            string result = Graph2.PerformBreadthFirstTraversal();
            Log($"Breadth-first traversal of Graph 2: {result}");
        }

        private void SearchGraph1_Click(object sender, RoutedEventArgs e)
        {
            if (TryGetSearchInputGraph1(out char vertexToSearch))
            {
                bool matchFound = Graph1.SearchDepthFirst(vertexToSearch);

                if (matchFound)
                {
                    Log($"The vertex {vertexToSearch} is in Graph 1!");
                }
                else
                {
                    Log($"The vertex {vertexToSearch} cannot be found in Graph 1.");
                }
            }
        }

        private void SearchGraph2_Click(object sender, RoutedEventArgs e)
        {
            if (TryGetSearchInputGraph2(out int vertexToSearch))
            {
                bool matchFound = Graph2.SearchBreadthFirst(vertexToSearch);

                if (matchFound)
                {
                    Log($"The vertex {vertexToSearch} is in Graph 2!");
                }
                else
                {
                    Log($"The vertex {vertexToSearch} cannot be found in Graph 2.");
                }
            }
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        /* === HELPER METHODS === */

        // Loads the exercise's predefined "Graph 1"
        private Graph<char> LoadGraph1()
        {
            char[] vertexValues = { 'A', 'B', 'C', 'D', 'E', 'F', 'G' };
            Graph<char> graph1 = new Graph<char>(vertexValues);

            // Setup adjacency lists for each vertex 
            graph1.AdjacencyLists['A'] = new char[] { 'B' };
            graph1.AdjacencyLists['B'] = new char[] { 'C', 'E' };
            graph1.AdjacencyLists['C'] = new char[] { 'A', 'D', 'G' };
            graph1.AdjacencyLists['D'] = new char[] { 'A' };
            graph1.AdjacencyLists['E'] = new char[] { 'C', 'F' };
            graph1.AdjacencyLists['F'] = new char[] { 'G' };
            graph1.AdjacencyLists['G'] = new char[] { 'D' };

            return graph1;
        }

        // Returns the exercise's predefined "Graph 2"
        private Graph<int> LoadGraph2()
        {
            int[] vertexValues = { 0, 1, 2, 3, 4, 5 };
            Graph<int> graph2 = new Graph<int>(vertexValues);

            // Setup adjacency lists for each vertex 
            graph2.AdjacencyLists[0] = new int[] { 1 };
            graph2.AdjacencyLists[1] = new int[] { 2, 5 };
            graph2.AdjacencyLists[2] = new int[] { 3, 4 };
            graph2.AdjacencyLists[3] = new int[] { };
            graph2.AdjacencyLists[4] = new int[] { 5 };
            graph2.AdjacencyLists[5] = new int[] { };

            return graph2;
        }

        // Gets the vertex to be searched for in Graph 1
        private bool TryGetSearchInputGraph1(out char result)
        {
            try
            {
                // Get the first character of the string
                // Converts lowercase characters to uppercase
                char userInput = Graph1VertexSearch.Text.Trim().ToUpper()[0];
                result = userInput;
                return true;
            }
            catch (IndexOutOfRangeException)
            {
                Log("Invalid input. Please enter a character.");
                result = default;
                return false;
            }
            finally
            {
                Graph1VertexSearch.Text = string.Empty;
            }
        }

        // Gets the vertex to be searched for in Graph 2
        private bool TryGetSearchInputGraph2(out int result)
        {
            try
            {
                string userInput = Graph2VertexSearch.Text.Trim();
                result = int.Parse(userInput);
                return true;
            }
            catch (Exception)
            {
                Log("Invalid input. Please enter an integer.");
                result = default;
                return false;
            }
            finally
            {
                Graph2VertexSearch.Text = string.Empty;
            }
        }

        // Displays a message to the designated output area
        private void Log(string message)
        {
            OutputBox.Text = message;
        }
    }
}
