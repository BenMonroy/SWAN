using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Threading;
using System.Windows.Media;

namespace SWAN.Views.WikiPages
{


    public partial class SA10WikiPage : Page
    {
        public SA10WikiPage()
        {
            InitializeComponent();

            //// Delay scrolling until after the UI is fully rendered
            //Dispatcher.BeginInvoke(new Action(() =>
            //{
            //    ScrollToSubsection();
            //}), DispatcherPriority.Loaded);
        }

        //    private void ScrollToSubsection()
        //    {
        //        string subsectionName = Application.Current.Properties["SubsectionName"] as string;
        //        if (!string.IsNullOrEmpty(subsectionName))
        //        {
        //            // Find the target paragraph
        //            Paragraph targetParagraph = FindParagraphByTag(flowDocument.Blocks, subsectionName);
        //            if (targetParagraph != null)
        //            {
        //                // Ensure layout is updated
        //                flowDocumentScrollViewer.UpdateLayout();

        //                // Bring the paragraph into view
        //                targetParagraph.BringIntoView();
        //            }
        //            else
        //            {
        //                MessageBox.Show($"Subsection '{subsectionName}' not found in the document.");
        //            }
        //        }
        //    }

        //    private Paragraph FindParagraphByTag(BlockCollection blocks, string tag)
        //    {
        //        foreach (Block block in blocks)
        //        {
        //            if (block is Paragraph paragraph)
        //            {
        //                if ((string)paragraph.Tag == tag)
        //                {
        //                    return paragraph;
        //                }
        //            }
        //            else if (block is Section section)
        //            {
        //                Paragraph result = FindParagraphByTag(section.Blocks, tag);
        //                if (result != null)
        //                {
        //                    return result;
        //                }
        //            }
        //        }
        //        return null;
        //    }
    }


}
