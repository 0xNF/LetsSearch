using System.Linq;

namespace JDictU.Model {
    //Applies various rules to a japanese words to produce conjugations of that word
    public class Conjugator
    {


        public static string findReg1InfinitiveKana(string endmarker) {
            switch (endmarker) {
                //Hiragana
                case "う":
                    return "い";
                case "く":
                    return "き";
                case "す":
                    return "し";
                case "つ":
                    return "ち";
                case "ぬ":
                    return "に";
                case "ふ":
                    return "ひ";
                case "む":
                    return "み";
                case "ゆ":
                    return "い";
                case "る":
                    return "り";
                case "ぐ":
                    return "ぎ";
                case "ぷ":
                    return "ぴ";
                case "づ":
                    return "ぢ";
                case "ず":
                    return "じ";
                case "ぶ":
                    return "び";
                //Katakana
                case "ウ":
                    return "イ";
                case "ク":
                    return "キ";
                case "ス":
                    return "シ";
                case "ツ":
                    return "チ";
                case "ヌ":
                    return "二";
                case "フ":
                    return "ヒ";
                case "ム":
                    return "ミ";
                case "ユ":
                    return "イ";
                case "ル":
                    return "リ";
                case "グ":
                    return "ギ";
                case "プ":
                    return "ピ";
                case "ヅ":
                    return "ヂ";
                case "ズ":
                    return "ジ";
                case "ブ":
                    return "ビ";
                default:
                    return "";
            }
        }
        public static string findReg1InfinitiveRomaji(string endmarker) {
            switch (endmarker) {
                //Hiragana
                case "u":
                    return "i";
                case "ku":
                    return "ki";
                case "su":
                    return "shi";
                case "tsu":
                    return "chi";
                case "nu":
                    return "ni";
                case "fu":
                    return "hi";
                case "mu":
                    return "mi";
                case "yu":
                    return "i";
                case "ru":
                    return "ri";
                case "gu":
                    return "gi";
                case "pu":
                    return "pi";
                case "dzu":
                    return "dji";
                case "zu":
                    return "ji";
                case "bu":
                    return "bi";
                default:
                   return "";
            }
        }

        public static string fromRomaToHiragana(string roma) {
            switch (roma) {
                case "a":
                    return "あ";
                case "i":
                    return "い";
                case "u":
                    return "う";
                case "e":
                    return "え";
                case "o":
                    return "お";
                case "ka":
                    return "か";
                case "ki":
                    return "き";
                case "ku":
                    return "く";
                case "ke":
                    return "け";
                case "ko":
                    return "こ";
                case "sa":
                    return "さ";
                case "shi":
                    return "し";
                case "su":
                    return "す";
                case "se":
                    return "せ";
                case "so":
                    return "そ";
                case "ta":
                    return "た";
                case "chi":
                    return "ち";
                case "tsu":
                    return "つ";
                case "te":
                    return "て";
                case "to":
                    return "と";
                case "na":
                    return "な";
                case "ni":
                    return "に";
                case "nu":
                    return "ぬ";
                case "ne":
                    return "ね";
                case "no":
                    return "の";
                case "ha":
                    return "は";
                case "hi":
                    return "ひ";
                case "fu": case "hu":
                    return "ふ";
                case "he":
                    return "へ";
                case "ho":
                    return "ほ";
                case "ma":
                    return "ま";
                case "mi":
                    return "み";
                case "mu":
                    return "む";
                case "me":
                    return "め";
                case "mo":
                    return "も";
                case "ra":
                    return "ら";
                case "ri":
                    return "り";
                case "ru":
                    return "る";
                case "re":
                    return "れ";
                case "ro":
                    return "ろ";
                case "ya":
                    return "や";
                case "yu":
                    return "ゆ";
                case "yo":
                    return "よ";
                case "wa":
                    return "わ";
                case "wo":
                    return "を";

                case "ba":
                    return "ば";
                case "bi":
                    return "び";
                case "bu":
                    return "ぶ";
                case "be":
                    return "べ";
                case "bo":
                    return "ぼ";

                case "pa":
                    return "ぱ";
                case "pi":
                    return "ぴ";
                case "pu":
                    return "ぷ";
                case "pe":
                    return "ぺ";
                case "po":
                    return "ぽ";

                case "ga":
                    return "が";
                case "gi":
                    return "ぎ";
                case "gu":
                    return "ぐ";
                case "ge":
                    return "げ";
                case "go":
                    return "ご";
                default:
                    return "";

            }
        }
        public static string fromRomaToKatakana(string roma) {
            switch (roma) {
                case "a":
                    return "ア";
                case "i":
                    return "イ";
                case "u":
                    return "ウ";
                case "e":
                    return "エ";
                case "o":
                    return "オ";
                case "ka":
                    return "カ";
                case "ki":
                    return "キ";
                case "ku":
                    return "ク";
                case "ke":
                    return "ケ";
                case "ko":
                    return "コ";
                case "sa":
                    return "サ";
                case "shi":
                    return "シ";
                case "su":
                    return "ス";
                case "se":
                    return "セ";
                case "so":
                    return "ソ";
                case "ta":
                    return "タ";
                case "chi":
                    return "チ";
                case "tsu":
                    return "ツ";
                case "te":
                    return "テ";
                case "to":
                    return "ト";
                case "na":
                    return "ナ";
                case "ni":
                    return "ニ";
                case "nu":
                    return "ヌ";
                case "ne":
                    return "ネ";
                case "no":
                    return "ノ";
                case "ha":
                    return "ハ";
                case "hi":
                    return "ヒ";
                case "fu": case "hu":
                    return "フ";
                case "he":
                    return "ヘ";
                case "ho":
                    return "ホ";
                case "ma":
                    return "マ";
                case "mi":
                    return "ミ";
                case "mu":
                    return "ム";
                case "me":
                    return "メ";
                case "mo":
                    return "モ";
                case "ra":
                    return "ラ";
                case "ri":
                    return "リ";
                case "ru":
                    return "ル";
                case "re":
                    return "レ";
                case "ro":
                    return "ロ";
                case "ya":
                    return "ヤ";
                case "yu":
                    return "ユ";
                case "yo":
                    return "ヨ";
                case "wa":
                    return "ワ";
                case "wo":
                    return "ヲ";

                case "ba":
                    return "バ";
                case "bi":
                    return "ビ";
                case "bu":
                    return "ブ";
                case "be":
                    return "ベ";
                case "bo":
                    return "ボ";

                case "pa":
                    return "パ";
                case "pi":
                    return "ピ";
                case "pu":
                    return "プ";
                case "pe":
                    return "ぺ";
                case "po":
                    return "ポ";

                case "ga":
                    return "ガ";
                case "gi":
                    return "ギ";
                case "gu":
                    return "グ";
                case "ge":
                    return "ゲ";
                case "go":
                    return "ゴ";
                default:
                    return "";

            }
        }


        private static string getFirstOnMarker(string endMarker) {
            string marker = "";
            switch (endMarker) {
                //Hiragana
                case "し":
                    marker = "sh";
                    break;
                case "ち":
                    marker = "ch";
                    break;
                case "じ":
                    marker = "j";
                    break;
                case "ぢ":
                    marker = "dz";
                    break;
                case "い":
                    marker = "w";
                    break;
                case "う":
                    marker = "";
                    break;
                case "く":
                    marker = "k";
                    break;
                case "す":
                    marker = "s";
                    break;
                case "つ":
                    marker = "ch";
                    break;
                case "ぬ":
                    marker = "n";
                    break;
                case "ふ":
                    marker = "h";
                    break;
                case "む":
                    marker = "m";
                    break;
                case "ゆ":
                    marker = "";
                    break;
                case "る":
                    marker = "r";
                    break;
                case "ぐ":
                    marker = "g";
                    break;
                case "ぷ":
                    marker = "p";
                    break;
                case "づ":
                    marker = "d";
                    break;
                case "ず":
                    marker = "j";
                    break;
                case "ぶ":
                    marker = "b";
                    break;
                //Katakana
                case "シ":
                    marker = "sh";
                    break;
                case "チ":
                    marker = "ch";
                    break;
                case "ジ":
                    marker = "j";
                    break;
                case "ヂ":
                    marker = "dz";
                    break;
                case "イ":
                    marker = "w";
                    break;
                case "ウ":
                    marker = "";
                    break;
                case "ク":
                    marker = "k";
                    break;
                case "ス":
                    marker = "s";
                    break;
                case "ツ":
                    marker = "c";
                    break;
                case "ヌ":
                    marker = "n";
                    break;
                case "フ":
                    marker = "h";
                    break;
                case "ム":
                    marker = "m";
                    break;
                case "ユ":
                    marker = "i";
                    break;
                case "ル":
                    marker = "r";
                    break;
                case "グ":
                    marker = "g";
                    break;
                case "プ":
                    marker = "p";
                    break;
                case "ヅ":
                    marker = "d";
                    break;
                case "ズ":
                    marker = "j";
                    break;
                case "ブ":
                    marker = "b";
                    break;
                default:
                    marker = "";
                    break;
            }
            return marker;
        }

        // ['o', 'く', "hiragana"] -> "こ"
        public static string convertMarkerToForm(char form, string endMarker, string hiraOrKata) {
            //form types -> 'a, i, o, u, e'
            string marker = getFirstOnMarker(endMarker);
            return hiraOrKata == "hiragana" ? fromRomaToHiragana(marker + form) : fromRomaToKatakana(marker + form);
        }

        public static void conjAuxSuru(Verb v) {
            conjIrreg(v);
        }


