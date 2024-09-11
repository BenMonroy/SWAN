using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;

namespace SWAN.Components
{
    public class PhysicalControl : ObservableObject
    {
        // Required properties to ensure Control and Severity are always set
        public required string Control { get; set; }
        public required string Severity { get; set; }
        public bool Passed { get; set; }  // Indicates if the control has passed
    }

    public class ConceptualCheckBox : ObservableObject
    {
        public string Name { get; set; }  // Name of the conceptual control
        public ObservableCollection<PhysicalControl> PhysicalControls { get; set; }  // Collection of physical controls

        // Constructor to initialize the collection
        public ConceptualCheckBox()
        {
            PhysicalControls = new ObservableCollection<PhysicalControl>();
        }
    }
}
