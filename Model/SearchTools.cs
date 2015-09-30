using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using SQLite.Net;
using JDictU.Model;

namespace JDictU.Model
{
    //Stub
    public class SearchTools
    {       

        public static SearchResult returnSearchResultByEntryID(int entryID) {
            List<Super> super = DBInfo.Jconn.Query<Super>("select * from super where entry_id = ?", entryID);
            if (super.Count != 0) {
                Super s = super[0];
                return new SearchResult(StringTools.splitBar(s.kanji), StringTools.splitBar(s.kana_map), StringTools.splitBar(s.definition), StringTools.splitBar(s.pos), s.entry_id);
            }
            return new SearchResult();
        }

  
        //Class that helps with searching over and returning entries from JDictFIXED3.db

        //English is tricky because it really does one search and returns two sets
        public static Tuple<List<SearchResult>, List<SearchResult>> searchEnglish(string term) {
            string def = "select * from super where entry_id in (select entry_id from definitions_eng where definition like '" + term + "%' order by definition limit 100) order by entry_id ASC";

            //Dictionaries to put specific results into
            Dictionary<int, List<List<string>>> def_exact = new Dictionary<int, List<List<string>>>();
            Dictionary<int, List<List<string>>> def_partial = new Dictionary<int, List<List<string>>>();

            //List of combined results for both Romaji and Definitions
            List<Super> definitions = DBInfo.Jconn.Query<Super>(def);
            //comb over the Combined results and add the results to their own dictionary entry
            foreach (Super c in definitions) {
                List<string> returnfromDefs = StringTools.splitBar(c.definition);
                if (returnfromDefs.Any(s => s.Equals(term, StringComparison.OrdinalIgnoreCase))) { //Come back to this when database has spaces in defs. getting just "term%" won't ever return "%term%":  || s.Equals("to " + term, StringComparison.OrdinalIgnoreCase))){
                    def_exact.Add(c.entry_id, new List<List<string>>() { returnfromDefs, StringTools.splitBar(c.kana_map), StringTools.splitBar(c.kanji), StringTools.splitBar(c.pos) });
                }
                else {
                    def_partial.Add(c.entry_id, new List<List<string>>() { returnfromDefs, StringTools.splitBar(c.kana_map), StringTools.splitBar(c.kanji), StringTools.splitBar(c.pos) });
                }
            }
            var srExact = neoSR_super(def_exact);
            var srInexact = neoSR_super(def_partial);
            return Tuple.Create<List<SearchResult>, List<SearchResult>>(srExact, srInexact);
        }

        public static List<SearchResult> searchRomajiExact(string term) {
            string query = "select * from super where entry_id in (select entry_id from romaji where romaji = '" + term + "' limit 200) order by entry_id ASC";
            return queryWork(query);
        }

        public static List<SearchResult> searchRomajiInexact(string term) {
            string query = "select * from super where entry_id in (select entry_id from romaji where romaji like '" + term + "%' AND romaji <> '" + term + "' limit 200) order by entry_id ASC";
            return queryWork(query);
        }

        public static List<SearchResult> searchKanaExact(string term) {
            string query = "select * from super where entry_id in (select entry_id from kana where kana = '" + term + "' limit 200) order by entry_id ASC";
            return queryWork(query);
        }

        public static List<SearchResult> searchKanaInexact(string term) {
            string query = "select * from super where entry_id in (select entry_id from kana where kana like '" + term + "%' and kana <> '" + term + "' limit 200) order by entry_id ASC";
            return queryWork(query);
        }

        public static List<SearchResult> searchKanjiExact(string term) {
            string query = "select * from super where entry_id in (select entry_id from kanji where kanji = '" + term + "' limit 200) order by entry_id ASC";
            return queryWork(query);
        }

        public static List<SearchResult> searchKanjiInexact(string term) {
            string query = "select * from super where entry_id in (select entry_id from kanji where kanji like '" + term + "%' and kanji <> '" + term + "' limit 200) order by entry_id ASC";
            return queryWork(query);
        }

        #region table searches

        /** searches through the Kanji table and returns a list of Kanji entries matching the given entry_id **/
        public static List<string> searchKanjiByID(int entryID) {
            TableQuery<Kanji> returnKanji = DBInfo.Jconn.Table<Kanji>().Where(x => x.entry_id == entryID);
            List<string> rets = new List<string>();
            foreach (Kanji d in returnKanji) {
                if (!rets.Contains(d.kanji)) {
                    rets.Add(d.kanji);
                }
            }
            return rets;
        }