        public static void conjReg1(Verb v) {

            bool isKatakana = StringTools.isKatakana(v.dictionary);
            string teRoma = te_roma_reg1;
            string teKana = isKatakana ? te_kata_reg1 : te_hira_reg1;
            string taRoma = ta_roma_reg1;
            string taKana = isKatakana ? ta_kata_reg1 : ta_hira_reg1;
            v.teKana = v.stemKana + (isKatakana ? te_kata_reg1 : te_hira_reg1);
            v.teRomaji = v.stemRomaji + te_roma_reg1;
            

            var reg1InfKana = findReg1InfinitiveKana(v.endMarkerKana);
            v.infinitiveKana = v.stemKana + reg1InfKana; //makeInfinitiveR1Kana(v.dictionary);
            var fr1ir = findReg1InfinitiveRomaji(v.endMarkerRomaji); //i.e., su -> shi, ku -> ki
            v.infinitiveRomaji = v.stemRomaji + fr1ir;//.Substring(0, fr1ir.Length-goBackHowMany); //Preserves the penultimate letter, i.e., 'takeru' -> 'taker', 'kau' ->'ka', 'kiku' -> 'kik'

            string firstOnMarker = getFirstOnMarker(v.endMarkerKana);

            if (StringTools.endsInBuMuNu(v.dictionary)) {
                string last = v.dictionary.Last().ToString();
                teRoma = nde_roma;//"nde";
                teKana = isKatakana ? nde_kata : nde_hira;//"んで";
                taRoma = nda_roma;//"nda";
                taKana = isKatakana ? nda_kata : nda_hira;//"んだ";
                v.teKana = v.dictionary.Substring(0, v.dictionary.Length - 1) + teKana;
                v.teRomaji = v.baseRoma.Substring(0, v.baseRoma.Length - 2) + teRoma;
            }
            else if (StringTools.endsInKu(v.dictionary)) {
                string last = v.dictionary.Last().ToString();
                teRoma = ite_roma;//"ite";
                teKana = isKatakana ? ite_kata : ite_hira;//"いて";
                taRoma = ita_roma;//"ita";
                taKana = isKatakana ? ita_kata : ita_hira;//"いた";
                v.teKana = v.dictionary.Substring(0, v.dictionary.Length - 1) + teKana;
                v.teRomaji = v.baseRoma.Substring(0, v.baseRoma.Length - 2) + teRoma;

            }
            else if (StringTools.endsInGu(v.dictionary)) {
                string last = v.dictionary.Last().ToString();
                teRoma = ide_roma;//"ide";
                teKana = isKatakana ? ide_kata : ide_hira;//"いで";
                taRoma = ida_roma;//"ida";
                taKana = isKatakana ? ida_kata : ida_hira;//"いだ";
                v.teKana = v.dictionary.Substring(0, v.dictionary.Length - 1) + teKana;
                v.teRomaji = v.baseRoma.Substring(0, v.baseRoma.Length - 2) + teRoma;
            }
            else {
                v.infinitiveKana = v.stemKana; //Regular 2 thing only
                v.infinitiveRomaji = v.stemRomaji;
                taKana = v.endMarkerKana == "す" ? reg1InfKana + "た" : "った";
                taRoma = v.endMarkerKana == "す" ? findReg1InfinitiveRomaji(v.endMarkerRomaji) +  "ta" : "tta";

                teKana = v.endMarkerKana == "す" ? reg1InfKana + "て" : "って";
                teRoma = v.endMarkerKana == "す" ? findReg1InfinitiveRomaji(v.endMarkerRomaji) + "te" : "tte";

                v.teKana = v.infinitiveKana + teKana;
                v.teRomaji = v.infinitiveRomaji + teRoma;
            }


            #region Romaji assignments


            var aform_romaji = v.stemRomaji + (v.endMarkerKana == "う" ? "wa" : firstOnMarker + "a");
            string iform_romaji;
            switch (v.endMarkerKana) {
                case ("す"): case ("ス"):
                    iform_romaji = v.stemRomaji + "shi";
                    break;
                case("つ"): case("ツ"):
                    iform_romaji = v.stemRomaji + "chi";
                    break;
                case ("づ"): case("ヅ"):
                    iform_romaji = v.stemRomaji + "dzi";
                    break;
                default:
                    iform_romaji = v.stemRomaji + firstOnMarker + "i";
                    break;
            }
            var uform_romaji = v.stemRomaji + firstOnMarker + "u";
            var eform_romaji = v.stemRomaji + firstOnMarker + "e";
            var oform_romaji = v.stemRomaji + firstOnMarker + "o";

            if (StringTools.endsInBuMuNu(v.dictionary)) {
                v.Present_Plain_Positive_Romaji_Chau = v.stemRomaji + "njau";
                v.Present_Polite_Positive_Romaji_Chau = v.stemRomaji + "njimau";
                v.Past_Plain_Positive_Romaji_Chau = v.stemRomaji + "njatta";
                v.Past_Polite_Positive_Romaji_Chau = v.stemRomaji + "njimaimashita";
            }
            else if (v.endMarkerRomaji == "u"){
                v.Present_Plain_Positive_Romaji_Chau = v.stemRomaji + "cchau";
                v.Present_Polite_Positive_Romaji_Chau = v.stemRomaji + "cchimau";
                v.Past_Plain_Positive_Romaji_Chau = v.stemRomaji + "cchatta";
                v.Past_Polite_Positive_Romaji_Chau = v.stemRomaji + "cchimaimashita";
            }
            else if (StringTools.endsInKu(v.dictionary)) {
                v.Present_Plain_Positive_Romaji_Chau = v.stemRomaji + "ichau";
                v.Present_Polite_Positive_Romaji_Chau = v.stemRomaji + "ichimau";
                v.Past_Plain_Positive_Romaji_Chau = v.stemRomaji + "ichatta";
                v.Past_Polite_Positive_Romaji_Chau = v.stemRomaji + "ichimaimashita";
            }
            else if (StringTools.endsInGu(v.dictionary)) {
                v.Present_Plain_Positive_Romaji_Chau = v.stemRomaji + "ijau";
                v.Present_Polite_Positive_Romaji_Chau = v.stemRomaji + "ijimau";
                v.Past_Plain_Positive_Romaji_Chau = v.stemRomaji + "ijatta";
                v.Past_Polite_Positive_Romaji_Chau = v.stemRomaji + "ijimaimashita";
            }
            else if (StringTools.endsInSuTsuDzu(v.dictionary)) {
                v.Present_Plain_Positive_Romaji_Chau = iform_romaji + "chau";
                v.Present_Polite_Positive_Romaji_Chau = iform_romaji + "shimau";
                v.Past_Plain_Positive_Romaji_Chau = iform_romaji + "chatta";
                v.Past_Polite_Positive_Romaji_Chau = iform_romaji + "maimashita";
            }
            else {
                v.Present_Plain_Positive_Romaji_Chau = v.stemRomaji + "chau";
                v.Present_Polite_Positive_Romaji_Chau = v.stemRomaji + "shimau";
                v.Past_Plain_Positive_Romaji_Chau = v.stemRomaji + "chatta";
                v.Past_Polite_Positive_Romaji_Chau = v.stemRomaji + "maimashita";
            }
            //Chau - Present - Romaji
            v.Present_Plain_Negative_Romaji_Chau = "n/a";
            v.Present_Polite_Negative_Romaji_Chau = "n/a";

            //Chau - Past - Romaji
            v.Past_Plain_Negative_Romaji_Chau = "n/a";
            v.Past_Polite_Negative_Romaji_Chau = "n/a";

            //Indicative - Present
            v.Present_Plain_Positive_Romaji_Indicative = uform_romaji;//v.infinitiveRomaji + "u";
            v.Present_Polite_Positive_Romaji_Indicative = iform_romaji + "masu";
            v.Present_Plain_Negative_Romaji_Indicative = aform_romaji + "nai";
            v.Present_Polite_Negative_Romaji_Indicative = iform_romaji + "masen";

            //Indicative - Past 
            v.Past_Plain_Positive_Romaji_Indicative = v.stemRomaji + taRoma;//"tta";
            v.Past_Polite_Positive_Romaji_Indicative = iform_romaji + "mashita";
            v.Past_Plain_Negative_Romaji_Indicative = aform_romaji + "nakatta";
            v.Past_Polite_Negative_Romaji_Indicative = iform_romaji + "masen deshita";

            //Presumptive - Present
            v.Present_Plain_Positive_Romaji_Volitional = oform_romaji + "u";
            v.Present_Plain_Negative_Romaji_Volitional = aform_romaji + "nai darou";
            v.Present_Polite_Positive_Romaji_Volitional = iform_romaji + "mashou";
            v.Present_Polite_Negative_Romaji_Volitional = aform_romaji + "nai deshou";

            //Presumptive - Past
            v.Past_Plain_Positive_Romaji_Volitional = v.stemRomaji + taRoma + "rou";
            v.Past_Plain_Negative_Romaji_Volitional = aform_romaji + "nakatta darou";
            v.Past_Polite_Positive_Romaji_Volitional = v.stemRomaji + taRoma + " deshou";
            v.Past_Polite_Negative_Romaji_Volitional = aform_romaji + "nakatta deshou";

            //Imperative - No Tense 
            v.Plain_Positive_Romaji_Imperative = eform_romaji;
            v.Plain_Negative_Romaji_Imperative = uform_romaji + "na";
            v.Polite_Positive_Romaji_Imperative = v.stemRomaji + teRoma + " kudasai";
            v.Polite_Negative_Romaji_Imperative = aform_romaji + "naide kudasai";

            //Progressive - Present
            v.Present_Plain_Positive_Romaji_Progressive = v.stemRomaji + teRoma + " iru";
            v.Present_Plain_Negative_Romaji_Progressive = v.stemRomaji + teRoma + " inai"; //According to http://www.japaneseverbconjugator.com/VerbDetails.asp?JapaneseVerb=mitomeru&VerbClass=2&EnglishVerb=admit,%20recognize, does not exist
            v.Present_Polite_Positive_Romaji_Pogressive = v.stemRomaji + teRoma + " imasu"; 
            v.Present_Polite_Negative_Romaji_Progressive = v.stemRomaji + teRoma + " imasen";

            //Progressive - Past
            v.Past_Plain_Positive_Romaji_Progressive = v.stemRomaji + teRoma + " ita"; 
            v.Past_Plain_Negative_Romaji_Progressive = v.stemRomaji + teRoma + " inakatta"; //According to above, does not exist 
            v.Past_Polite_Positive_Romaji_Pogressive = v.stemRomaji + teRoma + " imashita"; 
            v.Past_Polite_Negative_Romaji_Progressive = v.stemRomaji + teRoma + " imasen deshita"; 

            //Provisional ~eba - No Tense
            v.Plain_Positive_Romaji_Provisional = eform_romaji + "ba";
            v.Plain_Negative_Romaji_Provisional = aform_romaji + "nakereba";
            v.Polite_Positive_Romaji_Provisional = iform_romaji + "maseba";
            v.Polite_Negative_Romaji_Provisional = iform_romaji + "masen nara";

            //Conditional -tara - No Tense
            v.Plain_Positive_Romaji_Conditional = v.stemRomaji + taRoma + "ra"; 
            v.Plain_Negative_Romaji_Conditional = aform_romaji + "nakattara";
            v.Polite_Positive_Romaji_Conditional = iform_romaji + "mashitara";
            v.Polite_Negative_Romaji_Conditional = iform_romaji + "masen deshitara";

            //Potential - No Tense
            v.Plain_Positive_Romaji_Potential = eform_romaji + "ru";
            v.Plain_Negative_Romaji_Potential = eform_romaji + "nai";
            v.Polite_Positive_Romaji_Potential = eform_romaji + "masu";
            v.Polite_Negative_Romaji_Potential = eform_romaji + "masen";

            //Causative - No Tense
            v.Plain_Positive_Romaji_Causative = aform_romaji + "seru";
            v.Plain_Negative_Romaji_Causative = aform_romaji + "senai";
            v.Polite_Positive_Romaji_Causative = aform_romaji + "semasu";
            v.Polite_Negative_Romaji_Causative = aform_romaji + "semasen";

            //Passive - No Tense
            v.Plain_Positive_Romaji_Passive = aform_romaji + "reru";
            v.Plain_Negative_Romaji_Passive = aform_romaji + "renai";
            v.Polite_Positive_Romaji_Passive = aform_romaji + "remasu";
            v.Polite_Negative_Romaji_Passive = aform_romaji + "remasen";

#endregion

            //var iform_kana = !"すつづスツヅ".Contains(v.endMarkerKana)
            //    ? v.stemKana + v.endMarkerKana
            //    : StringTools.isKatakana(v.endMarkerKana)
            //        ? v.stemKana + convertMarkerToForm('i', v.endMarkerKana, "katakana")
            //        : v.stemKana + convertMarkerToForm('i', v.endMarkerKana, "hiragana");;

            var iform_kana = "";
            if (StringTools.isKatakana(v.endMarkerKana)) {
                if (v.endMarkerKana == "ス"){
                    //iform_romaji = v.stemRomaji + "shi";
                    iform_kana = v.stemKana + "シ";
                }
                else if (v.endMarkerKana == "ツ") {
                    iform_kana = v.stemKana + "チ";
                }
                else if (v.endMarkerKana == "ヅ") {
                    iform_kana = v.stemKana + "ヂ";
                }
                else {
                    iform_kana = v.stemKana + convertMarkerToForm('i', v.endMarkerKana, "katakana");
                }
            }
            else {
             if (v.endMarkerKana == "す"){
                    //iform_romaji = v.stemRomaji + "shi";
                    iform_kana = v.stemKana + "し";
                }
                else if (v.endMarkerKana == "つ") {
                    iform_kana = v.stemKana + "ち";
                }
                else if (v.endMarkerKana == "づ") {
                    iform_kana = v.stemKana + "ぢ";
                }
                else {
                    iform_kana = v.stemKana + convertMarkerToForm('i', v.endMarkerKana, "hiragana");
                }
            }

            var aform_kana = "";
#region setting aform
            if (StringTools.isKatakana(v.endMarkerKana)) {
                if (v.endMarkerKana == "ウ") {
                    aform_kana = v.stemKana + "ワ";
                }
                else {
                    aform_kana = v.stemKana + convertMarkerToForm('a', v.endMarkerKana, "katakana");
                }
            }
            else {
                if (v.endMarkerKana == "う") {
                    aform_kana = v.stemKana + "わ";
                }
                else {
                    aform_kana = v.stemKana + convertMarkerToForm('a', v.endMarkerKana, "hiragana");
                }
            }
#endregion

            var uform_kana = StringTools.isKatakana(v.endMarkerKana) ? v.stemKana + convertMarkerToForm('u', v.endMarkerKana, "katakana") : v.stemKana + convertMarkerToForm('u', v.endMarkerKana, "hiragana");
            var eform_kana = StringTools.isKatakana(v.endMarkerKana) ? v.stemKana + convertMarkerToForm('e', v.endMarkerKana, "katakana") : v.stemKana + convertMarkerToForm('e', v.endMarkerKana, "hiragana");
            var oform_kana = StringTools.isKatakana(v.endMarkerKana) ? v.stemKana + convertMarkerToForm('o', v.endMarkerKana, "katakana") : v.stemKana + convertMarkerToForm('o', v.endMarkerKana, "hiragana");


            #region katakana
            if (StringTools.isKatakana(v.endMarkerKana)) {

                if (StringTools.endsInBuMuNu(v.dictionary)) {
                    v.Present_Plain_Positive_Kana_Chau = v.stemKana + "ンジャウ";
                    v.Present_Polite_Positive_Kana_Chau = v.stemKana + "ンジマウ";
                    v.Past_Plain_Positive_Kana_Chau = v.stemKana + "ンジャッタ";
                    v.Past_Polite_Positive_Kana_Chau = v.stemKana + "ンジマイマシタ";
                }
                else if (v.endMarkerRomaji == "u") {
                    v.Present_Plain_Positive_Kana_Chau = v.stemKana + "ッチャウ";
                    v.Present_Polite_Positive_Kana_Chau = v.stemKana + "ッチマウ";
                    v.Past_Plain_Positive_Kana_Chau = v.stemKana + "チャッタ";
                    v.Past_Polite_Positive_Kana_Chau = v.stemKana + "ッチマイマシタ";
                }
                else if (StringTools.endsInKu(v.dictionary)) {
                    v.Present_Plain_Positive_Kana_Chau = v.stemKana + "イチャウ";
                    v.Present_Polite_Positive_Kana_Chau = v.stemKana + "イチマウ";
                    v.Past_Plain_Positive_Kana_Chau = v.stemKana + "イチャッタ";
                    v.Past_Polite_Positive_Kana_Chau = v.stemKana + "イチマイマシタ";
                }
                else if (StringTools.endsInGu(v.dictionary)) {
                    v.Present_Plain_Positive_Kana_Chau = v.stemKana + "イジャウ";
                    v.Present_Polite_Positive_Kana_Chau = v.stemKana + "イジマウ";
                    v.Past_Plain_Positive_Kana_Chau = v.stemKana + "イジャッタ";
                    v.Past_Polite_Positive_Kana_Chau = v.stemKana + "イジマイマシタ";
                }
                else {
                    v.Present_Plain_Positive_Kana_Chau = v.stemKana + "チャウ";
                    v.Present_Polite_Positive_Kana_Chau = v.stemKana + "シマウ";
                    v.Past_Plain_Positive_Kana_Chau = v.stemKana + "チャッタ";
                    v.Past_Polite_Positive_Kana_Chau = v.stemKana + "マイマシタ";
                }
                //Chau - Present - Romaji
                v.Present_Plain_Negative_Kana_Chau = "n/a";
                v.Present_Polite_Negative_Kana_Chau = "n/a";

                //Chau - Past - Romaji
                v.Past_Plain_Negative_Kana_Chau = "n/a";
                v.Past_Polite_Negative_Kana_Chau = "n/a";




                //Indicative - Present
                v.Present_Plain_Positive_Kana_Indicative = uform_kana;
                v.Present_Polite_Positive_Kana_Indicative = iform_kana + "マス";
                v.Present_Plain_Negative_Kana_Indicative = aform_kana + "ナイ";
                v.Present_Polite_Negative_Kana_Indicative = iform_kana + "マセン";

                //Indicative - Past
                v.Past_Plain_Positive_Kana_Indicative = v.stemKana + taKana + "";
                v.Past_Polite_Positive_Kana_Indicative = iform_kana + "マシタ";
                v.Past_Plain_Negative_Kana_Indicative = aform_kana + "ナカッタ";
                v.Past_Polite_Negative_Kana_Indicative = iform_kana + "マセンデシタ";

                //Presumptive - Present
                v.Present_Plain_Positive_Kana_Volitional = oform_kana + "ウ";
                v.Present_Plain_Negative_Kana_Volitional = aform_kana + "ナイダロウ";
                v.Present_Polite_Positive_Kana_Volitional = iform_kana + "マショウ";
                v.Present_Polite_Negative_Kana_Volitional = aform_kana + "ナイデショウ";

                //Presumptive - Past
                v.Past_Plain_Positive_Kana_Volitional = v.stemKana + taKana + "ロウ";
                v.Past_Plain_Negative_Kana_Volitional = aform_kana + "ナカッタダロウ";
                v.Past_Polite_Positive_Kana_Volitional = v.stemKana + taKana + "デショウ";
                v.Past_Polite_Negative_Kana_Volitional = aform_kana + "ナカッタデショウ";

                //Imperative - No Tense
                v.Plain_Positive_Kana_Imperative = eform_kana;
                v.Plain_Negative_Kana_Imperative = uform_kana + "ナ";
                v.Polite_Positive_Kana_Imperative = eform_kana + teKana + "クダサイ";
                v.Polite_Negative_Kana_Imperative = aform_kana + "ナイデクダサイ";

                //Progressive - Present
                v.Present_Plain_Positive_Kana_Progressive = v.stemKana + teKana + "イル";
                v.Present_Plain_Negative_Kana_Progressive = v.stemKana + teKana + "ナイ";
                v.Present_Polite_Positive_Kana_Pogressive = v.stemKana + teKana + "イマス";
                v.Present_Polite_Negative_Kana_Progressive = v.stemKana + teKana + "イマセン";

                //Progressive - Past
                v.Past_Plain_Positive_Kana_Progressive = v.stemKana + teKana + "イタ";
                v.Past_Plain_Negative_Kana_Progressive = v.stemKana + teKana + "ナカッタ";
                v.Past_Polite_Positive_Kana_Pogressive = v.stemKana + teKana + "イマシタ";
                v.Past_Polite_Negative_Kana_Progressive = v.stemKana + teKana + "イマセンデシタ";

                //Provisional ~eba - No Tense
                v.Plain_Positive_Kana_Provisional = eform_kana + "バ";
                v.Plain_Negative_Kana_Provisional = aform_kana + "ナケレバ";
                v.Polite_Positive_Kana_Provisional = iform_kana + "マセば";
                v.Polite_Negative_Kana_Provisional = iform_kana + "マセンナラ";

                //Conditional -tara - No Tense
                v.Plain_Positive_Kana_Conditional = v.stemKana + taKana + "ラ";
                v.Plain_Negative_Kana_Conditional = aform_kana + "ナカッタラ";
                v.Polite_Positive_Kana_Conditional = iform_kana + "マシタラ";
                v.Polite_Negative_Kana_Conditional = iform_kana + "マセンデシタラ";

                //Potential - No Tense
                v.Plain_Positive_Kana_Potential = eform_kana + "ル";
                v.Plain_Negative_Kana_Potential = eform_kana + "ナイ";
                v.Polite_Positive_Kana_Potential = eform_kana + "マス";
                v.Polite_Negative_Kana_Potential = eform_kana + "マセン";

                //Causative - No Tense
                v.Plain_Positive_Kana_Causative = aform_kana + "セル";
                v.Plain_Negative_Kana_Causative = aform_kana + "セナイ";
                v.Polite_Positive_Kana_Causative = aform_kana + "セマス";
                v.Polite_Negative_Kana_Causative = aform_kana + "セマセン";

                //Passive - No Tense
                v.Plain_Positive_Kana_Passive = aform_kana + "レル";
                v.Plain_Negative_Kana_Passive = aform_kana + "レナイ";
                v.Polite_Positive_Kana_Passive = aform_kana + "レマス";
                v.Polite_Negative_Kana_Passive = aform_kana + "レマセン";

            }
            #endregion
            else {

                if (StringTools.endsInBuMuNu(v.dictionary)) {
                    v.Present_Plain_Positive_Kana_Chau = v.stemKana + "んじゃう";
                    v.Present_Polite_Positive_Kana_Chau = v.stemKana + "んじまう";
                    v.Past_Plain_Positive_Kana_Chau = v.stemKana + "んじゃった";
                    v.Past_Polite_Positive_Kana_Chau = v.stemKana + "んじまいました";
                }
                else if (v.endMarkerRomaji == "u") {
                    v.Present_Plain_Positive_Kana_Chau = v.stemKana + "っちゃう";
                    v.Present_Polite_Positive_Kana_Chau = v.stemKana + "っちまう";
                    v.Past_Plain_Positive_Kana_Chau = v.stemKana + "ちゃった";
                    v.Past_Polite_Positive_Kana_Chau = v.stemKana + "っちまいました";
                }
                else if (StringTools.endsInKu(v.dictionary)) {
                    v.Present_Plain_Positive_Kana_Chau = v.stemKana + "いちゃう";
                    v.Present_Polite_Positive_Kana_Chau = v.stemKana + "いちまう";
                    v.Past_Plain_Positive_Kana_Chau = v.stemKana + "いちゃった";
                    v.Past_Polite_Positive_Kana_Chau = v.stemKana + "いちまいました";
                }
                else if (StringTools.endsInGu(v.dictionary)) {
                    v.Present_Plain_Positive_Kana_Chau = v.stemKana + "いじゃう";
                    v.Present_Polite_Positive_Kana_Chau = v.stemKana + "いじまう";
                    v.Past_Plain_Positive_Kana_Chau = v.stemKana + "いじゃった";
                    v.Past_Polite_Positive_Kana_Chau = v.stemKana + "いじまいました";
                }
                else {
                    v.Present_Plain_Positive_Kana_Chau = v.stemKana + "ちゃう";
                    v.Present_Polite_Positive_Kana_Chau = v.stemKana + "しまう";
                    v.Past_Plain_Positive_Kana_Chau = v.stemKana + "ちゃった";
                    v.Past_Polite_Positive_Kana_Chau = v.stemKana + "まいました";
                }
                //Chau - Present - Romaji
                v.Present_Plain_Negative_Kana_Chau = "n/a";
                v.Present_Polite_Negative_Kana_Chau = "n/a";

                //Chau - Past - Romaji
                v.Past_Plain_Negative_Kana_Chau = "n/a";
                v.Past_Polite_Negative_Kana_Chau = "n/a";

                //Indicative - Present
                v.Present_Plain_Positive_Kana_Indicative = uform_kana;
                v.Present_Polite_Positive_Kana_Indicative = iform_kana + "ます";
                v.Present_Plain_Negative_Kana_Indicative = aform_kana + "ない";
                v.Present_Polite_Negative_Kana_Indicative = iform_kana + "ません";

                //Indicative - Past
                v.Past_Plain_Positive_Kana_Indicative = v.stemKana + taKana + "";
                v.Past_Polite_Positive_Kana_Indicative = iform_kana + "ました";
                v.Past_Plain_Negative_Kana_Indicative = aform_kana + "なかった";
                v.Past_Polite_Negative_Kana_Indicative = iform_kana + "ませんでした";

                //Presumptive - Present
                v.Present_Plain_Positive_Kana_Volitional = oform_kana + "う";
                v.Present_Plain_Negative_Kana_Volitional = aform_kana + "ないだろう";
                v.Present_Polite_Positive_Kana_Volitional = iform_kana + "ましょう";
                v.Present_Polite_Negative_Kana_Volitional = aform_kana + "ないでしょう";

                //Presumptive - Past
                v.Past_Plain_Positive_Kana_Volitional = v.stemKana + taKana + "ろう";
                v.Past_Plain_Negative_Kana_Volitional = aform_kana + "なかっただろう";
                v.Past_Polite_Positive_Kana_Volitional = v.stemKana + taKana + "でしょう";
                v.Past_Polite_Negative_Kana_Volitional = aform_kana + "なかったでしょう";

                //Imperative - No Tense
                v.Plain_Positive_Kana_Imperative = eform_kana;
                v.Plain_Negative_Kana_Imperative = uform_kana + "な";
                v.Polite_Positive_Kana_Imperative = v.stemKana + teKana + "ください";
                v.Polite_Negative_Kana_Imperative = aform_kana + "ないでください";

                //Progressive - Present
                v.Present_Plain_Positive_Kana_Progressive = v.stemKana + teKana + "いる";
                v.Present_Plain_Negative_Kana_Progressive = v.stemKana + teKana + "いない";
                v.Present_Polite_Positive_Kana_Pogressive = v.stemKana + teKana + "います";
                v.Present_Polite_Negative_Kana_Progressive = v.stemKana + teKana + "いません";

                //Progressive - Past
                v.Past_Plain_Positive_Kana_Progressive = v.stemKana + teKana + "いた";
                v.Past_Plain_Negative_Kana_Progressive = v.stemKana + teKana + "いなかった";
                v.Past_Polite_Positive_Kana_Pogressive = v.stemKana + teKana + "いました";
                v.Past_Polite_Negative_Kana_Progressive = v.stemKana + teKana + "いませんでした";

                //Provisional ~eba - No Tense
                v.Plain_Positive_Kana_Provisional = eform_kana + "ば";
                v.Plain_Negative_Kana_Provisional = aform_kana + "なければ";
                v.Polite_Positive_Kana_Provisional = iform_kana + "ませば";
                v.Polite_Negative_Kana_Provisional = iform_kana + "ませんなら";

                //Conditional -tara - No Tense
                v.Plain_Positive_Kana_Conditional = v.stemKana + taKana + "ら";
                v.Plain_Negative_Kana_Conditional = aform_kana + "なかったら";
                v.Polite_Positive_Kana_Conditional = iform_kana + "ましたら";
                v.Polite_Negative_Kana_Conditional = iform_kana + "ませんでしたら";

                //Potential - No Tense
                v.Plain_Positive_Kana_Potential = eform_kana + "る";
                v.Plain_Negative_Kana_Potential = eform_kana + "ない";
                v.Polite_Positive_Kana_Potential = eform_kana + "ます";
                v.Polite_Negative_Kana_Potential = eform_kana + "ません";

                //Causative - No Tense
                v.Plain_Positive_Kana_Causative = aform_kana + "せる";
                v.Plain_Negative_Kana_Causative = aform_kana + "せない";
                v.Polite_Positive_Kana_Causative = aform_kana + "せます";
                v.Polite_Negative_Kana_Causative = aform_kana + "せません";

                //Passive - No Tense
                v.Plain_Positive_Kana_Passive = aform_kana + "れる";
                v.Plain_Negative_Kana_Passive = aform_kana + "れない";
                v.Polite_Positive_Kana_Passive = aform_kana + "れます";
                v.Polite_Negative_Kana_Passive = aform_kana + "れません";

            }
        }

