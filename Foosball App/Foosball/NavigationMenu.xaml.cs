﻿using Xamarin.Forms;
using System.Diagnostics;
using System;


namespace Foosball
{
    public partial class NavigationMenu : ContentPage
    {
        public NavigationMenu()
        {
            InitializeComponent();

        }
        void OnNewGameClicked(object sender, EventArgs args)
        {
            Navigation.PushAsync(new NewGame());
        }

        void OnLeaderboardsClicked(object sender, EventArgs args)
        {
            Navigation.PushAsync(new LeaderBoards());
        }
        void OnHistoryClicked(object sender, EventArgs args)
        {
            Navigation.PushAsync(new History());
        }

        void OnAboutClicked(object sender, EventArgs args)
        {
            Navigation.PushAsync(new About());
        }

        void OnFantasyClicked(object sender, EventArgs args)
        {
            Navigation.PushAsync(new Fantasy());
        }

        void OnTournamentClicked(object sender, EventArgs args)
        {
            Navigation.PushAsync(new Tournament());
        }

        protected override bool OnBackButtonPressed()
        {
            return base.OnBackButtonPressed();
        }
    }
}
