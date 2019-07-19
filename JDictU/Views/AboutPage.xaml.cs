using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace JDictU {
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class AboutPage : Page {
        public AboutPage() {
            this.InitializeComponent();
        }

        private void openFeedback(object sender, RoutedEventArgs e) {
            ComposeEmail();
        }

        private async void ComposeEmail() {
            var emailMessage = new Windows.ApplicationModel.Email.EmailMessage();
            emailMessage.Subject = "Feedback about Let's Search!";
            var emailRecipient = new Windows.ApplicationModel.Email.EmailRecipient("sagasou@articulateinsights.com");
            emailRecipient.Name = "Let's Search! Devs";
            emailMessage.To.Add(emailRecipient);
            await Windows.ApplicationModel.Email.EmailManager.ShowComposeNewEmailAsync(emailMessage);
        }

        private void goToSearch(object sender, RoutedEventArgs e) {
            this.Frame.Navigate(typeof(MainPage));
        }

        private void toFavorites(object sender, RoutedEventArgs e) {
            this.Frame.Navigate(typeof(FavoritesPage));

        }
        private void toHistory(object sender, RoutedEventArgs e) {
            this.Frame.Navigate(typeof(HistoryPage));
        }
    }
}
