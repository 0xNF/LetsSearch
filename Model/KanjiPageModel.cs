using System.Threading.Tasks;

namespace JDictU.Model {

    public class KanjiPageModel {

        public KanjiPageModel() {
            
        }

        public static async Task<KanjiDict> getKanji(string literal) {
            return await SearchToolsAsync.getKanji(literal);
        }
    }
}
