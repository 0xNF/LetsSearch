using System;
using System.Diagnostics;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Navigation;
using JDictU.Model;
using Windows.ApplicationModel.DataTransfer;
using JDictU.ViewModels;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkID=390556

namespace JDictU {
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Result : Page {

        private static ResultPageViewModel _viewmodel;

        private bool kana = true;
        private bool polite = true;
        private bool present = true;
        private bool positive = true;

        public Result() {
            this.InitializeComponent();
        }

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.
        /// This parameter is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e) {

            if (e.Parameter.GetType() == typeof(SearchResult)) {
                _viewmodel = new ResultPageViewModel((SearchResult)e.Parameter);
            }
            else if (e.Parameter is int) {
                _viewmodel = new ResultPageViewModel((int)e.Parameter);
            }
            else {
                throw new Exception("viewmodel type could not be determiend. Original link was neither a SearchResult nor an int");
            }
            _viewmodel.pr = LoadingExamples;
            _viewmodel.getExamples(_viewmodel.MainKanji).ConfigureAwait(false);
            this.DataContext = _viewmodel;
            TextBlock_KanjiSpace.DataContext = _viewmodel;
            TextBlock_Translation.DataContext = _viewmodel;
            ItemControl_ExtraKanji.ItemsSource = _viewmodel.KanjiList;
            ItemControl_Readings.ItemsSource = _viewmodel.KanaRomaMap;
            ItemControl_Properties.ItemsSource = _viewmodel.PoSList;
            ItemControl_Definitions.ItemsSource = _viewmodel.DefinitionList;
            ItemControl_Examples.ItemsSource = _viewmodel.HWSList;
            LoadingExamples.DataContext = _viewmodel.hwsview;

            if (_viewmodel.verb == null) {
                var pv = Pivot_Verb;
                pivotControl.Items.Remove(pv);
            }
            else {
                TextBlock_SoundGuide.DataContext = _viewmodel.verb;
                TextBlock_DictionaryForm.DataContext = _viewmodel.verb;
                setConjugationBlocks();
            }
            Image_Favorite.Symbol = _viewmodel.isFavorite ? Image_Favorite.Symbol = Symbol.UnFavorite : Symbol.Favorite;

        }

        //sets the blocks according to Kana,Present,Polite booleans
        private void setConjugationBlocks() {

            _viewmodel.formalText = this.polite ? "Polite" : "Plain";
            _viewmodel.kanaText = this.kana ? "Kana" : "Romaji";
            _viewmodel.tenseText = this.present ? "Present" : "Past";
            _viewmodel.agreementText = this.positive ? "Positive" : "Negative";

            //Polite Present Positive Kana
            if (polite && present && positive && kana) {
                setKanaPresentPolitePositive();
            }
            //Polite Present Positive Romaji
            else if (polite && present && positive && !kana) {
                setRomajiPresentPolitePositive();
            }
            //Polite Present Negative Kana
            else if (polite && present && !positive && kana) {
                setKanaPresentPoliteNegative();
            }
            //Polite Present Negative Romaji
            else if (polite && present && !positive && !kana) {
                setRomajiPresentPoliteNegative();
            }
            //Polite Past Positive Kana
            else if (polite && !present && positive && kana) {
                setKanaPolitePastPositive();
            }
            //Polite Past Positive Romaji
            else if (polite && !present && positive && !kana) {
                setRomajiPolitePastPositive();
            }
            //Polite Past Negative Kana
            else if (polite && !present && !positive && kana) {
                setKanaPolitePastNegative();
            }
            //Polite Past Negative Romaji
            else if (polite && !present && !positive && !kana) {
                setRomajiPolitePastNegative();
            }
            //Plain Present Positive Kana
            else if (!polite && present && positive && kana) {
                setKanaPlainPresentPositive();
            }
            //Plain Present Positive Romaji
            else if (!polite && present && positive && !kana) {
                setRomajiPlainPresentPositive();
            }
            //Plain Present Negative Kana
            else if (!polite && present && !positive && kana) {
                setKanaPlainPresentNegative();
            }
            //Plain Present Negative Romaji
            else if (!polite && present && !positive && !kana) {
                setRomajiPlainPresentNegative();
            }
            //Plain Past Positive Kana
            else if (!polite && !present && positive && kana) {
                setKanaPlainPastPositive();
            }
            //Plain Past Positive Romaji
            else if (!polite && !present && positive && !kana) {
                setRomajiPlainPastPositive();
            }
            //Plain Past Negative Kana
            else if (!polite && !present && !positive && kana) {
                setKanaPlainPastNegative();
            }
            //Plain Past Negative Romaji
            else if (!polite && !present && !positive && !kana) {
                setRomajiPlainPastNegative();
            }

        }

