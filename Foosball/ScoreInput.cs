using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Foosball
{
    public partial class ScoreInput : Form
    {
        private int goalsCount1, goalsCount2;
        private string team1Name, team2Name;
        public ScoreInput(int goalsCnt1,int goalsCnt2)
        {
            InitializeComponent();
            TextBoxGoalsCount1.AppendText(goalsCnt1.ToString());
            TextBoxGoalsCount2.AppendText(goalsCnt2.ToString());
        }

        private void ScoreInput_Load(object sender, EventArgs e)
        {
            Start_Screen StartScreen = new Start_Screen();
            this.team1Name = StartScreen.Team1Name;
            this.team2Name = StartScreen.Team2Name;
            TextBoxTeamName1.AppendText(team1Name + ": ");
            TextBoxTeamName2.AppendText(team2Name + ": ");

        }

        private void TextBox_TextChanged(object sender, EventArgs e)
        {
            

        }

        private void GoalsCountTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void SubmitButton_Click(object sender, EventArgs e)
        {
            this.goalsCount1 = Int32.Parse(TextBoxGoalsCount1.Text);
            this.goalsCount2 = Int32.Parse(TextBoxGoalsCount2.Text);

            Start_Screen StartScreen = new Start_Screen();
            this.Hide();
            StartScreen.Show();
        }
    }
}
