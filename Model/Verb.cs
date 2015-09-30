using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;

namespace JDictU.Model
{
    public class Verb {
        public type verbtype { get; set; }
        public int entry_id { get; set; }
        public string baseRoma { get; set; } //Romaji of dictionary form -> sagasu
        public string dictionary { get; set; } //Full dictionary form -> さがす
        public string stemKana { get; set; } //Stem is the part before the verb marker. Stem of さがす is さが
        public string endMarkerKana { get; set; } //Counter part of stem, endMarker of さがす is す
        public string pronounciationKana { get; set; } //stem.endMarker -> さが.す
        public string stemRomaji { get; set; } //Stem is the part before the verb marker. Stem of sagasu is saga
        public string endMarkerRomaji { get; set; } //Counter part of stem, endMarker of sagasu is su
        public string pronounciationRomaji { get; set; } //stem.endMarker -> saga.su
        public string teKana { get; set; } //command, connection
        public string teRomaji { get; set; }
        public string infinitiveKana { get; set; }
        public string infinitiveRomaji { get; set; }

        //Chau - Present
        public string Present_Plain_Positive_Kana_Chau { get; set; }
        public string Present_Polite_Positive_Kana_Chau { get; set; }
        public string Present_Plain_Negative_Kana_Chau { get; set; }
        public string Present_Polite_Negative_Kana_Chau { get; set; }

        public string Present_Plain_Positive_Romaji_Chau { get; set; }
        public string Present_Polite_Positive_Romaji_Chau { get; set; }
        public string Present_Plain_Negative_Romaji_Chau { get; set; }
        public string Present_Polite_Negative_Romaji_Chau { get; set; }

        //Chau - Past
        public string Past_Plain_Positive_Kana_Chau { get; set; }
        public string Past_Polite_Positive_Kana_Chau { get; set; }
        public string Past_Plain_Negative_Kana_Chau { get; set; }
        public string Past_Polite_Negative_Kana_Chau { get; set; }

        public string Past_Plain_Positive_Romaji_Chau { get; set; }
        public string Past_Polite_Positive_Romaji_Chau { get; set; }
        public string Past_Plain_Negative_Romaji_Chau { get; set; }
        public string Past_Polite_Negative_Romaji_Chau { get; set; }


        //Indicative - Present
        public string Present_Plain_Positive_Kana_Indicative { get; set; }
        public string Present_Polite_Positive_Kana_Indicative { get; set; }
        public string Present_Plain_Negative_Kana_Indicative { get; set; }
        public string Present_Polite_Negative_Kana_Indicative { get; set; }

        public string Present_Plain_Positive_Romaji_Indicative { get; set; }
        public string Present_Polite_Positive_Romaji_Indicative { get; set; }
        public string Present_Plain_Negative_Romaji_Indicative { get; set; }
        public string Present_Polite_Negative_Romaji_Indicative { get; set; }

        //Indicative - Past
        public string Past_Plain_Positive_Kana_Indicative { get; set; }
        public string Past_Polite_Positive_Kana_Indicative { get; set; }
        public string Past_Plain_Negative_Kana_Indicative { get; set; }
        public string Past_Polite_Negative_Kana_Indicative { get; set; }

        public string Past_Plain_Positive_Romaji_Indicative { get; set; }
        public string Past_Polite_Positive_Romaji_Indicative { get; set; }
        public string Past_Plain_Negative_Romaji_Indicative { get; set; }
        public string Past_Polite_Negative_Romaji_Indicative { get; set; }

        //Presumptive - Present
        public string Present_Plain_Positive_Kana_Volitional { get; set; }
        public string Present_Plain_Negative_Kana_Volitional { get; set; }
        public string Present_Polite_Positive_Kana_Volitional { get; set; }
        public string Present_Polite_Negative_Kana_Volitional { get; set; }

        public string Present_Plain_Positive_Romaji_Volitional { get; set; }
        public string Present_Plain_Negative_Romaji_Volitional { get; set; }
        public string Present_Polite_Positive_Romaji_Volitional { get; set; }
        public string Present_Polite_Negative_Romaji_Volitional { get; set; }

