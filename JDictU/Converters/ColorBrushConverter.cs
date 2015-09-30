using System;
using System.Globalization;
using Windows.UI.Xaml.Media;

using JDictU.Model;


namespace JDictU
{
    public class ColorBrushConverter : BaseValueConverter {

        //{Binding Path=verified, Converter={StaticResource ColorBrushConverter}}
        //http://dotnet.dzone.com/articles/build-both-converters-windows
        //http://stackoverflow.com/questions/11323169/converter-with-multiple-parameter
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture) {
            if (value != null && value is int) {
                var bValue = (int)value;
                if (bValue == 1) {
                    SolidColorBrush scb = SearchPageViewModel.HighlightedGreen;
                    return scb;
                }
                else {
                    return SearchPageViewModel.IceBlue;
                }
            }

            return null;
        }

        public override object ConvertBack(object value, Type targetType, object parameter,
                           CultureInfo culture) {
            throw new NotImplementedException();
        }
    }

    public class InverseColorBrushConverter : ColorBrushConverter {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture) {
            int val = (int) value;
            val = val == 0 ? 1 : 0;
            return base.Convert(val, targetType, parameter, culture);
        }
    }
}
