using System;
using System.Globalization;
using Windows.UI.Xaml.Data;

namespace JDictU.Converters {
    public abstract class BaseValueConverter : IValueConverter {
        public abstract object Convert(object value, Type targetType,
                                       object parameter, CultureInfo culture);
        public abstract object ConvertBack(object value, Type targetType,
                                            object parameter, CultureInfo culture);

        public object Convert(object value, Type targetType, object parameter,
                              string language) {
            CultureInfo ci = CultureInfo.CurrentCulture;
            if(!String.IsNullOrEmpty(language)) {
                ci = new CultureInfo(language);
            }
            return Convert(value, targetType, parameter, ci);
        }

        public object ConvertBack(object value, Type targetType, object parameter,
                                  string language) {
            CultureInfo ci = CultureInfo.CurrentCulture;
            if (!String.IsNullOrEmpty(language)) {
                ci = new CultureInfo(language);
            }
            return ConvertBack(value, targetType, parameter,
                               ci);
        }
    }
}