        private const string te_roma = "te";
        private const string te_hira = "て";
        private const string ta_hira = "た";
        private const string ta_roma = "ta";

        private const string te_kata = "テ";
        private const string ta_kata = "タ";

        private const string te_roma_reg1 = "tte";
        private const string te_hira_reg1 = "って";
        private const string ta_hira_reg1 = "った";
        private const string ta_roma_reg1 = "tta";

        private const string te_kata_reg1 = "ッテ";
        private const string ta_kata_reg1 = "ッタ";

        private const string nde_roma = "nde";
        private const string nda_roma = "nda";
        private const string ite_roma = "ite";
        private const string ita_roma = "ita";
        private const string ide_roma = "ide";
        private const string ida_roma = "ida";

        private const string nde_hira = "んで";
        private const string nda_hira = "んだ";
        private const string ite_hira = "いて";
        private const string ita_hira = "いた";
        private const string ide_hira = "いで";
        private const string ida_hira = "いだ";

        private const string nde_kata = "ンデ";
        private const string nda_kata = "ンダ";
        private const string ite_kata = "イテ";
        private const string ita_kata = "イタ";
        private const string ide_kata = "イデ";
        private const string ida_kata = "イダ";

        public static void conjReg2(Verb v) {//todo need to handle special case for 行く - maybe handle at Verb creation?

            string teRoma = "te";
            string teKana = StringTools.isKatakana(v.dictionary) ? "テ" : "て";
            string taRoma = "ta";
            string taKana = StringTools.isKatakana(v.dictionary) ? "タ" : "た";

            v.infinitiveKana = v.stemKana;
            v.infinitiveRomaji = v.stemRomaji;

            //Chau - Present - Romaji
            v.Present_Plain_Positive_Romaji_Chau = v.stemRomaji + "chau";
            v.Present_Polite_Positive_Romaji_Chau = v.stemRomaji + "chaimasu";
            v.Present_Plain_Negative_Romaji_Chau = "n/a";
            v.Present_Polite_Negative_Romaji_Chau = "n/a";

            //Chau - Past - Romaji
            v.Past_Plain_Positive_Romaji_Chau = v.stemRomaji + "chatta";
            v.Past_Polite_Positive_Romaji_Chau = v.stemRomaji + "chaimashita";
            v.Past_Plain_Negative_Romaji_Chau = "n/a";
            v.Past_Polite_Negative_Romaji_Chau = "n/a";


            //Indicative - Present
            v.Present_Plain_Positive_Romaji_Indicative = v.infinitiveRomaji + "ru";
            v.Present_Polite_Positive_Romaji_Indicative = v.infinitiveRomaji + "masu";
            v.Present_Plain_Negative_Romaji_Indicative = v.infinitiveRomaji + "nai";
            v.Present_Polite_Negative_Romaji_Indicative = v.infinitiveRomaji + "masen";

            //Indicative - Past
            v.Past_Plain_Positive_Romaji_Indicative = v.infinitiveRomaji + taRoma;
            v.Past_Polite_Positive_Romaji_Indicative = v.infinitiveRomaji + "mashita";
            v.Past_Plain_Negative_Romaji_Indicative = v.infinitiveRomaji + "nakatta";
            v.Past_Polite_Negative_Romaji_Indicative = v.infinitiveRomaji + "masen deshita";

            //Presumptive - Present
            v.Present_Plain_Positive_Romaji_Volitional = v.infinitiveRomaji + "you";
            v.Present_Plain_Negative_Romaji_Volitional = v.infinitiveRomaji + "nai darou";
            v.Present_Polite_Positive_Romaji_Volitional = v.infinitiveRomaji + "mashou";
            v.Present_Polite_Negative_Romaji_Volitional = v.infinitiveRomaji + "nai deshou";

            //Presumptive - Past
            v.Past_Plain_Positive_Romaji_Volitional = v.infinitiveRomaji + taRoma +"rou";
            v.Past_Plain_Negative_Romaji_Volitional = v.infinitiveRomaji + "nakatta darou";
            v.Past_Polite_Positive_Romaji_Volitional = v.infinitiveRomaji + taRoma + " deshou";
            v.Past_Polite_Negative_Romaji_Volitional = v.infinitiveRomaji + "nakatta deshou";

            //Imperative - No Tense
            v.Plain_Positive_Romaji_Imperative = v.infinitiveRomaji + "ro";
            v.Plain_Negative_Romaji_Imperative = v.infinitiveRomaji + "runa";
            v.Polite_Positive_Romaji_Imperative = v.infinitiveRomaji + teRoma + " kudasai";
            v.Polite_Negative_Romaji_Imperative = v.infinitiveRomaji + "naide kudasai";

            //Progressive - Present
            v.Present_Plain_Positive_Romaji_Progressive = v.infinitiveRomaji + teRoma + " iru";
            v.Present_Plain_Negative_Romaji_Progressive = v.infinitiveRomaji + teRoma + " inai"; //According to http://www.japaneseverbconjugator.com/VerbDetails.asp?JapaneseVerb=mitomeru&VerbClass=2&EnglishVerb=admit,%20recognize, does not exist
            v.Present_Polite_Positive_Romaji_Pogressive = v.infinitiveRomaji + teRoma + " imasu";
            v.Present_Polite_Negative_Romaji_Progressive = v.infinitiveRomaji + teRoma + " imasen";

            //Progressive - Past
            v.Past_Plain_Positive_Romaji_Progressive = v.infinitiveRomaji + teRoma + " ita";
            v.Past_Plain_Negative_Romaji_Progressive = v.infinitiveRomaji + teRoma + " inakatta"; //According to above, does not exist
            v.Past_Polite_Positive_Romaji_Pogressive = v.infinitiveRomaji + teRoma + " imashita";
            v.Past_Polite_Negative_Romaji_Progressive = v.infinitiveRomaji + teRoma + " imasen deshita";

            //Provisional ~eba - No Tense
            v.Plain_Positive_Romaji_Provisional = v.infinitiveRomaji + "reba";
            v.Plain_Negative_Romaji_Provisional = v.infinitiveRomaji + "nakereba";
            v.Polite_Positive_Romaji_Provisional = v.infinitiveRomaji + "maseba";
            v.Polite_Negative_Romaji_Provisional = v.infinitiveRomaji + "masen nara";

            //Conditional -tara - No Tense
            v.Plain_Positive_Romaji_Conditional = v.infinitiveRomaji + taRoma + "ra";
            v.Plain_Negative_Romaji_Conditional = v.infinitiveRomaji + "nakattara";
            v.Polite_Positive_Romaji_Conditional = v.infinitiveRomaji + "mashitara";
            v.Polite_Negative_Romaji_Conditional = v.infinitiveRomaji + "masen deshitara";

            //Potential - No Tense
            v.Plain_Positive_Romaji_Potential = v.infinitiveRomaji + "rareru";
            v.Plain_Negative_Romaji_Potential = v.infinitiveRomaji + "rarenai";
            v.Polite_Positive_Romaji_Potential = v.infinitiveRomaji + "raremasu";
            v.Polite_Negative_Romaji_Potential = v.infinitiveRomaji + "raremasen";

            //Causative - No Tense
            v.Plain_Positive_Romaji_Causative = v.infinitiveRomaji + "saseru";
            v.Plain_Negative_Romaji_Causative = v.infinitiveRomaji + "sasenai";
            v.Polite_Positive_Romaji_Causative = v.infinitiveRomaji + "sasemasu";
            v.Polite_Negative_Romaji_Causative = v.infinitiveRomaji + "sasemasen";

            //Passive - No Tense
            v.Plain_Positive_Romaji_Passive = v.infinitiveRomaji + "rareru";
            v.Plain_Negative_Romaji_Passive = v.infinitiveRomaji + "rarenai";
            v.Polite_Positive_Romaji_Passive = v.infinitiveRomaji + "raremasu";
            v.Polite_Negative_Romaji_Passive = v.infinitiveRomaji + "raremasen";

            if (v.endMarkerKana == "ル") {

                //Chau - Present - Kana
                v.Present_Plain_Positive_Kana_Chau = v.stemKana + "チヤウ";
                v.Present_Polite_Positive_Kana_Chau = v.stemKana + "チャイマス";
                v.Present_Plain_Negative_Kana_Chau = "n/a";
                v.Present_Polite_Negative_Kana_Chau = "n/a";

                //Chau - Past - Kana
                v.Past_Plain_Positive_Kana_Chau = v.stemKana + "チャッタ";
                v.Past_Polite_Positive_Kana_Chau = v.stemKana + "チャイマシタ";
                v.Past_Plain_Negative_Kana_Chau = "n/a";
                v.Past_Polite_Negative_Kana_Chau = "n/a";

                //Indicative - Present
                v.Present_Plain_Positive_Kana_Indicative = v.infinitiveKana + "ル";
                v.Present_Polite_Positive_Kana_Indicative = v.infinitiveKana + "マス";
                v.Present_Plain_Negative_Kana_Indicative = v.infinitiveKana + "ナイ";
                v.Present_Polite_Negative_Kana_Indicative = v.infinitiveKana + "マセン";

                //Indicative - Past
                v.Past_Plain_Positive_Kana_Indicative = v.infinitiveKana + taKana + "";
                v.Past_Polite_Positive_Kana_Indicative = v.infinitiveKana + "マシタ";
                v.Past_Plain_Negative_Kana_Indicative = v.infinitiveKana + "ナカッタ";
                v.Past_Polite_Negative_Kana_Indicative = v.infinitiveKana + "マセンデシタ";

                //Presumptive - Present
                v.Present_Plain_Positive_Kana_Volitional = v.infinitiveKana + "ヨウ";
                v.Present_Plain_Negative_Kana_Volitional = v.infinitiveKana + "ナイダロウ";
                v.Present_Polite_Positive_Kana_Volitional = v.infinitiveKana + "マショウ";
                v.Present_Polite_Negative_Kana_Volitional = v.infinitiveKana + "ナイデショウ";

                //Presumptive - Past
                v.Past_Plain_Positive_Kana_Volitional = v.infinitiveKana + "ダロウ";
                v.Past_Plain_Negative_Kana_Volitional = v.infinitiveKana + "ナカッタダロウ";
                v.Past_Polite_Positive_Kana_Volitional = v.infinitiveKana + taKana + "デショウ";
                v.Past_Polite_Negative_Kana_Volitional = v.infinitiveKana + "ナカッタデショウ";

                //Imperative - No Tense
                v.Plain_Positive_Kana_Imperative = v.infinitiveKana + "ロ";
                v.Plain_Negative_Kana_Imperative = v.infinitiveKana + "ルナ";
                v.Polite_Positive_Kana_Imperative = v.infinitiveKana + teKana + "クダサイ";
                v.Polite_Negative_Kana_Imperative = v.infinitiveKana + "ナイデクダサイ";

                //Progressive - Present
                v.Present_Plain_Positive_Kana_Progressive = v.infinitiveKana + teKana + "イル";
                v.Present_Plain_Negative_Kana_Progressive = v.infinitiveKana + teKana + "ナイ";
                v.Present_Polite_Positive_Kana_Pogressive = v.infinitiveKana + teKana + "イマス";
                v.Present_Polite_Negative_Kana_Progressive = v.infinitiveKana + teKana + "イマセン";

                //Progressive - Past
                v.Past_Plain_Positive_Kana_Progressive = v.infinitiveKana + teKana + "イタ";
                v.Past_Plain_Negative_Kana_Progressive = v.infinitiveKana + teKana + "ナカッタ";
                v.Past_Polite_Positive_Kana_Pogressive = v.infinitiveKana + teKana + "イマシタ";
                v.Past_Polite_Negative_Kana_Progressive = v.infinitiveKana + teKana + "イマセンデシタ";


                //Provisional ~eba - No Tense
                v.Plain_Positive_Kana_Provisional = v.infinitiveKana + "レバ";
                v.Plain_Negative_Kana_Provisional = v.infinitiveKana + "ナケレバ";
                v.Polite_Positive_Kana_Provisional = v.infinitiveKana + "マセば";
                v.Polite_Negative_Kana_Provisional = v.infinitiveKana + "マセンナラ";

                //Conditional -tara - No Tense
                v.Plain_Positive_Kana_Conditional = v.infinitiveKana + taKana + "ラ";
                v.Plain_Negative_Kana_Conditional = v.infinitiveKana + "ナカッタラ";
                v.Polite_Positive_Kana_Conditional = v.infinitiveKana + "マシタラ";
                v.Polite_Negative_Kana_Conditional = v.infinitiveKana + "マセンデシタラ";

                //Potential - No Tense
                v.Plain_Positive_Kana_Potential = v.infinitiveKana + "ラレル";
                v.Plain_Negative_Kana_Potential = v.infinitiveKana + "ラレナイ";
                v.Polite_Positive_Kana_Potential = v.infinitiveKana + "ラレマス";
                v.Polite_Negative_Kana_Potential = v.infinitiveKana + "ラレマセン";

                //Causative - No Tense
                v.Plain_Positive_Kana_Causative = v.infinitiveKana + "サセル";
                v.Plain_Negative_Kana_Causative = v.infinitiveKana + "サセナイ";
                v.Polite_Positive_Kana_Causative = v.infinitiveKana + "サセマス";
                v.Polite_Negative_Kana_Causative = v.infinitiveKana + "サセマセン";

                //Passive - No Tense
                v.Plain_Positive_Kana_Passive = v.infinitiveKana + "ラレル";
                v.Plain_Negative_Kana_Passive = v.infinitiveKana + "ラレナイ";
                v.Polite_Positive_Kana_Passive = v.infinitiveKana + "ラレマス";
                v.Polite_Negative_Kana_Passive = v.infinitiveKana + "ラレマセン";

            }
            else if (v.endMarkerKana == "る") {

                //Chau - Present - Kana
                v.Present_Plain_Positive_Kana_Chau = v.stemKana + "ちゃう";
                v.Present_Polite_Positive_Kana_Chau = v.stemKana + "ちゃいます";
                v.Present_Plain_Negative_Kana_Chau = "n/a";
                v.Present_Polite_Negative_Kana_Chau = "n/a";

                //Chau - Past - Kana
                v.Past_Plain_Positive_Kana_Chau = v.stemKana + "ちゃった";
                v.Past_Polite_Positive_Kana_Chau = v.stemKana + "ちゃいました";
                v.Past_Plain_Negative_Kana_Chau = "n/a";
                v.Past_Polite_Negative_Kana_Chau = "n/a";

                //Indicative - Present
                v.Present_Plain_Positive_Kana_Indicative = v.infinitiveKana + "る";
                v.Present_Polite_Positive_Kana_Indicative = v.infinitiveKana + "ます";
                v.Present_Plain_Negative_Kana_Indicative = v.infinitiveKana + "ない";
                v.Present_Polite_Negative_Kana_Indicative = v.infinitiveKana + "ません";

                //Indicative - Past
                v.Past_Plain_Positive_Kana_Indicative = v.infinitiveKana + taKana + "";
                v.Past_Polite_Positive_Kana_Indicative = v.infinitiveKana + "ました";
                v.Past_Plain_Negative_Kana_Indicative = v.infinitiveKana + "なかった";
                v.Past_Polite_Negative_Kana_Indicative = v.infinitiveKana + "ませんでした";

                //Presumptive - Present
                v.Present_Plain_Positive_Kana_Volitional = v.infinitiveKana + "よう";
                v.Present_Plain_Negative_Kana_Volitional = v.infinitiveKana + "ないだろう";
                v.Present_Polite_Positive_Kana_Volitional = v.infinitiveKana + "ましょう";
                v.Present_Polite_Negative_Kana_Volitional = v.infinitiveKana + "ないでしょう";

                //Presumptive - Past
                v.Past_Plain_Positive_Kana_Volitional = v.infinitiveKana + taKana + "ろう";
                v.Past_Plain_Negative_Kana_Volitional = v.infinitiveKana + "なかっただろう";
                v.Past_Polite_Positive_Kana_Volitional = v.infinitiveKana + taKana + "でしょう";
                v.Past_Polite_Negative_Kana_Volitional = v.infinitiveKana + "なかったでしょう";
                
                //Imperative - No Tense
                v.Plain_Positive_Kana_Imperative = v.infinitiveKana + "ろ";
                v.Plain_Negative_Kana_Imperative = v.infinitiveKana + "るな";
                v.Polite_Positive_Kana_Imperative = v.infinitiveKana + teKana + "ください";
                v.Polite_Negative_Kana_Imperative = v.infinitiveKana + "ないでください";

                //Progressive - Present
                v.Present_Plain_Positive_Kana_Progressive = v.infinitiveKana + teKana + "いる";
                v.Present_Plain_Negative_Kana_Progressive = v.infinitiveKana + teKana + "いない";
                v.Present_Polite_Positive_Kana_Pogressive = v.infinitiveKana + teKana + "います";
                v.Present_Polite_Negative_Kana_Progressive = v.infinitiveKana + teKana + "いません";

                //Progressive - Past
                v.Past_Plain_Positive_Kana_Progressive = v.infinitiveKana + teKana + "いた";
                v.Past_Plain_Negative_Kana_Progressive = v.infinitiveKana + teKana + "いなかった";
                v.Past_Polite_Positive_Kana_Pogressive = v.infinitiveKana + teKana + "いました";
                v.Past_Polite_Negative_Kana_Progressive = v.infinitiveKana + teKana + "いませんでした";

                //Provisional ~eba - No Tense
                v.Plain_Positive_Kana_Provisional = v.infinitiveKana + "れば";
                v.Plain_Negative_Kana_Provisional = v.infinitiveKana + "なければ";
                v.Polite_Positive_Kana_Provisional = v.infinitiveKana + "ませば";
                v.Polite_Negative_Kana_Provisional = v.infinitiveKana + "ませんなら";

                //Conditional -tara - No Tense
                v.Plain_Positive_Kana_Conditional = v.infinitiveKana + taKana + "ら";
                v.Plain_Negative_Kana_Conditional = v.infinitiveKana + "なかったら";
                v.Polite_Positive_Kana_Conditional = v.infinitiveKana + "ましたら";
                v.Polite_Negative_Kana_Conditional = v.infinitiveKana + "ませんでしたら";

                //Potential - No Tense
                v.Plain_Positive_Kana_Potential = v.infinitiveKana + "られる";
                v.Plain_Negative_Kana_Potential = v.infinitiveKana + "られない";
                v.Polite_Positive_Kana_Potential = v.infinitiveKana + "られます";
                v.Polite_Negative_Kana_Potential = v.infinitiveKana + "られません";

                //Causative - No Tense
                v.Plain_Positive_Kana_Causative = v.infinitiveKana + "させる";
                v.Plain_Negative_Kana_Causative = v.infinitiveKana + "させない";
                v.Polite_Positive_Kana_Causative = v.infinitiveKana + "させます";
                v.Polite_Negative_Kana_Causative = v.infinitiveKana + "させません";

                //Passive - No Tense
                v.Plain_Positive_Kana_Passive = v.infinitiveKana + "られる";
                v.Plain_Negative_Kana_Passive = v.infinitiveKana + "られない";
                v.Polite_Positive_Kana_Passive = v.infinitiveKana + "られます";
                v.Polite_Negative_Kana_Passive = v.infinitiveKana + "られません";

            }
        }


