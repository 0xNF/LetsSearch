﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;
using JDictU.Model;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace JDictU {
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class HistoryPage : Page {

        private static string fieldToOrderBy = "search_date";
        private static string direction = "DESC";

        public HistoryPage() {
            this.InitializeComponent();
        }

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.
        /// This parameter is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e) {
            getHistory(fieldToOrderBy, direction);
        }

        private async Task getHistory(string field, string order) {
            changeArrow();
            var res = await Task.Run(() => UserData.retrieveSearchHistory(field, order));
            this.ItemsControl_History.ItemsSource = res;
        }

        private void changeArrow() {
            if (fieldToOrderBy == "search_query") {
                //Setting SearchTermSort
                Image_SearchTermSort.Symbol = Symbol.Up;
                SearchTermSort_Icon_Rotation.Rotation = direction == "DESC" ? 180 : 0;

                //Fixing the DateTermSort
                this.Image_DateTermSort.Symbol = Symbol.Sort;
                this.DateTermSort_Icon_Rotation.Rotation = 0;
            }
            else {
                //Setting DateTermSort
                Image_DateTermSort.Symbol = Symbol.Up;
                DateTermSort_Icon_Rotation.Rotation = direction == "DESC" ? 180 : 0;

                //Fixing the SearchTermSort
                this.Image_SearchTermSort.Symbol = Symbol.Sort;
                this.SearchTermSort_Icon_Rotation.Rotation = 0;
            }
        }

        private void searchChangeSort(object sender, TappedRoutedEventArgs e) {
            direction = direction == "DESC" ? "ASC" : "DESC";
            fieldToOrderBy = "search_query";
            getHistory("search_query", direction);
        }

        private void dateChangeSort(object sender, TappedRoutedEventArgs e) {
            direction = direction == "DESC" ? "ASC" : "DESC";
            fieldToOrderBy = "search_date";
            getHistory("search_date", direction);
        }

        private void searchThis(object sender, TappedRoutedEventArgs e) {
            //string term = ((Grid) sender).Tag as string;
            string term = ((TextBlock)((Grid)sender).Children[0]).Text;
            Frame.Navigate(typeof(MainPage), term);
        }

        //go to a blank SearchPage
        private void goToSearch(object sender, RoutedEventArgs e) {
            Frame.Navigate(typeof(MainPage));
        }


        //Deleting history
        private async Task clearHistoryHelper() {
            await UserData.clearHistory();
            getHistory(fieldToOrderBy, direction);
        }

        private void clearHistory(IUICommand u) {
            clearHistoryHelper();
        }

        //Opens popup box asking if they're sure they want to clear their history
        //TODO NYI, investigate popup boxes for this
        private void clearHistoryCheck(object sender, RoutedEventArgs e) {
            MessageDialog m = new MessageDialog("This will delete all your search history. Continue?");
            var del = new Windows.UI.Popups.UICommand("Delete");
            var quit = new Windows.UI.Popups.UICommand("Cancel");
            del.Invoked += clearHistory;
            m.Commands.Add(del);
            m.Commands.Add(quit);
            m.DefaultCommandIndex = 1;
            m.ShowAsync();
        }

        //TODO NYI
        private void clearSingleHistory(object sender, RoutedEventArgs e) {

        }

        private void toFavorites(object sender, RoutedEventArgs e) {
            this.Frame.Navigate(typeof(FavoritesPage));
        }
    }
}