        private void setKanaPlainPastPositive() {
            this.TextBlock_IndicativeForm.Text = _viewmodel.verb.Past_Plain_Positive_Kana_Indicative;
            this.TextBlock_PresumptiveForm.Text = _viewmodel.verb.Past_Plain_Positive_Kana_Volitional;
            this.TextBlock_ImperativeForm.Text = _viewmodel.verb.Plain_Positive_Kana_Imperative;
            this.TextBlock_ProvisionalForm.Text = _viewmodel.verb.Plain_Positive_Kana_Provisional;
            this.TextBlock_ConditionalForm.Text = _viewmodel.verb.Plain_Positive_Kana_Conditional;
            this.TextBlock_PotentialForm.Text = _viewmodel.verb.Plain_Positive_Kana_Potential;
            this.TextBlock_CausativeForm.Text = _viewmodel.verb.Plain_Positive_Kana_Causative;
            this.TextBlock_ProgressiveForm.Text = _viewmodel.verb.Past_Plain_Positive_Kana_Progressive;
            this.TextBlock_PassiveForm.Text = _viewmodel.verb.Plain_Positive_Kana_Passive;
            this.TextBlock_ChauForm.Text = _viewmodel.verb.Past_Plain_Positive_Kana_Chau;
        }

        private void setKanaPlainPastNegative() {
            this.TextBlock_IndicativeForm.Text = _viewmodel.verb.Past_Plain_Negative_Kana_Indicative;
            this.TextBlock_PresumptiveForm.Text = _viewmodel.verb.Past_Plain_Negative_Kana_Volitional;
            this.TextBlock_ImperativeForm.Text = _viewmodel.verb.Plain_Negative_Kana_Imperative;
            this.TextBlock_ProvisionalForm.Text = _viewmodel.verb.Plain_Negative_Kana_Provisional;
            this.TextBlock_ConditionalForm.Text = _viewmodel.verb.Plain_Negative_Kana_Conditional;
            this.TextBlock_PotentialForm.Text = _viewmodel.verb.Plain_Negative_Kana_Potential;
            this.TextBlock_CausativeForm.Text = _viewmodel.verb.Plain_Negative_Kana_Causative;
            this.TextBlock_ProgressiveForm.Text = _viewmodel.verb.Past_Plain_Negative_Kana_Progressive;
            this.TextBlock_PassiveForm.Text = _viewmodel.verb.Plain_Negative_Kana_Passive;
            this.TextBlock_ChauForm.Text = _viewmodel.verb.Past_Plain_Negative_Kana_Chau;
        }

        private void setRomajiPlainPastNegative() {
            this.TextBlock_IndicativeForm.Text = _viewmodel.verb.Past_Plain_Negative_Romaji_Indicative;
            this.TextBlock_PresumptiveForm.Text = _viewmodel.verb.Past_Plain_Negative_Romaji_Volitional;
            this.TextBlock_ImperativeForm.Text = _viewmodel.verb.Plain_Negative_Romaji_Imperative;
            this.TextBlock_ProvisionalForm.Text = _viewmodel.verb.Plain_Negative_Romaji_Provisional;
            this.TextBlock_ConditionalForm.Text = _viewmodel.verb.Plain_Negative_Romaji_Conditional;
            this.TextBlock_PotentialForm.Text = _viewmodel.verb.Plain_Negative_Romaji_Potential;
            this.TextBlock_CausativeForm.Text = _viewmodel.verb.Plain_Negative_Romaji_Causative;
            this.TextBlock_ProgressiveForm.Text = _viewmodel.verb.Past_Plain_Negative_Romaji_Progressive;
            this.TextBlock_PassiveForm.Text = _viewmodel.verb.Plain_Negative_Romaji_Passive;
            this.TextBlock_ChauForm.Text = _viewmodel.verb.Past_Plain_Negative_Romaji_Chau;
        }

