using Xamarin.Forms;
using System.Diagnostics;
using System;

namespace Foosball
{
    public partial class FoosballPage : ContentPage
    {
        public FoosballPage()
        {
            InitializeComponent();

        }
        void OnLeaderboardsClicked(object sender, EventArgs args)
        {
            DisplayAlert("Clicked!", "The button Leaderboards has been clicked", "OK");
        }
        void OnWebServiceClicked(object sender, EventArgs args)
        {
            DisplayAlert("Clicked!", "The button Web Service has been clicked", "OK");
        }
        void OnNewGameClicked(object sender, EventArgs args)
        {
            DisplayAlert("Clicked!", "The button New Game has been clicked", "OK");
        }
        void OnAboutClicked(object sender, EventArgs args)
        {
            DisplayAlert("Clicked!", "The button About has been clicked", "OK");
        }
    }
}
