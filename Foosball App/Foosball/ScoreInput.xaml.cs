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
	public partial class ScoreInput : ContentPage
	{
        public ScoreInput()
        {
            InitializeComponent();
        }

		public ScoreInput (int team1Score, int team2Score)
		{
			InitializeComponent ();

            team1ScoreEntry.Text = team1Score.ToString();
            team2ScoreEntry.Text = team2Score.ToString();

		}

        private void Button_Clicked(object sender, EventArgs e)
        {

        }
    }
}