        private void setRomajiPlainPresentNegative() {
            this.TextBlock_IndicativeForm.Text = _viewmodel.verb.Present_Plain_Negative_Romaji_Indicative;
            this.TextBlock_PresumptiveForm.Text = _viewmodel.verb.Present_Plain_Negative_Romaji_Volitional;
            this.TextBlock_ImperativeForm.Text = _viewmodel.verb.Plain_Negative_Romaji_Imperative;
            this.TextBlock_ProvisionalForm.Text = _viewmodel.verb.Plain_Negative_Romaji_Provisional;
            this.TextBlock_ConditionalForm.Text = _viewmodel.verb.Plain_Negative_Romaji_Conditional;
            this.TextBlock_PotentialForm.Text = _viewmodel.verb.Plain_Negative_Romaji_Potential;
            this.TextBlock_CausativeForm.Text = _viewmodel.verb.Plain_Negative_Romaji_Causative;
            this.TextBlock_ProgressiveForm.Text = _viewmodel.verb.Present_Plain_Negative_Romaji_Progressive;
            this.TextBlock_PassiveForm.Text = _viewmodel.verb.Plain_Negative_Romaji_Passive;
            this.TextBlock_ChauForm.Text = _viewmodel.verb.Present_Plain_Negative_Romaji_Chau;
        }

        private void setKanaPlainPresentNegative() {
            this.TextBlock_IndicativeForm.Text = _viewmodel.verb.Present_Plain_Negative_Kana_Indicative;
            this.TextBlock_PresumptiveForm.Text = _viewmodel.verb.Present_Plain_Negative_Kana_Volitional;
            this.TextBlock_ImperativeForm.Text = _viewmodel.verb.Plain_Negative_Kana_Imperative;
            this.TextBlock_ProvisionalForm.Text = _viewmodel.verb.Plain_Negative_Kana_Provisional;
            this.TextBlock_ConditionalForm.Text = _viewmodel.verb.Plain_Negative_Kana_Conditional;
            this.TextBlock_PotentialForm.Text = _viewmodel.verb.Plain_Negative_Kana_Potential;
            this.TextBlock_CausativeForm.Text = _viewmodel.verb.Plain_Negative_Kana_Causative;
            this.TextBlock_ProgressiveForm.Text = _viewmodel.verb.Present_Plain_Negative_Kana_Progressive;
            this.TextBlock_PassiveForm.Text = _viewmodel.verb.Plain_Negative_Kana_Passive;
            this.TextBlock_ChauForm.Text = _viewmodel.verb.Present_Plain_Negative_Kana_Chau;
        }

        private void setKanaPlainPresentPositive() {
            this.TextBlock_IndicativeForm.Text = _viewmodel.verb.Present_Plain_Positive_Kana_Indicative;
            this.TextBlock_PresumptiveForm.Text = _viewmodel.verb.Present_Plain_Positive_Kana_Volitional;
            this.TextBlock_ImperativeForm.Text = _viewmodel.verb.Plain_Positive_Kana_Imperative;
            this.TextBlock_ProvisionalForm.Text = _viewmodel.verb.Plain_Positive_Kana_Provisional;
            this.TextBlock_ConditionalForm.Text = _viewmodel.verb.Plain_Positive_Kana_Conditional;
            this.TextBlock_PotentialForm.Text = _viewmodel.verb.Plain_Positive_Kana_Potential;
            this.TextBlock_CausativeForm.Text = _viewmodel.verb.Plain_Positive_Kana_Causative;
            this.TextBlock_ProgressiveForm.Text = _viewmodel.verb.Present_Plain_Positive_Kana_Progressive;
            this.TextBlock_PassiveForm.Text = _viewmodel.verb.Plain_Positive_Kana_Passive;
            this.TextBlock_ChauForm.Text = _viewmodel.verb.Present_Plain_Positive_Kana_Chau;
        }

