using System;
using System.Globalization;
using System.Windows.Data;

namespace SWAN.Converters
{
    internal sealed class ThemeToIndexConverter : IValueConverter
    {
        // Convert index to theme string
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            // Ensure value is an int
            if (value is int index)
            {
                // Map the index to the theme string
                return index switch
                {
                    0 => "Light",
                    1 => "Dark",
                    2 => "High Contrast",
                    _ => "Light" // Default to "Light"
                };
            }

            // Default case if value is not an int
            return "Light";
        }

        // Convert theme string back to index
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            // Ensure value is a string
            if (value is string theme)
            {
                // Map the theme string back to the index
                return theme switch
                {
                    "Light" => 0,
                    "Dark" => 1,
                    "High Contrast" => 2,
                    _ => 0 // Default to 0 if the string doesn't match
                };
            }

            // Default case if value is not a string
            return 0;
        }
    }
}