        public static void conjIrreg(Verb v) {

            //v.infinitiveKana = v.stemKana; //Regular 2 thing only
            //v.infinitiveRomaji = v.stemRomaji;
            //v.teKana = v.infinitiveKana + "て";
            //v.teRomaji = v.infinitiveRomaji + "te";

            if (v.dictionary.EndsWith("する")) {
                v.infinitiveKana = v.dictionary.Substring(0, v.dictionary.Length - 2); //なななする　→　なななす
                v.infinitiveRomaji = v.baseRoma.Substring(0, v.baseRoma.Length - 4); //nananasuru -> nananasu
                v.teKana = v.infinitiveKana + "して";
                v.teRomaji = v.infinitiveRomaji + "shite";

                //Chau - Present - Romaji
                v.Present_Plain_Positive_Romaji_Chau = v.infinitiveRomaji + "shichau";
                v.Present_Polite_Positive_Romaji_Chau = v.infinitiveRomaji + "shichaimasu";
                v.Present_Plain_Negative_Romaji_Chau = "n/a";
                v.Present_Polite_Negative_Romaji_Chau = "n/a";

                //Chau - Past - Romaji
                v.Past_Plain_Positive_Romaji_Chau = v.infinitiveKana + "shichatta";
                v.Past_Polite_Positive_Romaji_Chau = v.infinitiveKana + "shichaimashita";
                v.Past_Plain_Negative_Romaji_Chau = "n/a";
                v.Past_Polite_Negative_Romaji_Chau = "n/a";

                //Indicative - Present
                v.Present_Plain_Positive_Romaji_Indicative = v.infinitiveRomaji + "suru";
                v.Present_Polite_Positive_Romaji_Indicative = v.infinitiveRomaji + "shimasu";
                v.Present_Plain_Negative_Romaji_Indicative = v.infinitiveRomaji + "shinai";
                v.Present_Polite_Negative_Romaji_Indicative = v.infinitiveRomaji + "shimasen";

                //Indicative - Past 
                v.Past_Plain_Positive_Romaji_Indicative = v.infinitiveRomaji + "shita";
                v.Past_Polite_Positive_Romaji_Indicative = v.infinitiveRomaji + "shimashita";
                v.Past_Plain_Negative_Romaji_Indicative = v.infinitiveRomaji + "shinakatta";
                v.Past_Polite_Negative_Romaji_Indicative = v.infinitiveRomaji + "shimasen deshita";

                //Presumptive - Present
                v.Present_Plain_Positive_Romaji_Volitional = v.infinitiveRomaji + "shiyou";
                v.Present_Plain_Negative_Romaji_Volitional = v.infinitiveRomaji + "shinai darou";
                v.Present_Polite_Positive_Romaji_Volitional = v.infinitiveRomaji + "shimashou";
                v.Present_Polite_Negative_Romaji_Volitional = v.infinitiveRomaji + "shinai deshou";

                //Presumptive - Past
                v.Past_Plain_Positive_Romaji_Volitional = v.infinitiveRomaji + "shitarou";
                v.Past_Plain_Negative_Romaji_Volitional = v.infinitiveRomaji + "shinakatta darou";
                v.Past_Polite_Positive_Romaji_Volitional = v.infinitiveRomaji + "shimashitarou";
                v.Past_Polite_Negative_Romaji_Volitional = v.infinitiveRomaji + "shinakatta deshou";

                //Imperative - No Tense 
                v.Plain_Positive_Romaji_Imperative = v.infinitiveRomaji + "shiro";
                v.Plain_Negative_Romaji_Imperative = v.infinitiveRomaji + "suruna";
                v.Polite_Positive_Romaji_Imperative = v.infinitiveRomaji + "shite kudasai";
                v.Polite_Negative_Romaji_Imperative = v.infinitiveRomaji + "shinaide kudasai";

                //Progressive - Present
                v.Present_Plain_Positive_Romaji_Progressive = v.infinitiveRomaji + "shite iru";
                v.Present_Plain_Negative_Romaji_Progressive = v.infinitiveRomaji + "shite inai"; //According to http://www.japaneseverbconjugator.com/VerbDetails.asp?JapaneseVerb=mitomeru&VerbClass=2&EnglishVerb=admit,%20recognize, does not exist
                v.Present_Polite_Positive_Romaji_Pogressive = v.infinitiveRomaji + "shite imasu";
                v.Present_Polite_Negative_Romaji_Progressive = v.infinitiveRomaji + "shite imasen";

                //Progressive - Past
                v.Past_Plain_Positive_Romaji_Progressive = v.infinitiveRomaji + "shite ita";
                v.Past_Plain_Negative_Romaji_Progressive = v.infinitiveRomaji + "shite inakatta"; //According to above, does not exist 
                v.Past_Polite_Positive_Romaji_Pogressive = v.infinitiveRomaji + "shite imashita";
                v.Past_Polite_Negative_Romaji_Progressive = v.infinitiveRomaji + "shite imasen deshita";

                //Provisional ~eba - No Tense
                v.Plain_Positive_Romaji_Provisional = v.infinitiveRomaji + "sureba";
                v.Plain_Negative_Romaji_Provisional = v.infinitiveRomaji + "shinakereba";
                v.Polite_Positive_Romaji_Provisional = v.infinitiveRomaji + "shimaseba";
                v.Polite_Negative_Romaji_Provisional = v.infinitiveRomaji + "shimasen nara";

                //Conditional -tara - No Tense
                v.Plain_Positive_Romaji_Conditional = v.infinitiveRomaji + "shitara";
                v.Plain_Negative_Romaji_Conditional = v.infinitiveRomaji + "shinakattara";
                v.Polite_Positive_Romaji_Conditional = v.infinitiveRomaji + "shimashitara";
                v.Polite_Negative_Romaji_Conditional = v.infinitiveRomaji + "shimasen deshitara";

                //Potential - No Tense
                v.Plain_Positive_Romaji_Potential = v.infinitiveRomaji + "dekiru";
                v.Plain_Negative_Romaji_Potential = v.infinitiveRomaji + "dekinai";
                v.Polite_Positive_Romaji_Potential = v.infinitiveRomaji + "dekimasu";
                v.Polite_Negative_Romaji_Potential = v.infinitiveRomaji + "dekimasen";

                //Causative - No Tense
                v.Plain_Positive_Romaji_Causative = v.infinitiveRomaji + "saseru";
                v.Plain_Negative_Romaji_Causative = v.infinitiveRomaji + "sasenai";
                v.Polite_Positive_Romaji_Causative = v.infinitiveRomaji + "sasemasu";
                v.Polite_Negative_Romaji_Causative = v.infinitiveRomaji + "sasemasen";

                //Passive - No Tense
                v.Plain_Positive_Romaji_Passive = v.infinitiveRomaji + "sareru";
                v.Plain_Negative_Romaji_Passive = v.infinitiveRomaji + "sarenai";
                v.Polite_Positive_Romaji_Passive = v.infinitiveRomaji + "saremasu";
                v.Polite_Negative_Romaji_Passive = v.infinitiveRomaji + "saremasen";

                if (StringTools.isKatakana(v.endMarkerKana)) {

                    //Chau - Present - Kana
                    v.Present_Plain_Positive_Kana_Chau = "シチヤウ";
                    v.Present_Polite_Positive_Kana_Chau ="シチャイマス";
                    v.Present_Plain_Negative_Kana_Chau = "n/a";
                    v.Present_Polite_Negative_Kana_Chau = "n/a";

                    //Chau - Past - Kana
                    v.Past_Plain_Positive_Kana_Chau = "シチャッタ";
                    v.Past_Polite_Positive_Kana_Chau = "シチャイマシタ";
                    v.Past_Plain_Negative_Kana_Chau = "n/a";
                    v.Past_Polite_Negative_Kana_Chau = "n/a";

                    //Indicative - Present
                    v.Present_Plain_Positive_Kana_Indicative = v.infinitiveKana + "スル";
                    v.Present_Polite_Positive_Kana_Indicative = v.infinitiveKana + "シマス";
                    v.Present_Plain_Negative_Kana_Indicative = v.infinitiveKana + "シナイ";
                    v.Present_Polite_Negative_Kana_Indicative = v.infinitiveKana + "シマセン";

                    //Indicative - Past
                    v.Past_Plain_Positive_Kana_Indicative = v.infinitiveKana + "シタ";
                    v.Past_Polite_Positive_Kana_Indicative = v.infinitiveKana + "シマシタ";
                    v.Past_Plain_Negative_Kana_Indicative = v.infinitiveKana + "シナカッタ";
                    v.Past_Polite_Negative_Kana_Indicative = v.infinitiveKana + "シマセンデシタ";

                    //Presumptive - Present
                    v.Present_Plain_Positive_Kana_Volitional = v.infinitiveKana + "シヨウ";
                    v.Present_Plain_Negative_Kana_Volitional = v.infinitiveKana + "シナイダロウ";
                    v.Present_Polite_Positive_Kana_Volitional = v.infinitiveKana + "シマショウ";
                    v.Present_Polite_Negative_Kana_Volitional = v.infinitiveKana + "シナイデショウ";

                    //Presumptive - Past
                    v.Past_Plain_Positive_Kana_Volitional = v.infinitiveKana + "シタロウ";
                    v.Past_Plain_Negative_Kana_Volitional = v.infinitiveKana + "シナカッタダロウ";
                    v.Past_Polite_Positive_Kana_Volitional = v.infinitiveKana + "シマシタロウ";
                    v.Past_Polite_Negative_Kana_Volitional = v.infinitiveKana + "シナカッタデショウ";

                    //Imperative - No Tense
                    v.Plain_Positive_Kana_Imperative = v.infinitiveKana + "シロ";
                    v.Plain_Negative_Kana_Imperative = v.infinitiveKana + "スルナ";
                    v.Polite_Positive_Kana_Imperative = v.infinitiveKana + "シテクダサイ";
                    v.Polite_Negative_Kana_Imperative = v.infinitiveKana + "シナイデクダサイ";

                    //Progressive - Present
                    v.Present_Plain_Positive_Kana_Progressive = v.infinitiveKana + "シテイル";
                    v.Present_Plain_Negative_Kana_Progressive = v.infinitiveKana + "シテナイ";
                    v.Present_Polite_Positive_Kana_Pogressive = v.infinitiveKana + "シテイマス";
                    v.Present_Polite_Negative_Kana_Progressive = v.infinitiveKana + "シテイマセン";

                    //Progressive - Past
                    v.Past_Plain_Positive_Kana_Progressive = v.infinitiveKana + "シテイタ";
                    v.Past_Plain_Negative_Kana_Progressive = v.infinitiveKana + "シテナカッタ";
                    v.Past_Polite_Positive_Kana_Pogressive = v.infinitiveKana + "シテイマシタ";
                    v.Past_Polite_Negative_Kana_Progressive = v.infinitiveKana + "シテイマセンデシタ";

                    //Provisional ~eba - No Tense
                    v.Plain_Positive_Kana_Provisional = v.infinitiveKana + "スレバ";
                    v.Plain_Negative_Kana_Provisional = v.infinitiveKana + "シナケレバ";
                    v.Polite_Positive_Kana_Provisional = v.infinitiveKana + "シマセば";
                    v.Polite_Negative_Kana_Provisional = v.infinitiveKana + "シマセンナラ";

                    //Conditional -tara - No Tense
                    v.Plain_Positive_Kana_Conditional = v.infinitiveKana + "シタラ";
                    v.Plain_Negative_Kana_Conditional = v.infinitiveKana + "シナカッタラ";
                    v.Polite_Positive_Kana_Conditional = v.infinitiveKana + "シマシタラ";
                    v.Polite_Negative_Kana_Conditional = v.infinitiveKana + "シマセンデシタラ";

                    //Potential - No Tense
                    v.Plain_Positive_Kana_Potential = v.infinitiveKana + "デキル";
                    v.Plain_Negative_Kana_Potential = v.infinitiveKana + "デキナイ";
                    v.Polite_Positive_Kana_Potential = v.infinitiveKana + "デキマス";
                    v.Polite_Negative_Kana_Potential = v.infinitiveKana + "デキマセン";

                    //Causative - No Tense
                    v.Plain_Positive_Kana_Causative = v.infinitiveKana + "サセル";
                    v.Plain_Negative_Kana_Causative = v.infinitiveKana + "サセナイ";
                    v.Polite_Positive_Kana_Causative = v.infinitiveKana + "サセマス";
                    v.Polite_Negative_Kana_Causative = v.infinitiveKana + "サセマセン";

                    //Passive - No Tense
                    v.Plain_Positive_Kana_Passive = v.infinitiveKana + "サレル";
                    v.Plain_Negative_Kana_Passive = v.infinitiveKana + "サレナイ";
                    v.Polite_Positive_Kana_Passive = v.infinitiveKana + "サレマス";
                    v.Polite_Negative_Kana_Passive = v.infinitiveKana + "サレマセン";

                }
                else {

                    //Chau - Present - Kana
                    v.Present_Plain_Positive_Kana_Chau = v.infinitiveKana+  "しちゃう";
                    v.Present_Polite_Positive_Kana_Chau = v.infinitiveKana + "しちいます";
                    v.Present_Plain_Negative_Kana_Chau = "n/a";
                    v.Present_Polite_Negative_Kana_Chau = "n/a";

                    //Chau - Past - Kana
                    v.Past_Plain_Positive_Kana_Chau = v.infinitiveKana + "しちゃった";
                    v.Past_Polite_Positive_Kana_Chau = v.infinitiveKana + "しちゃいました";
                    v.Past_Plain_Negative_Kana_Chau = "n/a";
                    v.Past_Polite_Negative_Kana_Chau = "n/a";

                    //Indicative - Present
                    v.Present_Plain_Positive_Kana_Indicative = v.infinitiveKana + "する";
                    v.Present_Polite_Positive_Kana_Indicative = v.infinitiveKana + "します";
                    v.Present_Plain_Negative_Kana_Indicative = v.infinitiveKana + "しない";
                    v.Present_Polite_Negative_Kana_Indicative = v.infinitiveKana + "しません";

                    //Indicative - Past
                    v.Past_Plain_Positive_Kana_Indicative = v.infinitiveKana + "した";
                    v.Past_Polite_Positive_Kana_Indicative = v.infinitiveKana + "しました";
                    v.Past_Plain_Negative_Kana_Indicative = v.infinitiveKana + "しなかった";
                    v.Past_Polite_Negative_Kana_Indicative = v.infinitiveKana + "しませんでした";

                    //Presumptive - Present
                    v.Present_Plain_Positive_Kana_Volitional = v.infinitiveKana + "しよう";
                    v.Present_Plain_Negative_Kana_Volitional = v.infinitiveKana + "しないだろう";
                    v.Present_Polite_Positive_Kana_Volitional = v.infinitiveKana + "しましょう";
                    v.Present_Polite_Negative_Kana_Volitional = v.infinitiveKana + "しないでしょう";

                    //Presumptive - Past
                    v.Past_Plain_Positive_Kana_Volitional = v.infinitiveKana + "したろう";
                    v.Past_Plain_Negative_Kana_Volitional = v.infinitiveKana + "しなかっただろう";
                    v.Past_Polite_Positive_Kana_Volitional = v.infinitiveKana + "しましたろう";
                    v.Past_Polite_Negative_Kana_Volitional = v.infinitiveKana + "しなかったでしょう";

                    //Imperative - No Tense
                    v.Plain_Positive_Kana_Imperative = v.infinitiveKana + "しろ";
                    v.Plain_Negative_Kana_Imperative = v.infinitiveKana + "するな";
                    v.Polite_Positive_Kana_Imperative = v.infinitiveKana + "してください";
                    v.Polite_Negative_Kana_Imperative = v.infinitiveKana + "しないでください";

                    //Progressive - Present
                    v.Present_Plain_Positive_Kana_Progressive = v.infinitiveKana + "している";
                    v.Present_Plain_Negative_Kana_Progressive = v.infinitiveKana + "していない";
                    v.Present_Polite_Positive_Kana_Pogressive = v.infinitiveKana + "しています";
                    v.Present_Polite_Negative_Kana_Progressive = v.infinitiveKana + "していません";

                    //Progressive - Past
                    v.Past_Plain_Positive_Kana_Progressive = v.infinitiveKana + "していた";
                    v.Past_Plain_Negative_Kana_Progressive = v.infinitiveKana + "していなかった";
                    v.Past_Polite_Positive_Kana_Pogressive = v.infinitiveKana + "していました";
                    v.Past_Polite_Negative_Kana_Progressive = v.infinitiveKana + "していませんでした";

                    //Provisional ~eba - No Tense
                    v.Plain_Positive_Kana_Provisional = v.infinitiveKana + "すれば";
                    v.Plain_Negative_Kana_Provisional = v.infinitiveKana + "しなければ";
                    v.Polite_Positive_Kana_Provisional = v.infinitiveKana + "しませば";
                    v.Polite_Negative_Kana_Provisional = v.infinitiveKana + "しませんなら";

                    //Conditional -tara - No Tense
                    v.Plain_Positive_Kana_Conditional = v.infinitiveKana + "したら";
                    v.Plain_Negative_Kana_Conditional = v.infinitiveKana + "しなかったら";
                    v.Polite_Positive_Kana_Conditional = v.infinitiveKana + "しましたら";
                    v.Polite_Negative_Kana_Conditional = v.infinitiveKana + "しませんでしたら";

                    //Potential - No Tense
                    v.Plain_Positive_Kana_Potential = v.infinitiveKana + "できる";
                    v.Plain_Negative_Kana_Potential = v.infinitiveKana + "できない";
                    v.Polite_Positive_Kana_Potential = v.infinitiveKana + "できます";
                    v.Polite_Negative_Kana_Potential = v.infinitiveKana + "できません";

                    //Causative - No Tense
                    v.Plain_Positive_Kana_Causative = v.infinitiveKana + "させる";
                    v.Plain_Negative_Kana_Causative = v.infinitiveKana + "させない";
                    v.Polite_Positive_Kana_Causative = v.infinitiveKana + "させます";
                    v.Polite_Negative_Kana_Causative = v.infinitiveKana + "させません";

                    //Passive - No Tense
                    v.Plain_Positive_Kana_Passive = v.infinitiveKana + "される";
                    v.Plain_Negative_Kana_Passive = v.infinitiveKana + "されない";
                    v.Polite_Positive_Kana_Passive = v.infinitiveKana + "されます";
                    v.Polite_Negative_Kana_Passive = v.infinitiveKana + "されません";
                }



            }
            else if (v.dictionary.EndsWith("くる")) {
                v.infinitiveKana = v.dictionary.Substring(0, v.dictionary.Length - 2); //来る　→　来　（き）
                v.infinitiveRomaji = v.baseRoma.Substring(0, v.baseRoma.Length - 4); //Kuru -> ki
                v.stemKana = v.dictionary.Substring(0, v.dictionary.Length - 2) + "き";
                v.stemRomaji = v.baseRoma.Substring(0, v.baseRoma.Length - 4) + "ki";
                v.teKana = v.infinitiveKana + "きて";
                v.teRomaji = v.infinitiveRomaji + "kite";

                //Chau - Present - Romaji
                v.Present_Plain_Positive_Romaji_Chau = "kichau";
                v.Present_Polite_Positive_Romaji_Chau = "kichaimasu";
                v.Present_Plain_Negative_Romaji_Chau = "n/a";
                v.Present_Polite_Negative_Romaji_Chau = "n/a";

                //Chau - Past - Romaji
                v.Past_Plain_Positive_Romaji_Chau = "kichatta";
                v.Past_Polite_Positive_Romaji_Chau = "kichaimashita";
                v.Past_Plain_Negative_Romaji_Chau = "n/a";
                v.Past_Polite_Negative_Romaji_Chau = "n/a";

                //Indicative - Present
                v.Present_Plain_Positive_Romaji_Indicative = v.infinitiveRomaji + "kuru";
                v.Present_Polite_Positive_Romaji_Indicative = v.infinitiveRomaji + "kimasu";
                v.Present_Plain_Negative_Romaji_Indicative = v.infinitiveRomaji + "konai";
                v.Present_Polite_Negative_Romaji_Indicative = v.infinitiveRomaji + "kimasen";

                //Indicative - Past 
                v.Past_Plain_Positive_Romaji_Indicative = v.infinitiveRomaji + "kita";
                v.Past_Polite_Positive_Romaji_Indicative = v.infinitiveRomaji + "kimashita";
                v.Past_Plain_Negative_Romaji_Indicative = v.infinitiveRomaji + "konakatta";
                v.Past_Polite_Negative_Romaji_Indicative = v.infinitiveRomaji + "kimasen deshita";

                //Presumptive - Present
                v.Present_Plain_Positive_Romaji_Volitional = v.infinitiveRomaji + "koyou";
                v.Present_Plain_Negative_Romaji_Volitional = v.infinitiveRomaji + "konai darou";
                v.Present_Polite_Positive_Romaji_Volitional = v.infinitiveRomaji + "kimashou";
                v.Present_Polite_Negative_Romaji_Volitional = v.infinitiveRomaji + "konai deshou";

                //Presumptive - Past
                v.Past_Plain_Positive_Romaji_Volitional = v.infinitiveRomaji + "kitarou";
                v.Past_Plain_Negative_Romaji_Volitional = v.infinitiveRomaji + "konakatta darou";
                v.Past_Polite_Positive_Romaji_Volitional = v.infinitiveRomaji + "kita deshou";
                v.Past_Polite_Negative_Romaji_Volitional = v.infinitiveRomaji + "konakatta deshou";

                //Imperative - No Tense 
                v.Plain_Positive_Romaji_Imperative = v.infinitiveRomaji + "koi";
                v.Plain_Negative_Romaji_Imperative = v.infinitiveRomaji + "kuruna";
                v.Polite_Positive_Romaji_Imperative = v.infinitiveRomaji + "kite kudasai";
                v.Polite_Negative_Romaji_Imperative = v.infinitiveRomaji + "konaide kudasai";

                //Progressive - Present
                v.Present_Plain_Positive_Romaji_Progressive = "n/a";//v.infinitiveRomaji + "kite iru";
                v.Present_Plain_Negative_Romaji_Progressive = "n/a";//v.infinitiveRomaji + "kite inai"; //According to http://www.japaneseverbconjugator.com/VerbDetails.asp?JapaneseVerb=mitomeru&VerbClass=2&EnglishVerb=admit,%20recognize, does not exist
                v.Present_Polite_Positive_Romaji_Pogressive = "n/a";//v.infinitiveRomaji + "kite imasu";
                v.Present_Polite_Negative_Romaji_Progressive = "n/a";//v.infinitiveRomaji + "kite imasen";

                //Progressive - Past
                v.Past_Plain_Positive_Romaji_Progressive = "n/a";//v.infinitiveRomaji + "shite ita";
                v.Past_Plain_Negative_Romaji_Progressive = "n/a";//v.infinitiveRomaji + "shite inakatta"; //According to above, does not exist 
                v.Past_Polite_Positive_Romaji_Pogressive = "n/a";//v.infinitiveRomaji + "shite imashita";
                v.Past_Polite_Negative_Romaji_Progressive = "n/a";//v.infinitiveRomaji + "shite imasen deshita";

                //Provisional ~eba - No Tense
                v.Plain_Positive_Romaji_Provisional = v.infinitiveRomaji + "kureba";
                v.Plain_Negative_Romaji_Provisional = v.infinitiveRomaji + "konakereba";
                v.Polite_Positive_Romaji_Provisional = v.infinitiveRomaji + "kimaseba";
                v.Polite_Negative_Romaji_Provisional = v.infinitiveRomaji + "kimasen nara";

                //Conditional -tara - No Tense
                v.Plain_Positive_Romaji_Conditional = v.infinitiveRomaji + "kitara";
                v.Plain_Negative_Romaji_Conditional = v.infinitiveRomaji + "konakattara";
                v.Polite_Positive_Romaji_Conditional = v.infinitiveRomaji + "kimashitara";
                v.Polite_Negative_Romaji_Conditional = v.infinitiveRomaji + "kimasen deshitara";

                //Potential - No Tense
                v.Plain_Positive_Romaji_Potential = v.infinitiveRomaji + "korareru";
                v.Plain_Negative_Romaji_Potential = v.infinitiveRomaji + "korarenai";
                v.Polite_Positive_Romaji_Potential = v.infinitiveRomaji + "koraremasu";
                v.Polite_Negative_Romaji_Potential = v.infinitiveRomaji + "koraremasen";

                //Causative - No Tense
                v.Plain_Positive_Romaji_Causative = v.infinitiveRomaji + "kosaseru";
                v.Plain_Negative_Romaji_Causative = v.infinitiveRomaji + "kosasenai";
                v.Polite_Positive_Romaji_Causative = v.infinitiveRomaji + "kosasemasu";
                v.Polite_Negative_Romaji_Causative = v.infinitiveRomaji + "kosasemasen";

                //Passive - No Tense
                v.Plain_Positive_Romaji_Passive = v.infinitiveRomaji + "korareru";
                v.Plain_Negative_Romaji_Passive = v.infinitiveRomaji + "korarenai";
                v.Polite_Positive_Romaji_Passive = v.infinitiveRomaji + "koraremasu";
                v.Polite_Negative_Romaji_Passive = v.infinitiveRomaji + "koraremasen";


                if (StringTools.isKatakana(v.endMarkerKana)) {

                    //Chau - Present - Kana
                    v.Present_Plain_Positive_Kana_Chau = "キチャウ";
                    v.Present_Polite_Positive_Kana_Chau = "キチャイマス";
                    v.Present_Plain_Negative_Kana_Chau = "n/a";
                    v.Present_Polite_Negative_Kana_Chau = "n/a";

                    //Chau - Past - Kana
                    v.Past_Plain_Positive_Kana_Chau = "キチャッタ";
                    v.Past_Polite_Positive_Kana_Chau = "キチャイマシタ";
                    v.Past_Plain_Negative_Kana_Chau = "n/a";
                    v.Past_Polite_Negative_Kana_Chau = "n/a";

                    //Indicative - Present
                    v.Present_Plain_Positive_Kana_Indicative = v.infinitiveKana + "クル";
                    v.Present_Polite_Positive_Kana_Indicative = v.infinitiveKana + "キマス";
                    v.Present_Plain_Negative_Kana_Indicative = v.infinitiveKana + "コナイ";
                    v.Present_Polite_Negative_Kana_Indicative = v.infinitiveKana + "キマセン";

                    //Indicative - Past 
                    v.Past_Plain_Positive_Kana_Indicative = v.infinitiveKana + "キタ";
                    v.Past_Polite_Positive_Kana_Indicative = v.infinitiveKana + "キマシタ";
                    v.Past_Plain_Negative_Kana_Indicative = v.infinitiveKana + "コナカッタ";
                    v.Past_Polite_Negative_Kana_Indicative = v.infinitiveKana + "キマセンデシタ";

                    //Presumptive - Present
                    v.Present_Plain_Positive_Kana_Volitional = v.infinitiveKana + "コヨウ";
                    v.Present_Plain_Negative_Kana_Volitional = v.infinitiveKana + "コナイダロウ";
                    v.Present_Polite_Positive_Kana_Volitional = v.infinitiveKana + "キマショウ";
                    v.Present_Polite_Negative_Kana_Volitional = v.infinitiveKana + "コナイデショウ";

                    //Presumptive - Past
                    v.Past_Plain_Positive_Kana_Volitional = v.infinitiveKana + "キタロウ";
                    v.Past_Plain_Negative_Kana_Volitional = v.infinitiveKana + "コナカッタダロウ";
                    v.Past_Polite_Positive_Kana_Volitional = v.infinitiveKana + "キマシタロウ";
                    v.Past_Polite_Negative_Kana_Volitional = v.infinitiveKana + "コナカッタデショウ";

                    //Imperative - No Tense 
                    v.Plain_Positive_Kana_Imperative = v.infinitiveKana + "コイ";
                    v.Plain_Negative_Kana_Imperative = v.infinitiveKana + "クルナ";
                    v.Polite_Positive_Kana_Imperative = v.infinitiveKana + "キテクダサイ";
                    v.Polite_Negative_Kana_Imperative = v.infinitiveKana + "コナイデクダサイ";

                    //Progressive - Present
                    v.Present_Plain_Positive_Kana_Progressive = "n/a";//v.infinitiveKana + "kite iru";
                    v.Present_Plain_Negative_Kana_Progressive = "n/a";//v.infinitiveKana + "kite inai"; //According to http://www.japaneseverbconjugator.com/VerbDetails.asp?JapaneseVerb=mitomeru&VerbClass=2&EnglishVerb=admit,%20recognize, does not exist
                    v.Present_Polite_Positive_Kana_Pogressive = "n/a";//v.infinitiveKana + "kite imasu";
                    v.Present_Polite_Negative_Kana_Progressive = "n/a";//v.infinitiveKana + "kite imasen";

                    //Progressive - Past
                    v.Past_Plain_Positive_Kana_Progressive = "n/a";//v.infinitiveKana + "shite ita";
                    v.Past_Plain_Negative_Kana_Progressive = "n/a";//v.infinitiveKana + "shite inakatta"; //According to above, does not exist 
                    v.Past_Polite_Positive_Kana_Pogressive = "n/a";//v.infinitiveKana + "shite imashita";
                    v.Past_Polite_Negative_Kana_Progressive = "n/a";//v.infinitiveKana + "shite imasen deshita";

                    //Provisional ~eba - No Tense
                    v.Plain_Positive_Kana_Provisional = v.infinitiveKana + "クレバ";
                    v.Plain_Negative_Kana_Provisional = v.infinitiveKana + "コナケレバ";
                    v.Polite_Positive_Kana_Provisional = v.infinitiveKana + "キマセバ";
                    v.Polite_Negative_Kana_Provisional = v.infinitiveKana + "キマセンナラ";

                    //Conditional -tara - No Tense
                    v.Plain_Positive_Kana_Conditional = v.infinitiveKana + "キタラ";
                    v.Plain_Negative_Kana_Conditional = v.infinitiveKana + "コナカッタラ";
                    v.Polite_Positive_Kana_Conditional = v.infinitiveKana + "キマシタラ";
                    v.Polite_Negative_Kana_Conditional = v.infinitiveKana + "キマセンデシタラ";

                    //Potential - No Tense
                    v.Plain_Positive_Kana_Potential = v.infinitiveKana + "コラレル";
                    v.Plain_Negative_Kana_Potential = v.infinitiveKana + "コラレナイ";
                    v.Polite_Positive_Kana_Potential = v.infinitiveKana + "コラレマス";
                    v.Polite_Negative_Kana_Potential = v.infinitiveKana + "コラレマセン";

                    //Causative - No Tense
                    v.Plain_Positive_Kana_Causative = v.infinitiveKana + "コサセル";
                    v.Plain_Negative_Kana_Causative = v.infinitiveKana + "コサセナイ";
                    v.Polite_Positive_Kana_Causative = v.infinitiveKana + "コサセマス";
                    v.Polite_Negative_Kana_Causative = v.infinitiveKana + "コサセマセン";

                    //Passive - No Tense
                    v.Plain_Positive_Kana_Passive = v.infinitiveKana + "コラレル";
                    v.Plain_Negative_Kana_Passive = v.infinitiveKana + "コラレナイ";
                    v.Polite_Positive_Kana_Passive = v.infinitiveKana + "コラレマス";
                    v.Polite_Negative_Kana_Passive = v.infinitiveKana + "コラレマセン";

                }
                else {


                    //Chau - Present - Kana
                    v.Present_Plain_Positive_Kana_Chau = "きちゃう";
                    v.Present_Polite_Positive_Kana_Chau = "きちゃいます";
                    v.Present_Plain_Negative_Kana_Chau = "n/a";
                    v.Present_Polite_Negative_Kana_Chau = "n/a";

                    //Chau - Past - Kana
                    v.Past_Plain_Positive_Kana_Chau = "きちゃった";
                    v.Past_Polite_Positive_Kana_Chau = "きちゃいました";
                    v.Past_Plain_Negative_Kana_Chau = "n/a";
                    v.Past_Polite_Negative_Kana_Chau = "n/a";


                    //Indicative - Present
                    v.Present_Plain_Positive_Kana_Indicative = v.infinitiveKana + "くる";
                    v.Present_Polite_Positive_Kana_Indicative = v.infinitiveKana + "きます";
                    v.Present_Plain_Negative_Kana_Indicative = v.infinitiveKana + "こない";
                    v.Present_Polite_Negative_Kana_Indicative = v.infinitiveKana + "きません";

                    //Indicative - Past 
                    v.Past_Plain_Positive_Kana_Indicative = v.infinitiveKana + "きた";
                    v.Past_Polite_Positive_Kana_Indicative = v.infinitiveKana + "きました";
                    v.Past_Plain_Negative_Kana_Indicative = v.infinitiveKana + "こなかった";
                    v.Past_Polite_Negative_Kana_Indicative = v.infinitiveKana + "きませんでした";

                    //Presumptive - Present
                    v.Present_Plain_Positive_Kana_Volitional = v.infinitiveKana + "こよう";
                    v.Present_Plain_Negative_Kana_Volitional = v.infinitiveKana + "こないだろう";
                    v.Present_Polite_Positive_Kana_Volitional = v.infinitiveKana + "きましょう";
                    v.Present_Polite_Negative_Kana_Volitional = v.infinitiveKana + "こないでしょう";

                    //Presumptive - Past
                    v.Past_Plain_Positive_Kana_Volitional = v.infinitiveKana + "きたろう";
                    v.Past_Plain_Negative_Kana_Volitional = v.infinitiveKana + "こなかっただろう";
                    v.Past_Polite_Positive_Kana_Volitional = v.infinitiveKana + "きたでしょうshin";
                    v.Past_Polite_Negative_Kana_Volitional = v.infinitiveKana + "こなかったでしょう";

                    //Imperative - No Tense 
                    v.Plain_Positive_Kana_Imperative = v.infinitiveKana + "こい";
                    v.Plain_Negative_Kana_Imperative = v.infinitiveKana + "くるな";
                    v.Polite_Positive_Kana_Imperative = v.infinitiveKana + "きてください";
                    v.Polite_Negative_Kana_Imperative = v.infinitiveKana + "こないでください";

                    //Progressive - Present
                    v.Present_Plain_Positive_Kana_Progressive = "n/a";//v.infinitiveKana + "kite iru";
                    v.Present_Plain_Negative_Kana_Progressive = "n/a";//v.infinitiveKana + "kite inai"; //According to http://www.japaneseverbconjugator.com/VerbDetails.asp?JapaneseVerb=mitomeru&VerbClass=2&EnglishVerb=admit,%20recognize, does not exist
                    v.Present_Polite_Positive_Kana_Pogressive = "n/a";//v.infinitiveKana + "kite imasu";
                    v.Present_Polite_Negative_Kana_Progressive = "n/a";//v.infinitiveKana + "kite imasen";

                    //Progressive - Past
                    v.Past_Plain_Positive_Kana_Progressive = "n/a";//v.infinitiveKana + "shite ita";
                    v.Past_Plain_Negative_Kana_Progressive = "n/a";//v.infinitiveKana + "shite inakatta"; //According to above, does not exist 
                    v.Past_Polite_Positive_Kana_Pogressive = "n/a";//v.infinitiveKana + "shite imashita";
                    v.Past_Polite_Negative_Kana_Progressive = "n/a";//v.infinitiveKana + "shite imasen deshita";

                    //Provisional ~eba - No Tense
                    v.Plain_Positive_Kana_Provisional = v.infinitiveKana + "くれば";
                    v.Plain_Negative_Kana_Provisional = v.infinitiveKana + "こなければ";
                    v.Polite_Positive_Kana_Provisional = v.infinitiveKana + "きませば";
                    v.Polite_Negative_Kana_Provisional = v.infinitiveKana + "きませんなら";

                    //Conditional -tara - No Tense
                    v.Plain_Positive_Kana_Conditional = v.infinitiveKana + "きたら";
                    v.Plain_Negative_Kana_Conditional = v.infinitiveKana + "こなかったら";
                    v.Polite_Positive_Kana_Conditional = v.infinitiveKana + "きましたら";
                    v.Polite_Negative_Kana_Conditional = v.infinitiveKana + "きませんでしたら";

                    //Potential - No Tense
                    v.Plain_Positive_Kana_Potential = v.infinitiveKana + "こられる";
                    v.Plain_Negative_Kana_Potential = v.infinitiveKana + "こられない";
                    v.Polite_Positive_Kana_Potential = v.infinitiveKana + "こられます";
                    v.Polite_Negative_Kana_Potential = v.infinitiveKana + "こられません";

                    //Causative - No Tense
                    v.Plain_Positive_Kana_Causative = v.infinitiveKana + "こさせる";
                    v.Plain_Negative_Kana_Causative = v.infinitiveKana + "こさせない";
                    v.Polite_Positive_Kana_Causative = v.infinitiveKana + "こさせます";
                    v.Polite_Negative_Kana_Causative = v.infinitiveKana + "こさせません";

                    //Passive - No Tense
                    v.Plain_Positive_Kana_Passive = v.infinitiveKana + "こられる";
                    v.Plain_Negative_Kana_Passive = v.infinitiveKana + "こられない";
                    v.Polite_Positive_Kana_Passive = v.infinitiveKana + "こられます";
                    v.Polite_Negative_Kana_Passive = v.infinitiveKana + "こられません";
                }
                
            }


        }

