
using System.Diagnostics;
using System.Data.SqlClient;
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
            FrontPageTitle.Text = "StatTracker"; // Frontpage title. 
        }


        private void UsernameInput(object sender, TextChangedEventArgs e)
        {
            username = Username.Text; // Gets input from textbox and put your info into a string.
        }

        private void Button_Click_Search(object sender, RoutedEventArgs e)
        {
            // Checking if any fields are empty, if sp it will print that below.
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(platform) || string.IsNullOrEmpty(database))
            {
                UserNameDisplay.Text = "Need to type Username, Platform and Database";
            }
            else
            {   
                if(database == "Online")// If Tracker.gg database/Online is choosen.
                {
                    try
                    {  
                        FrontPageTitle.Text = "Online Database for Apex Legends"; // Just so it is easier to see that the online database is the choosen one.
                           
                        // API borrowed from tracker.gg that takes platfrom and username and adds it to the url
                        string url = @"https://public-api.tracker.gg/v2/apex/standard/profile/" + platform + "/" + username + @"?TRN-Api-Key=620a071e-c41c-47ae-8e79-8f612c05e022";

                        string backupInfo = "No info in database or recived..."; // If it can't find any info. 

                        Debug.WriteLine(url); // Just a nice print to have. So inn console you can check what info it are trying to read. It will show a link that it tries to check.

                        var json = new WebClient().DownloadString(url); // Gets info to json from url above

                        var allInfo = JsonConvert.DeserializeObject<Datadb>(json); //Converting info from json to objects in datadb.cs
                        var kill = JsonConvert.DeserializeObject<Segment>(json); //Converting info from json to objects in datadb.cs

                        string userDisplay = allInfo?.Data?.PlatformInfo?.PlatformUserId ?? backupInfo; // Displaying username on the front page.
                        string kills = kill?.Stats?.Kills?.DisplayValue ?? backupInfo; //1. Have found out that APEX is wierd with it's info. 
                        string death = kill?.Stats?.Kills?.DisplayValue ?? backupInfo;  //2. Our database won't get it if it's not shown in the player banner in-game. Explanation in the document.
                        string lastPlayedCharacter = allInfo?.Data?.Metadata?.ActiveLegendName ?? backupInfo; // Displaying last used legend(character)

                        // Field used to show info on the front page
                        UserNameDisplay.Text = userDisplay;
                        KillsDisplay.Text = kills;
                        DeathDisplay.Text = death;
                        LastPlayedCharacter.Text = lastPlayedCharacter;

                    }
                    catch (Exception error)
                    {
                        Debug.WriteLine("Error : " + error.Message); 
                        UserNameDisplay.Text = "This username : " + username + " does not exist in database on choosen platform or database";
                        // If any error it prints it in the console, and if it can't find username in choosen platform/databse, it will show it on the fontpage
                    }
                }
                else if(database == "Local")// If local database is choosen. Using a database we got to use in .NET lecture.
                {
                    try
                    {
                        FrontPageTitle.Text = "Local Database for Apex Legends"; // Just so it is easier to see that the local database is the choosen one.

                        SqlConnectionStringBuilder connStringBuilder = new SqlConnectionStringBuilder
                        {
                            DataSource = @"donau.hiof.no",
                            InitialCatalog = "kristoss",
                            IntegratedSecurity = false,
                            UserID = userId, // UserId on the almost last line in this file.
                            Password = password // Password on the last line in this file. 
                        };
                        SqlConnection conn = new SqlConnection(connStringBuilder.ToString());

                        // Multiple SQL commands used to get information from the local database.
                        SqlCommand cmdUserName = new SqlCommand("SELECT UserName FROM dbo.Apex WHERE UserName ='" + username + "' AND Platform ='" + platform + "'", conn);
                        SqlCommand cmdKills = new SqlCommand("SELECT Kills FROM dbo.Apex WHERE UserName ='" + username + "' AND Platform ='" + platform + "'", conn);
                        SqlCommand cmdDeath = new SqlCommand("SELECT Death FROM dbo.Apex WHERE UserName ='" + username + "' AND Platform ='" + platform + "'", conn);
                        SqlCommand cmdLastCharachter = new SqlCommand("SELECT LastCharacter FROM dbo.Apex WHERE UserName ='" + username + "' AND Platform ='" + platform + "'", conn);

                        string backupInfo = "No info in database or recived..."; // If not any information recived, it will print out backup information on the frontpage.
                        var kills = backupInfo; 
                        var death = backupInfo;  
                        var lastCharacter = backupInfo; 
                        var userDisplay = backupInfo; 

                            // For loop to use SQL command above to get user info.
                        for (int i = 0; i < 4; i++)
                        {
                            switch (i)
                            {
                                case 0:
                                    conn.Open();
                                    userDisplay = (string)cmdUserName.ExecuteScalar();
                                    conn.Close();
                                    break;
                                case 1:
                                    conn.Open();
                                    var killsResult = cmdKills.ExecuteScalar();
                                    if (killsResult == null) // If it can't find info it will print backupInfo.
                                    { //  Had to use if statment because it should get a Int, but the code didn't like that.
                                        kills = backupInfo;
                                    }
                                    else
                                    {
                                        kills = killsResult.ToString();
                                    }
                                    conn.Close();
                                    break;
                                case 2:
                                    conn.Open();
                                    var deathResult = cmdDeath.ExecuteScalar();
                                    if (deathResult == null) // Same as case 1
                                    {
                                        death = backupInfo;
                                    }
                                    else
                                    {
                                        death = deathResult.ToString();
                                    }
                                    conn.Close();

                                    break;
                                case 3:
                                    conn.Open();
                                    lastCharacter = (string)cmdLastCharachter.ExecuteScalar();
                                    conn.Close();
                                    break;
                            }

                        }
                        // Field used to show info on the front page
                        UserNameDisplay.Text = (string)userDisplay;
                        KillsDisplay.Text = kills;
                        DeathDisplay.Text = death;
                        LastPlayedCharacter.Text = (string)lastCharacter;
                    }
                    catch (Exception error)
                    {
                        Debug.WriteLine("Error : " + error.Message);
                        UserNameDisplay.Text = "This username : " + username + " does not exist in database on choosen platform or database";
                        // If any error it prints it in the console, and if it can't find username in choosen platform/databse, it will show it on the fontpage
                    }

                }
            }
        }

        private void PlayerPlatform_SelectionChanged(object sender, SelectionChangedEventArgs e)
        { // Checking which platform the user want to check
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
        { // Checking which database that the user chooses
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

        private void TextBlock_SelectionChanged(object sender, RoutedEventArgs e)
        {
        }
        private void TextBlock_SelectionChanged_1(object sender, RoutedEventArgs e)
        {
        }

        // password and userID to one of our local database. 
        private static string userId = "kristoss"; 
        private static string password = "Ed:txh6B"; 
    }
}