using System;
using System.Collections.Generic;
using JDictU.Model;
using System.Collections.ObjectModel;
using Windows.UI.Xaml.Media;
using Windows.UI;
using System.Threading.Tasks;
using System.Diagnostics;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading;

namespace JDictU.Model {
    public class SearchPageViewModel : INotifyPropertyChanged// : BaseViewModel
    {

        public static readonly SolidColorBrush Black = GetColorFromHexa("#00000000");
        public static readonly SolidColorBrush Grey = GetColorFromHexa("#FF131313");
        public static readonly SolidColorBrush HighlightedGreen = GetColorFromHexa("#FF91FAFF");
        public static readonly SolidColorBrush IceBlue = GetColorFromHexa("#FF91C3FF");
        private static bool _lastColorWasGrey = true;
        public static SolidColorBrush CurrentColor{
            get {
                if (!_lastColorWasGrey) {
                    _lastColorWasGrey = true;
                    return Grey;
                }
                else {
                    _lastColorWasGrey = false;
                    return Black;
                }
            }
        }
        private static bool _progressBarActive = false;
        public bool ProgressBarActive {
            get {
                return _progressBarActive;
            }
            set {
                _progressBarActive = value;
                NotifyPropertyChanged();
            }
        }
        private static bool _searchComplete = true;
        public bool SearchComplete {
            get {
                return _searchComplete;
            }
            set {
                _searchComplete = value;
                NotifyPropertyChanged();
            }
        }

        private static bool _NoResults = false;
        public bool NoResults {
            get {
                return _NoResults;
            }
            set {
                _NoResults = value;
                NotifyPropertyChanged();
            }
        }

        public ObservableCollection<SearchResult> Exacts = new ObservableCollection<SearchResult>(); 
        public ObservableCollection<SearchResult> Partials = new ObservableCollection<SearchResult>();

        private List<SearchResult> _exactsFull = new List<SearchResult>();
        private List<SearchResult> _partialsFull = new List<SearchResult>();

        public SearchPageViewModel() {

        }

        public void resetViewModel(){
            Exacts.Clear();
            Partials.Clear();
            _exactsFull.Clear();
            _partialsFull.Clear();
            _lastColorWasGrey = true;
            SearchComplete = true;
            ProgressBarActive = false;
        }


        //unused
        private void addToPartial(IAsyncResult result) {
            List<SearchResult> srl = (List<SearchResult>)result.AsyncState;
            foreach (SearchResult sr in srl) {
                Partials.Add(sr);
            }
        }


        //unused
        private void addToExact(IAsyncResult result) {
            List<SearchResult> srl = (List<SearchResult>)result.AsyncState;
            foreach(SearchResult sr in srl){
                Exacts.Add(sr);
            }
        }

        //Still need logic to do in chunks of 25
        //Reverse forloop necessary because .removeAt() will update the count of the list.
        private async void transferToList(ObservableCollection<SearchResult> to, List<SearchResult> from) {
            //if (!SearchComplete) {
                for (int i = from.Count - 1; i >= 0 && to.Count < 150; i--) {                    
                    SearchResult sr = from[i];
                    to.Add(sr);
                    //from.RemoveAt(i);
                }
            //}
        }

        private void updateUI(ObservableCollection<SearchResult> to, List<SearchResult> from, SynchronizationContext sync) {

            sync.Post(new SendOrPostCallback(o => {

                for (int i = from.Count - 1; i >= 0 && to.Count < 150; i--) {
                    SearchResult sr = from[i];
                    to.Add(sr);
                }

            }), from);           
        
    }

        public void submitSearch(string searchText, SynchronizationContext sync, int limit=75) {
            if (!SearchComplete) {
                Debug.WriteLine("Search still in progress");
                return; 
            }
            resetViewModel();
            ProgressBarActive = true;
            SearchComplete = false;
            if(limit >= 75) { //this means that it was a search by enter, not by typing
                UserData.insertIntoSearchHistory(searchText);
            }
            if (!StringTools.ContainsUnicodeCharacter(searchText)) {  //If it does not contain any unicode, limit searching to either Romaji or Definitions
                if (searchText.Contains(" ") || StringTools.endsInConsonantNotN(searchText)) {//If it contains a space, it's guaranteed to be found within Definitions
                    Debug.WriteLine("Contained Space or ended in consonant not 'n', search was in Definitions");

                    Task.Run(async () => {
                        var re = await SearchToolsAsync.searchEnglishAsync(searchText, limit);
                        updateUI(Exacts, re.Item1, sync);
                        updateUI(Partials, re.Item2, sync);
                    });

                }
                else { //if it didn't contain a space, then it can be found in either Romaji or Definitions, so we return both.
                    Debug.WriteLine("Ended in either a vowel, or a vowel + n, searching over both");

                    Task.Run(async () => {
                        var re = await SearchToolsAsync.searchRomajiExactAsync(searchText, limit);
                        updateUI(Exacts, re, sync);
                    });



                    Task.Run(async () => {
                        var re = await SearchToolsAsync.searchRomajiInexactAsync(searchText, limit);
                        updateUI(Partials, re, sync);
                    });


                    Task.Run(async () => {
                        var re = await SearchToolsAsync.searchEnglishAsync(searchText, limit);
                        updateUI(Exacts, re.Item1, sync);
                        updateUI(Partials, re.Item2, sync);
                    });
                    



                }
            }
            else {
                //if it does contain unicode, then it can be found in either Kana or Kanji (ignoring french/german defintions), but first check to see that it's not a halfwidth character
                //if (StringTools.hasHalfwidthLatin(searchText)) {
                    
                //}
                if (StringTools.allKana(searchText)) {
                    Debug.WriteLine("match is in Kana");



                    Task.Run(async () => {
                        var re = await SearchToolsAsync.searchKanaExactAsync(searchText, limit);
                        updateUI(Exacts, re, sync);
                    });


                    Task.Run(async () => {
                        var re = await SearchToolsAsync.searchKanaInexactAsync(searchText, limit);
                        updateUI(Partials, re, sync);
                    });



                }
                else {                    
                    Debug.WriteLine("match is in Kanji");

                    Task.Run(async () => {
                        var re = await SearchToolsAsync.searchKanjiExactAsync(searchText, limit);
                        updateUI(Exacts, re, sync);
                    });


                    Task.Run(async () => {
                        var re = await SearchToolsAsync.searchKanjiInexactAsync(searchText, limit);
                        updateUI(Partials, re, sync);
                    });



                }
            }
            ProgressBarActive = false;
            SearchComplete = true;
            if (Exacts.Count == 0 && Partials.Count == 0) {
                NoResults = true;
            }
        }


       /** gets a brush from a hex value **/
        public static SolidColorBrush GetColorFromHexa(string hexaColor) {
                       return new SolidColorBrush(
                Color.FromArgb(
                    Convert.ToByte(hexaColor.Substring(1, 2), 16),
                    Convert.ToByte(hexaColor.Substring(3, 2), 16),
                    Convert.ToByte(hexaColor.Substring(5, 2), 16),
                    Convert.ToByte(hexaColor.Substring(7, 2), 16)
                )
            );
        }

        public event PropertyChangedEventHandler PropertyChanged;

        // This method is called by the Set accessor of each property. 
        // The CallerMemberName attribute that is applied to the optional propertyName 
        // parameter causes the property name of the caller to be substituted as an argument. 
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "") {
            if (PropertyChanged != null) {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }


    }
}
