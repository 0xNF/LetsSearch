using System;
using System.Linq;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;
using Windows.UI;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace JDictU {
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class KanjiLookupPage : Page {

        KanjiLookupPageViewModel view { get; set; }

        SolidColorBrush transparent = new SolidColorBrush(Colors.Transparent);
        SolidColorBrush IceBlueBrush = new SolidColorBrush(colorFromHex("FF91C3FF"));



        public KanjiLookupPage() {
            this.InitializeComponent();
            view = new KanjiLookupPageViewModel(this.lb_1,this.lb_2,this.lb_3,this.lb_4,this.lb_5,this.lb_6,this.lb_7,this.lb_8,this.lb_9,this.lb_10,this.lb_11,this.lb_12,this.lb_13,this.lb_14, this.lb_17);
            //this.DataContext = view;
        }


        private childItem FindVisualChild<childItem>(DependencyObject obj)
where childItem : DependencyObject {
            for (int i = 0; i < VisualTreeHelper.GetChildrenCount(obj); i++) {
                DependencyObject child = VisualTreeHelper.GetChild(obj, i);
                if (child != null && child is childItem)
                    return (childItem)child;
                else {
                    childItem childOfChild = FindVisualChild<childItem>(child);
                    if (childOfChild != null)
                        return childOfChild;
                }
            }
            return null;
        }



        private void getSelectedRadicals() {

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

        private void toAbout(object sender, RoutedEventArgs e) {
            this.Frame.Navigate(typeof(AboutPage));
        }

        private void lbSelectionChanged(object sender, SelectionChangedEventArgs e) {
            ListBox lb = sender as ListBox;
            string name = lb.Name;
            var x = e.AddedItems.ToList();
            if(e.AddedItems.Count > 0) {
                view.selectedRadicals.Add(e.AddedItems[0] as string);
            }
            else if(e.RemovedItems.Count > 0) {
                view.selectedRadicals.Remove(e.RemovedItems[0] as string);
            }
            view.getKanjiForRadicals(view.selectedRadicals);


            foreach (ListBox lbox in view.lbs) {
                StackPanel lbPanel = FindVisualChild<StackPanel>(lbox);
                foreach (ListBoxItem lbi in lbPanel.Children) {
                    string content = lbi.Content as string;
                    bool isIn = view.validRadicals.Contains(content);
                    if (!isIn) {
                        lbi.Background = transparent;
                    }
                    else {
                        lbi.Background = IceBlueBrush;
                    }
                }
            }    

        }

        public static Color colorFromInt(int input) {
            Color c = Color.FromArgb((byte)((input & -16777216) >> 0x18),
         (byte)((input & 0xff0000) >> 0x10),
         (byte)((input & 0xff00) >> 8),
         (byte)(input & 0xff));
            return c;
        }

        public static int hex2colorint(string input) {
            int argb = Int32.Parse(input, System.Globalization.NumberStyles.HexNumber);
            return argb;
        }

        public static Color colorFromHex(string input) {
            return colorFromInt(hex2colorint(input));
        }


        private void searchThisKanji(object sender, ItemClickEventArgs e) {
            string kanji = e.ClickedItem as string;
            Frame.Navigate(typeof(KanjiPage), kanji);
        }
    }
}