        /** searches through the Definitions table and returns a list of Definition entries matching the given entry_id **/
        public static List<string> searchDefinitionsByID(int entryID) {
            TableQuery<Definitions_eng> returnDefinitions = DBInfo.Jconn.Table<Definitions_eng>().Where(x => x.entry_id == entryID);
            List<string> rets = new List<string>();
            foreach (Definitions_eng d in returnDefinitions) {
                if (!rets.Contains(d.definition)) {
                    rets.Add(d.definition);
                }
            }
            return rets;
        }

        /** searches through the Kana table and returns a list of Kana entries matching the given entry_id **/
        public static List<string> searchKanaByID(int entryID) {
            TableQuery<Kana> returnKana = DBInfo.Jconn.Table<Kana>().Where(x => x.entry_id == entryID);
            //return returnKana.ToList();
            List<string> retkana = new List<string>();
            foreach (Kana k in returnKana) {
                if (!retkana.Contains(k.kana)) {
                    retkana.Add(k.kana);
                }
            }
            return retkana;
        }

        /** searches through the Romaji table and returns a list of Romaji entries matching the given entry_id **/
        public static List<string> searchRomajiByID(int entryID) {
            TableQuery<Romaji> returnRomaji = DBInfo.Jconn.Table<Romaji>().Where(x => x.entry_id == entryID);
            // return returnRomaji.ToList();
            List<string> retRomas = new List<string>();
            foreach (Romaji r in returnRomaji) {
                if (!retRomas.Contains(r.romaji)) {
                    retRomas.Add(r.romaji);
                }
            }
            return retRomas;
        }

        /** Returns a list of Parts of Speech(text only) from functions matching the given EntryID **/
        public static List<string> searchPoSById(int entryId) {
            TableQuery<Functions> returnFunc = DBInfo.Jconn.Table<Functions>().Where(x => x.entry_id == entryId);
            List<Functions> funcs = returnFunc.ToList();
            List<string> posNoDups = new List<string>();
            foreach (Functions F in funcs) {
                if (!posNoDups.Contains(F.pos)) {
                    posNoDups.Add(F.pos);
                }
            }
            return posNoDups;
        }


        #endregion


        private static List<SearchResult> queryWork(string query) {
            Dictionary<int, List<List<string>>> resultDictionary = new Dictionary<int, List<List<string>>>();
            List<Super> resultSupers = DBInfo.Jconn.Query<Super>(query);

            foreach (Super s in resultSupers) {
                resultDictionary.Add(s.entry_id, new List<List<string>>() { StringTools.splitBar(s.definition), StringTools.splitBar(s.kana_map), StringTools.splitBar(s.kanji), StringTools.splitBar(s.pos) });
            }
            return neoSR_super(resultDictionary);
        }


        /** SUPER returns a 2 lists of search results for a given term, exact matches and partial matches. Type is given by the enumeration searchType **/
        public static Tuple<List<SearchResult>, List<SearchResult>> fetchResults_Unicode_super(string term, int type) {
            Tuple<List<SearchResult>, List<SearchResult>> rets = Tuple.Create(new List<SearchResult>(), new List<SearchResult>());
            //format is {exact, partial}            
            if (type == 0) {
                //return over romaji
                var romaExact = searchRomajiExact(term);
                var romaPartial = searchRomajiInexact(term);
                rets = Tuple.Create(romaExact, romaPartial);
            }
            else if (type == 1) {
                //return over kana
                var kanaExact = searchKanaExact(term);
                var kanaPartial = searchKanaInexact(term);
                rets = Tuple.Create(kanaExact, kanaPartial);
            }
            else if (type == 2) {
                //return over kanji
                var kanjiExact = searchKanjiExact(term);
                var kanjiIPartial = searchKanjiInexact(term);
                rets = Tuple.Create(kanjiExact, kanjiIPartial);
            }
            return rets;
        }


        private static List<SearchResult> neoSR_super(Dictionary<int, List<List<string>>> dicts) {

            Dictionary<int, List<List<string>>> match = new Dictionary<int, List<List<string>>>();

            foreach (KeyValuePair<int, List<List<string>>> kvp in dicts) {
                //kanji, kana, definition, pos
                match.Add(kvp.Key, new List<List<string>>() { kvp.Value[0], kvp.Value[1], kvp.Value[2], kvp.Value[3] });
            }
            List<SearchResult> lsr = new List<SearchResult>();
            foreach (int eid in match.Keys) {
                lsr.Add(new SearchResult(match[eid][2], match[eid][1], match[eid][0], match[eid][3], eid));
            }
            return lsr;
        }

    }
}
