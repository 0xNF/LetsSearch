using System.Linq;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Navigation;
using JDictU.Model;
using System.Diagnostics;
using Windows.System;
using System.Threading;
using Windows.ApplicationModel.DataTransfer;
using JDictU.ViewModels;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace JDictU.Views {
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        static SearchPageViewModel viewmodel { get; set; }
        private string oldText = "";

        private bool ctrlDown { get; set; } = false;
        private bool altDown { get; set; } = false;

        public MainPage() {

            this.InitializeComponent();
            viewmodel = new SearchPageViewModel();
            DataContext = viewmodel;
            this.NoResults.DataContext = viewmodel;
            this.NavigationCacheMode = Windows.UI.Xaml.Navigation.NavigationCacheMode.Enabled;
            this.ProgressBar_Search.DataContext = viewmodel;
            this.EndOfResults.DataContext = viewmodel;

            TextBlock_ExactMatches_Count.DataContext = viewmodel.Exacts;
            TextBlock_InexactMatches_Count.DataContext = viewmodel.Partials;
            StackPanel_ExactMatches.ItemsSource = viewmodel.Exacts;
            StackPanel_InexactMatches.ItemsSource = viewmodel.Partials;
        }

        protected override void OnNavigatedTo(NavigationEventArgs e) {
            var s = e.Parameter as string;
            if (!string.IsNullOrEmpty(s)) { //TODO dangerous - for some reason e.sourcePageType reads as MainPage, even if navigated from History. As such, have to resort to checking for string type. Should be okay, since no other page navigates to MainPage with a parameter.
                //Fill search box and automatically search
                if (s.StartsWith("kanji:")) {
                    string term = s.Substring("kanji:".Length);
                    this.TextBox_Search.Text = term;
                    viewmodel.useDoubleLike = true;
                    searchButton_Internal();
                    viewmodel.useDoubleLike = false;
                }
                else {
                    string term = s;
                    this.TextBox_Search.Text = term;
                    searchButton_Internal();
                }

            }
            else if (e.NavigationMode == NavigationMode.Back) {
                //do nothing, it automatically populates it with stored cached values
            }
            else {
                //Parameter not a search string, and not asking to restore from cache, so reset page by default
                resetPage();
            }
        }

        private void searchGotFocus(object sender, RoutedEventArgs e) {
            TextBox t = (TextBox)sender;
            t.BorderBrush.Opacity = 1;
            t.Background.Opacity = 100;
        }

        private void searchLostFocus(object sender, RoutedEventArgs e) {
            TextBox t = (TextBox)sender;
            t.BorderBrush.Opacity = 0;
            t.Background.Opacity = 74.9;
        }

        //Clears input and sets the focus to the textbox, bringing up the keyboard
        private void clearInput_Tapped(object sender, TappedRoutedEventArgs e) {
            clearInput_Internal();
        }

        //see clearInput_Tapped
        private void clearInput_Internal() {
            this.TextBox_Search.Text = "";
            this.TextBox_Search.Focus(Windows.UI.Xaml.FocusState.Keyboard);
        }

        //Checks if the enter key on the soft keyboard was hit, and if so, search
        private void checkEnter(object sender, KeyRoutedEventArgs e) {
            if (e.Key.Equals(VirtualKey.Enter)) {
                searchButton_Internal();
            }
        }

        //Sanitizes and trims the string, then searches on the term. - FIXME TODO, progress bar never stops
        private void submitSearch(string textboxstring) {
            TextBox_Search.Text = TextBox_Search.Text.Trim().Replace("%", "");
            string searchText = TextBox_Search.Text;
            if (searchText.Length != 0) {
                int numapos = searchText.Count(f => f == '\'');
                if (numapos != 0) {
                    searchText = searchText.Replace("'", "''");
                }
                viewmodel.submitSearch(searchText, SynchronizationContext.Current);
            }
        }

        internal void checkHotkeysUp(object sender, KeyRoutedEventArgs e) {
            if ((e.Key == VirtualKey.D && altDown)
                || (e.Key == VirtualKey.E && ctrlDown)
                ) {
                // highlight search
                this.TextBox_Search.Focus(Windows.UI.Xaml.FocusState.Keyboard);
            }
            if (e.Key == VirtualKey.D && ctrlDown) {

            }
            else if (e.Key == VirtualKey.Control) {
                ctrlDown = false;
            } else if (e.Key == VirtualKey.Menu) {
                altDown = false;
            }
        }

        internal void checkHotkeysDown(object sender, KeyRoutedEventArgs e) {
            if(e.Key == VirtualKey.Control) {
                ctrlDown = true;
            }else if(e.Key == VirtualKey.Menu) {
                altDown = true;
            }
        }

        private void keyByKeySearch(object sender, TextChangedEventArgs e) {
            if(TextBox_Search.Text == oldText) {
                return;
            }
            oldText = TextBox_Search.Text;
            viewmodel.resetViewModel();
            TextBox_Search.Text.Trim().Replace("%", "");
            string searchText = TextBox_Search.Text;
            if (searchText.Length != 0) {
                viewmodel.keybykey = true;
                int numapos = searchText.Count(f => f == '\'');
                if (numapos != 0) {
                    searchText = searchText.Replace("'", "''");
                }
                viewmodel.submitSearch(searchText, SynchronizationContext.Current, limit: 5);
            }
            else {
                viewmodel.keybykey = false;
            }

        }

        //Colapses or expands a given stackpanel (item control) from view
        private void collapse(object sender, TappedRoutedEventArgs e) {
            StackPanel sentFrom = (StackPanel)sender;
            TextBlock signToChange;
            ItemsControl thingToCollapse;
            if (sentFrom.Name == "StackPanel_ExactMatches_TextBlock") {
                thingToCollapse = this.StackPanel_ExactMatches;
                signToChange = this.TextBlock_ExactMatches_Sign;
            }
            else {
                thingToCollapse = this.StackPanel_InexactMatches;
                signToChange = this.TextBlock_InexactMatches_Sign;
            }
            if (thingToCollapse.Visibility == Visibility.Visible) {
                thingToCollapse.Visibility = Visibility.Collapsed;
                signToChange.Text = signToChange.Text.Replace('-', '+');
            }
            else if (thingToCollapse.Visibility == Visibility.Collapsed) {
                thingToCollapse.Visibility = Visibility.Visible;
                signToChange.Text = signToChange.Text.Replace('+', '-');
            }
        }

        //FIXME TODO NYI have to add this button - adds an additional max 25 results from the [Lists]_Full to [Lists] for display
        private void addMoreResults(object sender, TappedRoutedEventArgs e) {

        }


        #region Command Bar methods
        //Navigate to the Favorites page
        private void toFavorites(object sender, RoutedEventArgs e) {
            this.Frame.Navigate(typeof(FavoritesPage));

        }

        //Navigate to the History Page
        private void toHistory(object sender, RoutedEventArgs e) {
            this.Frame.Navigate(typeof(HistoryPage));
        }

        //When the Search Button is hit (also triggered by CheckEnter)
        private void searchButton_Click(object sender, TappedRoutedEventArgs e) {
            searchButton_Internal();
        }

        private void searchButton_Tapped(object sender, RoutedEventArgs e) {
            searchButton_Internal();
        }

        private void searchButton_Click(object sender, RoutedEventArgs e) {
            searchButton_Internal();
        }

        //When the search button on command bar is hit, searches non-empty text or resets the page
        private void searchButton_Internal() {
            viewmodel.keybykey = false;
            string tosearch = TextBox_Search.Text.Trim();
            if (viewmodel.SearchComplete) {
                resetPage();
            }
            //This ungracefully dismisses the touch keyboard
            this.Focus(FocusState.Pointer);
            TextBox_Search.IsEnabled = false;
            TextBox_Search.IsTabStop = false;
            TextBox_Search.IsEnabled = true;
            TextBox_Search.IsTabStop = true;
            //Start the real work
            TextBox_Search.Text = tosearch;
            if (!tosearch.Equals("")) {
                submitSearch(tosearch);
            }
        }

        #endregion

        //Resets the page to the default no results displayed
        private void resetPage() {
            viewmodel.resetViewModel();
            this.clearInput_Internal();
            this.NoResults.Visibility = Visibility.Collapsed;
            this.EndOfResults.Visibility = Visibility.Collapsed;
            this.Button_PartialFetchMore.Visibility = Visibility.Collapsed;
        }


        //Debug method
        private void addSR(object sender, RoutedEventArgs e) {
            SearchResult sr = Model.SearchResult.createDebugSR();
            viewmodel.Exacts.Add(sr);
            Debug.WriteLine(sr.defText);
        }

        private void resultClicked(object sender, TappedRoutedEventArgs e) {
            SearchResult sr = (SearchResult)((Grid)sender).Tag;
            if (sr.headerText.EndsWith("[Kanji]")) {
                string literal = sr.headerText[0].ToString();
                Frame.Navigate(typeof(KanjiPage), literal);
            }
            else {
                Frame.Navigate(typeof(Result), sr);
            }
        }

        private void toAbout(object sender, RoutedEventArgs e) {
            Frame.Navigate(typeof(AboutPage));
        }

        private void toKanjiLookup(object sender, RoutedEventArgs e) {
            Frame.Navigate(typeof(KanjiLookupPage));
        }


        private void copyText(object sender, RoutedEventArgs e) {
            FrameworkElement tb = sender as FrameworkElement;
            string text = (string)tb.DataContext;
            DataPackage dp = new DataPackage {
                RequestedOperation = DataPackageOperation.Copy
            };
            dp.SetText(text);
            Clipboard.SetContent(dp);
        }
    }
}
