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
        private int goalsCount;
        private string teamName;
        public ScoreInput(int goalsCnt)
        {
            InitializeComponent();
            GoalsCountTextBox.AppendText(goalsCnt.ToString());
        }

        private void ScoreInput_Load(object sender, EventArgs e)
        {
            Start_Screen StartScreen = new Start_Screen();
            this.teamName = StartScreen.TeamName;
            TextBox.AppendText("How many goals did " + StartScreen.TeamName + " score?");

        }

        private void TextBox_TextChanged(object sender, EventArgs e)
        {
            

        }

        private void GoalsCountTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void SubmitButton_Click(object sender, EventArgs e)
        {
            this.goalsCount = Int32.Parse(GoalsCountTextBox.Text);
        }
    }
}
