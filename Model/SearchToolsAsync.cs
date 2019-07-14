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
                return new SearchResult(s);
            }
            return new SearchResult();
        }

        //NYI TODO
        public static async Task terminateSearch() {
            
        }

        public static async Task<KanjiDict> getKanji(string literal) {
            string query = "SELECT * FROM kanji WHERE literal is ?";
            List<KanjiDict> kanj  = await DBInfo.KconnAsync.QueryAsync<KanjiDict>(query, literal);
            if(kanj.Count != 0) {
                return kanj.First();
            }
            else {
                return null;
            }
        }

        public static async Task<List<HeadwordSentence>>  getSentences(string word) {
            string query = "SELECT headword,reading,form,sensenumber, verified, sentencejpn, sentenceeng FROM headwords AS H JOIN sentences AS S ON H.sentenceid=S.id WHERE H.headword IS ? ORDER BY H.verified DESC LIMIT 10";
            List<HeadwordSentence> hws = await DBInfo.JconnAsync.QueryAsync<HeadwordSentence>(query, word);
            return hws;
        } 


        public static async Task<Tuple<List<SearchResult>, List<SearchResult>>> searchEnglishAsync(string term, int limit = 75, bool useDoubleLike = false) {
            string def = "select * from super where entry_id in (select entry_id from definitions_eng where definition like ? order by definition limit ?) ORDER BY example_verified DESC, example_total DESC, Rank ASC";
            //Dictionaries to put specific results into
            List<SearchResult> def_exact = new List<SearchResult>();
            List<SearchResult> def_partial = new List<SearchResult>();
            //List of combined results for both Romaji and Definitions
            List<Super> definitions = await DBInfo.JconnAsync.QueryAsync<Super>(def, term+"%", limit);
            //comb over the Combined results and add the results to their own dictionary entry
            foreach (Super c in definitions) {
                List<string> returnfromDefs = StringTools.splitBar(c.definition);
                if (returnfromDefs.Any(s => s.Equals(term, StringComparison.OrdinalIgnoreCase))) {
                    def_exact.Add(new SearchResult(c));
                    //Come back to this when database has spaces in defs. getting just "term%" won't ever return "%term%":  || s.Equals("to " + term, StringComparison.OrdinalIgnoreCase))){
                }
                else {
                    def_partial.Add(new SearchResult(c));
                }
            }
            var srExact = def_exact;
            var srInexact = def_partial;
            return Tuple.Create<List<SearchResult>, List<SearchResult>>(srExact, srInexact);
        }

        public static async Task<List<SearchResult>> searchRomajiExactAsync(string term, int limit,bool useDoubleLike = false) {
            string query = "select * from super where entry_id in (select entry_id from romaji where romaji = ? limit ?) ORDER BY example_verified DESC, example_total DESC, Rank ASC";
            return queryWork2(await DBInfo.JconnAsync.QueryAsync<Super>(query, term, limit));
        }

        public static async Task<List<SearchResult>> searchRomajiInexactAsync(string term, int limit, bool useDoubleLike = false) {
            string param = "select * from super where entry_id in (select entry_id from romaji where romaji like ? AND romaji <> ? limit ?) ORDER BY example_verified DESC, example_total DESC, Rank ASC";
            return queryWork2(await DBInfo.JconnAsync.QueryAsync<Super>(param, term+"%", term, limit));
        }

        public static async Task<List<SearchResult>> searchKanaExactAsync(string term, int limit, bool useDoubleLike = false) {
            string query = "select * from super where entry_id in (select entry_id from kana where kana = ? limit ?) ORDER BY example_verified DESC, example_total DESC, Rank ASC";
            return queryWork2(await DBInfo.JconnAsync.QueryAsync<Super>(query, term, limit));
        }

        public static async Task<List<SearchResult>> searchKanaInexactAsync(string term, int limit, bool useDoubleLike = false) {
            string param = "select * from super where entry_id in (select entry_id from kana where kana like ? and kana <> ? limit ?) ORDER BY example_verified DESC, example_total DESC, Rank ASC";
            return queryWork2(await DBInfo.JconnAsync.QueryAsync<Super>(param, term+"%", term, limit));
        }

        public static async Task<List<SearchResult>> searchKanjiExactAsync(string term, int limit, bool useDoubleLike = false) {
            string param = "select * from super where entry_id in (select entry_id from kanji where kanji = ? limit ?) ORDER BY example_verified DESC, example_total DESC, Rank ASC";
            return queryWork2(await DBInfo.JconnAsync.QueryAsync<Super>(param, term, limit));
        }

        public static async Task<List<SearchResult>> searchKanjiInexactAsync(string term, int limit, bool useDoubleLike = false) {
            string param = "select * from super where entry_id in (select entry_id from kanji where kanji like ? and kanji <> ? limit ?) ORDER BY example_verified DESC, example_total DESC, Rank ASC";
            if (useDoubleLike) {
                return queryWork2(await DBInfo.JconnAsync.QueryAsync<Super>(param, "%" + term + "%", term, limit));
            }
            else {
                return queryWork2(await DBInfo.JconnAsync.QueryAsync<Super>(param, term + "%", term, limit));

            }
        }
        #endregion

        private static List<SearchResult> queryWork2(List<Super> supers) {
            return supers.Select(x => new SearchResult(x)).ToList();
        }

        private static async Task<List<SearchResult>> queryWork(string query, int limit=75) {
            Dictionary<int, List<List<string>>> resultDictionary = new Dictionary<int, List<List<string>>>();
            List<Super> resultSupers = await DBInfo.JconnAsync.QueryAsync<Super>(query);
            return resultSupers.Select(x => new SearchResult(x)).ToList();
        }

        /** SUPER returns a 2 lists of search results for a given term, exact matches and partial matches. Type is given by the enumeration searchType **/
        public static async Task<Tuple<List<SearchResult>, List<SearchResult>>> fetchResults_Unicode_superAsync(string term, int type, int limit=75) {
            Tuple<List<SearchResult>, List<SearchResult>> rets = Tuple.Create(new List<SearchResult>(), new List<SearchResult>());
            //format is {exact, partial}
            if (type == 0) {
                //return over romaji
                var romaExact = await searchRomajiExactAsync(term, limit);
                var romaPartial = await searchRomajiInexactAsync(term, limit);
                rets = Tuple.Create(romaExact, romaPartial);
            }
            else if (type == 1) {
                //return over kana
                var kanaExact = await searchKanaExactAsync(term, limit);
                var kanaPartial = await searchKanaInexactAsync(term, limit);
                rets = Tuple.Create(kanaExact, kanaPartial);
            }
            else if (type == 2) {
                //return over kanji
                var kanjiExact = await searchKanjiExactAsync(term, limit);
                var kanjiIPartial = await searchKanjiInexactAsync(term, limit);
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
