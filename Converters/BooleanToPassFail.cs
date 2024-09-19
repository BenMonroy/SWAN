using System;
using System.Globalization;
using System.Windows.Data;

namespace SWAN.Converters
{
    public class BooleanToPassFail : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is bool boolValue)
            {
                return boolValue ? "Passed" : "Failed";
            }
            return "Failed"; // Default value in case of unexpected value
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is string strValue)
            {
                return strValue.Equals("Passed", StringComparison.OrdinalIgnoreCase);
            }
            return false; // Default value in case of unexpected value
        }
    }
}