        public static void conjAru(Verb v) {
            v.infinitiveKana = v.dictionary.Substring(0, v.dictionary.Length - 2); //なななする　→　なななす
            v.infinitiveRomaji = v.baseRoma.Substring(0, v.baseRoma.Length - 3); //nananasuru -> nananasu
            v.teKana = v.infinitiveKana + "あって";
            v.teRomaji = v.infinitiveRomaji + "atte";

            #region Romaji
            //Indicative - Present
            v.Present_Plain_Positive_Romaji_Indicative = v.infinitiveRomaji + "aru";
            v.Present_Polite_Positive_Romaji_Indicative = v.infinitiveRomaji + "arimasu";
            v.Present_Plain_Negative_Romaji_Indicative = v.infinitiveRomaji + "nai";
            v.Present_Polite_Negative_Romaji_Indicative = v.infinitiveRomaji + "arimasen";

            //Indicative - Past 
            v.Past_Plain_Positive_Romaji_Indicative = v.infinitiveRomaji + "atta";
            v.Past_Polite_Positive_Romaji_Indicative = v.infinitiveRomaji + "arimashita";
            v.Past_Plain_Negative_Romaji_Indicative = v.infinitiveRomaji + "nakatta";
            v.Past_Polite_Negative_Romaji_Indicative = v.infinitiveRomaji + "arimasen deshita";

            //Presumptive - Present
            v.Present_Plain_Positive_Romaji_Volitional = v.infinitiveRomaji + "arou";
            v.Present_Plain_Negative_Romaji_Volitional = v.infinitiveRomaji + "nai darou";
            v.Present_Polite_Positive_Romaji_Volitional = v.infinitiveRomaji + "arimashou";
            v.Present_Polite_Negative_Romaji_Volitional = v.infinitiveRomaji + "nai deshou";

            //Presumptive - Past
            v.Past_Plain_Positive_Romaji_Volitional = v.infinitiveRomaji + "attarou";
            v.Past_Plain_Negative_Romaji_Volitional = v.infinitiveRomaji + "nakatta darou";
            v.Past_Polite_Positive_Romaji_Volitional = v.infinitiveRomaji + "atta deshou";
            v.Past_Polite_Negative_Romaji_Volitional = v.infinitiveRomaji + "nakatta deshou";

            //Imperative - No Tense 
            v.Plain_Positive_Romaji_Imperative = v.infinitiveRomaji + "are";
            v.Plain_Negative_Romaji_Imperative = v.infinitiveRomaji + "aruna";
            v.Polite_Positive_Romaji_Imperative = v.infinitiveRomaji + "atte kudasai";
            v.Polite_Negative_Romaji_Imperative = v.infinitiveRomaji + "naide kudasai";

            //Progressive - Present
            v.Present_Plain_Positive_Romaji_Progressive = v.infinitiveRomaji + "n/a";
            v.Present_Plain_Negative_Romaji_Progressive = v.infinitiveRomaji + "n/a"; //According to http://www.japaneseverbconjugator.com/VerbDetails.asp?JapaneseVerb=mitomeru&VerbClass=2&EnglishVerb=admit,%20recognize, does not exist
            v.Present_Polite_Positive_Romaji_Pogressive = v.infinitiveRomaji + "n/a";
            v.Present_Polite_Negative_Romaji_Progressive = v.infinitiveRomaji + "n/a";

            //Progressive - Past
            v.Past_Plain_Positive_Romaji_Progressive = v.infinitiveRomaji + "n/a";
            v.Past_Plain_Negative_Romaji_Progressive = v.infinitiveRomaji + "n/a"; //According to above, does not exist 
            v.Past_Polite_Positive_Romaji_Pogressive = v.infinitiveRomaji + "n/a";
            v.Past_Polite_Negative_Romaji_Progressive = v.infinitiveRomaji + "n/a";

            //Provisional ~eba - No Tense
            v.Plain_Positive_Romaji_Provisional = v.infinitiveRomaji + "areba";
            v.Plain_Negative_Romaji_Provisional = v.infinitiveRomaji + "nakereba";
            v.Polite_Positive_Romaji_Provisional = v.infinitiveRomaji + "arimaseba";
            v.Polite_Negative_Romaji_Provisional = v.infinitiveRomaji + "arimasen nara";

            //Conditional -tara - No Tense
            v.Plain_Positive_Romaji_Conditional = v.infinitiveRomaji + "attara";
            v.Plain_Negative_Romaji_Conditional = v.infinitiveRomaji + "nakattara";
            v.Polite_Positive_Romaji_Conditional = v.infinitiveRomaji + "arimashitara";
            v.Polite_Negative_Romaji_Conditional = v.infinitiveRomaji + "arimasen deshitara";

            //Potential - No Tense
            v.Plain_Positive_Romaji_Potential = "n/a";
            v.Plain_Negative_Romaji_Potential = "n/a";
            v.Polite_Positive_Romaji_Potential = "n/a";
            v.Polite_Negative_Romaji_Potential = "n/a";

            //Causative - No Tense
            v.Plain_Positive_Romaji_Causative = "n/a";
            v.Plain_Negative_Romaji_Causative = "n/a";
            v.Polite_Positive_Romaji_Causative = "n/a";
            v.Polite_Negative_Romaji_Causative = "n/a";

            //Passive - No Tense
            v.Plain_Positive_Romaji_Passive = v.infinitiveRomaji + "arareru";
            v.Plain_Negative_Romaji_Passive = v.infinitiveRomaji + "ararenai";
            v.Polite_Positive_Romaji_Passive = v.infinitiveRomaji + "araremasu";
            v.Polite_Negative_Romaji_Passive = v.infinitiveRomaji + "araremasen";
#endregion
            #region Hiragana
            //Indicative - Present
            v.Present_Plain_Positive_Kana_Indicative = v.infinitiveKana + "ある";
            v.Present_Polite_Positive_Kana_Indicative = v.infinitiveKana + "あります";
            v.Present_Plain_Negative_Kana_Indicative = v.infinitiveKana + "ない";
            v.Present_Polite_Negative_Kana_Indicative = v.infinitiveKana + "ありません";

            //Indicative - Past 
            v.Past_Plain_Positive_Kana_Indicative = v.infinitiveKana + "あった";
            v.Past_Polite_Positive_Kana_Indicative = v.infinitiveKana + "ありました";
            v.Past_Plain_Negative_Kana_Indicative = v.infinitiveKana + "なかった";
            v.Past_Polite_Negative_Kana_Indicative = v.infinitiveKana + "ありませんでした";

            //Presumptive - Present
            v.Present_Plain_Positive_Kana_Volitional = v.infinitiveKana + "あろう";
            v.Present_Plain_Negative_Kana_Volitional = v.infinitiveKana + "ないだろう";
            v.Present_Polite_Positive_Kana_Volitional = v.infinitiveKana + "ありましょう";
            v.Present_Polite_Negative_Kana_Volitional = v.infinitiveKana + "ない でしょう";

            //Presumptive - Past
            v.Past_Plain_Positive_Kana_Volitional = v.infinitiveKana + "あったろう";
            v.Past_Plain_Negative_Kana_Volitional = v.infinitiveKana + "なかっただろう";
            v.Past_Polite_Positive_Kana_Volitional = v.infinitiveKana + "あったでしょう";
            v.Past_Polite_Negative_Kana_Volitional = v.infinitiveKana + "なかったでしょう";

            //Imperative - No Tense 
            v.Plain_Positive_Kana_Imperative = v.infinitiveKana + "あれ";
            v.Plain_Negative_Kana_Imperative = v.infinitiveKana + "あるな";
            v.Polite_Positive_Kana_Imperative = v.infinitiveKana + "あってください";
            v.Polite_Negative_Kana_Imperative = v.infinitiveKana + "ないでください";

            //Progressive - Present
            v.Present_Plain_Positive_Kana_Progressive = "n/a";
            v.Present_Plain_Negative_Kana_Progressive = "n/a"; //According to http://www.japaneseverbconjugator.com/VerbDetails.asp?JapaneseVerb=mitomeru&VerbClass=2&EnglishVerb=admit,%20recognize, does not exist
            v.Present_Polite_Positive_Kana_Pogressive = "n/a";
            v.Present_Polite_Negative_Kana_Progressive = "n/a";

            //Progressive - Past
            v.Past_Plain_Positive_Kana_Progressive = "n/a";
            v.Past_Plain_Negative_Kana_Progressive = "n/a"; //According to above, does not exist 
            v.Past_Polite_Positive_Kana_Pogressive = "n/a";
            v.Past_Polite_Negative_Kana_Progressive = "n/a";

            //Provisional ~eba - No Tense
            v.Plain_Positive_Kana_Provisional = v.infinitiveKana + "あれば";
            v.Plain_Negative_Kana_Provisional = v.infinitiveKana + "なければ";
            v.Polite_Positive_Kana_Provisional = v.infinitiveKana + "ありませば";
            v.Polite_Negative_Kana_Provisional = v.infinitiveKana + "ありませんなら";

            //Conditional -tara - No Tense
            v.Plain_Positive_Kana_Conditional = v.infinitiveKana + "あったら";
            v.Plain_Negative_Kana_Conditional = v.infinitiveKana + "なかったら";
            v.Polite_Positive_Kana_Conditional = v.infinitiveKana + "ありましったら";
            v.Polite_Negative_Kana_Conditional = v.infinitiveKana + "ありませんでしたら";

            //Potential - No Tense
            v.Plain_Positive_Kana_Potential = "n/a";
            v.Plain_Negative_Kana_Potential = "n/a";
            v.Polite_Positive_Kana_Potential = "n/a";
            v.Polite_Negative_Kana_Potential = "n/a";

            //Causative - No Tense
            v.Plain_Positive_Kana_Causative = "n/a";
            v.Plain_Negative_Kana_Causative ="n/a";
            v.Polite_Positive_Kana_Causative =  "n/a";
            v.Polite_Negative_Kana_Causative = "n/a";

            //Passive - No Tense
            v.Plain_Positive_Kana_Passive = v.infinitiveKana + "あられる";
            v.Plain_Negative_Kana_Passive = v.infinitiveKana + "あられない";
            v.Polite_Positive_Kana_Passive = v.infinitiveKana + "あられます";
            v.Polite_Negative_Kana_Passive = v.infinitiveKana + "あられません";
            #endregion

        }

