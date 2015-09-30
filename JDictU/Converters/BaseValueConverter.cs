using System;
using System.Globalization;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Media;
using JDictU.Model;
using Windows.UI.Xaml.Data;

namespace JDictU{
    public abstract class BaseValueConverter : IValueConverter {
        public abstract object Convert(object value, Type targetType,
                                       object parameter, CultureInfo culture);
        public abstract object ConvertBack(object value, Type targetType,
                                            object parameter, CultureInfo culture);

        public object Convert(object value, Type targetType, object parameter,
                              string language) {
            return Convert(value, targetType, parameter, new CultureInfo(language));
        }

        public object ConvertBack(object value, Type targetType, object parameter,
                                  string language) {
            return ConvertBack(value, targetType, parameter,
                               new CultureInfo(language));
        }
    }    
}