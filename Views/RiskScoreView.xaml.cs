<<<<<<< HEAD
﻿using System.Windows.Controls;
=======
﻿using System;
using System.Collections.ObjectModel;
using System.Windows.Controls;
>>>>>>> main
using SWAN.ViewModels;

namespace SWAN.Views
{
    public partial class RiskScoreView : UserControl
    {
        public RiskScoreViewModel ViewModel { get; private set; }

        public RiskScoreView(RMFDashboardViewModel dashboardViewModel)
        {
            InitializeComponent();
            // Initialize the ViewModel with the dashboard view model
            ViewModel = new RiskScoreViewModel(dashboardViewModel);
            DataContext = ViewModel;
        }
    }
}
