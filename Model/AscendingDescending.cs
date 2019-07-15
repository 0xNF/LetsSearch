using System.Collections.Generic;

namespace JDictU.Model {
    public class AscendingDescending {
        public int Id { get; private set; }
        public string Key { get; private set; }
        public static IEnumerable<AscendingDescending> AscnendingDescendings {
            get {
                return _AscendingDescendings;
            }
        }
        private static List<AscendingDescending> _AscendingDescendings = new List<AscendingDescending>();

        private AscendingDescending(int id, string key) {
            this.Id = id;
            this.Key = key;
            _AscendingDescendings.Add(this);
        }


        public static AscendingDescending ASC = new AscendingDescending(0, "Ascending");
        public static AscendingDescending DESC = new AscendingDescending(1, "Descending");
    }
}
