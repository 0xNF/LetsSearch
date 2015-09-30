using JDictU.Model;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JDictU.Model { 
public class SearchPageModel {
    //When a search is executed...
    /**
     * 1. Async search the Databases
     * 2. When that returns, look at that data
     * 3. Update UI thread with necessary elements
     **/

    //Temp stuff for initial setup stages of new codebase. Will be moved to appropriate destinations later
    public static string searchTerm = "test";
    private void searchGO(string searchTerm) {
        //ProgressBar.Visibility = Visibility.Visible;
        //ProgressBar.IsIndeterminate = true;
        Task.Run(() => {
            //Tuple<List<SearchResult>, List<SearchResult>> getResults = search(searchTerm);
        });
    }


    //This whole thing happens on the background thread - Also create an Async version!
    private async Task<Tuple<List<SearchResult>, List<SearchResult>>> search(string searchText) {
        //Update the userdata asynchronously. Who cares when it returns
        await UserData.insertIntoSearchHistory(searchText);

        //Lists that we will add to
        List<SearchResult> exacts = new List<SearchResult>();
        List<SearchResult> inexacts = new List<SearchResult>();

        //Limit the scope of the search
        //If there's no unicode, then we can limit the table search to be over Romaji and English
        if (!StringTools.ContainsUnicodeCharacter(searchText)) {
            //If there's a space, it's guaranteed to be in Definitions(english) (if term exists). The same is true if term ends in a consonant that isn't 'n'.
            if (searchText.Contains(" ") || StringTools.endsInConsonantNotN(searchText)) {
                var english = SearchTools.searchEnglish(searchTerm);
                exacts = english.Item1;
                inexacts = english.Item2;
            }
            //If it didn't contain a space, or it ended in a vowel or 'n', then it can be found in either Romaji or Definitions, so we return both
            else {
                var english = SearchTools.searchEnglish(searchTerm);

                List<SearchResult> roma_results_exact = SearchTools.searchRomajiExact(searchTerm);
                List<SearchResult> roma_results_inexact = SearchTools.searchRomajiInexact(searchTerm);
                List<SearchResult> engl_results_exact = english.Item1;
                List<SearchResult> engl_results_inexact = english.Item2;
                //Add them to the lists
                exacts.AddRange(roma_results_exact);
                exacts.AddRange(engl_results_exact);
                inexacts.AddRange(roma_results_inexact);
                inexacts.AddRange(engl_results_inexact);
            }
        }
        else {
            //if it does contain unicode, then it can be found in either Kana or Kanji (ignoring french/german defintions)
            //if every letter is kana,then it's guaranteed to be a Kana table match
            if (StringTools.allKana(searchTerm)) {
                List<SearchResult> kana_results_exact = SearchTools.searchKanaExact(searchText);
                List<SearchResult> kana_results_inexact = SearchTools.searchKanaInexact(searchText);
                //Add them to the lists
                exacts.AddRange(kana_results_exact);
                exacts.AddRange(kana_results_inexact);
            }
            else {
                List<SearchResult> kanji_results_exact = SearchTools.searchKanjiExact(searchText);
                List<SearchResult> kanji_results_inexact = SearchTools.searchKanjiInexact(searchText);
                //Add them to the lists
                exacts.AddRange(kanji_results_exact);
                exacts.AddRange(kanji_results_inexact);
            }
        }
        return Tuple.Create(exacts, inexacts);

    }





    public SearchPageModel() {
    }
}
}
