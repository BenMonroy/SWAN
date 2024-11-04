using System;
using System.Globalization;
using System.Windows.Data;

namespace SWAN.Converters
{
    public class ColumnIndexConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is int index)
            {
                // Return 0 for even indices (left column) and 1 for odd indices (right column)
                return index % 2;
            }
            return 0;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}