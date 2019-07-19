using JDictU.Model;
using JDictU.Views;
using System.Collections.ObjectModel;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace JDictU.Views {
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class FavoritesPage : Page {

        ObservableCollection<Favorites> favs = new ObservableCollection<Favorites>();

        public FavoritesPage() {
            this.InitializeComponent();
            populateFavorites();
            this.DataContext = favs;
        }

        private async void populateFavorites() {
            var x = await UserData.retrieveFavorite();
            foreach(Favorites f in x) {
                favs.Add(f);
            }
        }


        private void toResult(object sender, TappedRoutedEventArgs e) {
            Grid g = sender as Grid;
            int id = (int)g.Tag;
            Frame.Navigate(typeof(Result), id);
        }

        private void toHistory(object sender, RoutedEventArgs e) {
            this.Frame.Navigate(typeof(HistoryPage));
        }

        private void goToSearch(object sender, RoutedEventArgs e) {
            this.Frame.Navigate(typeof(MainPage));
        }

        private async void clearFavorites(object sender, RoutedEventArgs e) {
            await UserData.clearFavorites();
            this.favs.Clear();
        }
    }
}
