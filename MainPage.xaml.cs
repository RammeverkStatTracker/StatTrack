
using System.Diagnostics;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Newtonsoft.Json;
using System.Net;



namespace StatTrack
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private static string username = "";



        public MainPage()
        {
            this.InitializeComponent();

        }

        private void TextBlock_SelectionChanged(object sender, RoutedEventArgs e)
        {

        }

        private void TextBlock_SelectionChanged_1(object sender, RoutedEventArgs e)
        {

        }

        private void UsernameInput(object sender, TextChangedEventArgs e)
        {
            username = Username.Text; // Gets input from textbox and put your info into a string.
        }

        private void Button_Click_Search(object sender, RoutedEventArgs e)
        {
            // API url med en key. Tar inn det som blir skrevet inn i textbox som da blir lagt med i linken
            string url = @"https://public-api.tracker.gg/v2/apex/standard/profile/origin/"+ username +@"?TRN-Api-Key=620a071e-c41c-47ae-8e79-8f612c05e022";
            Debug.WriteLine(url);

            var json = new WebClient().DownloadString(url); // Henter infoen som er i linken.

           var allInfo =  JsonConvert.DeserializeObject<Datadb>(json); // Converterer infoen som er json til objekter I Datadb Klassen.
           var kill =  JsonConvert.DeserializeObject<Kills>(json);
           var legend =  JsonConvert.DeserializeObject<DataMetadata>(json);

            string userDisplay = allInfo.Data.PlatformInfo.PlatformUserId; // Viser brukernavn på forsiden
            string kills = "1234"; // Har ikke funnet enda hva vi skal kalle på for dette. Men er der
            string death = "500";  // Har ikke funnet enda hva vi skal kalle på for dette. Men er der
            string gamesPlayed = allInfo.Data.Metadata.ActiveLegendName; // Viser sist brukte karakter i spillet.

            // Blir vist frem på forsiden da bruker har trykket på søk.
            UserNameDisplay.Text = userDisplay;
            KillsDisplay.Text = kills;
            DeathDisplay.Text = death;
            GamesPlayedDisplay.Text = gamesPlayed;
        }
    }
}