        private void setRomajiPlainPastPositive() {
            this.TextBlock_IndicativeForm.Text = _viewmodel.verb.Past_Plain_Positive_Romaji_Indicative;
            this.TextBlock_PresumptiveForm.Text = _viewmodel.verb.Past_Plain_Positive_Romaji_Volitional;
            this.TextBlock_ImperativeForm.Text = _viewmodel.verb.Plain_Positive_Romaji_Imperative;
            this.TextBlock_ProvisionalForm.Text = _viewmodel.verb.Plain_Positive_Romaji_Provisional;
            this.TextBlock_ConditionalForm.Text = _viewmodel.verb.Polite_Positive_Romaji_Conditional;
            this.TextBlock_PotentialForm.Text = _viewmodel.verb.Plain_Positive_Romaji_Potential;
            this.TextBlock_CausativeForm.Text = _viewmodel.verb.Plain_Positive_Romaji_Causative;
            this.TextBlock_ProgressiveForm.Text = _viewmodel.verb.Past_Plain_Positive_Romaji_Progressive;
            this.TextBlock_PassiveForm.Text = _viewmodel.verb.Plain_Positive_Romaji_Passive;
            this.TextBlock_ChauForm.Text = _viewmodel.verb.Past_Plain_Positive_Romaji_Chau;
        }

        private void setRomajiPlainPresentPositive() {
            this.TextBlock_IndicativeForm.Text = _viewmodel.verb.Present_Plain_Positive_Romaji_Indicative;
            this.TextBlock_PresumptiveForm.Text = _viewmodel.verb.Present_Plain_Positive_Romaji_Volitional;
            this.TextBlock_ImperativeForm.Text = _viewmodel.verb.Plain_Positive_Romaji_Imperative;
            this.TextBlock_ProvisionalForm.Text = _viewmodel.verb.Plain_Positive_Romaji_Provisional;
            this.TextBlock_ConditionalForm.Text = _viewmodel.verb.Plain_Positive_Romaji_Conditional;
            this.TextBlock_PotentialForm.Text = _viewmodel.verb.Plain_Positive_Romaji_Potential;
            this.TextBlock_CausativeForm.Text = _viewmodel.verb.Plain_Positive_Romaji_Causative;
            this.TextBlock_ProgressiveForm.Text = _viewmodel.verb.Present_Plain_Positive_Romaji_Progressive;
            this.TextBlock_PassiveForm.Text = _viewmodel.verb.Polite_Positive_Romaji_Passive;
            this.TextBlock_ChauForm.Text = _viewmodel.verb.Present_Plain_Positive_Romaji_Chau;
        }

        private void setRomajiPolitePastPositive() {
            this.TextBlock_IndicativeForm.Text = _viewmodel.verb.Past_Polite_Positive_Romaji_Indicative;
            this.TextBlock_PresumptiveForm.Text = _viewmodel.verb.Past_Polite_Positive_Romaji_Volitional;
            this.TextBlock_ImperativeForm.Text = _viewmodel.verb.Polite_Positive_Romaji_Imperative;
            this.TextBlock_ProvisionalForm.Text = _viewmodel.verb.Polite_Positive_Romaji_Provisional;
            this.TextBlock_ConditionalForm.Text = _viewmodel.verb.Polite_Positive_Romaji_Conditional;
            this.TextBlock_PotentialForm.Text = _viewmodel.verb.Polite_Positive_Romaji_Potential;
            this.TextBlock_CausativeForm.Text = _viewmodel.verb.Polite_Positive_Romaji_Causative;
            this.TextBlock_ProgressiveForm.Text = _viewmodel.verb.Past_Polite_Positive_Romaji_Pogressive;
            this.TextBlock_PassiveForm.Text = _viewmodel.verb.Polite_Positive_Romaji_Passive;
            this.TextBlock_ChauForm.Text = _viewmodel.verb.Past_Polite_Positive_Romaji_Chau;
        }

