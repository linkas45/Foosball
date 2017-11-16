using System;
using Foosball.Utils;
using System.Windows.Forms;

namespace Foosball
{
    public partial class ScoreInput : Form
    {
        private String Team1Name, Team2Name;

        //Constants
        private static string FILE_PATH = @"Data/Leaderboards.txt";
        private static int INITIAL_SCORE = 1000;
        private static int NO_VALUE = -1;
        private static double PROBABILITY_FOR_GEO_PROGRESSION = 0.999;
        private static int AMOUNT_FOR_SCORE = 50;
        private static int DEFAULT_RESULT = 100;
        private static int ZERO_VALUE = 0;

        public ScoreInput(int goalsCnt1, int goalsCnt2, String Team1Name, String Team2Name)
        {
            InitializeComponent();
            TextBoxGoalsCount1.AppendText(goalsCnt1.ToString());
            TextBoxGoalsCount2.AppendText(goalsCnt2.ToString());
            this.Team1Name = Team1Name;
            this.Team2Name = Team2Name;
        }

        private void ScoreInput_Load(object sender, EventArgs e)
        {
            TextBoxTeamName1.AppendText(Team1Name + ": ");
            TextBoxTeamName2.AppendText(Team2Name + ": ");

        }

        private void TextBox_TextChanged(object sender, EventArgs e)
        {
            

        }

        private void GoalsCountTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        public void CalculateRanking(ref Team Team1, ref Team Team2, int GoalsCount1, int GoalsCount2)
        {
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
            WriteReadData.updateResults(Team1, Team2, FILE_PATH);
        }

        private void SubmitButton_Click(object sender, EventArgs e)
        {
            int goalsCount1 = Int32.Parse(TextBoxGoalsCount1.Text);
            int goalsCount2 = Int32.Parse(TextBoxGoalsCount2.Text);

            Team team1 = WriteReadData.getTeam(Team1Name, FILE_PATH);
            Team team2 = WriteReadData.getTeam(Team2Name, FILE_PATH);

            CalculateRanking(ref team1, ref team2, goalsCount1, goalsCount2);

            //Start_Screen StartScreen = new Start_Screen();
            Leaderboards leaderboards = new Leaderboards();
            this.Hide();
            leaderboards.Show();
        }
    }
}
