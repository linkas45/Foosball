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


            //Creating TapGestureRecognizers  
            var tapImage = new TapGestureRecognizer();
            //Binding events  
            tapImage.Tapped += tapImage_Tapped;
            //Associating tap events to the image buttons  
            leaderboardsButton.GestureRecognizers.Add(tapImage);
        }


        void tapImage_Tapped(object sender, EventArgs e)
        {
            // handle the tap  
            Navigation.PushAsync(new LeaderBoards());
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new ScoreInput(Int32.Parse(team1Score.Text), Int32.Parse(team2Score.Text)));
        }
    }
}