        //Presumptive - Past
        public string Past_Plain_Positive_Kana_Volitional { get; set; }
        public string Past_Plain_Negative_Kana_Volitional { get; set; }
        public string Past_Polite_Positive_Kana_Volitional { get; set; }
        public string Past_Polite_Negative_Kana_Volitional { get; set; }

        public string Past_Plain_Positive_Romaji_Volitional { get; set; }
        public string Past_Plain_Negative_Romaji_Volitional { get; set; }
        public string Past_Polite_Positive_Romaji_Volitional { get; set; }
        public string Past_Polite_Negative_Romaji_Volitional { get; set; }

        //Imperative - No Tense
        public string Plain_Positive_Kana_Imperative { get; set; }
        public string Plain_Negative_Kana_Imperative { get; set; }
        public string Polite_Positive_Kana_Imperative { get; set; }
        public string Polite_Negative_Kana_Imperative { get; set; }

        public string Plain_Positive_Romaji_Imperative { get; set; }
        public string Plain_Negative_Romaji_Imperative { get; set; }
        public string Polite_Positive_Romaji_Imperative { get; set; }
        public string Polite_Negative_Romaji_Imperative { get; set; }

        //Progressive - Present
        public string Present_Plain_Positive_Kana_Progressive { get; set; }
        public string Present_Plain_Negative_Kana_Progressive { get; set; }
        public string Present_Polite_Positive_Kana_Pogressive { get; set; }
        public string Present_Polite_Negative_Kana_Progressive { get; set; }

        public string Present_Plain_Positive_Romaji_Progressive { get; set; }
        public string Present_Plain_Negative_Romaji_Progressive { get; set; }
        public string Present_Polite_Positive_Romaji_Pogressive { get; set; }
        public string Present_Polite_Negative_Romaji_Progressive { get; set; }

        //Progressive - Past
        public string Past_Plain_Positive_Kana_Progressive { get; set; }
        public string Past_Plain_Negative_Kana_Progressive { get; set; }
        public string Past_Polite_Positive_Kana_Pogressive { get; set; }
        public string Past_Polite_Negative_Kana_Progressive { get; set; }

        public string Past_Plain_Positive_Romaji_Progressive { get; set; }
        public string Past_Plain_Negative_Romaji_Progressive { get; set; }
        public string Past_Polite_Positive_Romaji_Pogressive { get; set; }
        public string Past_Polite_Negative_Romaji_Progressive { get; set; }

        //Provisional ~eba - No Tense
        public string Plain_Positive_Kana_Provisional { get; set; }
        public string Plain_Negative_Kana_Provisional { get; set; }
        public string Polite_Positive_Kana_Provisional { get; set; }
        public string Polite_Negative_Kana_Provisional { get; set; }

        public string Plain_Positive_Romaji_Provisional { get; set; }
        public string Plain_Negative_Romaji_Provisional { get; set; }
        public string Polite_Positive_Romaji_Provisional { get; set; }
        public string Polite_Negative_Romaji_Provisional { get; set; }

        //Conditional -tara - No Tense
        public string Plain_Positive_Kana_Conditional { get; set; }
        public string Plain_Negative_Kana_Conditional { get; set; }
        public string Polite_Positive_Kana_Conditional { get; set; }
        public string Polite_Negative_Kana_Conditional { get; set; }

        public string Plain_Positive_Romaji_Conditional { get; set; }
        public string Plain_Negative_Romaji_Conditional { get; set; }
        public string Polite_Positive_Romaji_Conditional { get; set; }
        public string Polite_Negative_Romaji_Conditional { get; set; }

        //Potential - No Tense
        public string Plain_Positive_Kana_Potential { get; set; }
        public string Plain_Negative_Kana_Potential { get; set; }
        public string Polite_Positive_Kana_Potential { get; set; }
        public string Polite_Negative_Kana_Potential { get; set; }

        public string Plain_Positive_Romaji_Potential { get; set; }
        public string Plain_Negative_Romaji_Potential { get; set; }
        public string Polite_Positive_Romaji_Potential { get; set; }
        public string Polite_Negative_Romaji_Potential { get; set; }

