using System.Windows;

namespace FranciscoExer3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void DepthTraversalMenu_Click(object sender, RoutedEventArgs e)
        {
            // Open DFT Context Menu
            MenuDFT.IsOpen = true;
        }

        private void DepthTraversalGraph1_Click(object sender, RoutedEventArgs e)
        {
            // Not yet implemented
        }

        private void DepthTraversalGraph2_Click(object sender, RoutedEventArgs e)
        {
            // Not yet implemented
        }

        private void BreadthTraversalMenu_Click(object sender, RoutedEventArgs e)
        {
            // Open BFT Context Menu
            MenuBFT.IsOpen = true;
        }

        private void BreadthTraversalGraph1_Click(object sender, RoutedEventArgs e)
        {
            // Not yet implemented
        }

        private void BreadthTraversalGraph2_Click(object sender, RoutedEventArgs e)
        {
            // Not yet implemented
        }

        private void SearchGraph1_Click(object sender, RoutedEventArgs e)
        {
            // Not yet implemented
        }

        private void SearchGraph2_Click(object sender, RoutedEventArgs e)
        {
            // Not yet implemented
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