        private void setRomajiPolitePastNegative() {
            this.TextBlock_IndicativeForm.Text = _viewmodel.verb.Past_Polite_Negative_Romaji_Indicative;
            this.TextBlock_PresumptiveForm.Text = _viewmodel.verb.Past_Polite_Negative_Romaji_Volitional;
            this.TextBlock_ImperativeForm.Text = _viewmodel.verb.Polite_Negative_Romaji_Imperative;
            this.TextBlock_ProvisionalForm.Text = _viewmodel.verb.Polite_Negative_Romaji_Provisional;
            this.TextBlock_ConditionalForm.Text = _viewmodel.verb.Polite_Negative_Romaji_Conditional;
            this.TextBlock_PotentialForm.Text = _viewmodel.verb.Polite_Negative_Romaji_Potential;
            this.TextBlock_CausativeForm.Text = _viewmodel.verb.Polite_Negative_Romaji_Causative;
            this.TextBlock_ProgressiveForm.Text = _viewmodel.verb.Past_Polite_Negative_Romaji_Progressive;
            this.TextBlock_PassiveForm.Text = _viewmodel.verb.Polite_Negative_Romaji_Passive;
            this.TextBlock_ChauForm.Text = _viewmodel.verb.Past_Polite_Negative_Romaji_Chau;
        }

        private void setKanaPresentPoliteNegative() {
            this.TextBlock_IndicativeForm.Text = _viewmodel.verb.Present_Polite_Negative_Kana_Indicative;
            this.TextBlock_PresumptiveForm.Text = _viewmodel.verb.Present_Polite_Negative_Kana_Volitional;
            this.TextBlock_ImperativeForm.Text = _viewmodel.verb.Polite_Negative_Kana_Imperative;
            this.TextBlock_ProvisionalForm.Text = _viewmodel.verb.Polite_Negative_Kana_Provisional;
            this.TextBlock_ConditionalForm.Text = _viewmodel.verb.Polite_Negative_Kana_Conditional;
            this.TextBlock_PotentialForm.Text = _viewmodel.verb.Polite_Negative_Kana_Potential;
            this.TextBlock_CausativeForm.Text = _viewmodel.verb.Polite_Negative_Kana_Causative;
            this.TextBlock_ProgressiveForm.Text = _viewmodel.verb.Present_Polite_Negative_Kana_Progressive;
            this.TextBlock_PassiveForm.Text = _viewmodel.verb.Polite_Negative_Kana_Passive;
            this.TextBlock_ChauForm.Text = _viewmodel.verb.Present_Polite_Negative_Kana_Chau;
        }

        private void setKanaPolitePastPositive() {
            this.TextBlock_IndicativeForm.Text = _viewmodel.verb.Past_Polite_Positive_Kana_Indicative;
            this.TextBlock_PresumptiveForm.Text = _viewmodel.verb.Past_Polite_Positive_Kana_Volitional;
            this.TextBlock_ImperativeForm.Text = _viewmodel.verb.Polite_Positive_Kana_Imperative;
            this.TextBlock_ProvisionalForm.Text = _viewmodel.verb.Polite_Positive_Kana_Provisional;
            this.TextBlock_ConditionalForm.Text = _viewmodel.verb.Polite_Positive_Kana_Conditional;
            this.TextBlock_PotentialForm.Text = _viewmodel.verb.Polite_Positive_Kana_Potential;
            this.TextBlock_CausativeForm.Text = _viewmodel.verb.Polite_Positive_Kana_Causative;
            this.TextBlock_ProgressiveForm.Text = _viewmodel.verb.Past_Plain_Positive_Kana_Progressive;
            this.TextBlock_PassiveForm.Text = _viewmodel.verb.Polite_Positive_Kana_Passive;
            this.TextBlock_ChauForm.Text = _viewmodel.verb.Past_Polite_Positive_Kana_Chau;
        }