        //Causative - No Tense
        public string Plain_Positive_Kana_Causative { get; set; }
        public string Plain_Negative_Kana_Causative { get; set; }
        public string Polite_Positive_Kana_Causative { get; set; }
        public string Polite_Negative_Kana_Causative { get; set; }

        public string Plain_Positive_Romaji_Causative { get; set; }
        public string Plain_Negative_Romaji_Causative { get; set; }
        public string Polite_Positive_Romaji_Causative { get; set; }
        public string Polite_Negative_Romaji_Causative { get; set; }

        //Passive - No Tense
        public string Plain_Positive_Kana_Passive { get; set; }
        public string Plain_Negative_Kana_Passive { get; set; }
        public string Polite_Positive_Kana_Passive { get; set; }
        public string Polite_Negative_Kana_Passive { get; set; }

        public string Plain_Positive_Romaji_Passive { get; set; }
        public string Plain_Negative_Romaji_Passive { get; set; }
        public string Polite_Positive_Romaji_Passive { get; set; }
        public string Polite_Negative_Romaji_Passive { get; set; }

        public enum type {
            Godan,
            Ichidan,
            Irregular
        };

        public static Verb makeVerb(SearchResult sr) {
            return Verb.conjugate(sr);
        }

        private static Verb conjugate(SearchResult sr) {
            var v = new Verb(sr);
            if (v.verbtype == type.Godan) {
                Conjugator.conjReg1(v);
            }
            else if (v.verbtype == type.Ichidan) {
                Conjugator.conjReg2(v);
            }
            else {
                Conjugator.conjIrreg(v);
            }
            return v;
        }



        public Verb(SearchResult sr) {
            foreach (string pos in sr.pos) {
                if (pos.Contains("Godan verb")) {
                    verbtype = type.Godan;
                    break;
                }
                else if (pos.Contains("Ichidan verb")) {
                    verbtype = type.Ichidan;
                    break;
                }
                else if (pos.Contains("irregular") || pos.Contains("Kuru verb")) {
                    verbtype = type.Irregular;
                    break;
                }
            }

            var krm = sr.getKanaRomaMap()[0];
            dictionary = krm.Item1; //TODO assumption is that the first kana is the dictionary form
            baseRoma = krm.Item2;
            entry_id = sr.entry_id;
            stemKana = dictionary.Substring(0, dictionary.Length - 1); //takes off る
            endMarkerKana = dictionary.Last().ToString();//.Substring(stemKana.Length-1);
            if (endMarkerKana == "う" || endMarkerKana == "ウ") {
                stemRomaji = baseRoma.Substring(0, baseRoma.Length - 1);
                endMarkerRomaji = baseRoma.Substring(baseRoma.Length - 1);
            }
            else {
                stemRomaji = baseRoma.Substring(0, baseRoma.Length - 2); //takes off -ru
                endMarkerRomaji = baseRoma.Substring(baseRoma.Length - 2);
            }
            pronounciationKana = stemKana + "." + endMarkerKana;
            pronounciationRomaji = stemRomaji + "." + endMarkerRomaji;

        }
 
