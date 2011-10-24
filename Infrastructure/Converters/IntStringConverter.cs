using System;
using System.Windows.Data;

namespace MvvmUtility.Infrastructure.Converters {
    public class IntStringConverter : IValueConverter {

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture) {
            if (value == null) return string.Empty;
            var val = (int)value;
            return val == 0 ? string.Empty : value.ToString();
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture) {
            int retVal;
            return int.TryParse(value.ToString(), out retVal) ? retVal : 0;
        }
    }

}

