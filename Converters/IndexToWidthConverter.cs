using System;
using System.Globalization;
using System.Windows.Data;

namespace SWAN.Converters
{
    public class IndexToWidthConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            // Convert the CheckBoxWidth (1-5) to the ComboBox SelectedIndex (0-4)
            if (value is int width)
            {
                return width - 1; // Subtract 1 to match the ComboBox's 0-based index
            }
            return 0; // Default to first ComboBoxItem if value is not valid
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            // Convert the ComboBox SelectedIndex (0-4) back to CheckBoxWidth (1-5)
            if (value is int selectedIndex)
            {
                return selectedIndex + 1; // Add 1 to match the CheckBoxWidth
            }
            return 1; // Default to CheckBoxWidth 1 if value is not valid
        }
    }
}
