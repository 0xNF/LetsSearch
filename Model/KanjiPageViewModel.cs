using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JDictU.Model;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace JDictU {


    public class KanjiPageViewModel : INotifyPropertyChanged {

        public event PropertyChangedEventHandler PropertyChanged;


        private static KanjiPageModel model { get; set; }

        public KanjiDict KD { get; set; }

        public ObservableCollection<string> readings_pinyin { get; set; }
        public ObservableCollection<string> readings_hangeul_h { get; set; }
        public ObservableCollection<string> readings_hangeul_r { get; set; }
        public ObservableCollection<string> readings_ja_on { get; set; }
        public ObservableCollection<string> readings_ja_kun { get; set; }

        public ObservableCollection<string> meanings { get; set; }

        public ObservableCollection<string> nanori { get; set; }

        public ObservableCollection<KanjiDict.Radical> radicals { get; set; }

        public ObservableCollection<KanjiDict.DictRef> dic_num { get; set; }

        public ObservableCollection<KanjiDict.CodePoint> codepoints { get; set; }


        public ObservableCollection<string> variants { get; set; }

        public ObservableCollection<string> dictionaryRefs { get; set; }

        public ObservableCollection<KanjiDict.QueryCode> query_codes { get; set; }

        public ObservableCollection<string> radicalsForThisKanji { get; set; }



        //TODO
        //Also! KanjiPage should have a Search For Words Using This Kanji feature, take to Mainpage, do search on [kanji and %kanji%]

        private string _literal;
        public string literal {
            get { return _literal; }
            set { _literal = value; OnPropertyChanged("literal"); }
        }

        private string _jlpt;
        public string jlpt {
            get { return _jlpt; }
            set { _jlpt = value; OnPropertyChanged("jlpt"); }
        }

        private string _grade;
        public string grade {
            get { return _grade; }
            set { _grade = value; OnPropertyChanged("grade"); }
        }

        private string _frequency;
        public string frequency {
            get { return _frequency; }
            set { _frequency = value; OnPropertyChanged("frequency"); }
        }

        private int _strokecount;
        public int strokecount {
            get {
                return _strokecount;
            }
            set { _strokecount = value; OnPropertyChanged("strokecount"); }
        }        
        public ObservableCollection<int> commonMiscounts { get; set; }


        private string _radicalname;
        public string radicalname {
            get { return _radicalname; }
            set { _radicalname = value; OnPropertyChanged("radicalname"); }
        }

        public KanjiPageViewModel() {

        }

        public KanjiPageViewModel(string literal) {
            this.nanori = new ObservableCollection<string>();

            this.readings_hangeul_h = new ObservableCollection<string>();
            this.readings_hangeul_r = new ObservableCollection<string>();
            this.readings_ja_kun = new ObservableCollection<string>();
            this.readings_ja_on = new ObservableCollection<string>();
            this.readings_ja_kun = new ObservableCollection<string>();
            this.readings_pinyin = new ObservableCollection<string>();

            this.commonMiscounts = new ObservableCollection<int>();

            this.radicals = new ObservableCollection<KanjiDict.Radical>();

            this.variants = new ObservableCollection<string>();

            this.meanings = new ObservableCollection<string>();

            this.dic_num = new ObservableCollection<KanjiDict.DictRef>();

            this.codepoints = new ObservableCollection<KanjiDict.CodePoint>();

            this.dictionaryRefs = new ObservableCollection<string>();

            this.radicalsForThisKanji = new ObservableCollection<string>();

            this.query_codes = new ObservableCollection<KanjiDict.QueryCode>();
            getKanji(literal);
        }

        private void getReadingsFromKanji() {
            //readings
            if (KD.reading != "") {
                foreach (string reading in KD.reading.Split('|')) {
                    List<string> splits = reading.Split(',').ToList();

                    if (splits[1] == "ja_kun") {
                        string main = splits[0];
                        string toAdd = "";
                        if (splits[3] != "None" || splits[2] != "None") {
                            toAdd = "(";
                            if (splits[2] != "None") {
                                toAdd += splits[2];
                            }
                            if (splits[3] != "None") {
                                toAdd += "," + splits[3];
                            }
                            toAdd += ")";
                        }

                        this.readings_ja_kun.Add(main + " " + toAdd);

                    }
                    else if (splits[1] == "ja_on") {
                        string main = splits[0];
                        string toAdd = "";
                        if (splits[3] != "None" || splits[2] != "None") {
                            toAdd = "(";
                            if (splits[2] != "None") {
                                toAdd += splits[2];
                            }
                            if (splits[3] != "None") {
                                toAdd += "," + splits[3];
                            }
                            toAdd += ")";
                        }
                        this.readings_ja_on.Add(main + " " + toAdd);

                    }
                    else if (splits[1] == "pinyin") {
                        this.readings_pinyin.Add(splits[0]);
                    }
                    else if (splits[1] == "korean_r") {
                        this.readings_hangeul_r.Add(splits[0]);
                    }
                    else if (splits[1] == "korean_h") {
                        this.readings_hangeul_h.Add(splits[0]);
                    }
                }
            }
        }

        private void radicalsFromKradFile() {
            foreach(string rad in KanjiLookupPageModel.getRadicalsFromKanji(KD.literal)) {
                this.radicalsForThisKanji.Add(rad);
            }
        }

        private void getNanoriFromKanji() {
            //Nanori
            if (KD.nanori != "") {
                foreach (string nano in KD.nanori.Split('|')) {
                    this.nanori.Add(nano);
                }
            }
        }

        private void getMeaningsFromKanji() {
            //meanings
            if (KD.meaning != "") {
                foreach (string meaning in KD.meaning.Split('|')) {
                    this.meanings.Add(meaning);
                }
            }
        }

        private void getRadicalsFromKanji() {
            if(KD.radical != "") {
                foreach (string radical in KD.radical.Split('|')) {
                    List<string> splits = radical.Split(',').ToList();
                    int id = Convert.ToInt32(splits[0]);
                    string type = splits[1];
                    string radtype = "";
                    if(type == "classical") {
                        radtype = "Classical (KangXi Zidian)";
                    }
                    else if(type == "nelson_c") {
                        radtype = "Classic Nelson";
                    }
                    KanjiDict.Radical r = new KanjiDict.Radical(id, radtype);
                    this.radicals.Add(r);
                }
            }
        }

        private void getDictRefsFromKanji() {
            if(KD.dic_number != "") {
                List<string> splits = KD.dic_number.Split('|').ToList();
                foreach(string dicref in splits) {
                    List<string> splits2 = dicref.Split(',').ToList();
                    string num = splits2[0];
                    string dict = splits2[1];
                    dic_num.Add(new KanjiDict.DictRef(num, dict));
                }
            }
        }

        private void getMiscFromKanji() {
            if(KD.misc != "") {

                //Common Miscounts
                List<string> splits = KD.misc.Split(',').ToList();
                List<string> strokes = splits[0].Replace("(", "").Replace(")", "").Split('|').ToList();
                strokecount = Convert.ToInt32(strokes[0]);
                if(strokes.Count > 1) {

                    for(int i = 1; i < strokes.Count; i++) {
                        commonMiscounts.Add(Convert.ToInt32(strokes[i]));
                    }
                }

               //Variations - becaue of way data was stored, comma breaks wreck the input.
               //But variations will always tehrefore come in a pair of two, i.e.,:
               //                1: (15)
               //2: (20 - 10
               //3: jis - 212)
               //4: ()
                if (splits.Count >= 4) {
                    //Get the second element of the list, and go through to the second to last element in the list.
                    //python would make this easy... lst[1:-1]
                    var pairs = splits.GetRange(1, splits.Count - 2).Select(x => x.Replace("(", "").Replace(")", "")).ToList();
                    //every 2 of these is a single Variation
                    for(int i = 0; i < pairs.Count; i += 2) {
                        string num = pairs[i];
                        string type = pairs[i + 1];
                        string variation = num + ", " + type;
                        variants.Add(variation);
                    }
                    
                }

                //Radical Name
                radicalname = splits.Last().Replace("(", "").Replace(")", "");
   


                

   
            }
        }

        private void getQueryCodesFromKanji() {
            if(KD.query_code != "") {
                var qc = KD.query_code.Split('|').ToList();
                foreach (string s in qc) {
                    var splits = s.Split(',').ToList();
                    this.query_codes.Add(new KanjiDict.QueryCode(splits[0], splits[1]));
                }
            }
            
        }

        public void getCodepointsFromKanji() {
            if(KD.codepoint != "") {
                var cp = KD.codepoint.Split('|').ToList();
                foreach (string s in cp) {
                    var splits = s.Split(',').ToList();
                    this.codepoints.Add(new KanjiDict.CodePoint(splits[0], splits[1]));
                }
            }
        }

        private async Task getKanji(string literal) {
            var x = await KanjiPageModel.getKanji(literal);
            KD = x;
            if(KD.jlpt > 0) {
                this.jlpt = "" + KD.jlpt;
            }
            else {
                this.jlpt = "N/A";
            }
            if (KD.grade > 0) {
                this.grade = "" + KD.grade;
            }
            else {
                this.grade = "N/A";
            }
            if (KD.frequency > 0) {
                this.frequency = "" + KD.frequency;
            }
            else {
                this.frequency = "N/A";
            }
            this.literal = KD.literal;

            getReadingsFromKanji();
            getNanoriFromKanji();
            getMeaningsFromKanji();
            getRadicalsFromKanji();
            radicalsFromKradFile();
            getMiscFromKanji();
            getDictRefsFromKanji();
            getQueryCodesFromKanji();
            getCodepointsFromKanji();



        }

        protected void OnPropertyChanged(string name) {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }
    }
}
