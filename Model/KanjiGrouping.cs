using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace JDictU.Model {

    public class KanjiGrouping : IGrouping<int, KanjiDict> {
        public int Key { get; private set; }
        public string DisplayKey { get; private set; }
        private List<KanjiDict> _kanji;

        public KanjiGrouping(int groupKey, string dkey, IEnumerable<KanjiDict> kanji) {
            this.Key = groupKey;
            this.DisplayKey = dkey;
            this._kanji = new List<KanjiDict>(kanji);
        }


        public IEnumerator<KanjiDict> GetEnumerator() {
            return this._kanji.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator() {
            return this._kanji.GetEnumerator();
        }
    }
}