        public static void conjIku(Verb v) {
            v.infinitiveKana = v.dictionary; //なななする　→　なななす
            v.infinitiveRomaji =  v.baseRoma; //nananasuru -> nananasu
            v.teKana = "いって";
            v.teRomaji = "itte";

            #region Romaji
            //Indicative - Present
            v.Present_Plain_Positive_Romaji_Indicative = "iku";
            v.Present_Polite_Positive_Romaji_Indicative = "ikimasu";
            v.Present_Plain_Negative_Romaji_Indicative = "ikanai";
            v.Present_Polite_Negative_Romaji_Indicative = "ikimasen";

            //Indicative - Past 
            v.Past_Plain_Positive_Romaji_Indicative = "itta";
            v.Past_Polite_Positive_Romaji_Indicative = "ikimashita";
            v.Past_Plain_Negative_Romaji_Indicative = "ikanakatta";
            v.Past_Polite_Negative_Romaji_Indicative = "ikimasen deshita";

            //Presumptive - Present
            v.Present_Plain_Positive_Romaji_Volitional = "ikou";
            v.Present_Plain_Negative_Romaji_Volitional = "ikanai darou";
            v.Present_Polite_Positive_Romaji_Volitional = "ikimashou";
            v.Present_Polite_Negative_Romaji_Volitional = "ikanai deshou";

            //Presumptive - Past
            v.Past_Plain_Positive_Romaji_Volitional = "ittarou";
            v.Past_Plain_Negative_Romaji_Volitional = "ikanakatta darou";
            v.Past_Polite_Positive_Romaji_Volitional = "itta deshou";
            v.Past_Polite_Negative_Romaji_Volitional = "ikanakatta deshou";

            //Imperative - No Tense 
            v.Plain_Positive_Romaji_Imperative = "ike";
            v.Plain_Negative_Romaji_Imperative = "ikuna";
            v.Polite_Positive_Romaji_Imperative = "itte kudasai";
            v.Polite_Negative_Romaji_Imperative = "ikanaide kudasai";

            //Progressive - Present
            v.Present_Plain_Positive_Romaji_Progressive = "itte iru";
            v.Present_Plain_Negative_Romaji_Progressive = "itte inai"; //According to http://www.japaneseverbconjugator.com/VerbDetails.asp?JapaneseVerb=mitomeru&VerbClass=2&EnglishVerb=admit,%20recognize, does not exist
            v.Present_Polite_Positive_Romaji_Pogressive = "itte imasu";
            v.Present_Polite_Negative_Romaji_Progressive = "itte imasen";

            //Progressive - Past
            v.Past_Plain_Positive_Romaji_Progressive = "itte ita";
            v.Past_Plain_Negative_Romaji_Progressive = "itte inakatta"; //According to above, does not exist 
            v.Past_Polite_Positive_Romaji_Pogressive = "itte imashita";
            v.Past_Polite_Negative_Romaji_Progressive = "itte imasen deshita";

            //Provisional ~eba - No Tense
            v.Plain_Positive_Romaji_Provisional = "ikeba";
            v.Plain_Negative_Romaji_Provisional = "ikanakereba";
            v.Polite_Positive_Romaji_Provisional = "ikimaseba";
            v.Polite_Negative_Romaji_Provisional = "ikimasen nara";

            //Conditional -tara - No Tense
            v.Plain_Positive_Romaji_Conditional = "ittara";
            v.Plain_Negative_Romaji_Conditional = "ikanakattara";
            v.Polite_Positive_Romaji_Conditional = "ikimashitara";
            v.Polite_Negative_Romaji_Conditional = "ikimasen deshitara";

            //Potential - No Tense
            v.Plain_Positive_Romaji_Potential = "ikeru";
            v.Plain_Negative_Romaji_Potential = "ikenai";
            v.Polite_Positive_Romaji_Potential = "ikemasu";
            v.Polite_Negative_Romaji_Potential = "ikemasen";

            //Causative - No Tense
            v.Plain_Positive_Romaji_Causative = "ikaseru";
            v.Plain_Negative_Romaji_Causative =  "ikasenai";
            v.Polite_Positive_Romaji_Causative =  "ikasemasu";
            v.Polite_Negative_Romaji_Causative = "ikasemasen";

            //Passive - No Tense
            v.Plain_Positive_Romaji_Passive =  "ikareru";
            v.Plain_Negative_Romaji_Passive ="ikarenai";
            v.Polite_Positive_Romaji_Passive = "ikaremasu";
            v.Polite_Negative_Romaji_Passive =  "ikaremasen";
            #endregion
            #region Hiragana
            //Indicative - Present
            v.Present_Plain_Positive_Kana_Indicative = "いく";
            v.Present_Polite_Positive_Kana_Indicative = "いきます";
            v.Present_Plain_Negative_Kana_Indicative = "いかない";
            v.Present_Polite_Negative_Kana_Indicative = "いきません";

            //Indicative - Past 
            v.Past_Plain_Positive_Kana_Indicative = "いった";
            v.Past_Polite_Positive_Kana_Indicative = "いきました";
            v.Past_Plain_Negative_Kana_Indicative = "いかなかった";
            v.Past_Polite_Negative_Kana_Indicative = "いきませんでした";

            //Presumptive - Present
            v.Present_Plain_Positive_Kana_Volitional = "いこう";
            v.Present_Plain_Negative_Kana_Volitional = "いかないだろう";
            v.Present_Polite_Positive_Kana_Volitional = "いきましょう";
            v.Present_Polite_Negative_Kana_Volitional = "いかないでしょう";

            //Presumptive - Past
            v.Past_Plain_Positive_Kana_Volitional = "いったろう";
            v.Past_Plain_Negative_Kana_Volitional = "いかなかっただろう";
            v.Past_Polite_Positive_Kana_Volitional = "いったでしょう";
            v.Past_Polite_Negative_Kana_Volitional = "いかなかったでしょう";

            //Imperative - No Tense 
            v.Plain_Positive_Kana_Imperative = "いけ";
            v.Plain_Negative_Kana_Imperative = "いくな";
            v.Polite_Positive_Kana_Imperative = "いってください";
            v.Polite_Negative_Kana_Imperative = "いかないでください";

            //Progressive - Present
            v.Present_Plain_Positive_Kana_Progressive = "いっている";
            v.Present_Plain_Negative_Kana_Progressive = "いっていない"; //According to http://www.japaneseverbconjugator.com/VerbDetails.asp?JapaneseVerb=mitomeru&VerbClass=2&EnglishVerb=admit,%20recognize, does not exist
            v.Present_Polite_Positive_Kana_Pogressive = "いっています";
            v.Present_Polite_Negative_Kana_Progressive = "いっていません";

            //Progressive - Past
            v.Past_Plain_Positive_Kana_Progressive = "いっていた";
            v.Past_Plain_Negative_Kana_Progressive = "いっていなかった"; //According to above, does not exist 
            v.Past_Polite_Positive_Kana_Pogressive = "いっていました";
            v.Past_Polite_Negative_Kana_Progressive = "いっていませんでした";

            //Provisional ~eba - No Tense
            v.Plain_Positive_Kana_Provisional = "いけば";
            v.Plain_Negative_Kana_Provisional = "いかなければ";
            v.Polite_Positive_Kana_Provisional = "いきませば";
            v.Polite_Negative_Kana_Provisional = "いきませんなら";

            //Conditional -tara - No Tense
            v.Plain_Positive_Kana_Conditional = "いったら";
            v.Plain_Negative_Kana_Conditional = "いかなかったら";
            v.Polite_Positive_Kana_Conditional = "いきましたら";
            v.Polite_Negative_Kana_Conditional = "いきませんでしたら";

            //Potential - No Tense
            v.Plain_Positive_Kana_Potential = "いける";
            v.Plain_Negative_Kana_Potential = "いけない";
            v.Polite_Positive_Kana_Potential = "いけます";
            v.Polite_Negative_Kana_Potential = "いけません";

            //Causative - No Tense
            v.Plain_Positive_Kana_Causative = "いかせる";
            v.Plain_Negative_Kana_Causative = "いかせない";
            v.Polite_Positive_Kana_Causative =  "いかせます";
            v.Polite_Negative_Kana_Causative = "いかせません";

            //Passive - No Tense
            v.Plain_Positive_Kana_Passive =  "いかれる";
            v.Plain_Negative_Kana_Passive = "いかれない";
            v.Polite_Positive_Kana_Passive =  "いかれます";
            v.Polite_Negative_Kana_Passive = "いかれません";
            #endregion
        }

