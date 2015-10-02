using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using SQLite;
using JDictU.Model;
using SQLite.Net.Attributes;

namespace JDictU.Model
{
    
    public interface ITableObjectEntry
    {
        //[PrimaryKey, AutoIncrement]
        int id { get; set; }
        int entry_id { get; set; }
    }

    public class Kanji : ITableObjectEntry
    {
        //[PrimaryKey, AutoIncrement]
        public int id { get; set; }
        //[Column("Kanji"), Indexed]
        public string kanji { get; set; }
        //[Column("entry_id")]
        public int entry_id { get; set; }

        public override string ToString()
        {
            return kanji;
        }
    }

    public class Romaji : ITableObjectEntry
    {
        //[PrimaryKey, AutoIncrement]
        public int id { get; set; }
        //[Column("romaji"), Indexed]
        public string romaji { get; set; }
        //[Column("entry_id")]
        public int entry_id { get; set; }

        public override string ToString()
        {
            return romaji;
        }
    }

    public class Functions : ITableObjectEntry
    {
        //[PrimaryKey, AutoIncrement]
        public int id { get; set; }
        //[Column("pos")]
        public string pos { get; set; }
        //[Column("entry_id")]
        public int entry_id { get; set; }

        public override string ToString()
        {
            return pos;
        }
    }

    public class Kana : ITableObjectEntry
    {
        //[PrimaryKey, AutoIncrement]
        public int id { get; set; }
        //[Column("kana"), Indexed]
        public string kana { get; set; }
        //[Column("entry_id")]
        public int entry_id { get; set; }

        public override string ToString()
        {
            return kana;
        }
    }

    public class Definitions : ITableObjectEntry
    {
        //[PrimaryKey, AutoIncrement]
        public int id { get; set; }
        //[MaxLength(1000)]
        public string definition { get; set; }
        //[MaxLength(1000)]
        public string lang { get; set; }
        public int entry_id { get; set; }

        public override string ToString()
        {
            return definition;
        }
    }

    public class Definitions_eng : ITableObjectEntry
    {
        //[PrimaryKey]
        public int id { get; set; }
        //[Column("definition"), Indexed]
        public string definition { get; set; }
        //[Column("entry_id")]
        public int entry_id { get; set; }
    }

    //Secondary Database things
    public class Favorites
    {
        [PrimaryKey]
        public int entry_id { get; set; }
        [Column("display_string")]
        public string display_string { get; set; }

        public override string ToString()
        {
            return entry_id.ToString();
        }
    }
    public class History
    {

        [PrimaryKey, AutoIncrement]
        public int id { get; set; }
        [Column("search_query"), MaxLength(1000)]
        public string search_query { get; set; }
        [Column("search_date")]
        public long search_date { get; set; }
        
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
        //[PrimaryKey]
        public int entry_id { get; set; }
        //[Column("kanji")]
        public string kanji { get; set; }
        //[Column("kana_map")]
        public string kana_map { get; set; }
        //[Column("definition")]
        public string definition { get; set; }
        //[Column("pos")]
        public string pos { get; set; }
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
