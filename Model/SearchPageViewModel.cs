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
        private async Task transferToList(ObservableCollection<SearchResult> to, List<SearchResult> from) {
            for (int i = from.Count-1; i >= 0 && to.Count < 150; i--) {
                SearchResult sr = from[i];
                to.Add(sr);
                from.RemoveAt(i);
            }
        }

        public async Task submitSearch(string searchText) {
            if (!SearchComplete) {
                Debug.WriteLine("Search still in progress");
                return; 
            }
            ProgressBarActive = true;
            SearchComplete = false;
            //TODO: Transfer the LIMIT to the exacts and partials list, with respect to the button that adds more if so clicked
            UserData.insertIntoSearchHistory(searchText); //TODO - BUG with inserting duplicate elements,even across sessions
            if (!StringTools.ContainsUnicodeCharacter(searchText)) {  //If it does not contain any unicode, limit searching to either Romaji or Definitions
                if (searchText.Contains(" ") || StringTools.endsInConsonantNotN(searchText)) {//If it contains a space, it's guaranteed to be found within Definitions
                    Debug.WriteLine("Contained Space or ended in consonant not 'n', search was in Definitions");
                    var res = await Task.Run(() => SearchToolsAsync.searchEnglishAsync(searchText));
                    _exactsFull = res.Item1;
                    _partialsFull = res.Item2;
                    Debug.WriteLine("FINISHED AWAITING, inDefs");
                    transferToList(Exacts, _exactsFull);
                    transferToList(Partials, _partialsFull);
                }
                else { //if it didn't contain a space, then it can be found in either Romaji or Definitions, so we return both.
                    Debug.WriteLine("Ended in either a vowel, or a vowel + n, searching over both");
                    Task<List<SearchResult>> resRomaExact = Task.Run(() => SearchToolsAsync.searchRomajiExactAsync(searchText));
                    Task<List<SearchResult>> resRomaInexact = Task.Run(() => SearchToolsAsync.searchRomajiInexactAsync(searchText));
                    Task<Tuple<List<SearchResult>, List<SearchResult>>> resEng = Task.Run(() => SearchToolsAsync.searchEnglishAsync(searchText));
                    _exactsFull = await resRomaExact;
                    transferToList(Exacts, _exactsFull);
                    _partialsFull = await resRomaInexact;
                    transferToList(Partials, _partialsFull);
                    var vareng = await resEng;
                    Debug.WriteLine("FINISHED AWAITING, defs and roma");
                    _exactsFull.AddRange(vareng.Item1);
                    transferToList(Exacts, _exactsFull);
                    _partialsFull.AddRange(vareng.Item2);
                    transferToList(Partials, _partialsFull);
                }
            }
            else {
                //if it does contain unicode, then it can be found in either Kana or Kanji (ignoring french/german defintions)
                if (StringTools.allKana(searchText)) {
                    Debug.WriteLine("match is in Kana");
                    Task<List<SearchResult>> resKanaExact = Task.Run(() => SearchToolsAsync.searchKanaExactAsync(searchText));
                    Task<List<SearchResult>> resKanaInexact = Task.Run(() => SearchToolsAsync.searchKanaInexactAsync(searchText));
                    _exactsFull = await resKanaExact;
                    transferToList(Exacts, _exactsFull);
                    _partialsFull = await resKanaInexact;
                    transferToList(Partials, _partialsFull);
                }
                else {
                    Debug.WriteLine("match is in Kanji");
                    Task<List<SearchResult>> resKanjiExact = Task.Run(() => SearchToolsAsync.searchKanjiExactAsync(searchText));
                    Task<List<SearchResult>> resKanjiInexact = Task.Run(() => SearchToolsAsync.searchKanjiInexactAsync(searchText));
                    _exactsFull = await resKanjiExact;
                    transferToList(Exacts, _exactsFull);
                    _partialsFull = await resKanjiInexact;                    
                    transferToList(Partials, _partialsFull);
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