        private void setKanaPolitePastNegative() {
            this.TextBlock_IndicativeForm.Text = _viewmodel.verb.Past_Polite_Negative_Kana_Indicative;
            this.TextBlock_PresumptiveForm.Text = _viewmodel.verb.Past_Polite_Negative_Kana_Volitional;
            this.TextBlock_ImperativeForm.Text = _viewmodel.verb.Polite_Negative_Kana_Imperative;
            this.TextBlock_ProvisionalForm.Text = _viewmodel.verb.Polite_Negative_Kana_Provisional;
            this.TextBlock_ConditionalForm.Text = _viewmodel.verb.Polite_Negative_Kana_Conditional;
            this.TextBlock_PotentialForm.Text = _viewmodel.verb.Polite_Negative_Kana_Potential;
            this.TextBlock_CausativeForm.Text = _viewmodel.verb.Polite_Negative_Kana_Causative;
            this.TextBlock_ProgressiveForm.Text = _viewmodel.verb.Past_Polite_Negative_Kana_Progressive;
            this.TextBlock_PassiveForm.Text = _viewmodel.verb.Polite_Negative_Kana_Passive;
            this.TextBlock_ChauForm.Text = _viewmodel.verb.Past_Polite_Negative_Kana_Chau;
        }

        private void setRomajiPresentPoliteNegative() {
            this.TextBlock_IndicativeForm.Text = _viewmodel.verb.Present_Polite_Negative_Romaji_Indicative;
            this.TextBlock_PresumptiveForm.Text = _viewmodel.verb.Present_Polite_Negative_Romaji_Volitional;
            this.TextBlock_ImperativeForm.Text = _viewmodel.verb.Polite_Negative_Romaji_Imperative;
            this.TextBlock_ProvisionalForm.Text = _viewmodel.verb.Polite_Negative_Romaji_Provisional;
            this.TextBlock_ConditionalForm.Text = _viewmodel.verb.Polite_Negative_Romaji_Conditional;
            this.TextBlock_PotentialForm.Text = _viewmodel.verb.Polite_Negative_Romaji_Potential;
            this.TextBlock_CausativeForm.Text = _viewmodel.verb.Polite_Negative_Romaji_Causative;
            this.TextBlock_ProgressiveForm.Text = _viewmodel.verb.Present_Polite_Negative_Romaji_Progressive;
            this.TextBlock_PassiveForm.Text = _viewmodel.verb.Polite_Negative_Romaji_Passive;
            this.TextBlock_ChauForm.Text = _viewmodel.verb.Present_Polite_Negative_Romaji_Chau;
        }

        private void setKanaPresentPolitePositive() {
            this.TextBlock_IndicativeForm.Text = _viewmodel.verb.Present_Polite_Positive_Kana_Indicative;
            this.TextBlock_PresumptiveForm.Text = _viewmodel.verb.Present_Polite_Positive_Kana_Volitional;
            this.TextBlock_ImperativeForm.Text = _viewmodel.verb.Polite_Positive_Kana_Imperative;
            this.TextBlock_ProvisionalForm.Text = _viewmodel.verb.Polite_Positive_Kana_Provisional;
            this.TextBlock_ConditionalForm.Text = _viewmodel.verb.Polite_Positive_Kana_Conditional;
            this.TextBlock_PotentialForm.Text = _viewmodel.verb.Polite_Positive_Kana_Potential;
            this.TextBlock_CausativeForm.Text = _viewmodel.verb.Polite_Positive_Kana_Causative;
            this.TextBlock_ProgressiveForm.Text = _viewmodel.verb.Present_Polite_Positive_Kana_Pogressive;
            this.TextBlock_PassiveForm.Text = _viewmodel.verb.Polite_Positive_Kana_Passive;
            this.TextBlock_ChauForm.Text = _viewmodel.verb.Present_Polite_Positive_Kana_Chau;
        }

        private void setRomajiPresentPolitePositive() {
            this.TextBlock_IndicativeForm.Text = _viewmodel.verb.Present_Polite_Positive_Romaji_Indicative;
            this.TextBlock_PresumptiveForm.Text = _viewmodel.verb.Present_Polite_Positive_Romaji_Volitional;
            this.TextBlock_ImperativeForm.Text = _viewmodel.verb.Polite_Positive_Romaji_Imperative;
            this.TextBlock_ProvisionalForm.Text = _viewmodel.verb.Polite_Positive_Romaji_Provisional;
            this.TextBlock_ConditionalForm.Text = _viewmodel.verb.Polite_Positive_Romaji_Conditional;
            this.TextBlock_PotentialForm.Text = _viewmodel.verb.Polite_Positive_Romaji_Potential;
            this.TextBlock_CausativeForm.Text = _viewmodel.verb.Polite_Positive_Romaji_Causative;
            this.TextBlock_ProgressiveForm.Text = _viewmodel.verb.Present_Polite_Positive_Romaji_Pogressive;
            this.TextBlock_PassiveForm.Text = _viewmodel.verb.Polite_Positive_Romaji_Passive;
            this.TextBlock_ChauForm.Text = _viewmodel.verb.Present_Polite_Positive_Romaji_Chau;
        }

