using JDictU.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The User Control item template is documented at https://go.microsoft.com/fwlink/?LinkId=234236

namespace JDictU.Controls {
    public sealed partial class SearchResultControl : UserControl, INotifyPropertyChanged {

        #region INotifyPropertyChanged

        public event PropertyChangedEventHandler PropertyChanged;

        public void Set<T>(ref T storage, T value, [CallerMemberName] string propertyName = null) {
            if (!Equals(storage, value)) {
                storage = value;
                RaisePropertyChanged(propertyName);
            }
        }

        public void RaisePropertyChanged([CallerMemberName] string propertyName = null) =>
           PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        #endregion

        public SearchResult SearchResult { get { return _SearchResult; } set { Set(ref _SearchResult, value); } }
        SearchResult _SearchResult = default(SearchResult);

        DependencyProperty SearchResultDepenencyProperty = DependencyProperty.Register(nameof(SearchResult), typeof(SearchResult), typeof(SearchResultControl), new PropertyMetadata(default(SearchResult)));

        public SearchResultControl() {
            this.InitializeComponent();
        }
    }
}