        public override string ToString() {
            var retstr = new List<string> {
                String.Format(
                    "VerbType: {0}\nentry_id: {1}\nbaseRoma: {2}\ndictionary: {3}\nstemKana: {4}\nendMarkerKana: {5}\nPronounciationKana: {6}\nPronounciationRomaji: {7}\nstemRomaji: {8}\nendMarkerRomaji: {9}\n",
                    verbtype, entry_id, baseRoma, dictionary, stemKana, endMarkerKana, pronounciationKana,
                    pronounciationRomaji, stemRomaji, endMarkerRomaji),

                String.Format("teKana: {0}\nteRomaji: {1}\ninfinitiveKana: {2}\ninfinitiveRomaji: {3}",
                    teKana, teRomaji, infinitiveKana, infinitiveRomaji),

                String.Format(
                    "Present_Plain_Positive_Kana_Indicative: {0}\nPresent_Polite_Positive_Kana_Indicative: {1}\nPresent_Plain_Negative_Kana_Indicative: {2}\nPresent_Polite_Negative_Kana_Indicative: {3}",
                    Present_Plain_Positive_Kana_Indicative, Present_Polite_Positive_Kana_Indicative,
                    Present_Plain_Negative_Kana_Indicative, Present_Polite_Negative_Kana_Indicative),
            
                String.Format(
                    "Present_Plain_Positive_Romaji_Indicative: {0}\nPresent_Polite_Positive_Romaji_Indicative: {1}\nPresent_Plain_Negative_Romaji_Indicative: {2}\nPresent_Polite_Negative_Romaji_Indicative: {3}",
                Present_Plain_Positive_Romaji_Indicative,
                Present_Polite_Positive_Romaji_Indicative,
                Present_Plain_Negative_Romaji_Indicative,
                Present_Polite_Negative_Romaji_Indicative),

                String.Format(
                    "Past_Plain_Positive_Kana_Indicative: {0}\nast_Polite_Positive_Kana_Indicative: {1}\nast_Plain_Negative_Kana_Indicative: {2}\nast_Polite_Negative_Kana_Indicative: {3}",
                    Past_Plain_Positive_Kana_Indicative, Past_Polite_Positive_Kana_Indicative,
                    Past_Plain_Negative_Kana_Indicative, Past_Polite_Negative_Kana_Indicative),

                String.Format(
                    "Past_Plain_Positive_Romaji_Indicative: {0}\nPast_Polite_Positive_Romaji_Indicative: {1}\nPast_Plain_Negative_Romaji_Indicative: {2}\nPast_Polite_Negative_Romaji_Indicative: {3}",
                    Past_Plain_Positive_Romaji_Indicative, Past_Polite_Positive_Romaji_Indicative,
                    Past_Plain_Negative_Romaji_Indicative, Past_Polite_Negative_Romaji_Indicative),

                String.Format(
                    "Present_Plain_Positive_Kana_Volitional: {0}\nPresent_Plain_Negative_Kana_Volitional: {1}\nPresent_Polite_Positive_Kana_Volitional: {2}\nPresent_Polite_Negative_Kana_Volitional: {3}",
                    Present_Plain_Positive_Kana_Volitional, Present_Plain_Negative_Kana_Volitional,
                    Present_Polite_Positive_Kana_Volitional, Present_Polite_Negative_Kana_Volitional),

                String.Format("Present_Plain_Positive_Romaji_Volitional: {0}\n" +
                              "Present_Plain_Negative_Romaji_Volitional: {1}\n" +
                              "Present_Polite_Positive_Romaji_Volitional: {2}\n" +
                              "Present_Polite_Negative_Romaji_Volitional: {3}",
                    Present_Plain_Positive_Romaji_Volitional,
                    Present_Plain_Negative_Romaji_Volitional,
                    Present_Polite_Positive_Romaji_Volitional,
                    Present_Polite_Negative_Romaji_Volitional),

                String.Format("Past_Plain_Positive_Kana_Volitional: {0}\n" +
                              "Past_Plain_Negative_Kana_Volitional: {1}\n" +
                              "Past_Polite_Positive_Kana_Volitional: {2}\n" +
                              "Past_Polite_Negative_Kana_Volitional: {3}",
                    Past_Plain_Positive_Kana_Volitional,
                    Past_Plain_Negative_Kana_Volitional,
                    Past_Polite_Positive_Kana_Volitional,
                    Past_Polite_Negative_Kana_Volitional),

                String.Format("Past_Plain_Positive_Romaji_Volitional: {0}\n" +
                              "Past_Plain_Negative_Romaji_Volitional: {1}\n" +
                              "Past_Polite_Positive_Romaji_Volitional: {2}\n" +
                              "Past_Polite_Negative_Romaji_Volitional: {3}",
                    Past_Plain_Positive_Romaji_Volitional,
                    Past_Plain_Negative_Romaji_Volitional,
                    Past_Polite_Positive_Romaji_Volitional,
                    Past_Polite_Negative_Romaji_Volitional),


                //Imperative - No Tense
                String.Format("Plain_Positive_Kana_Imperative: {0}\n" +
                              "Plain_Negative_Kana_Imperative: {1}\n" +
                              "Polite_Positive_Kana_Imperative: {2}\n" +
                              "Past_Polite_Negative_Romaji_Volitional: {3}",
                    Plain_Positive_Kana_Imperative,
                    Plain_Negative_Kana_Imperative,
                    Polite_Positive_Kana_Imperative,
                    Polite_Negative_Kana_Imperative),
                String.Format("Plain_Positive_Romaji_Imperative: {0}\n" +
                              "Plain_Negative_Romaji_Imperative: {1}\n" +
                              "Polite_Positive_Romaji_Imperative: {2}\n" +
                              "Polite_Negative_Romaji_Imperative: {3}",
                    Plain_Positive_Romaji_Imperative,
                    Plain_Negative_Romaji_Imperative,
                    Polite_Positive_Romaji_Imperative,
                    Polite_Negative_Romaji_Imperative),

                //Progressive - Present
                String.Format("Present_Plain_Positive_Kana_Progressive: {0}\n" +
                              "Present_Plain_Negative_Kana_Progressive: {1}\n" +
                              "Present_Polite_Positive_Kana_Pogressive: {2}\n" +
                              "Present_Polite_Negative_Kana_Progressive: {3}",
                    Present_Plain_Positive_Kana_Progressive,
                    Present_Plain_Negative_Kana_Progressive,
                    Present_Polite_Positive_Kana_Pogressive,
                    Present_Polite_Negative_Kana_Progressive),

                String.Format("Present_Plain_Positive_Romaji_Progressive: {0}\n" +
                              "Present_Plain_Negative_Romaji_Progressive: {1}\n" +
                              "Present_Polite_Positive_Romaji_Pogressive: {2}\n" +
                              "Present_Polite_Negative_Romaji_Progressive: {3}",
                    Present_Plain_Positive_Romaji_Progressive,
                    Present_Plain_Negative_Romaji_Progressive,
                    Present_Polite_Positive_Romaji_Pogressive,
                    Present_Polite_Negative_Romaji_Progressive),

                //Progressive - Past
                String.Format("Past_Plain_Positive_Kana_Progressive: {0}\n" +
                              "Past_Plain_Negative_Kana_Progressive: {1}\n" +
                              "Past_Polite_Positive_Kana_Pogressive: {2}\n" +
                              "Past_Polite_Negative_Kana_Progressive: {3}",
                    Past_Plain_Positive_Kana_Progressive,
                    Past_Plain_Negative_Kana_Progressive,
                    Past_Polite_Positive_Kana_Pogressive,
                    Past_Polite_Negative_Kana_Progressive),
                String.Format("Past_Plain_Positive_Romaji_Progressive: {0}\n" +
                              "Past_Plain_Negative_Romaji_Progressive: {1}\n" +
                              "Past_Polite_Positive_Romaji_Pogressive: {2}\n" +
                              "Past_Polite_Negative_Romaji_Volitional: {3}",
                    Past_Plain_Positive_Romaji_Progressive,
                    Past_Plain_Negative_Romaji_Progressive,
                    Past_Polite_Positive_Romaji_Pogressive,
                    Past_Polite_Negative_Romaji_Progressive),

                //Provisional ~eba - No Tense
                String.Format("Plain_Positive_Kana_Provisional: {0}\n" +
                              "Plain_Negative_Kana_Provisional: {1}\n" +
                              "Polite_Positive_Kana_Provisional: {2}\n" +
                              "Polite_Negative_Kana_Provisional: {3}",
                    Plain_Positive_Kana_Provisional,
                    Plain_Negative_Kana_Provisional,
                    Polite_Positive_Kana_Provisional,
                    Polite_Negative_Kana_Provisional),

                String.Format("Plain_Positive_Romaji_Provisional: {0}\n" +
                              "Plain_Negative_Romaji_Provisional: {1}\n" +
                              "Polite_Positive_Romaji_Provisional: {2}\n" +
                              "Polite_Negative_Romaji_Provisional: {3}",
                    Plain_Positive_Romaji_Provisional,
                    Plain_Negative_Romaji_Provisional,
                    Polite_Positive_Romaji_Provisional,
                    Polite_Negative_Romaji_Provisional),

                //Conditional -tara - No Tense
                String.Format("Plain_Positive_Kana_Conditional: {0}\n" +
                              "Plain_Negative_Kana_Conditional: {1}\n" +
                              "Polite_Positive_Kana_Conditional: {2}\n" +
                              "Polite_Negative_Kana_Conditional: {3}",
                    Plain_Positive_Kana_Conditional,
                    Plain_Negative_Kana_Conditional,
                    Polite_Positive_Kana_Conditional,
                    Polite_Negative_Kana_Conditional),

                String.Format("Plain_Positive_Romaji_Conditional: {0}\n" +
                              "Plain_Negative_Romaji_Conditional: {1}\n" +
                              "Polite_Positive_Romaji_Conditional: {2}\n" +
                              "Polite_Negative_Romaji_Conditional: {3}",
                    Plain_Positive_Romaji_Conditional,
                    Plain_Negative_Romaji_Conditional,
                    Polite_Positive_Romaji_Conditional,
                    Polite_Negative_Romaji_Conditional),

                //Potential - No Tense
                String.Format("Plain_Positive_Kana_Potential: {0}\n" +
                              "Plain_Negative_Kana_Potential: {1}\n" +
                              "Polite_Positive_Kana_Potential: {2}\n" +
                              "Polite_Negative_Kana_Potential: {3}",
                    Plain_Positive_Kana_Potential,
                    Plain_Negative_Kana_Potential,
                    Polite_Positive_Kana_Potential,
                    Polite_Negative_Kana_Potential),

                String.Format("Plain_Positive_Romaji_Potential: {0}\n" +
                              "Plain_Negative_Romaji_Potential: {1}\n" +
                              "Polite_Positive_Romaji_Potential: {2}\n" +
                              "Past_Polite_Negative_Romaji_Volitional: {3}",
                    Plain_Positive_Romaji_Potential,
                    Plain_Negative_Romaji_Potential,
                    Polite_Positive_Romaji_Potential,
                    Polite_Negative_Romaji_Potential),

                //Causative - No Tense
                String.Format("Plain_Positive_Kana_Causative: {0}\n" +
                              "Plain_Negative_Kana_Causative: {1}\n" +
                              "Polite_Positive_Kana_Causative: {2}\n" +
                              "Polite_Negative_Kana_Causative: {3}",
                    Plain_Positive_Kana_Causative,
                    Plain_Negative_Kana_Causative,
                    Polite_Positive_Kana_Causative,
                    Polite_Negative_Kana_Causative),

                String.Format("Plain_Positive_Romaji_Causative: {0}\n" +
                              "Plain_Negative_Romaji_Causative: {1}\n" +
                              "Polite_Positive_Romaji_Causative: {2}\n" +
                              "Polite_Negative_Romaji_Causative: {3}",
                    Plain_Positive_Romaji_Causative,
                    Plain_Negative_Romaji_Causative,
                    Polite_Positive_Romaji_Causative,
                    Polite_Negative_Romaji_Causative),

                //Passive - No Tense
                String.Format("Plain_Positive_Kana_Passive: {0}\n" +
                              "Plain_Negative_Kana_Passive: {1}\n" +
                              "Polite_Positive_Kana_Passive: {2}\n" +
                              "Past_Polite_Negative_Romaji_Volitional: {3}",
                    Plain_Positive_Kana_Passive,
                    Plain_Negative_Kana_Passive,
                    Polite_Positive_Kana_Passive,
                    Polite_Negative_Kana_Passive),

                String.Format("Plain_Positive_Romaji_Passive: {0}\n" +
                              "Plain_Negative_Romaji_Passive: {1}\n" +
                              "Polite_Positive_Romaji_Passive: {2}\n" +
                              "Polite_Negative_Romaji_Passive: {3}",
                    Plain_Positive_Romaji_Passive,
                    Plain_Negative_Romaji_Passive,
                    Polite_Positive_Romaji_Passive,
                    Polite_Negative_Romaji_Passive)
            };


            foreach (String s in retstr) {
                Debug.WriteLine(s);
            }
            return retstr.ToString();
        }

    }
}
