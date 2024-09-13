using System.Globalization;
using System.Windows.Data;

namespace SWAN.Converters
{
    public class BooleanToCheckedConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is bool boolValue)
            {
                return boolValue ? "Checked" : "Unchecked";
            }
            return "Unchecked";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value is string strValue && strValue.Equals("Checked", StringComparison.OrdinalIgnoreCase);
        }
    }
}
