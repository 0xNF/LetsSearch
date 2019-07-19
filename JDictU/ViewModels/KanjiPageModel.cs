using JDictU.Model;
using System.Threading.Tasks;

namespace JDictU.ViewModels {

    public class KanjiPageModel {

        public KanjiPageModel() {
            
        }

        public static async Task<KanjiDict> getKanji(string literal) {
            return await SearchToolsAsync.getKanji(literal);
        }
    }
}
