﻿using System;
using System.Globalization;
using Windows.UI.Xaml;


namespace JDictU.Converters {
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
