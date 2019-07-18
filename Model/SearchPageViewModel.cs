using System;
using System.Collections.Generic;
using Windows.UI.Xaml.Media;
using Windows.UI;
using System.Threading.Tasks;
using System.Diagnostics;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading;
using Windows.UI.Xaml;
using System.Linq;

namespace JDictU.Model {
    public class SearchPageViewModel : INotifyPropertyChanged// : BaseViewModel
    {

        private const int DISPLAY_LIMIT = 150;

        public event PropertyChangedEventHandler PropertyChanged;

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
                OnPropertyChanged("NoResults");
            }
        }

        public Visibility visForDots { get; set; }
        private bool _keybykey = false;
        public bool keybykey {
            get { return _keybykey; }
            set {
                _keybykey = value;
                if (!_keybykey) {
                    visForDots = Visibility.Collapsed;
                }
                else {
                    visForDots = Visibility.Visible;
                }
                OnPropertyChanged("visForDots");

                OnPropertyChanged("keybykey");
            }
        }


        public bool useDoubleLike = false;


        public ResettableObservableCollection<SearchResult> Exacts = new ResettableObservableCollection<SearchResult>(); 
        public ResettableObservableCollection<SearchResult> Partials = new ResettableObservableCollection<SearchResult>();

        private List<SearchResult> _exactsFull = new List<SearchResult>();
        private List<SearchResult> _partialsFull = new List<SearchResult>();

        public SearchPageViewModel() {
            visForDots = Visibility.Collapsed;
        }

        public void resetViewModel(){
            visForDots = Visibility.Collapsed;
            Exacts.Clear();
            Partials.Clear();
            _exactsFull.Clear();
            _partialsFull.Clear();
            _lastColorWasGrey = true;
            SearchComplete = true;
            ProgressBarActive = false;
        }

        private void updateUI(ResettableObservableCollection<SearchResult> to, List<SearchResult> from, SynchronizationContext sync) {
            sync.Post(new SendOrPostCallback(o => {
                int takecount = DISPLAY_LIMIT - to.Count;
                to.AddRange(from.Take(takecount));
            }), from);

        }

        public void submitSearch(string searchText, SynchronizationContext sync, int limit=DISPLAY_LIMIT) {
            if (!SearchComplete) {
                Debug.WriteLine("Search still in progress");
                return; 
            }
            resetViewModel();
            ProgressBarActive = true;
            SearchComplete = false;
            if(limit >= DISPLAY_LIMIT) { //this means that it was a search by enter, not by typing
                Task.Run(() => UserData.insertIntoSearchHistory(searchText));
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
                        var re = await SearchToolsAsync.searchKanjiInexactAsync(searchText, limit, useDoubleLike);
                        updateUI(Partials, re, sync);
                    });

                    if(searchText.Length == 1) {
                        Task.Run(async () => {
                            var fromKanjiDict = await SearchToolsAsync.getKanji(searchText);
                            List<SearchResult> lst = new List<SearchResult>();
                            SearchResult sr = new SearchResult {
                                headerText = fromKanjiDict.literal + " [Kanji]"
                            };
                            if (fromKanjiDict.meaning != "") {
                                var splits = fromKanjiDict.meaning.Split('|');
                                string deftext = "";
                                foreach(string split in splits) {
                                    deftext += split + ",";
                                }
                                deftext = deftext.Substring(0, deftext.Length - 1);
                                sr.defText = deftext;
                            }
                            lst.Add(sr);
                            //Need to package the returned Kanji to a SearchResult, then format it properly for display.
                            //Need to re-investigate how SearchResults work. Does the Tag determine where you go? IF so, tag should be Kanji:kanji to indicate that we be taken to the kanjiresult page.
                            if (fromKanjiDict != null) {
                                updateUI(Exacts, lst, sync);
                            }
                        });
                    }
                    


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

        // This method is called by the Set accessor of each property. 
        // The CallerMemberName attribute that is applied to the optional propertyName 
        // parameter causes the property name of the caller to be substituted as an argument. 
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "") {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        protected void OnPropertyChanged(string name) {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }


    }
}
