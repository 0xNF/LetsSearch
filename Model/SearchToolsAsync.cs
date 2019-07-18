using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using SQLite.Net.Async;

namespace JDictU.Model {
    public class SearchToolsAsync
    {

        public enum SearchType {
            English = 0,
            Romaji = 1,
            Kana = 2,
            Kanji = 3
        }


        #region Async versions
        public static SearchResult returnSearchResultByEntryIDAsync(int entryID) {
            var task = DBInfo.JconnAsync.QueryAsync<Super>("SELECT * FROM super WHERE entry_id = ?", entryID);
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
            await Task.CompletedTask;
        }

        public static async Task<List<KanjiDict>> getAllKanji() {
            string q = "SELECT * FROM kanji;";
            List<KanjiDict> kanj = await DBInfo.KconnAsync.QueryAsync<KanjiDict>(q);
            return kanj;
        }

        public static async Task<KanjiDict> getKanji(string literal) {
            string query = "SELECT * FROM kanji WHERE literal IS ?";
            List<KanjiDict> kanj  = await DBInfo.KconnAsync.QueryAsync<KanjiDict>(query, literal);
            if(kanj.Count != 0) {
                return kanj.First();
            }
            else {
                return null;
            }
        }

        public static async Task<List<HeadwordSentence>> getSentences(string word) {
            string query = "SELECT headword,reading,form,sensenumber, verified, sentencejpn, sentenceeng FROM headwords AS H JOIN sentences AS S ON H.sentenceid=S.id WHERE H.headword IS ? ORDER BY H.verified DESC LIMIT 10";
            List<HeadwordSentence> hws = await DBInfo.JconnAsync.QueryAsync<HeadwordSentence>(query, word);
            return hws;
        } 


        public static async Task<Tuple<List<SearchResult>, List<SearchResult>>> searchEnglishAsync(string term, int limit = 75, bool useDoubleLike = false) {
            string def = "SELECT * FROM super WHERE entry_id in (SELECT entry_id FROM definitions_eng WHERE definition LIKE ? ORDER BY definition LIMIT ?) ORDER BY example_verified DESC, example_total DESC, Rank ASC";
            //Dictionaries to put specific results into
            List<SearchResult> def_exact = new List<SearchResult>();
            List<SearchResult> def_partial = new List<SearchResult>();
            //List of combined results for both Romaji and Definitions
            string t = term + "%";
            if (useDoubleLike) {
                t = "%" + t + "%";
            }
            List<Super> definitions = await DBInfo.JconnAsync.QueryAsync<Super>(def, t, limit);
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
            string query = "SELECT * FROM super WHERE entry_id in (SELECT entry_id FROM romaji WHERE romaji = ? LIMIT ?) ORDER BY example_verified DESC, example_total DESC, Rank ASC";
            return queryWork2(await DBInfo.JconnAsync.QueryAsync<Super>(query, term, limit));
        }

        public static async Task<List<SearchResult>> searchRomajiInexactAsync(string term, int limit, bool useDoubleLike = false) {
            string param = "SELECT * FROM super WHERE entry_id in (SELECT entry_id FROM romaji WHERE romaji LIKE ? AND romaji <> ? LIMIT ?) ORDER BY example_verified DESC, example_total DESC, Rank ASC";
            string t = term + "%";
            if (useDoubleLike) {
                t = "%" + t + "%";
            }
            return queryWork2(await DBInfo.JconnAsync.QueryAsync<Super>(param, t, term, limit));
        }

        public static async Task<List<SearchResult>> searchKanaExactAsync(string term, int limit, bool useDoubleLike = false) {
            string query = "SELECT * FROM super WHERE entry_id in (SELECT entry_id FROM kana WHERE kana = ? LIMIT ?) ORDER BY example_verified DESC, example_total DESC, Rank ASC";
            return queryWork2(await DBInfo.JconnAsync.QueryAsync<Super>(query, term, limit));
        }

        public static async Task<List<SearchResult>> searchKanaInexactAsync(string term, int limit, bool useDoubleLike = false) {
            string param = "SELECT * FROM super WHERE entry_id in (SELECT entry_id FROM kana WHERE kana LIKE ? AND kana <> ? LIMIT ?) ORDER BY example_verified DESC, example_total DESC, Rank ASC";
            string t = term + "%";
            if (useDoubleLike) {
                t = "%" + t + "%";
            }
            return queryWork2(await DBInfo.JconnAsync.QueryAsync<Super>(param, t, term, limit));
        }

        public static async Task<List<SearchResult>> searchKanjiExactAsync(string term, int limit, bool useDoubleLike = false) {
            string param = "SELECT * FROM super WHERE entry_id in (SELECT entry_id FROM kanji WHERE kanji = ? LIMIT ?) ORDER BY example_verified DESC, example_total DESC, Rank ASC";
            return queryWork2(await DBInfo.JconnAsync.QueryAsync<Super>(param, term, limit));
        }

        public static async Task<List<SearchResult>> searchKanjiInexactAsync(string term, int limit, bool useDoubleLike = false) {
            string param = "SELECT * FROM super WHERE entry_id in (SELECT entry_id FROM kanji WHERE kanji LIKE ? AND kanji <> ? LIMIT ?) ORDER BY example_verified DESC, example_total DESC, Rank ASC";
            string t = term + "%";
            if (useDoubleLike) {
                t = "%" + t + "%";
            }
            return queryWork2(await DBInfo.JconnAsync.QueryAsync<Super>(param, t, term, limit));
        }
        #endregion

        private static List<SearchResult> queryWork2(List<Super> supers) {
            return supers.Select(x => new SearchResult(x)).ToList();
        }

    }
}
