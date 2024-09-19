using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;
using System.Windows;

namespace SWAN.Components
{
    public partial class PhysicalControl : ObservableObject
    {
        // Required properties to ensure Control and Severity are always set
        public required string Control { get; set; }
        [ObservableProperty]
        public bool passed;  // Indicates if the control has passed
    }

    public partial class ConceptualCheckBox : ObservableObject
    {
        public string Name { get; set; }  // Name of the conceptual control

        [ObservableProperty]
        public bool allPassed;

        [ObservableProperty]
        public bool isVisible;
        public string Severity { get; set; }

        [ObservableProperty]
        public int failedCount;
        public string CIA { get; set; }
        public ObservableCollection<PhysicalControl> PhysicalControls { get; set; }  // Collection of physical controls

        // Constructor to initialize the collection
        public ConceptualCheckBox()
        {
           
        }
    }
}
