using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using SQLite;
using JDictU.Model;
using SQLite.Net.Attributes;

namespace JDictU.Model {

    public interface ITableObjectEntry {
        //[PrimaryKey, AutoIncrement]
        int id { get; set; }
        int entry_id { get; set; }
    }

    public class Kanji : ITableObjectEntry {
        //[PrimaryKey, AutoIncrement]
        public int id { get; set; }
        //[Column("Kanji"), Indexed]
        public string kanji { get; set; }
        //[Column("entry_id")]
        public int entry_id { get; set; }

        public override string ToString() {
            return kanji;
        }
    }

    public class Romaji : ITableObjectEntry {
        //[PrimaryKey, AutoIncrement]
        public int id { get; set; }
        //[Column("romaji"), Indexed]
        public string romaji { get; set; }
        //[Column("entry_id")]
        public int entry_id { get; set; }

        public override string ToString() {
            return romaji;
        }
    }

    public class Functions : ITableObjectEntry {
        //[PrimaryKey, AutoIncrement]
        public int id { get; set; }
        //[Column("pos")]
        public string pos { get; set; }
        //[Column("entry_id")]
        public int entry_id { get; set; }

        public override string ToString() {
            return pos;
        }
    }

    public class Kana : ITableObjectEntry {
        //[PrimaryKey, AutoIncrement]
        public int id { get; set; }
        //[Column("kana"), Indexed]
        public string kana { get; set; }
        //[Column("entry_id")]
        public int entry_id { get; set; }

        public override string ToString() {
            return kana;
        }
    }

    public class Definitions : ITableObjectEntry {
        //[PrimaryKey, AutoIncrement]
        public int id { get; set; }
        //[MaxLength(1000)]
        public string definition { get; set; }
        //[MaxLength(1000)]
        public string lang { get; set; }
        public int entry_id { get; set; }

        public override string ToString() {
            return definition;
        }
    }

    public class Definitions_eng : ITableObjectEntry {
        //[PrimaryKey]
        public int id { get; set; }
        //[Column("definition"), Indexed]
        public string definition { get; set; }
        //[Column("entry_id")]
        public int entry_id { get; set; }
    }

    //Secondary Database things
    public class Favorites {
        [PrimaryKey]
        public int entry_id { get; set; }
        [Column("display_string")]
        public string display_string { get; set; }

        public override string ToString() {
            return entry_id.ToString();
        }
    }
    public class History {

        [PrimaryKey, AutoIncrement]
        public int id { get; set; }
        [Column("search_query"), MaxLength(1000)]
        public string search_query { get; set; }
        [Column("search_date")]
        public long search_date { get; set; }

    }

    //From Kanji.sqlite
    public class KanjiDict {
        [PrimaryKey]
        public string literal { get; set; }
        [Column("radical")]
        public string radical { get; set; }
        [Column("codepoint")]
        public string codepoint { get; set; }
        [Column("misc")]
        public string misc { get; set; }
        [Column("dic_number")]
        public string dic_number { get; set; }
        [Column("query_code")]
        public string query_code { get; set; }
        [Column("nanori")]
        public string nanori { get; set; }
        [Column("jlpt")]
        public int jlpt { get; set; }
        [Column("frequency")]
        public int frequency { get; set; }
        [Column("grade")]
        public int grade { get; set; }
        [Column("reading")]
        public string reading { get; set; }
        [Column("meaning")]
        public string meaning { get; set; }

        public class QueryCode {
            public string query_code { get; set; }
            public string qc_type { get; set; }

            public QueryCode(string qc, string type) {
                this.query_code = qc;
                this.qc_type = type;
            }
        }

        public class CodePoint {
            public string code { get; set; }
            public string encoding { get; set; }

            public CodePoint(string code, string enc) {
                this.code = code;
                this.encoding = enc;
            }
        }


        public class Radical {
            public int radicalID { get; set; }
            public string radicalType { get; set; }

            public Radical(int id, string radtype) {
                this.radicalID = id;
                this.radicalType = radtype;
            }
        }

        public class DictRef {
            public int kanjiId { get; set; }
            public string dictionaryName { get; set; }
            public int m_vol { get; set; }
            public int m_page { get; set; }

