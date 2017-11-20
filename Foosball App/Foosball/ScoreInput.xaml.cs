﻿using System;
using Foosball_dll;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Foosball
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ScoreInput : ContentPage
    {


        public ScoreInput()
        {
            InitializeComponent();
        }

        public ScoreInput(int team1Score, int team2Score)
        {
            InitializeComponent();

            team1ScoreEntry.Text = team1Score.ToString();
            team2ScoreEntry.Text = team2Score.ToString();


            t1Name.Text = Foosball_dll.Utils.CurrentGameInfo.Team1Name;
            t2Name.Text = Foosball_dll.Utils.CurrentGameInfo.Team2Name;

        }
         
        private void Button_Clicked(object sender, EventArgs e)
        {
            int goalsCount1 = Int32.Parse(team1ScoreEntry.Text);
            int goalsCount2 = Int32.Parse(team2ScoreEntry.Text);

            WriteReadData.WriteMatchesDataToFileAsync(goalsCount1.ToString() + ":" + goalsCount2.ToString());
            CalculateRanking.CalcRanking(goalsCount1, goalsCount2);
            Navigation.PushAsync(new NavigationMenu());
        }

    }
}