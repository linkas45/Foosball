using Xamarin.Forms;
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

        // Fantasy and Tournament
        void OnTournamentClicked(object sender, EventArgs args)
        {
            Navigation.PushAsync(new Tournament());
        }

        void OnFantasyClicked(object sender, EventArgs args)
        {
            Navigation.PushAsync(new FantasyFoosball());
        }
        //

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

        protected override bool OnBackButtonPressed()
        {
            return true;
        }
    }
}