            public DictRef(string id, string name) {
                this.kanjiId = Convert.ToInt32(id);
                this.m_page = 0;
                this.m_vol = 0;
                string n = "";
                switch (name) {
                    case "nelson_c":
                        n = "Classic Nelson";
                        break;
                    case "nelson_n":
                        n = "New Nelson";
                        break;
                    case "halpern_njecd":
                        n = "New Japanese-English Character Dictionary";
                        break;
                    case "halpern_kkd":
                        n = "Kodansha Kanji Dictionary";
                        break;
                    case "halpern_kkld":
                        n = "Kanji Learners Dictionary";
                        break;
                    case "halpern_kkld_2ed":
                        n = "Kanji Learners Dictionary 2nd Ed";
                        break;
                    case "heisig":
                        n = "Remembering The  Kanji";
                        break;
                    case "heisig6":
                        n = "Remembering The  Kanji, Sixth Ed.";
                        break;
                    case "gakken":
                        n = "A  New Dictionary of Kanji Usage";
                        break;
                    case "oneill_names":
                        n = "Japanese Names";
                        break;
                    case "oneill_kk":
                        n = "Essential Kanji";
                        break;
                    case "moro":
                        n = "Daikanwajiten";
                        break;
                    case "henshall":
                        n = "A Guide To Remembering Japanese Characters";
                        break;
                    case "henshall3":
                        n = "A Guide To Reading and Writing Japanese 3rd Ed.";
                        break;
                    case "sh_kk":
                        n = "Kanji and Kana";
                        break;
                    case "sh_kk2":
                        n = "Kanji and Kana 2nd Ed.";
                        break;
                    case "sakade":
                        n = "A Guide To Reading and Writing Japanese";
                        break;
                    case "jf_cards":
                        n = "Japanese Kanji Flashcards";
                        break;
                    case "tutt_cards":
                        n = "Tuttle Kanji Cards";
                        break;
                    case "crowley":
                        n = "The Kanji Way to Japanese Language Power";
                        break;
                    case "kanji_in_context":
                        n = "Kanji in Context";
                        break;
                    case "busy_people":
                        n = "Japanese For Busy People vols I-III";
                        break;
                    case "kodansha_compact":
                        n = "Kodansha Compact Kanji Guide";
                        break;
                    case "maniette":
                        n = "Les Kanjis dans la tete";
                        break;
                    default:
                        n = "";
                        break;
                }

                this.dictionaryName = n;

            }
        }
    }



    public class Sentences
    {
        //[PrimaryKey]
        public int id { get; set; }
        //[Column("sentencejpn")]
        public string sentencejpn { get; set; }
        //[Column("sentenceeng")]
        public string sentenceeng { get; set; }
    }

    public class Headwords {
        //[PrimaryKey]
        public int id { get; set; }
        //[Column("headword")]
        public string headword { get; set; }
        //[Column("sentenceid")]
        public int sentenceid { get; set; }
        //[Column("verified")]
        public int verified { get; set; }
        //[Column("form")]
        public string form { get; set; }
        //[Column("reading")]
        public string reading { get; set; }
        //[Column("sensenumber")]
        public int sensenumber { get; set; }
    }

    public class HeadwordSentence {
        //[PrimaryKey]
        public int id { get; set; }
        //[Column("headword")]
        public string headword { get; set; }
        //[Column("reading")]
        public string reading { get; set; }
        //[Column("form")]
        public string form { get; set; }
        //[Column("sensenumber")]
        public int sensenumber { get; set; }
        //[Column("verified")]
        public int verified { get; set; }
        //[Column("sentencejpn")]
        public string sentencejpn { get; set; }
        //[Column("sentenceeng")]
        public string sentenceeng { get; set; }

        public string beforeForm { get; set; }
        public string afterForm { get; set; }

        public override string ToString() {
            var s = string.Format("Headword: {0}\nReading: {1}\nForm: {2}\nSense: {3}\nVerified: {4}\nSentenceJPN: {5}\nSentenceENG: {6}", headword, reading, form, sensenumber, verified, sentencejpn, sentenceeng);
            return s;
 ;       }
    }

    public class Super
    {
        [PrimaryKey]
        public int entry_id { get; set; }
        [Column("kanji")]
        public string kanji { get; set; }
        [Column("kana_map")]
        public string kana_map { get; set; }
        [Column("definition")]
        public string definition { get; set; }
        [Column("pos")]
        public string pos { get; set; }
        [Column("rank")]
        public int rank { get; set; }
    }


    //throwaways
    public class KanjiKana
    {
        public string kana { get; set; }
        public string kanji { get; set; }
    }

    public class KanaRoma
    {
        public int entry_id { get; set; }
        public string kana { get; set; }
        public string romaji { get; set; }
    }

    public class KanaRomaKanjiDef
    {
        public int entry_id { get; set; }
        public string kana { get; set; }
        public string romaji { get; set; }
        public string kanji { get; set; }
        public string definition { get; set; }
    }

    public class Entry_id
    {
        public int entry_id { get; set; }
    }
    public class ID
    {
        public int id { get; set; }
    }
    public class def_eng
    {
        public string definition { get; set; }
    }
    public class ka
    {
        public string kana { get; set; }
    }
    public class kj
    {
        public string kanji { get; set; }
    }
    public class roma
    {
        public string romaji { get; set; }
    }

    public class Combined
    {
        //[PrimaryKey]
        public int id { get; set; }
        public int entry_id { get; set; }
        public int kana { get; set; }
        public int kanji { get; set; }
        public int romaji { get; set; }
        public int definition { get; set; }
    }



}
