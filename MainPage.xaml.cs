
using System.Diagnostics;
using System.Data.SqlClient;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Newtonsoft.Json;
using System.Net;
using System;
using System.Data;
using System.Collections.Generic;

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

                        SqlConnectionStringBuilder connStringBuilder = new SqlConnectionStringBuilder
                        {
                            DataSource = @"donau.hiof.no",
                            InitialCatalog = "kristoss",
                            IntegratedSecurity = false,
                            UserID = "kristoss",
                            Password = "Ed:txh6B"
                        };
                        SqlConnection conn = new SqlConnection(connStringBuilder.ToString());

                        SqlCommand cmdUserName = new SqlCommand("SELECT UserName FROM dbo.Apex WHERE UserName ='" + username + "' AND Platform ='" + platform + "'", conn);
                        SqlCommand cmdKills = new SqlCommand("SELECT Kills FROM dbo.Apex WHERE UserName ='" + username + "' AND Platform ='" + platform + "'", conn);
                        SqlCommand cmdDeath = new SqlCommand("SELECT Death FROM dbo.Apex WHERE UserName ='" + username + "' AND Platform ='" + platform + "'", conn);
                        SqlCommand cmdLastCharachter = new SqlCommand("SELECT LastCharacter FROM dbo.Apex WHERE UserName ='" + username + "' AND Platform ='" + platform + "'", conn);

                        string backupInfo = "No info in database or recived...";
                        var kills = backupInfo; 
                        var death = backupInfo;  
                        var lastCharacter = backupInfo; 
                        var userDisplay = backupInfo; 


                            for (int i = 0; i < 4; i++)
                            {
                                if (i == 0)
                                {
                                    conn.Open();
                                    userDisplay = (string)cmdUserName.ExecuteScalar();
                                    conn.Close();
                                }
                                if (i == 1)
                                {
                                    conn.Open();
                                    var killsResult = cmdKills.ExecuteScalar();
                                    if(killsResult == null)
                                    {
                                    kills = backupInfo;
                                    }
                                    else
                                    {
                                    kills = killsResult.ToString();
                                    }
                                conn.Close();
                                }
                                if (i == 2)
                                {
                                    conn.Open();
                                    var deathResult = cmdDeath.ExecuteScalar();
                                    if(deathResult == null)
                                    {
                                        death = backupInfo;
                                    }
                                    else
                                    {
                                        death = deathResult.ToString();
                                    }
                                     conn.Close();
                                }
                                if (i == 3)
                                {
                                    conn.Open();
                                    lastCharacter = (string)cmdLastCharachter.ExecuteScalar();
                                    conn.Close();
                                }

                            }

                        UserNameDisplay.Text = (string)userDisplay;
                        KillsDisplay.Text = kills;
                        DeathDisplay.Text = death;
                        GamesPlayedDisplay.Text = (string)lastCharacter;
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
