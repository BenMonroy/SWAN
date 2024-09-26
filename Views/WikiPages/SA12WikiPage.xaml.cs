using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace SWAN.Views.WikiPages
{
    /// <summary>
    /// Interaction logic for Page1.xaml
    /// </summary>
    public partial class SA12WikiPage : Page
    {
        public SA12WikiPage()
        {
            InitializeComponent();

            Dispatcher.BeginInvoke(new Action(() =>
            {
                ScrollToSubsection();
            }), DispatcherPriority.Loaded);
        }

        private void ScrollToSubsection()
        {
            string subsectionName = Application.Current.Properties["SubsectionName"] as string;
            if (!string.IsNullOrEmpty(subsectionName))
            {
                Paragraph targetParagraph = FindParagraphByTag(flowDocument.Blocks, subsectionName);
                if (targetParagraph != null)
                {
                    // Get the vertical offset of the paragraph
                    double verticalOffset = GetParagraphVerticalOffset(targetParagraph);

                    // Access the internal ScrollViewer
                    ScrollViewer scrollViewer = GetScrollViewer(flowDocumentScrollViewer);
                    if (scrollViewer != null)
                    {
                        // Scroll to the exact vertical offset
                        scrollViewer.ScrollToVerticalOffset(verticalOffset);
                    }
                    else
                    {
                        MessageBox.Show("ScrollViewer not found.");
                    }
                }
                else
                {
                    MessageBox.Show($"Subsection '{subsectionName}' not found in the document.");
                }
                Application.Current.Properties.Remove("SubsectionName");

            }
        }

        private double GetParagraphVerticalOffset(Paragraph targetParagraph)
        {
            // Force the layout to update so we can get accurate positions
            flowDocumentScrollViewer.UpdateLayout();

            // Get the TextPointer at the start of the paragraph
            TextPointer contentStart = targetParagraph.ContentStart;

            // Get a bounding rectangle for the TextPointer
            Rect rect = contentStart.GetCharacterRect(LogicalDirection.Forward);

            // The vertical offset is the Y-coordinate of the rectangle
            return rect.Top;
        }

        private ScrollViewer GetScrollViewer(DependencyObject depObj)
        {
            if (depObj is ScrollViewer)
                return (ScrollViewer)depObj;

            for (int i = 0; i < VisualTreeHelper.GetChildrenCount(depObj); i++)
            {
                DependencyObject child = VisualTreeHelper.GetChild(depObj, i);
                ScrollViewer result = GetScrollViewer(child);
                if (result != null)
                    return result;
            }
            return null;
        }

        private Paragraph FindParagraphByTag(BlockCollection blocks, string tag)
        {
            foreach (Block block in blocks)
            {
                if (block is Paragraph paragraph)
                {
                    if ((string)paragraph.Tag == tag)
                    {
                        return paragraph;
                    }
                }
                else if (block is Section section)
                {
                    Paragraph result = FindParagraphByTag(section.Blocks, tag);
                    if (result != null)
                    {
                        return result;
                    }
                }
            }
            return null;
        }
    }
}
