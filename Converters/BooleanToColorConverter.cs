using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media;

namespace SWAN.Converters
{
        public class BooleanToColorConverter : IValueConverter
        {
            public Brush TrueBrush { get; set; }
            public Brush FalseBrush { get; set; }

            public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
            {
                if (value is bool boolValue)
                {
                    return boolValue ? TrueBrush : FalseBrush;
                }
                return Brushes.Transparent; // Default if the value is not a boolean
            }

            public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
            {
                throw new NotImplementedException();
            }
        }
    }


