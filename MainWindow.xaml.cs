using SWAN.ViewModels;
using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SWAN
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // Change this when choosing a file
        private string currentFilePath = string.Empty;

        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = new ScaffoldViewModel();
        }

        private void CloseOnClick(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void MinimizeOnClick(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void MaximizeOnClick(object sender, RoutedEventArgs e)
        {
            if (this.WindowState == WindowState.Maximized)
            {
                this.WindowState = WindowState.Normal;
            }
            else
            {
                this.WindowState = WindowState.Maximized;
            }
        }


        private void TitleBarButton_Click(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
            if (btn != null)
            {
                ContextMenu cm = btn.ContextMenu;
                if (cm != null)
                {
                    cm.PlacementTarget = btn;
                    cm.Placement = PlacementMode.Bottom;
                    cm.IsOpen = true;
                }
            }
        }

        private void NewFile_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("New File clicked");
        }

        private void OpenFile_Click(object sender, RoutedEventArgs e)
        {
            // Configure open file dialog box
            var dialog = new Microsoft.Win32.OpenFileDialog();
            dialog.FileName = "Document"; // Default file name
            dialog.DefaultExt = ".txt"; // Default file extension
            dialog.Filter = "Text documents (.txt)|*.txt"; // Filter files by extension

            // Show open file dialog box
            bool? result = dialog.ShowDialog();

            // Process open file dialog box results
            if (result == true)
            {
                // Open document
                string filename = dialog.FileName;
            }

            //TODO handle what we do with the selected file
        }

        private void SaveFile_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(currentFilePath))
            {
                // Save the content to the current file
                File.WriteAllText(currentFilePath, "Your file content here"); // Replace with your actual content
                MessageBox.Show("File saved successfully.");
            }
            else
            {
                SaveAs_Click(sender, e); // Prompt Save As if no file is currently open
            }
        }
        private void SaveAs_Click(object sender, RoutedEventArgs e)
        {

            // Configure save file dialog box
            var dialog = new Microsoft.Win32.SaveFileDialog();
            dialog.FileName = "Document"; // Default file name
            dialog.DefaultExt = ".txt"; // Default file extension
            dialog.Filter = "Text documents (.txt)|*.txt"; // Filter files by extension

            // Show save file dialog box
            bool? result = dialog.ShowDialog();

            // Process save file dialog box results
            if (result == true)
            {
                // Save document
                string filename = dialog.FileName;
            }
            // TODO change how we save the files/format that 
            MessageBox.Show("File Saved");

        }
        private void PrintFile_Click(object sender, RoutedEventArgs e)
        {
            // Configure printer dialog box
            var dialog = new System.Windows.Controls.PrintDialog();
            dialog.PageRangeSelection = System.Windows.Controls.PageRangeSelection.AllPages;
            dialog.UserPageRangeEnabled = true;

            // Show save file dialog box
            bool? result = dialog.ShowDialog();

            // Process save file dialog box results
            if (result == true)
            {
                // Document was printed
            }
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void Todo_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("TODO: Unimplemented Feature");
        }
    }
}