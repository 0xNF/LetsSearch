using System;
using System.Collections;
using System.Globalization;
using Windows.UI.Xaml;
using System.Diagnostics;

namespace JDictU.Converters {

    public class VisibilityConverter : BaseValueConverter
    {

        //http://dotnet.dzone.com/articles/build-both-converters-windows
        //http://stackoverflow.com/questions/11323169/converter-with-multiple-parameter
            public override object Convert(object value, Type targetType, object parameter, CultureInfo culture) {
                if (value != null && value is bool && parameter != null) {
                    var bValue = (bool)value;
                    if (bValue) {
                    Debug.WriteLine("Vis was True, setting to Visiible :");
                    return Visibility.Visible;//visibility;
                    }
                    else {
                    Debug.WriteLine("Vis was False, setting to INvisivle :");
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

    public class InverseVisibilityConverter : BaseValueConverter {

        //http://dotnet.dzone.com/articles/build-both-converters-windows
        //http://stackoverflow.com/questions/11323169/converter-with-multiple-parameter
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture) {
            if (value != null && value is bool) {
                var bValue = (bool)value;
                if (bValue) {
                    Debug.WriteLine("Vis was True, setting to Visiible :");
                    return Visibility.Collapsed;//visibility;
                }
                else {
                    Debug.WriteLine("Vis was False, setting to INvisivle :");
                    return Visibility.Visible;
                }
            }

            return null;
        }

        public override object ConvertBack(object value, Type targetType, object parameter,
                           CultureInfo culture) {
            throw new NotImplementedException();
        }
    }

    public class VisibilityConverterListCount : BaseValueConverter {

        //http://dotnet.dzone.com/articles/build-both-converters-windows
        //http://stackoverflow.com/questions/11323169/converter-with-multiple-parameter
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture) {
            if (value != null) {
                int c = (int)value;
                if (c > 0) {
                    return Visibility.Visible;//visibility;
                }
                else {
                    return Visibility.Collapsed;
                }
            }

            return Visibility.Visible;
        }

        public override object ConvertBack(object value, Type targetType, object parameter,
                           CultureInfo culture) {
            throw new NotImplementedException();
        }
    }

    public class VisibilityConverterStringisEmptyString : BaseValueConverter {

        //http://dotnet.dzone.com/articles/build-both-converters-windows
        //http://stackoverflow.com/questions/11323169/converter-with-multiple-parameter
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture) {
            if (value != null) {
                string c = (string)value;
                if (c != "") {
                    return Visibility.Visible;//visibility;
                }
                else {
                    return Visibility.Collapsed;
                }
            }

            return Visibility.Visible;
        }

        public override object ConvertBack(object value, Type targetType, object parameter,
                           CultureInfo culture) {
            throw new NotImplementedException();
        }
    }

    public class VisibilityConverterListEmpty : BaseValueConverter {

        //http://dotnet.dzone.com/articles/build-both-converters-windows
        //http://stackoverflow.com/questions/11323169/converter-with-multiple-parameter
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture) {
            Debug.WriteLine("INVOKED WITH: " + parameter);
            if (value != null && value is bool && parameter != null) {

                string[] parameters = ((string)parameter).Split(new char[] { '|' });
                if (bool.Parse(parameters[0]) && parameters[1].Equals("0") && parameters[2].Equals("0")) {
                    return Visibility.Visible;
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


    //TODO This dont work for shit, yo. Null values interpreted as False in XAML, and it probably only received one update from the list?
    public class TrueIfListNotEmptyConverter : BaseValueConverter {

        //http://dotnet.dzone.com/articles/build-both-converters-windows
        //http://stackoverflow.com/questions/11323169/converter-with-multiple-parameter
        public override object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture) {
            if (parameter == null)
                return false;
            return ((ICollection) parameter).Count > 0;
        }

        public override object ConvertBack(object value, Type targetType, object parameter,
                           CultureInfo culture) {
            throw new NotImplementedException();
        }
    }
}
