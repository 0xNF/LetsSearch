using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Windows.Storage;

namespace JDictU.Model {

    public class KanjiLookupPageModel {

        private const string kradfile = "kradfile-u.txt";

        private static Dictionary<string, List<string>> radicals { get; set; }

        public readonly static Dictionary<int, List<string>> radDict = new Dictionary<int, List<string>>() {
            { 1, new List<String>() { "一", "｜", "丶", "ノ", "乙", "亅" } },
            { 2, new List<String>() { "二", "亠", "人", "𠆢", "儿", "入", "𠆢", "ハ", "冂", "冖", "冫", "几", "凵", "刀", "刂", "力", "勹", "匕", "匚", "十", "卜", "卩", "厂", "厶", "又", "𠆢", "マ", "九", "ユ", "乃", "刂" } },
            { 3, new List<String>() { "亡", "口", "囗", "土", "士", "夂", "夕", "大", "女", "子", "宀", "寸", "小", "⺌", "尢", "尤", "尸", "屮", "山", "巛", "川", "工", "已", "巾", "干", "幺", "广", "廴", "廾", "弋", "弓", "彑", "彡", "彳", "邑", "⻏", "⻖", "⺌", "川", "彑", "也", "亡", "及", "久", "忄", "扌", "氵", "犭" } },
            { 4, new List<String>() { "心", "忄", "戈", "戸", "手", "扌", "支", "攵", "文", "斗", "斤", "方", "无", "日", "曰", "月", "木", "欠", "止", "歹", "殳", "毋", "母", "比", "毛", "氏", "气", "水", "氵", "火", "灬", "爪", "父", "爻", "爿", "片", "牛", "犬", "犭", "王", "⺹", "灬", "元", "井", "勿", "尤", "五", "屯", "巴", "礻" } },
            { 5, new List<String>() { "牙", "玄", "瓦", "甘", "生", "用", "田", "疋", "疒", "癶", "白", "皮", "皿", "目", "矛", "矢", "石", "示", "礻", "禸", "禾", "穴", "立", "罒", "衤", "世", "巨", "冊", "母" } },
            { 6, new List<String>() { "瓜", "竹", "米", "糸", "缶", "羊", "羽", "而", "耒", "耳", "聿", "肉", "月", "自", "至", "臼", "舌", "舟", "艮", "色", "虍", "虫", "血", "行", "衣", "衤", "西" } },
            { 7, new List<String>() { "臣", "舛", "見", "角", "言", "谷", "豆", "豕", "豸", "貝", "赤", "走", "足", "身", "車", "辛", "辰", "酉", "釆", "里", "麦" } },
            { 8, new List<String>() { "金", "長", "門", "隶", "隹", "雨", "青", "非", "奄", "岡", "免", "斉" } },
            { 9, new List<String>() { "面", "革", "韭", "音", "頁", "風", "飛", "食", "首", "香", "品" } },
            { 10, new List<String>() { "韋", "馬", "骨", "高", "髟", "鬥", "鬯", "鬲", "鬼", "竜" } },
            { 11, new List<String>() { "魚", "鳥", "鹵", "鹿", "麻", "黄", "黒", "亀" } },
            { 12, new List<String>() { "黍", "黹", "歯", "無" } },
            { 13, new List<String>() { "黽", "鼎", "鼓", "鼠" } },
            { 14, new List<String>() { "鼻", "齊" } },
            { 17, new List<String>() { "龠" } }
        };

