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
    public partial class Start_Screen : Form
    {
        private static string team1Name;
        public string Team1Name
        {
            get { return team1Name; }
            set { team1Name = value; }
        }

        private static string team2Name;
        public string Team2Name
        {
            get { return team2Name; }
            set { team2Name = value; }
        }

        public Start_Screen()
        {
            InitializeComponent();
        }

        private void Start_Screen_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void TeamNameInput_TextChanged(object sender, EventArgs e)
        {

        }

        private void Start_Click(object sender, EventArgs e)
        {
            if (TextBoxTeam1NameInput.Text == "" || TextBoxTeam2NameInput.Text == "")
            {
                MessageBox.Show("Enter your team names");
            }
            else
            {
                Counting_Goals countingGoals = new Counting_Goals(TextBoxTeam1NameInput.Text, TextBoxTeam2NameInput.Text);
                this.Hide();
                countingGoals.Show();
            }

        }
    }
}
