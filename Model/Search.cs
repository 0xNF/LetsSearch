using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace JDictU.Model
{
    public class Search
    {

        /** returns a list of search results given a list of entry_ids **/
        public static List<SearchResult> getSearchResults(List<int> entry_ids)
        {
            List<SearchResult> srs = new List<SearchResult>();
            foreach (int id in entry_ids)
            {
                srs.Add(getSearchResult(id));
            }
            return srs;
        }

        /** returns the search result of the given entry_id **/
        public static SearchResult getSearchResult(int entry_id)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            List<string> kj = SearchTools.searchKanjiByID(entry_id);
            List<string> ka = SearchTools.searchKanaByID(entry_id);
            List<string> d = SearchTools.searchDefinitionsByID(entry_id);
            sw.Stop();

            SearchResult r = new SearchResult();
            if (kj.Count != 0)
            {
                r.kanji = kj;
            }
            if (ka.Count != 0)
            {
                r.kana = ka;
            }
            if (d.Count != 0)
            {
                r.definitions = d;
            }
            r.entry_id = entry_id;           

            return r;
        }


    }

}
