using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Foosball
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PlayScreen : ContentPage
    {
        public PlayScreen()
        {
            InitializeComponent();

            team1Score.Text = 0.ToString();  //ToDo
            team2Score.Text = 0.ToString();  //ToDo

        }

        void LeaderboardsClicked(object sender, EventArgs args)
        {
            Navigation.PushAsync(new LeaderBoards());
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new ScoreInput(Int32.Parse(team1Score.Text), Int32.Parse(team2Score.Text)));
        }
    }
}