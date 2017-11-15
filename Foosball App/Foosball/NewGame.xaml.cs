using System;
using System.Collections.Generic;
using Foosball.Utils;

using Xamarin.Forms;

namespace Foosball
{
    public partial class NewGame : ContentPage
    {
        public static string Team1Name { get; set; }
        public static string Team2Name { get; set; }

        public NewGame()
        {
            InitializeComponent();
        }

        // Submit button
        private void Button_Clicked(object sender, EventArgs e)
        {
           
            if(NameChecking())
            {
                Team1Name = team1NameEntry.Text;
                Team2Name = team2NameEntry.Text;
                Navigation.PushAsync(new PlayScreen());
            }
        }


        private bool NameChecking()
        {

            //Make placeholder text red, if team name is empty
            if (team1NameEntry.Text == string.Empty)
            {
                team1NameEntry.PlaceholderColor = Color.Red;
                emptyNameErrorLabel.IsVisible = true;
                emptyNameErrorLabel.Text = "Insert your team name";

                return false;
            }


            //Make placeholder text red, if team name is empty
            if (team2NameEntry.Text == string.Empty)
            {
                team2NameEntry.PlaceholderColor = Color.Red;
                emptyNameErrorLabel.Text = "Insert your team name";
                emptyNameErrorLabel.IsVisible = true;

                return false;
            }


            //Make placeholder red, if both teams have same name
            if (team1NameEntry.Text == team2NameEntry.Text)
            {
                team2NameEntry.PlaceholderColor = Color.Red;
                emptyNameErrorLabel.Text = "Team names must be different";
                emptyNameErrorLabel.IsVisible = true;

                return false;
            }

            return true;
        }

    }
}
