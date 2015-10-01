using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using SQLite.Net.Async;
using JDictU.Model;
using System.Diagnostics;
using Windows.Foundation;

namespace JDictU.Model
{
    class SearchToolsAsync
    {

    
        #region Async versions
        public static SearchResult returnSearchResultByEntryIDAsync(int entryID) {
            var task = DBInfo.JconnAsync.QueryAsync<Super>("select * from super where entry_id = ?", entryID);
            task.Wait();
            List<Super> super = task.Result;
            if (super.Count != 0) {
                Super s = super[0];
                return new SearchResult(StringTools.splitBar(s.kanji), StringTools.splitBar(s.kana_map), StringTools.splitBar(s.definition), StringTools.splitBar(s.pos), s.entry_id);
            }
            return new SearchResult();
        }

        //NYI TODO
        public static async Task terminateSearch() {
            
        }

        public static async Task<List<HeadwordSentence>>  getSentences(string word) {
            string query = "SELECT headword,reading,form,sensenumber, verified, sentencejpn, sentenceeng FROM headwords AS H JOIN sentences AS S ON H.sentenceid=S.id WHERE H.headword IS ? ORDER BY H.verified DESC LIMIT 10";
            List<HeadwordSentence> hws = await DBInfo.EconnAsync.QueryAsync<HeadwordSentence>(query, word);
            return hws;
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


        public static async Task<Tuple<List<SearchResult>, List<SearchResult>>> searchEnglishAsync(string term) {
            string def = "select * from super where entry_id in (select entry_id from definitions_eng where definition like '" + term + "%' order by definition limit 100) order by entry_id ASC";
            //Dictionaries to put specific results into
            Dictionary<int, List<List<string>>> def_exact = new Dictionary<int, List<List<string>>>();
            Dictionary<int, List<List<string>>> def_partial = new Dictionary<int, List<List<string>>>();
            //List of combined results for both Romaji and Definitions
                List<Super> definitions = await DBInfo.JconnAsync.QueryAsync<Super>(def);
                //comb over the Combined results and add the results to their own dictionary entry
                foreach (Super c in definitions) {
                    List<string> returnfromDefs = StringTools.splitBar(c.definition);
                    if (returnfromDefs.Any(s => s.Equals(term, StringComparison.OrdinalIgnoreCase))) {
                        //Come back to this when database has spaces in defs. getting just "term%" won't ever return "%term%":  || s.Equals("to " + term, StringComparison.OrdinalIgnoreCase))){
                        def_exact.Add(c.entry_id,
                            new List<List<string>>() {
                                returnfromDefs,
                                StringTools.splitBar(c.kana_map),
                                StringTools.splitBar(c.kanji),
                                StringTools.splitBar(c.pos)
                            });
                    }
                    else {
                        def_partial.Add(c.entry_id,
                            new List<List<string>>() {
                                returnfromDefs,
                                StringTools.splitBar(c.kana_map),
                                StringTools.splitBar(c.kanji),
                                StringTools.splitBar(c.pos)
                            });
                    }
                }
                var srExact = neoSR_super(def_exact);
                var srInexact = neoSR_super(def_partial);
                return Tuple.Create<List<SearchResult>, List<SearchResult>>(srExact, srInexact);
            }

        public static async Task<List<SearchResult>> searchRomajiExactAsync(string term) {
            string query = "select * from super where entry_id in (select entry_id from romaji where romaji = '" + term + "' limit 200) order by entry_id ASC";
            return await queryWork(query);
        }

        public static async Task<List<SearchResult>> searchRomajiInexactAsync(string term) {
            string query = "select * from super where entry_id in (select entry_id from romaji where romaji like '" + term + "%' AND romaji <> '" + term + "' limit 200) order by entry_id ASC";
            return await queryWork(query);
        }

        public static async Task<List<SearchResult>> searchKanaExactAsync(string term) {
            string query = "select * from super where entry_id in (select entry_id from kana where kana = '" + term + "' limit 200) order by entry_id ASC";
            return await queryWork(query);
        }

        public static async Task<List<SearchResult>> searchKanaInexactAsync(string term) {
            string query = "select * from super where entry_id in (select entry_id from kana where kana like '" + term + "%' and kana <> '" + term + "' limit 200) order by entry_id ASC";
            return await queryWork(query);
        }

        public static async Task<List<SearchResult>> searchKanjiExactAsync(string term) {
            string query = "select * from super where entry_id in (select entry_id from kanji where kanji = '" + term + "' limit 200) order by entry_id ASC";
            return await queryWork(query);
        }

        public static async Task<List<SearchResult>> searchKanjiInexactAsync(string term) {
            string query = "select * from super where entry_id in (select entry_id from kanji where kanji like '" + term + "%' and kanji <> '" + term + "' limit 200) order by entry_id ASC";
            return await queryWork(query);
        }
        #endregion

        private static async Task<List<SearchResult>> queryWork(string query) {
            Dictionary<int, List<List<string>>> resultDictionary = new Dictionary<int, List<List<string>>>();
            List<Super> resultSupers = await DBInfo.JconnAsync.QueryAsync<Super>(query);
            foreach (Super s in resultSupers) {
                resultDictionary.Add(s.entry_id, new List<List<string>>() { StringTools.splitBar(s.definition), StringTools.splitBar(s.kana_map), StringTools.splitBar(s.kanji), StringTools.splitBar(s.pos) });
            }
            return neoSR_super(resultDictionary);
        }

        /** SUPER returns a 2 lists of search results for a given term, exact matches and partial matches. Type is given by the enumeration searchType **/
        public static async Task<Tuple<List<SearchResult>, List<SearchResult>>> fetchResults_Unicode_superAsync(string term, int type) {
            Tuple<List<SearchResult>, List<SearchResult>> rets = Tuple.Create(new List<SearchResult>(), new List<SearchResult>());
            //format is {exact, partial}            
            if (type == 0) {
                //return over romaji
                var romaExact = await searchRomajiExactAsync(term);
                var romaPartial = await searchRomajiInexactAsync(term);
                rets = Tuple.Create(romaExact, romaPartial);
            }
            else if (type == 1) {
                //return over kana
                var kanaExact = await searchKanaExactAsync(term);
                var kanaPartial = await searchKanaInexactAsync(term);
                rets = Tuple.Create(kanaExact, kanaPartial);
            }
            else if (type == 2) {
                //return over kanji
                var kanjiExact = await searchKanjiExactAsync(term);
                var kanjiIPartial = await searchKanjiInexactAsync(term);
                rets = Tuple.Create(kanjiExact, kanjiIPartial);
            }
            return rets;
        }

        #region tableSearches
        /** searches through the Kanji table and returns a list of Kanji entries matching the given entry_id **/
        public async static Task<List<string>> searchKanjiByIDAsync(int entryID) {
            AsyncTableQuery<Kanji> retQuery = DBInfo.JconnAsync.Table<Kanji>().Where(x => x.entry_id == entryID);
            List<string> rets = new List<string>();
            var retlist = await retQuery.ToListAsync();
            foreach (Kanji d in retlist) {
                if (!rets.Contains(d.kanji)) {
                    rets.Add(d.kanji);
                }
            }
            return rets;
        }

        /** searches through the Definitions table and returns a list of Definition entries matching the given entry_id **/
        public async static Task<List<string>> searchDefinitionsByID(int entryID) {
            AsyncTableQuery<Definitions_eng> retQuery = DBInfo.JconnAsync.Table<Definitions_eng>().Where(x => x.entry_id == entryID);
            List<string> rets = new List<string>();
            var retlist = await retQuery.ToListAsync();
            foreach (Definitions_eng d in retlist) {
                if (!rets.Contains(d.definition)) {
                    rets.Add(d.definition);
                }
            }
            return rets;
        }

        /** searches through the Kana table and returns a list of Kana entries matching the given entry_id **/
        public async static Task<List<string>> searchKanaByID(int entryID) {
            AsyncTableQuery<Kana> retQuery = DBInfo.JconnAsync.Table<Kana>().Where(x => x.entry_id == entryID);
            //return returnKana.ToList();
            List<string> rets = new List<string>();
            var retlist = await retQuery.ToListAsync();
            foreach (Kana k in retlist) {
                if (!rets.Contains(k.kana)) {
                    rets.Add(k.kana);
                }
            }
            return rets;
        }

        /** searches through the Romaji table and returns a list of Romaji entries matching the given entry_id **/
       public async static Task<List<string>> searchRomajiByID(int entryID) {
            AsyncTableQuery<Romaji> retQuery = DBInfo.JconnAsync.Table<Romaji>().Where(x => x.entry_id == entryID);
            // return returnRomaji.ToList();
            List<string> rets = new List<string>();
            var retlist = await retQuery.ToListAsync();
            foreach (Romaji r in retlist) {
                if (!rets.Contains(r.romaji)) {
                    rets.Add(r.romaji);
                }
            }
            return rets;
        }

       /** Returns a list of Parts of Speech(text only) from functions matching the given EntryID **/
       public async static Task<List<string>> searchPoSByIdAsync(int entryId) {
           AsyncTableQuery<Functions> retQuery = DBInfo.JconnAsync.Table<Functions>().Where(x => x.entry_id == entryId);
           List<string> rets = new List<string>();
           List<Functions> retlist = await retQuery.ToListAsync();
           foreach (Functions F in retlist) {
               if (!rets.Contains(F.pos)) {
                   rets.Add(F.pos);
               }
           }
           return rets;
       }

        #endregion

    }
}
