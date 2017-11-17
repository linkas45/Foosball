using System;
using Foosball.Utils;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Diagnostics;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Foosball
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ScoreInput : ContentPage
	{
        //Constants
        private static int INITIAL_SCORE = 1000;
        private static int NO_VALUE = -1;
        private static double PROBABILITY_FOR_GEO_PROGRESSION = 0.999;
        private static int AMOUNT_FOR_SCORE = 50;
        private static int DEFAULT_RESULT = 100;
        private static int ZERO_VALUE = 0;

        public ScoreInput(int team1Score, int team2Score)
        {
            InitializeComponent();

            team1ScoreEntry.Text = team1Score.ToString();
            team2ScoreEntry.Text = team2Score.ToString();
            
            t1Name.Text = NewGame.Team1Name;
            t2Name.Text = NewGame.Team2Name;

        }
         
        private async void Button_Clicked(object sender, EventArgs e)
        {
            int goalsCount1 = Int32.Parse(team1ScoreEntry.Text);
            int goalsCount2 = Int32.Parse(team2ScoreEntry.Text);
            String team1 = t1Name.Text;
            String team2 = t2Name.Text;

            await CalculateRanking(goalsCount1, goalsCount2);
            await WriteReadData.updateMatchesAsync(team1 + " - " + team2 + " " + goalsCount1.ToString() + ":" + goalsCount2.ToString());
            await Navigation.PushAsync(new NavigationMenu());
        }

        public async Task CalculateRanking(int GoalsCount1, int GoalsCount2)
        {
            Team Team1 = await WriteReadData.getTeamAsync(NewGame.Team1Name);
            Team Team2 = await WriteReadData.getTeamAsync(NewGame.Team2Name);

            if (Team1.GlobalScore == NO_VALUE)
                Team1.GlobalScore = INITIAL_SCORE;
            if (Team2.GlobalScore == NO_VALUE)
                Team2.GlobalScore = INITIAL_SCORE;

            int result, xScore = Team1.GlobalScore, yScore = Team2.GlobalScore;

            if((xScore >= yScore && GoalsCount1 >= GoalsCount2) || (xScore <= yScore && GoalsCount1 <= GoalsCount2))
            {
                result = (int) (Math.Abs(GoalsCount1 - GoalsCount2) * AMOUNT_FOR_SCORE * Math.Pow(PROBABILITY_FOR_GEO_PROGRESSION, xScore - yScore));

            } else if((xScore < yScore && GoalsCount1 > GoalsCount2) || (xScore > yScore && GoalsCount1 < GoalsCount2)) {
                result = (int)(Math.Abs(GoalsCount1 - GoalsCount2) * AMOUNT_FOR_SCORE * 2 * Math.Pow(PROBABILITY_FOR_GEO_PROGRESSION, xScore - yScore));
            } else {
                result = DEFAULT_RESULT;
            }

            if (GoalsCount1 > GoalsCount2) {
                xScore += result;
                yScore -= result;
            } else if(GoalsCount1 < GoalsCount2) {
                xScore -= result;
                yScore += result;
            } else {
                xScore += result;
                yScore += result;
            }

            if (xScore < ZERO_VALUE) xScore = ZERO_VALUE;
            if (yScore < ZERO_VALUE) yScore = ZERO_VALUE;

            Team1.GlobalScore = xScore;
            Team2.GlobalScore = yScore;
            await WriteReadData.updateResultsAsync(Team1, Team2);
        }
    }
}