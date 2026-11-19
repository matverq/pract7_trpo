using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace pract7_trpo.Converters
{
    public class DiscountConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null) return string.Empty;
            if (decimal.TryParse(value.ToString(), NumberStyles.Any, culture, out decimal result))
                return result * 100;
            return string.Empty;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null) return null;
            if (decimal.TryParse(value.ToString(), NumberStyles.Any, culture, out decimal result))
                return result / 100m;
            return null;
        }
    }
}
