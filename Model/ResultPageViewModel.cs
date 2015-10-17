using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Data;
using JDictU.Model;


namespace JDictU
{
    public class ResultPageViewModel {
        private SearchResult _sr { get; set; }
        private string _mainKanji;
        public string MainKanji {
            get { return _mainKanji; }
            set { _mainKanji = value; }
        }
        public Verb verb { get; set; }
        private bool _noKanji;
        public List<string> kana { get; set; }
        public List<string> KanjiList { get; set; }
        private string _mainEnglish;
        public string MainEnglish { get { return _mainEnglish; } set { _mainEnglish = value; } }
        public List<Tuple<string, string>> KanaRomaMap { get; set; }
        public List<string> DefinitionList { get; set; }
        public List<string> PoSList { get; set; }
        public ObservableCollection<HeadwordSentence> HWSList { get; set; }
        //public ObservableCollection<KanjiDict> KanjiComponents { get; set; }
        public ObservableCollection<KanjiPageViewModel> KanjiComponents { get; set; }
        public ICollectionView hwsview { get; set; }
        public bool isFavorite { get; set; }

        public ProgressRing pr { get; set; }

        public ResultPageViewModel(SearchResult sr) {
            _sr = sr;
            KanjiComponents = new ObservableCollection<KanjiPageViewModel>();
            MainKanji = setMainKanji();
            KanjiList = _sr.kanji.GetRange(1, _sr.kanji.Count - 1); //Should return everything except first element
            MainEnglish = setMainEnglish();
            KanaRomaMap = _sr.getKanaRomaMap();
            DefinitionList = _sr.definitions.GetRange(1, _sr.definitions.Count - 1);//Should return everything except first element
            PoSList = _sr.pos;
            verb = PoSList.Any(pos => pos.Contains((" verb"))) ? Verb.makeVerb(sr) : null;
            Debug.WriteLine("ID: " + sr.entry_id);
            isFavorite = UserData.isFavorited(this._sr.entry_id);
            getKanjiForWord(this.MainKanji);
        }

        public async Task getExamples(string headword) {
            pr.IsActive = true;
            if (HWSList == null) {
                HWSList = new ObservableCollection<HeadwordSentence>();

                //TODO this is experimental as taken from http://stackoverflow.com/questions/16372822/wpf-binding-observablecollection-with-converter
                var viewSource = new CollectionViewSource { Source = HWSList };
                //Get the ICollectionView and set Filter
                hwsview = viewSource.View;
            }
            else {
                HWSList.Clear();
            }
            var hws = await SearchToolsAsync.getSentences(headword);
            pr.IsActive = false;
            foreach (HeadwordSentence hw in hws) {
                hw.form = hw.form != "" ? hw.form : hw.headword;

                int beforeStart = hw.sentencejpn.IndexOf(hw.form);
                int afterStart = beforeStart + hw.form.Length;

                hw.beforeForm = hw.sentencejpn.Substring(0, beforeStart);
                hw.afterForm = hw.sentencejpn.Substring(afterStart);
                HWSList.Add(hw);
            }
        }

        public ResultPageViewModel(int id) {
            KanjiComponents = new ObservableCollection<KanjiPageViewModel>();
            _sr = SearchToolsAsync.returnSearchResultByEntryIDAsync(id);
            MainKanji = setMainKanji();
            KanjiList = _sr.kanji.GetRange(1, _sr.kanji.Count - 1); //Should return everything except first element
            MainEnglish = setMainEnglish();
            KanaRomaMap = _sr.getKanaRomaMap();
            DefinitionList = _sr.definitions;
            PoSList = _sr.pos;
            getKanjiForWord(this.MainKanji);

        }

        private async void getKanjiForWord(string kanjis) {
            foreach(char c in kanjis) {
                string cstring = "" + c;
                if(StringTools.ContainsUnicodeCharacter(cstring) && !StringTools.allKana(cstring)) {
                    KanjiComponents.Add(new KanjiPageViewModel(cstring));
                }
            }
        }

        private string setMainEnglish() {
            return _sr.definitions[0];
        }


        private string setMainKanji(){
            if (_sr.kanji.Count == 1 && _sr.kanji[0].Equals("")) {
                _noKanji = true;
                return _sr.kana[0];
            }
            else {
                _noKanji = false;
                return _sr.kanji[0];
            }
        }
        
        private string formatForFavorite() {
            string text = string.Format("{0} - {1}", this.MainEnglish, this.MainKanji);
            return text;
        }

        public void favorite() {
            UserData.insertIntoFavorites(this._sr.entry_id, this.formatForFavorite());
            this.isFavorite = true;
        }

        public void unFavorite() {
            UserData.removeFromFavorites(this._sr.entry_id);
            this.isFavorite = false;
        }

    }
}
