using System;
using System.Globalization;
using Windows.UI.Xaml;

namespace JDictU{
    public class PlusMinusConverter : BaseValueConverter {

        //http://dotnet.dzone.com/articles/build-both-converters-windows
        //http://stackoverflow.com/questions/4253554/xaml-binding-to-a-converter
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture) {
            if (value != null && value is int && parameter != null) {
                var bValue = (int)value;
                //var visibility = (Visibility)Enum.Parse(
                //     typeof(Visibility), parameter.ToString(), true);
                if (bValue == 0) {
                    return "*";
                }
                else {
                    return Visibility.Collapsed;
                }
            }

            return null;
        }

        public override object ConvertBack(object value, Type targetType, object parameter,
                           CultureInfo culture) {
            throw new NotImplementedException();
        }
    }
}