        private void goToSearch(object sender, RoutedEventArgs e) {
            this.Frame.Navigate(typeof(MainPage));
        }

        private void toConjugations(object sender, RoutedEventArgs e) {
            int numPivs =  this.pivotControl.Items.Count;
            Debug.WriteLine("Moved from " + this.pivotControl.SelectedIndex + " to " + (this.pivotControl.SelectedIndex+1) % numPivs);
            this.pivotControl.SelectedItem = this.pivotControl.Items[(this.pivotControl.SelectedIndex+1) % numPivs];
        }

        private void toFavorites(object sender, RoutedEventArgs e) {
            this.Frame.Navigate(typeof(FavoritesPage));
        }
        private void toHistory(object sender, RoutedEventArgs e) {
            this.Frame.Navigate(typeof(HistoryPage));
        }

        private void switchFormality(object sender, RoutedEventArgs e) {
            this.polite = !this.polite;
            setConjugationBlocks();
        }

        private void switchTense(object sender, RoutedEventArgs e) {
            this.present = !this.present;
            setConjugationBlocks();
        }

        private void switchAlphabet(object sender, RoutedEventArgs e) {
            this.kana = !this.kana;
            setConjugationBlocks();
        }

        private void switchAgreement(object sender, RoutedEventArgs e) {
            this.positive = !this.positive;
            setConjugationBlocks();
        }

        private void Pivot_SelectionChanged(object sender, SelectionChangedEventArgs e) {

        }

        //When a textblock is held down, brings up a context menu to offer copy command
        private void highlight(object sender, RoutedEventArgs e) {

        }

        //Adds the word to the UserData.favorites table
        private void favoriteEntry(object sender, RoutedEventArgs e) {

        }


        //Opens the context menu, if selected from a generated textblock
        private void openContextMenu(object sender, RoutedEventArgs e) {

        }

        //Adds context menus to a generated textblock
        private void addContextMenu(string nameOfMenu, DependencyObject elem) {

        }

        private void favoriteEntry(object sender, TappedRoutedEventArgs e) {
            //Unfavorite the item
            if (_viewmodel.isFavorite) {
                Image_Favorite.Symbol = Symbol.Favorite; //Show that the item is free to favorite
                _viewmodel.unFavorite();
            }
            else {
                Image_Favorite.Symbol = Symbol.UnFavorite;
                _viewmodel.favorite();
            }

  
        }

        private void goBack(object sender, RoutedEventArgs e) {
            
        }

        private void toKanjiFromResult(object sender, TappedRoutedEventArgs e) {
            FrameworkElement s = sender as FrameworkElement;
            KanjiPageViewModel kpvm = s.Tag as KanjiPageViewModel;
            this.Frame.Navigate(typeof(KanjiPage), kpvm);
        }

        private void copyText(object sender, RoutedEventArgs e) {
            FrameworkElement tb = sender as FrameworkElement;
            string text = (string)tb.DataContext;
            DataPackage dp = new DataPackage {
                RequestedOperation = DataPackageOperation.Copy
            };
            dp.SetText(text);
            Clipboard.SetContent(dp);
        }

        private void copySentence(object sender, RoutedEventArgs e) {
            FrameworkElement tb = sender as FrameworkElement;
            var hws = tb.DataContext as HeadwordSentence;
            var text = $"{hws.beforeForm}{hws.form}{hws.afterForm}";
            DataPackage dp = new DataPackage {
                RequestedOperation = DataPackageOperation.Copy
            };
            dp.SetText(text);
            Clipboard.SetContent(dp);
        }
    }
}
