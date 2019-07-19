using System;
using System.Threading.Tasks;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Navigation;
using JDictU.Model;


namespace JDictU.Views {
    public sealed partial class HistoryPage : Page {

        enum SortOrder {
            ASC = 0,
            DESC = 1
        }

        private static string fieldToOrderBy = "search_date";
        private static SortOrder direction = SortOrder.DESC;

        public ResettableObservableCollection<History> history { get; } = new ResettableObservableCollection<History>();

        public HistoryPage() {
            this.InitializeComponent();
            this.DataContext = this;
        }


        protected override async void OnNavigatedTo(NavigationEventArgs e) {
            await getHistory();
        }

        private async Task getHistory() {
            history.Clear();
            changeArrow();
            string d = "ASC";
            if(direction  == SortOrder.ASC) {
                d = "ASC";
            } else {
                d = "DESC";
            }
            var res = await Task.Run(() => UserData.retrieveSearchHistory(fieldToOrderBy, d));
            history.AddRange(res);
        }

        private void changeArrow() {
            if (fieldToOrderBy == "search_query") {
                //Setting SearchTermSort
                Image_SearchTermSort.Symbol = Symbol.Up;
                SearchTermSort_Icon_Rotation.Rotation = direction == SortOrder.DESC ? 180 : 0;

                //Fixing the DateTermSort
                this.Image_DateTermSort.Symbol = Symbol.Sort;
                this.DateTermSort_Icon_Rotation.Rotation = 0;
            }
            else {
                //Setting DateTermSort
                Image_DateTermSort.Symbol = Symbol.Up;
                DateTermSort_Icon_Rotation.Rotation = direction == SortOrder.DESC ? 180 : 0;

                //Fixing the SearchTermSort
                this.Image_SearchTermSort.Symbol = Symbol.Sort;
                this.SearchTermSort_Icon_Rotation.Rotation = 0;
            }
        }

        private void searchChangeSort(object sender, TappedRoutedEventArgs e) {
            fieldToOrderBy = "search_query";
            if (direction == SortOrder.DESC) {
                direction = SortOrder.ASC;
            } else {
                direction = SortOrder.DESC;
            }
            getHistory().ConfigureAwait(false);
        }

        private void dateChangeSort(object sender, TappedRoutedEventArgs e) {
            fieldToOrderBy = "search_date";
            if (direction == SortOrder.DESC) {
                direction = SortOrder.ASC;
            }
            else {
                direction = SortOrder.DESC;
            }
            getHistory().ConfigureAwait(false);
        }

        private void searchThis(object sender, TappedRoutedEventArgs e) {
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
            await getHistory();
        }

        private async void clearHistory(IUICommand u) {
            await clearHistoryHelper();
        }

        //Opens popup box asking if they're sure they want to clear their history
        //TODO NYI, investigate popup boxes for this
        private async Task _clearHistoryCheck() {
            MessageDialog m = new MessageDialog("This will delete all your search history. Continue?");
            var del = new UICommand("Delete");
            var quit = new UICommand("Cancel");
            del.Invoked += clearHistory;
            m.Commands.Add(del);
            m.Commands.Add(quit);
            m.DefaultCommandIndex = 1;
            await m.ShowAsync();
        }
        private async void clearHistoryCheck(object sender, RoutedEventArgs e) {
            await _clearHistoryCheck();
        }

        //TODO NYI
        private void clearSingleHistory(object sender, RoutedEventArgs e) {

        }

        private void toFavorites(object sender, RoutedEventArgs e) {
            this.Frame.Navigate(typeof(FavoritesPage));
        }
    }
}

