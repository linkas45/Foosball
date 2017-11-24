﻿using System;
using Foosball_dll;
using Foosball_dll.Utils;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Foosball_dll.Interfaces;

namespace Foosball
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ScoreInput : ContentPage
    {
        private IWriteReadData _data = new WriteReadData();
        private ICalculateRanking _calcRanking = new CalculateRanking();

        public ScoreInput()
        {
            InitializeComponent();
        }

        public ScoreInput(int team1Score, int team2Score)
        {
            InitializeComponent();

            //Display scores
            team1ScoreEntry.Text = team1Score.ToString();
            team2ScoreEntry.Text = team2Score.ToString();

            //Get team naems
            t1Name.Text = CurrentGameInfo.Team1Name;
            t2Name.Text = CurrentGameInfo.Team2Name;

        }
         
        private async void Button_Clicked(object sender, EventArgs e)
        {
            //Parse scores
            int goalsCount1 = Int32.Parse(team1ScoreEntry.Text);
            int goalsCount2 = Int32.Parse(team2ScoreEntry.Text);

            //Update and write info of game to file for leaderboards and history
            await _data.WriteMatchesDataToFileAsync();
            _calcRanking.CalcRanking(goalsCount1, goalsCount2);
            await Navigation.PushAsync(new NavigationMenu());
        }

    }
}