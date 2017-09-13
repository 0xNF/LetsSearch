﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.ApplicationModel.DataTransfer;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace JDictU {
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class KanjiPage : Page {

        private KanjiPageViewModel view { get; set; }
        private string rads { get; set; }

        public KanjiPage() {
            this.InitializeComponent();
            view = new KanjiPageViewModel();
            this.DataContext = view;
        }


        protected override void OnNavigatedTo(NavigationEventArgs e) {
            if(e.Parameter != null) {
                if(e.Parameter.GetType() == typeof(string)) {
                    string literal = e.Parameter as string;
                    view = new KanjiPageViewModel(literal);
                }else if(e.Parameter.GetType() == typeof(KanjiPageViewModel)) {
                    view = e.Parameter as KanjiPageViewModel;
                }    
                this.DataContext = view;
            }
        }

        private void toHistory(object sender, RoutedEventArgs e) {
            this.Frame.Navigate(typeof(HistoryPage));
        }

        private void toFavorites(object sender, RoutedEventArgs e) {
            this.Frame.Navigate(typeof(FavoritesPage));

        }

        private void toKanjiLookup(object sender, RoutedEventArgs e) {
            this.Frame.Navigate(typeof(KanjiLookupPage));

        }

        private void goToSearch(object sender, RoutedEventArgs e) {
            this.Frame.Navigate(typeof(MainPage));
        }

        private void findThisKanji(object sender, RoutedEventArgs e) {
            this.Frame.Navigate(typeof(MainPage), "kanji:" + view.literal);
        }
        private void copyText(object sender, RoutedEventArgs e) {
            FrameworkElement tb = sender as FrameworkElement;
            string text = (string)tb.DataContext;
            DataPackage dp = new DataPackage();
            dp.RequestedOperation = DataPackageOperation.Copy;
            dp.SetText(text);
            Clipboard.SetContent(dp);
        }
    }
}