        public static void conjMasu(Verb v) {
            v.infinitiveKana = v.dictionary; //なななする　→　なななす
            v.infinitiveRomaji = v.baseRoma; //nananasuru -> nananasu
            v.teKana = "て";
            v.teRomaji = "te";

            #region Romaji
            //Indicative - Present
            v.Present_Plain_Positive_Romaji_Indicative = "ru";
            v.Present_Polite_Positive_Romaji_Indicative = "masu";
            v.Present_Plain_Negative_Romaji_Indicative = "nai";
            v.Present_Polite_Negative_Romaji_Indicative = "masen";

            //Indicative - Past 
            v.Past_Plain_Positive_Romaji_Indicative = "ta";
            v.Past_Polite_Positive_Romaji_Indicative = "mashita";
            v.Past_Plain_Negative_Romaji_Indicative = "nakatta";
            v.Past_Polite_Negative_Romaji_Indicative = "masen deshita";

            //Presumptive - Present
            v.Present_Plain_Positive_Romaji_Volitional = "rou";
            v.Present_Plain_Negative_Romaji_Volitional = "nai darou";
            v.Present_Polite_Positive_Romaji_Volitional = "mashou";
            v.Present_Polite_Negative_Romaji_Volitional = "nai deshou";

            //Presumptive - Past
            v.Past_Plain_Positive_Romaji_Volitional = "tarou";
            v.Past_Plain_Negative_Romaji_Volitional = "nakatta darou";
            v.Past_Polite_Positive_Romaji_Volitional = "ta deshou";
            v.Past_Polite_Negative_Romaji_Volitional = "nakatta deshou";

            //Imperative - No Tense 
            v.Plain_Positive_Romaji_Imperative = "te";
            v.Plain_Negative_Romaji_Imperative = "runa";
            v.Polite_Positive_Romaji_Imperative = "mashite kudasai";
            v.Polite_Negative_Romaji_Imperative = "naide kudasai";

            //Progressive - Present
            v.Present_Plain_Positive_Romaji_Progressive = "te iru";
            v.Present_Plain_Negative_Romaji_Progressive = "te inai"; //According to http://www.japaneseverbconjugator.com/VerbDetails.asp?JapaneseVerb=mitomeru&VerbClass=2&EnglishVerb=admit,%20recognize, does not exist
            v.Present_Polite_Positive_Romaji_Pogressive = "te imasu";
            v.Present_Polite_Negative_Romaji_Progressive = "te imasen";

            //Progressive - Past
            v.Past_Plain_Positive_Romaji_Progressive = "te ita";
            v.Past_Plain_Negative_Romaji_Progressive = "te inakatta"; //According to above, does not exist 
            v.Past_Polite_Positive_Romaji_Pogressive = "te imashita";
            v.Past_Polite_Negative_Romaji_Progressive = "te imasen deshita";

            //Provisional ~eba - No Tense
            v.Plain_Positive_Romaji_Provisional = "reba";
            v.Plain_Negative_Romaji_Provisional = "nakereba";
            v.Polite_Positive_Romaji_Provisional = "maseba";
            v.Polite_Negative_Romaji_Provisional = "masen nara";

            //Conditional -tara - No Tense
            v.Plain_Positive_Romaji_Conditional = "tara";
            v.Plain_Negative_Romaji_Conditional = "nakattara";
            v.Polite_Positive_Romaji_Conditional = "mashitara";
            v.Polite_Negative_Romaji_Conditional = "masen deshitara";

            //Potential - No Tense
            v.Plain_Positive_Romaji_Potential = "n/a";
            v.Plain_Negative_Romaji_Potential = "n/a";
            v.Polite_Positive_Romaji_Potential = "n/a";
            v.Polite_Negative_Romaji_Potential = "n/a";

            //Causative - No Tense
            v.Plain_Positive_Romaji_Causative = "seru";
            v.Plain_Negative_Romaji_Causative = "senai";
            v.Polite_Positive_Romaji_Causative = "semasu";
            v.Polite_Negative_Romaji_Causative = "semasen";

            //Passive - No Tense
            v.Plain_Positive_Romaji_Passive = "reru";
            v.Plain_Negative_Romaji_Passive = "renai";
            v.Polite_Positive_Romaji_Passive = "remasu";
            v.Polite_Negative_Romaji_Passive = "remasen";
            #endregion
            #region Hiragana
            //Indicative - Present
            v.Present_Plain_Positive_Kana_Indicative = "る";
            v.Present_Polite_Positive_Kana_Indicative = "ます";
            v.Present_Plain_Negative_Kana_Indicative = "ない";
            v.Present_Polite_Negative_Kana_Indicative = "ません";

            //Indicative - Past 
            v.Past_Plain_Positive_Kana_Indicative = "た";
            v.Past_Polite_Positive_Kana_Indicative = "ました";
            v.Past_Plain_Negative_Kana_Indicative = "なかった";
            v.Past_Polite_Negative_Kana_Indicative = "ませんでした";

            //Presumptive - Present
            v.Present_Plain_Positive_Kana_Volitional = "ろう";
            v.Present_Plain_Negative_Kana_Volitional = "ないだろう";
            v.Present_Polite_Positive_Kana_Volitional = "ましょう";
            v.Present_Polite_Negative_Kana_Volitional = "ないでしょう";

            //Presumptive - Past
            v.Past_Plain_Positive_Kana_Volitional = "たろう";
            v.Past_Plain_Negative_Kana_Volitional = "なかっただろう";
            v.Past_Polite_Positive_Kana_Volitional = "たでしょう";
            v.Past_Polite_Negative_Kana_Volitional = "なかったでしょう";

            //Imperative - No Tense 
            v.Plain_Positive_Kana_Imperative = "て";
            v.Plain_Negative_Kana_Imperative = "るな";
            v.Polite_Positive_Kana_Imperative = "ましてください";
            v.Polite_Negative_Kana_Imperative = "ないでください";

            //Progressive - Present
            v.Present_Plain_Positive_Kana_Progressive = "ている";
            v.Present_Plain_Negative_Kana_Progressive = "ていない"; //According to http://www.japaneseverbconjugator.com/VerbDetails.asp?JapaneseVerb=mitomeru&VerbClass=2&EnglishVerb=admit,%20recognize, does not exist
            v.Present_Polite_Positive_Kana_Pogressive = "ています";
            v.Present_Polite_Negative_Kana_Progressive = "ていません";

            //Progressive - Past
            v.Past_Plain_Positive_Kana_Progressive = "ていた";
            v.Past_Plain_Negative_Kana_Progressive = "ていなかった"; //According to above, does not exist 
            v.Past_Polite_Positive_Kana_Pogressive = "ていました";
            v.Past_Polite_Negative_Kana_Progressive = "ていませんでした";

            //Provisional ~eba - No Tense
            v.Plain_Positive_Kana_Provisional = "れば";
            v.Plain_Negative_Kana_Provisional = "なければ";
            v.Polite_Positive_Kana_Provisional = "ませば";
            v.Polite_Negative_Kana_Provisional = "ませんなら";

            //Conditional -tara - No Tense
            v.Plain_Positive_Kana_Conditional = "たら";
            v.Plain_Negative_Kana_Conditional = "なかったら";
            v.Polite_Positive_Kana_Conditional = "ましたら";
            v.Polite_Negative_Kana_Conditional = "ませんでしたら";

            //Potential - No Tense
            v.Plain_Positive_Kana_Potential = "n/a";
            v.Plain_Negative_Kana_Potential = "n/a";
            v.Polite_Positive_Kana_Potential = "n/a";
            v.Polite_Negative_Kana_Potential = "n/a";

            //Causative - No Tense
            v.Plain_Positive_Kana_Causative = "せる";
            v.Plain_Negative_Kana_Causative = "せない";
            v.Polite_Positive_Kana_Causative = "せます";
            v.Polite_Negative_Kana_Causative = "せません";

            //Passive - No Tense
            v.Plain_Positive_Kana_Passive = "れる";
            v.Plain_Negative_Kana_Passive = "れない";
            v.Polite_Positive_Kana_Passive = "れます";
            v.Polite_Negative_Kana_Passive = "れません";
            #endregion
        }


