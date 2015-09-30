using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JDictU.Model;

namespace JDictU.Model
{

    public class SearchResult {
        //visible to user data
        internal List<string> kanji { get; set; }
        internal List<string> kana { get; set; }
        internal List<string> romaji { get; set; }
        internal List<string> definitions { get; set; }
        internal List<string> pos { get; set; }

        //Note for data binding - {get;set;} needs to be attached to each property that you would like to expose to the xaml
        public string headerText {get;set;}
        public string defText {get;set;}
        //internal use only data
        public int entry_id { get; set; }

        /// <summary>
        /// 4 argument constructor, does not have a list of PoS associated
        /// </summary>
        /// <param name="kj">List of Kanji</param>
        /// <param name="ka">List of Kana:Romaji</param>
        /// <param name="def">List of Definitions</param>
        /// <param name="id">entry_id</param>
        public SearchResult(List<string> kj, List<string> ka, List<string> def, int id) {
            kanji = kj;
            kana = StringTools.stringFromKanaMap(ka, 0);
            definitions = def;
            entry_id = id;
            pos = new List<string>();
            romaji = StringTools.stringFromKanaMap(ka, 1);
            headerText = getTitleString();
            defText = getDefinitionString();
        }

        /// <summary>
        /// 5 argument constructor, includes PoS
        /// </summary>
        /// <param name="kj">List of Kanji</param>
        /// <param name="ka">List of Kana:Romaji</param>
        /// <param name="def">List of Definitions</param>
        /// <param name="func">List of PoS</param>
        /// <param name="id">entry_id</param>
        public SearchResult(List<string> kj, List<string> ka, List<string> def, List<string> func, int id) {
            this.kanji = kj;
            this.kana = StringTools.stringFromKanaMap(ka, 0);
            this.definitions = def;
            this.entry_id = id;
            this.romaji = StringTools.stringFromKanaMap(ka, 1);
            this.pos = func;
            this.headerText = getTitleString();
            this.defText = getDefinitionString();
        }

        /// <summary>
        /// Zero argument constructor - used for bugs
        /// </summary>
        public SearchResult() {
            this.kanji = new List<string>();
            this.kana = new List<string>();
            this.romaji = new List<string>();
            this.definitions = new List<string>();
            this.pos = new List<string>();
            this.entry_id = 0;
        }

        public static SearchResult createDebugSR() {
            return new SearchResult(new List<String>() { "月", "火", "水", "木", "金", "土", "日" }, new List<String>() { "げつ:getsu", "か:ka", "すい:sui", "もく:moku", "きん:kin", "ど:do", "にち:nichi" }, new List<String>() { "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday" }, 00000);
        }

        /** Produces a string of all the romaji **/
        public string getRomajiString() {
            return getXString(romaji);
        }

        /** Produces a string of all the KanjiList **/
        public string getKanjiString() {
            return getXString(kanji);
        }

        /** Produces a string of all the definitions **/
        public string getDefinitionString() {
            return getXString(definitions);
        }

        /** Produces a string of all the kana **/
        public string getKanaString() {
            return getXString(kana);
        }

        private string getXString(List<string> lst) {
            string XStr = "";
            for (int i = 0; i < lst.Count; i++) {
                XStr += lst[i].ToString();
                if (i < lst.Count - 1) {
                    XStr += ", ";
                }
            }
            return XStr;
        }

        public string getTitleString() {
            string text = (this.kanji.Count == 1 && this.kanji[0] == "") ? this.getKanaString() : (this.getKanjiString() + " [" + this.getKanaString() + "]");
            return text;
        }

        public override string ToString() {
            string text = (this.kanji.Count == 1 && this.kanji[0] == "") ? this.getKanaString() : (this.getKanjiString() + " [" + this.getKanaString() + "]");
            return text;
        }

        public string ToStringDebug() {
            return "Kanji: " + kanji + ", Kana: " + kana + "Romaji: " + romaji + ", Def: " + definitions + ", Id: " + entry_id;
        }

        public List<Tuple<string, string>> getKanaRomaMap() {
            return this.kana.Select((t, i) => new Tuple<string, string>(t, this.romaji[i])).ToList();
        }
    }

}
