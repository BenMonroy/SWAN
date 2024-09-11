using SWAN.Components;
using SWAN.ViewModels;
using System.Collections.Generic;
using System.Windows.Controls;

namespace SWAN.Views
{
    public partial class HistoryView : UserControl
    {
        public HistoryView(HistoryViewModel viewModel)
        {
            InitializeComponent();
            this.DataContext = viewModel;
        }
    }
}