        //TODO not implemented. Need to find proper conjugations of Kou online.
        public static void conjKou(Verb v) {
            v.infinitiveKana = v.dictionary; //なななする　→　なななす
            v.infinitiveRomaji = v.baseRoma; //nananasuru -> nananasu
            v.teKana = "て";
            v.teRomaji = "te";

            #region Romaji
            //Indicative - Present
            v.Present_Plain_Positive_Romaji_Indicative = "ru";
            v.Present_Polite_Positive_Romaji_Indicative = "masu";
            v.Present_Plain_Negative_Romaji_Indicative = "nai";
            v.Present_Polite_Negative_Romaji_Indicative = "masen";

            //Indicative - Past 
            v.Past_Plain_Positive_Romaji_Indicative = "ta";
            v.Past_Polite_Positive_Romaji_Indicative = "mashita";
            v.Past_Plain_Negative_Romaji_Indicative = "nakatta";
            v.Past_Polite_Negative_Romaji_Indicative = "masen deshita";

            //Presumptive - Present
            v.Present_Plain_Positive_Romaji_Volitional = "rou";
            v.Present_Plain_Negative_Romaji_Volitional = "nai darou";
            v.Present_Polite_Positive_Romaji_Volitional = "mashou";
            v.Present_Polite_Negative_Romaji_Volitional = "nai deshou";

            //Presumptive - Past
            v.Past_Plain_Positive_Romaji_Volitional = "tarou";
            v.Past_Plain_Negative_Romaji_Volitional = "nakatta darou";
            v.Past_Polite_Positive_Romaji_Volitional = "ta deshou";
            v.Past_Polite_Negative_Romaji_Volitional = "nakatta deshou";

            //Imperative - No Tense 
            v.Plain_Positive_Romaji_Imperative = "te";
            v.Plain_Negative_Romaji_Imperative = "runa";
            v.Polite_Positive_Romaji_Imperative = "mashite kudasai";
            v.Polite_Negative_Romaji_Imperative = "naide kudasai";

            //Progressive - Present
            v.Present_Plain_Positive_Romaji_Progressive = "te iru";
            v.Present_Plain_Negative_Romaji_Progressive = "te inai"; //According to http://www.japaneseverbconjugator.com/VerbDetails.asp?JapaneseVerb=mitomeru&VerbClass=2&EnglishVerb=admit,%20recognize, does not exist
            v.Present_Polite_Positive_Romaji_Pogressive = "te imasu";
            v.Present_Polite_Negative_Romaji_Progressive = "te imasen";

            //Progressive - Past
            v.Past_Plain_Positive_Romaji_Progressive = "te ita";
            v.Past_Plain_Negative_Romaji_Progressive = "te inakatta"; //According to above, does not exist 
            v.Past_Polite_Positive_Romaji_Pogressive = "te imashita";
            v.Past_Polite_Negative_Romaji_Progressive = "te imasen deshita";

            //Provisional ~eba - No Tense
            v.Plain_Positive_Romaji_Provisional = "reba";
            v.Plain_Negative_Romaji_Provisional = "nakereba";
            v.Polite_Positive_Romaji_Provisional = "maseba";
            v.Polite_Negative_Romaji_Provisional = "masen nara";

            //Conditional -tara - No Tense
            v.Plain_Positive_Romaji_Conditional = "tara";
            v.Plain_Negative_Romaji_Conditional = "nakattara";
            v.Polite_Positive_Romaji_Conditional = "mashitara";
            v.Polite_Negative_Romaji_Conditional = "masen deshitara";

            //Potential - No Tense
            v.Plain_Positive_Romaji_Potential = "n/a";
            v.Plain_Negative_Romaji_Potential = "n/a";
            v.Polite_Positive_Romaji_Potential = "n/a";
            v.Polite_Negative_Romaji_Potential = "n/a";

            //Causative - No Tense
            v.Plain_Positive_Romaji_Causative = "seru";
            v.Plain_Negative_Romaji_Causative = "senai";
            v.Polite_Positive_Romaji_Causative = "semasu";
            v.Polite_Negative_Romaji_Causative = "semasen";

            //Passive - No Tense
            v.Plain_Positive_Romaji_Passive = "reru";
            v.Plain_Negative_Romaji_Passive = "renai";
            v.Polite_Positive_Romaji_Passive = "remasu";
            v.Polite_Negative_Romaji_Passive = "remasen";
            #endregion
        }

        //TODO NYI
        public static void conjOssharu(Verb v) {
            v.infinitiveKana = v.dictionary; //なななする　→　なななす
            v.infinitiveRomaji = v.baseRoma; //nananasuru -> nananasu
            v.teKana = "て";
            v.teRomaji = "te";

            #region Romaji
            //Indicative - Present
            v.Present_Plain_Positive_Romaji_Indicative = "ossharu";
            v.Present_Polite_Positive_Romaji_Indicative = "osshaimasu";
            v.Present_Plain_Negative_Romaji_Indicative = "nai";
            v.Present_Polite_Negative_Romaji_Indicative = "masen";

            //Indicative - Past 
            v.Past_Plain_Positive_Romaji_Indicative = "ta";
            v.Past_Polite_Positive_Romaji_Indicative = "mashita";
            v.Past_Plain_Negative_Romaji_Indicative = "nakatta";
            v.Past_Polite_Negative_Romaji_Indicative = "masen deshita";

            //Presumptive - Present
            v.Present_Plain_Positive_Romaji_Volitional = "rou";
            v.Present_Plain_Negative_Romaji_Volitional = "nai darou";
            v.Present_Polite_Positive_Romaji_Volitional = "mashou";
            v.Present_Polite_Negative_Romaji_Volitional = "nai deshou";

            //Presumptive - Past
            v.Past_Plain_Positive_Romaji_Volitional = "tarou";
            v.Past_Plain_Negative_Romaji_Volitional = "nakatta darou";
            v.Past_Polite_Positive_Romaji_Volitional = "ta deshou";
            v.Past_Polite_Negative_Romaji_Volitional = "nakatta deshou";

            //Imperative - No Tense 
            v.Plain_Positive_Romaji_Imperative = "te";
            v.Plain_Negative_Romaji_Imperative = "runa";
            v.Polite_Positive_Romaji_Imperative = "mashite kudasai";
            v.Polite_Negative_Romaji_Imperative = "naide kudasai";

            //Progressive - Present
            v.Present_Plain_Positive_Romaji_Progressive = "te iru";
            v.Present_Plain_Negative_Romaji_Progressive = "te inai"; //According to http://www.japaneseverbconjugator.com/VerbDetails.asp?JapaneseVerb=mitomeru&VerbClass=2&EnglishVerb=admit,%20recognize, does not exist
            v.Present_Polite_Positive_Romaji_Pogressive = "te imasu";
            v.Present_Polite_Negative_Romaji_Progressive = "te imasen";

            //Progressive - Past
            v.Past_Plain_Positive_Romaji_Progressive = "te ita";
            v.Past_Plain_Negative_Romaji_Progressive = "te inakatta"; //According to above, does not exist 
            v.Past_Polite_Positive_Romaji_Pogressive = "te imashita";
            v.Past_Polite_Negative_Romaji_Progressive = "te imasen deshita";

            //Provisional ~eba - No Tense
            v.Plain_Positive_Romaji_Provisional = "reba";
            v.Plain_Negative_Romaji_Provisional = "nakereba";
            v.Polite_Positive_Romaji_Provisional = "maseba";
            v.Polite_Negative_Romaji_Provisional = "masen nara";

            //Conditional -tara - No Tense
            v.Plain_Positive_Romaji_Conditional = "tara";
            v.Plain_Negative_Romaji_Conditional = "nakattara";
            v.Polite_Positive_Romaji_Conditional = "mashitara";
            v.Polite_Negative_Romaji_Conditional = "masen deshitara";

            //Potential - No Tense
            v.Plain_Positive_Romaji_Potential = "n/a";
            v.Plain_Negative_Romaji_Potential = "n/a";
            v.Polite_Positive_Romaji_Potential = "n/a";
            v.Polite_Negative_Romaji_Potential = "n/a";

            //Causative - No Tense
            v.Plain_Positive_Romaji_Causative = "seru";
            v.Plain_Negative_Romaji_Causative = "senai";
            v.Polite_Positive_Romaji_Causative = "semasu";
            v.Polite_Negative_Romaji_Causative = "semasen";

            //Passive - No Tense
            v.Plain_Positive_Romaji_Passive = "reru";
            v.Plain_Negative_Romaji_Passive = "renai";
            v.Polite_Positive_Romaji_Passive = "remasu";
            v.Polite_Negative_Romaji_Passive = "remasen";
            #endregion
        }

    }
}
