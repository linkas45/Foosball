using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Foosball.Utils;
using System.Windows.Forms;

namespace Foosball
{
    public partial class ScoreInput : Form
    {
        private String Team1Name, Team2Name;
        private static string FILE_PATH = @"Data/Leaderboards.txt";

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

        private void CalculateRanking(Team Team1, Team Team2, int GoalsCount1, int GoalsCount2)
        {
            if (Team1.GlobalScore == -1)
                Team1.GlobalScore = 1000;
            if (Team2.GlobalScore == -1)
                Team2.GlobalScore = 1000;

            int result, xScore = Team1.GlobalScore, yScore = Team2.GlobalScore;

            if((xScore >= yScore && GoalsCount1 >= GoalsCount2) || (xScore <= yScore && GoalsCount1 <= GoalsCount2))
            {
                result = (int) (Math.Abs(GoalsCount1 - GoalsCount2) * 50 * Math.Pow(0.999, xScore - yScore));

            } else if((xScore < yScore && GoalsCount1 > GoalsCount2) || (xScore > yScore && GoalsCount1 < GoalsCount2)) {
                result = (int)(Math.Abs(GoalsCount1 - GoalsCount2) * 100 * Math.Pow(0.999, xScore - yScore));
            } else {
                result = 100;
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

            if (xScore < 0) xScore = 0;
            if (yScore < 0) yScore = 0;

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

            CalculateRanking(team1, team2, goalsCount1, goalsCount2);

            Start_Screen StartScreen = new Start_Screen();
            this.Hide();
            StartScreen.Show();
        }
    }
}
