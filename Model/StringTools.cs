using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace JDictU.Model {
    public class StringTools
    {
        /** enumeration of Kana characters **/
        private const string kana = "ぁあぃいぅうぇえぉおかがきぎだちぢっつづてでとどなにぬねのはばぱひびぴふぶぷへべぺほぼぽまみむめもゃやゅゆょよらりるれろゎわゐゑをんゔゕゖ	゙ 	゚゛ ゜ゝゞゟ゠ァアィイゥウェエォオカガキギクグケゲコゴサザシジスズセゼソゾタダチヂッツヅテデトドナニヌネノハバパヒビピフブプヘベペホボポマミムメモャヤュユョヨラリルレロヮワヰヱヲンヴヵヶヷヸヹヺ・ーヽヾヿ｡｢｣､･ｦｧｨｩｪｫｬｭｮｯｰｱｲｳｴｵｶｷｸｹｺｻｼｽｾｿﾀﾁﾂﾃﾄﾅﾆﾇﾈﾉﾊﾋﾌﾍﾎﾏﾐﾑﾒﾓﾔﾕﾖﾗﾘﾙﾚﾛﾜﾝﾞﾟㇰㇱㇲㇳㇴㇵㇶㇷㇸㇹㇺㇻㇼㇽㇾㇿ𛀀𛀁くぐけげこごさざしじすずせぜそぞた";
        private const string bumunu = "ぶむぬブムヌ";//todo: halfhearted, doesn't take into account the halfwidths and whatever from the above Kana field.
        private const string katakana = "ァアィイゥウェエォオカガキギクグケゲコゴサザシジスズセゼソゾタダチヂッツヅテデトドナニヌネノハバパヒビピフブプヘベペホボポマミムメモャヤュユョヨラリルレロヮワヰヱヲンヴヵヶヷヸヹヺｦｧｨｩｪｫｬｭｮｯｰｱｲｳｴｵｶｷｸｹｺｻｼｽｾｿﾀﾁﾂﾃﾄﾅﾆﾇﾈﾉﾊﾋﾌﾍﾎﾏﾐﾑﾒﾓﾔﾕﾖﾗﾘﾙﾚﾛﾜﾝﾞﾟㇰㇱㇲㇳㇴㇵㇶㇷㇸㇹㇺㇻㇼㇽㇾㇿ";
        private const string halfwidthlatin = "！＂＃＄％＆＇（）＊＋，－．／：；＜＝＞？［＼］＾＿｀";
        private static readonly byte[] bytes = Encoding.UTF8.GetBytes(kana);
        private const string vowels = "aeiou";
        private const string consonantsNotN = "bcdfghjklmpqrstvwxyz";
        private const int MaxAnsiCode = 255;

        public static bool endsInBuMuNu(string toTest) {
            return bumunu.Contains(toTest.Last().ToString());
        }

        public static bool endsInKu(string toTest) {
            return "くク".Contains(toTest.Last().ToString());
        }

        public static bool endsInGu(string toTest) {
            return "ぐグ".Contains(toTest.Last().ToString());
        }

        /// <summary>
        /// Tests if a string ends in any consonant excluding 'n'. Used for testing if a string should be run over Kana
        /// </summary>
        /// <param name="toTest"></param>
        /// <returns></returns>
        public static bool endsInConsonantNotN(string toTest) {
            return consonantsNotN.Contains(toTest[toTest.Length - 1]);
        }

        /// <summary>
        /// Tests if a string ends in a vowel. Used for testing if a string should be run over Romaji
        /// </summary>
        /// <param name="toTest">string to test</param>
        /// <returns>Whether or not the given string ends in a vowel</returns>
        public static bool endsInVowel(string toTest) {
            return vowels.Contains(toTest[toTest.Length - 1]);
        }

        /// <summary>
        /// Tests if a string is entirely in kana. ex) ろまじ => true, T-バック => false
        /// </summary>
        /// <param name="toTest"></param>
        /// <returns></returns>
        public static bool allKana(string toTest) {
            foreach (byte b in Encoding.UTF8.GetBytes(toTest.ToCharArray())) {
                if (!bytes.Contains(b)) {
                    return false;
                }
            }
            return true;
        }


        /// <summary>
        /// Tests if a string ends in a combination of vowel+n. Useful for determining if a string should be run over Romaji, ex) konban => an => true
        /// </summary>
        /// <param name="toTest">string to test</param>
        /// <returns>whether or not </returns>
        public static bool endsInVowelAndN(string toTest) {
            if (toTest.Length >= 2) {
                return (vowels.Contains(toTest[toTest.Length - 2]) && toTest[toTest.Length - 1] == 'n');
            }
            else {
                return false;
            }
        }

        /// <summary>
        /// Gets Kana from a map of Kana:Romaji from the Super Table
        /// </summary>
        /// <param name="toSplit"></param>
        /// <returns></returns>
        internal static List<string> getKanaFromMap(string toSplit) {
            List<string> Kana2Roma = toSplit.Split('|').ToList();
            List<string> Kana = new List<string>();
            foreach (string k in Kana2Roma) {
                Kana.Add(k.Split(':')[0]);
            }
            return Kana;
        }


        /// <summary>
        /// Checks if the given string contains non-ansi chars, i.e., is in Japanese
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static bool ContainsUnicodeCharacter(string input) {
            return input.ToCharArray().Any(c => c > MaxAnsiCode);
        }

        /// <summary>
        /// Gets Kana or Romaji from a list of strings of the following format: "kana:romaji"
        /// </summary>
        /// <param name="s"></param>
        /// <param name="kanaOrRoma">0 = get Kana, 1 = get Romaji</param>
        /// <returns></returns>
        internal static List<string> stringFromKanaMap(List<string> s, int kanaOrRoma) {
            List<string> lst = new List<string>();
            foreach (string map in s) {
                lst.Add(map.Split(':')[kanaOrRoma]);
            }
            return lst;
        }

        /// <summary>
        /// Splits a string from the Super Table on the "|" character
        /// </summary>
        /// <param name="toSplit"></param>
        /// <returns></returns>
        internal static List<string> splitBar(string toSplit) {
            return toSplit.Split('|').ToList();
        }

        /// <summary>
        /// Returns a dictionary of JapaneseString:English string, used in the non-empty constructor of ExampleResult
        /// </summary>
        /// <param name="jp"></param>
        /// <param name="eng"></param>
        /// <returns></returns>
        public static Dictionary<string, string> makeDictionaryExamples(List<string> jp, List<string> eng) {
            Dictionary<string, string> dict = new Dictionary<string, string>();
            if (jp.Count == eng.Count) {
                for (int i = 0; i < jp.Count; i++) {
                    dict.Add(jp[i], eng[i]);
                }
            }
            return dict;
        }


        public static bool isKatakana(string p) {
            return katakana.Contains(p);
        }

        internal static bool endsInSuTsuDzu(string p) {
            return p.EndsWith("す") || p.EndsWith("つ") || p.EndsWith("づ") || p.EndsWith("ス") || p.EndsWith("ツ") || p.EndsWith("ヅ");
        }

        internal static bool hasHalfwidthLatin(object searchText) {
            return false;
        }
    }
}
