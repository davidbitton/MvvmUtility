using System;
using System.Globalization;
using System.Windows.Data;

namespace MvvmUtility.Infrastructure.Converters {
    public class IsNullOrEmptyConverter : IValueConverter {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture) {
            return targetType.IsInstanceOfType(value) && !String.IsNullOrEmpty(value.ToString());
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) {
            throw new InvalidOperationException("IsNullOrEmptyConverter can only be used OneWay.");
        }
    }
}
