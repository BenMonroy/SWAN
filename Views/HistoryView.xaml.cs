using System.Collections.Generic;
using System.Windows.Controls;

namespace SWAN.Views
{
    public partial class HistoryView : UserControl
    {
        public List<HorizontalSection> HorizontalSections { get; set; } = new();

        public HistoryView()
        {
            InitializeComponent();
            LoadData();
            DataContext = this; // Set DataContext for binding
        }

        private void LoadData()
        {
            HorizontalSections.Add(new HorizontalSection
            {
                Title = "Section 1",
                Main = "This is the main content for section 1.",
                Stuff = "Additional information for section 1."
            });

            HorizontalSections.Add(new HorizontalSection
            {
                Title = "Section 2",
                Main = "This is the main content for section 2.",
                Stuff = "Additional information for section 2."
            });

            HorizontalSections.Add(new HorizontalSection
            {
                Title = "Section 3",
                Main = "This is the main content for section 3.",
                Stuff = "Additional information for section 3."
            });
        }
    }

    public class HorizontalSection
    {
        public string Title { get; set; } = string.Empty;
        public string Main { get; set; } = string.Empty;
        public string Stuff { get; set; } = string.Empty;
    }
}
