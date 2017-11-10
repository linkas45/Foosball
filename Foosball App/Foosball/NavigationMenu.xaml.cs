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

        void OnLeaderboardsClicked(object sender, EventArgs args)
        {
            Navigation.PushAsync(new LeaderBoards());
        }
        void OnWebServiceClicked(object sender, EventArgs args)
        {
            Navigation.PushAsync(new WebService());
        }

        void OnAboutClicked(object sender, EventArgs args)
        {
            Navigation.PushAsync(new About());
        }
    }
}
