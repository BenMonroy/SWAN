using SWAN.Components;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWAN.Services;

public class ConceptualControlsUpdatedMessage
{
    public ObservableCollection<ConceptualCheckBox> UpdatedControls { get; }

    public ConceptualControlsUpdatedMessage(ObservableCollection<ConceptualCheckBox> updatedControls)
    {
        UpdatedControls = updatedControls;
    }
}
