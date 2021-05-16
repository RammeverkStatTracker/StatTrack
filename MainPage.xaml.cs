
using System.Diagnostics;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Newtonsoft.Json;
using System.Net;
using System;

namespace StatTrack
{

    public sealed partial class MainPage : Page
    {

        private static string username;
        private static string platform;
        private static string database;

        public MainPage()
        {
            this.InitializeComponent();
            FrontPageTitle.Text = "StatTracker";

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

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(platform))
            {
                UserNameDisplay.Text = "Need to type Username or Platform";
            }
            else
            {
                if(database == "Online")
                {
                    try
                    {
                        FrontPageTitle.Text = "Online Database for Apex Legends";

                        string url = @"https://public-api.tracker.gg/v2/apex/standard/profile/" + platform + "/" + username + @"?TRN-Api-Key=620a071e-c41c-47ae-8e79-8f612c05e022";

                        Debug.WriteLine(platform);
                        string backupInfo = "No info in database or recived...";
                        //API url with key. It takes input from username textbox and attach it to url below.
                        Debug.WriteLine(url);
                        var json = new WebClient().DownloadString(url); // Gets info to json from url above

                        var allInfo = JsonConvert.DeserializeObject<Datadb>(json); //Converting info from json to objects in datadb.cs
                        var kill = JsonConvert.DeserializeObject<Segment>(json);
                        var legend = JsonConvert.DeserializeObject<DataMetadata>(json);

                        string userDisplay = allInfo?.Data?.PlatformInfo?.PlatformUserId ?? backupInfo; // Displaying username on the front page.
                        string kills = kill?.Stats?.Kills?.DisplayValue ?? backupInfo; // Haven't found why yet it won't display kills yet. So this is a temp
                        string death = kill?.Stats?.Kills?.DisplayValue ?? backupInfo;  // Haven't found why yet it won't display death yet. So this is a temp
                        string gamesPlayed = allInfo?.Data?.Metadata?.ActiveLegendName ?? backupInfo; // Displaying last used legend(character)

                        // Displaying information on the frontpage when clicked search button
                        UserNameDisplay.Text = userDisplay;
                        KillsDisplay.Text = kills;
                        DeathDisplay.Text = death;
                        GamesPlayedDisplay.Text = gamesPlayed;

                    }
                    catch (Exception error)
                    {
                        Debug.WriteLine("Error : " + error.Message);
                        UserNameDisplay.Text = "This username : " + username + " does not exist in database on choosen platform";
                    }
                }
                else if(database == "Local")
                {
                    try
                    {
                        FrontPageTitle.Text = "Local Database for Apex Legends";
                        //Prøve å sette inn lokale databasen her. Slik at når det blir valgt lokal database så starter denne.
            
                    }
                    catch (Exception error)
                    {
                        Debug.WriteLine("Error : " + error.Message);
                        UserNameDisplay.Text = "This username : " + username + " does not exist in database on choosen platform";
                    }

                }
            }
        }

        private void PlayerPlatform_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string platformChoosen = e.AddedItems[0].ToString();
            switch (platformChoosen)
            {
                case "Origin":
                    platform = "origin";
                    break;
                case "Playstation 4":
                    platform = "psn";
                    break;
                case "Xbox":
                    platform = "xbl";
                    break;
            }
        }

        private void Database_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string databaseChoosen = e.AddedItems[0].ToString();
            switch (databaseChoosen)
            {
                case "Local":
                    database = "Local";
                    break;
                case "Online":
                    database = "Online";
                    break;
            }
        }
    }
}