        #region allRads
        private readonly static List<string> allRads = new List<string>() {
            "長",
            "亠",
"品",
"乙",
"羊",
"士",
"癶",
"巾",
"亀",
"臼",
"飛",
"耳",
"鼻",
"滴",
"卜",
"方",
"角",
"火",
"⻖",
"行",
"食",
"鬥",
"毛",
"黹",
"鬲",
"井",
"氏",
"尤",
"巴",
"虫",
"卩",
"瓜",
"鼠",
"忄",
"⺌",
"尸",
"鬯",
"勿",
"儿",
"非",
"韭",
"里",
"乃",
"身",
"見",
"齊",
"文",
"石",
"疒",
"人",
"豆",
"青",
"屯",
"頁",
"走",
"山",
"⻏",
"足",
"雨",
"𠆢",
"黒",
"ヨ",
"風",
"戈",
"瓦",
"匕",
"立",
"高",
"及",
"黽",
"羽",
"扌",
"冖",
"穴",
"尢",
"鬼",
"玄",
"鼓",
"虍",
"亡",
"比",
"衤",
"西",
"隶",
"龠",
"二",
"口",
"斤",
"鹿",
"髟",
"手",
"｜",
"大",
"弋",
"竹",
"目",
"心",
"彡",
"冫",
"五",
"鳥",
"父",
"弓",
"入",
"日",
"宀",
"禸",
"刀",
"麦",
"小",
"斉",
"矢",
"ユ",
"貝",
"皮",
"⺅",
"刂",
"衣",
"巨",
"豕",
"工",
"巛",
"母",
"元",
"禾",
"欠",
"囗",
"至",
"舌",
"門",
"谷",
"并",
"干",
"夕",
"皿",
"牙",
"自",
"豸",
"歯",
"片",
"韋",
"色",
"無",
"辶",
"缶",
"血",
"戸",
"歹",
"疋",
"罒",
"馬",
"勹",
"香",
"川",
"廾",
"舟",
"毋",
"鼎",
"舛",
"女",
"匚",
"夂",
"免",
"麻",
"白",
"マ",
"王",
"而",
"一",
"十",
"釆",
"月",
"无",
"久",
"首",
"魚",
"彳",
"厶",
"車",
"辰",
"矛",
"⺹",
"礻",
"斗",
"田",
"竜",
"ハ",
"支",
"子",
"ノ",
"金",
"示",
"酉",
"九",
"凵",
"糸",
"灬",
"牛",
"攵",
"爪",
"冂",
"水",
"氵",
"世",
"辛",
"犬",
"爻",
"廴",
"骨",
"革",
"土",
"邑",
"犭",
"已",
"言",
"艮",
"臣",
"也",
"几",
"曰",
"幺",
"气",
"岡",
"音",
"丶",
"亅",
"⺾",
"生",
"冊",
"黄",
"赤",
"又",
"耒",
"屮",
"殳",
"鹵",
"止",
"黍",
"厂",
"力",
"肉",
"寸",
"广",
"爿",
"聿",
"奄",
"面",
"木",
"彑",
"用",
"米",
"甘",
"隹"
        };

        #endregion

        //Kradfile.prepare_radikals()
        private async static Task<Dictionary<string, List<string>>> prepareRadicals() {
            if(radicals == null) {
                Dictionary<string, List<string>> results = new Dictionary<string, List<string>>();
                StorageFile sf = await ApplicationData.Current.LocalFolder.GetFileAsync(kradfile);
                IList<string> lines = await FileIO.ReadLinesAsync(sf, Windows.Storage.Streams.UnicodeEncoding.Utf8);
                foreach (string line in lines) {
                    if (line != "" && !line.StartsWith("#")) {
                        string[] splits = line.Split(':');
                        //results[splits[0].Trim()] = splits[1].Split(' ').Where(x => x != "").ToList(); /* caused a number of allocations that were unnecessary. */
                        List<string> nonEmpty = new List<string>();
                        foreach (string s in splits[1].Split(' ')) {
                            if(!s.Equals("")) {
                                nonEmpty.Add(s);
                            }
                        }
                        results[splits[0].Trim()] = nonEmpty;
                    }
                }
                return results;
            }

            return radicals;;
        }

        //get_RadicalsFromKanji
        public static List<string> getRadicalsFromKanji(string kanji) {
            if (radicals.ContainsKey(kanji)) {
                return radicals[kanji];
            }
            else {
                return new List<string>();
            }
        }

        //kanjiForRadical
        //Returns a list of kanji that can be assembled using this radical
        public static List<string> kanjisForRadical(string rad) {
            List<string> kanji = new List<string>();
            foreach (KeyValuePair<string, List<string>> kvp in radicals) {
                if (kvp.Value.Contains(rad)) {
                    kanji.Add(kvp.Key);
                }
            }
            return kanji;
        }

        //kanjiForRadicals
        //returns a list of kanji that can be assembled with these radicals
        public static List<string> kanjiForRadicals(List<string> radList) {
            List<string> kanji = new List<string>();
            foreach (KeyValuePair<string, List<string>> kvp in radicals) {
                bool append = true;
                foreach(string rad in radList) {
                    if (!kvp.Value.Contains(rad)) {
                        append = false;
                        break;
                    }
                }
                if (append) {
                    kanji.Add(kvp.Key);
                }
            }
            return kanji.Distinct().ToList();
        }

        //validRadsStartingWith
        //Returns the list of radicals that can be used in conjunction with the suppled radicals
        public static List<string> validRadsWithTheseRad(List<string> radList) {
            List<string> kanjis = kanjiForRadicals(radList);
            IEnumerable<string> retRads = new List<string>();
            foreach(string k in kanjis) {
                List<string> rads = radicals[k];
                retRads = retRads.Union(rads);
            }
            return retRads.Distinct().ToList();

        }


        public KanjiLookupPageModel() {
        }

        public static async Task prepareModel() {
            radicals = await prepareRadicals();
        }

    }
}
