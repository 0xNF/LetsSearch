using System;
using System.Globalization;

namespace JDictU{
    public class DateConverter : BaseValueConverter
    {

       // {Binding Path=verified, Converter={StaticResource ColorBrushConverter}}
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture) {
            if (value != null && value is long) {
                var ticks = (long)value;
                var d = new DateTime(ticks).ToUniversalTime();
                var dstring = d.ToString() + " [" + d.DayOfWeek + "]";
                return dstring;
            }
            return null;
        }

       public override object ConvertBack(object value, Type targetType, object parameter,
                           CultureInfo culture) {
            throw new NotImplementedException();
        }
    }

}
