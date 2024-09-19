using System;
using System.Globalization;
using System.Linq;
using System.Windows;
using System.Windows.Data;
using SWAN.Components;
using System.Collections.ObjectModel;

namespace SWAN.Converters
{
    public class ConceptualVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is ObservableCollection<PhysicalControl> physicalControls)
            {
                // If all physical controls have passed, return Collapsed, otherwise Visible
                return physicalControls.All(control => control.Passed) ? Visibility.Collapsed : Visibility.Visible;
            }

            return Visibility.Visible;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
