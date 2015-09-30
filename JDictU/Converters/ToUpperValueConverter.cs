using System;
using System.Collections.Generic;
using System.Text;
using System.Globalization;
using System.Windows;
using JDictU.Model;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Media;


namespace JDictU{
    public class ToUpperValueConverter : BaseValueConverter {
        public override object Convert(object value, Type targetType,
                               object parameter, CultureInfo culture) {
            if (value == null) return string.Empty;

            return value.ToString().ToUpperInvariant();
        }

        public override object ConvertBack(object value, Type targetType,
                                           object parameter, CultureInfo culture) {
            return DependencyProperty.UnsetValue;
        }
    }    
}
