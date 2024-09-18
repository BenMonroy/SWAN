using System;
using System.Globalization;
using System.Windows.Data;

namespace SWAN.Converters
{
    public class BooleanToPassFailConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is bool booleanValue)
            {
                return booleanValue ? "Pass" : "Fail";
            }
            return "Fail"; // Default to "Fail" if the value is not a boolean
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException(); // One-way binding only
        }
    }
}
