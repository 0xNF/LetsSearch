using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JDictU.Model;
using Windows.UI.Xaml.Controls;
using System.Collections.ObjectModel;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Media;

namespace JDictU {


   public class KanjiLookupPageViewModel {

        public ObservableCollection<string> matchingKanji { get; set; }
        public List<string> selectedRadicals { get; set; }
        public List<string> validRadicals { get; set; }
        KanjiLookupPageModel model = new KanjiLookupPageModel();
        ListBox lb_1 { get; set; }
        ListBox lb_2 { get; set; }
        ListBox lb_3 { get; set; }
        ListBox lb_4 { get; set; }
        ListBox lb_5 { get; set; }
        ListBox lb_6 { get; set; }
        ListBox lb_7 { get; set; }
        ListBox lb_8 { get; set; }
        ListBox lb_9 { get; set; }
        ListBox lb_10 { get; set; }
        ListBox lb_11 { get; set; }
        ListBox lb_12 { get; set; }
        ListBox lb_13 { get; set; }
        ListBox lb_14 { get; set; }
        ListBox lb_17 { get; set; }

        public List<ListBox> lbs;

        public List<TextBlock> tbs { get; set; }





        public KanjiLookupPageViewModel(ListBox lb_1,ListBox lb_2,ListBox lb_3,ListBox lb_4,ListBox lb_5,ListBox lb_6,ListBox lb_7,ListBox lb_8,ListBox lb_9,ListBox lb_10,ListBox lb_11,ListBox lb_12,ListBox lb_13,ListBox lb_14, ListBox lb_17) {
            this.lb_1 = lb_1;
            this.lb_2 = lb_2;
            this.lb_3 = lb_3;
            this.lb_4 = lb_4;
            this.lb_5 = lb_5;
            this.lb_6 = lb_6;
            this.lb_7 = lb_7;
            this.lb_8 = lb_8;
            this.lb_9 = lb_9;
            this.lb_10 = lb_10;
            this.lb_11 = lb_11;
            this.lb_12 = lb_12;
            this.lb_13 = lb_13;
            this.lb_14 = lb_14;
            this.lb_17 = lb_17;
            this.lbs = new List<ListBox>() {
                this.lb_1,this.lb_2,this.lb_3,this.lb_4,this.lb_5,this.lb_6,this.lb_7,this.lb_8,this.lb_9,this.lb_10,this.lb_11,this.lb_12,this.lb_13,this.lb_14,this.lb_17
            };
            this.matchingKanji = new ObservableCollection<string>();
            this.selectedRadicals = new List<string>();
            this.validRadicals = new List<string>();
            tbs = new List<TextBlock>();
            setup();
        }

        private async void setup() {
            await KanjiLookupPageModel.prepareModel();
            lb_1.ItemsSource = KanjiLookupPageModel.radDict[1];
            lb_2.ItemsSource = KanjiLookupPageModel.radDict[2];
            lb_3.ItemsSource = KanjiLookupPageModel.radDict[3];
            lb_4.ItemsSource = KanjiLookupPageModel.radDict[4];
            lb_5.ItemsSource = KanjiLookupPageModel.radDict[5];
            lb_6.ItemsSource = KanjiLookupPageModel.radDict[6];
            lb_7.ItemsSource = KanjiLookupPageModel.radDict[7];
            lb_8.ItemsSource = KanjiLookupPageModel.radDict[8];
            lb_9.ItemsSource = KanjiLookupPageModel.radDict[9];
            lb_10.ItemsSource = KanjiLookupPageModel.radDict[10];
            lb_11.ItemsSource = KanjiLookupPageModel.radDict[11];
            lb_12.ItemsSource = KanjiLookupPageModel.radDict[12];
            lb_13.ItemsSource = KanjiLookupPageModel.radDict[13];
            lb_14.ItemsSource = KanjiLookupPageModel.radDict[14];
            lb_17.ItemsSource = KanjiLookupPageModel.radDict[17];

        }

        private List<MSGS> makeMGS(List<string> lst) {
            List<MSGS> g = new List<MSGS>();
            foreach(string s in lst) {
                g.Add(new MSGS() { color = "#FFFFFF", message =s });
            }
            return g;
        }

        public class MSGS {
            public string color { get; set; }
            public string message { get; set; }
        }

        public void getKanjiForRadicals(List<string> radicals) {
            matchingKanji.Clear();
            validRadicals.Clear();
            if (radicals.Count != 0) {
                var returnedKanji = KanjiLookupPageModel.kanjiForRadicals(radicals);
                validRadicals = KanjiLookupPageModel.validRadsWithTheseRad(radicals); //Use this to grey out everythign not in this list
                foreach (string kanji in returnedKanji) {
                    matchingKanji.Add(kanji);
                }

            }
        }

        //private List<string> getSelectedRadicals() {
        //    for(List)
        //}

    }
}
