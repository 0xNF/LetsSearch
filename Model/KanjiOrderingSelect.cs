using System.Collections.Generic;

namespace JDictU.Model {

    public class KanjiOrderingSelect {
        public int Id { get; private set; }
        public string Key { get; private set; }

        public static IEnumerable<KanjiOrderingSelect> Orders {
            get {
                return _Orders;
            }
        }
        private static List<KanjiOrderingSelect> _Orders = new List<KanjiOrderingSelect>();

        private KanjiOrderingSelect(int id, string key) {
            this.Id = id;
            this.Key = key;
            _Orders.Add(this);
        }


        public static KanjiOrderingSelect ByJLPT = new KanjiOrderingSelect(0, "JLPT");
        public static KanjiOrderingSelect ByGrade = new KanjiOrderingSelect(0, "Grade");
        public static KanjiOrderingSelect ByFreq = new KanjiOrderingSelect(0, "Frequency");

    }
}
