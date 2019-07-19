using System;
using System.Globalization;
using JDictU.Model;

namespace JDictU.Converters {
    public class ToKanjiObjectConverter : BaseValueConverter {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture) {
            if (value == null) {
                return KanjiOrderingSelect.ByJLPT;
            }
            KanjiOrderingSelect kos = (KanjiOrderingSelect)value;
            return kos;
        }

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) {
            if (value == null) {
                return KanjiOrderingSelect.ByJLPT;
            }
            KanjiOrderingSelect kos = (KanjiOrderingSelect)value;
            return kos;
        }
    }

    public class ToUpDownConverter : BaseValueConverter {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture) {
            if (value == null) {
                return AscendingDescending.ASC;
            }
            AscendingDescending kos = (AscendingDescending)value;
            return kos;
        }

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) {
            if (value == null) {
                return AscendingDescending.AscnendingDescendings;
            }
            AscendingDescending kos = (AscendingDescending)value;
            return kos;
        }
    }
}