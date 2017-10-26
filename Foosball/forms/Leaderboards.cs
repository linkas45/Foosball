using Foosball.Utils;
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
    public partial class Leaderboards : Form
    {
        //Constants
        private static string FILE_PATH = @"Data/Leaderboards.txt";
        private static string STANDING = "Standing";
        private static string TEAM_NAME = "Team Name";
        private static string RANKING = "Ranking";

        public Leaderboards()
        {
            InitializeComponent();

        }

        private void Leaderboards_Load(object sender, EventArgs e)
        {
            leaderBoard.View = View.Details;
            leaderBoard.Columns.Add(STANDING);
            leaderBoard.Columns.Add(TEAM_NAME);
            leaderBoard.Columns.Add(RANKING);
           
            List<Team> teams = WriteReadData.ReadDataFromFile(FILE_PATH);

            int i = 1;
            foreach (Team team in teams)
            {
                leaderBoard.Items.Add(new ListViewItem(new string[] {i.ToString(), team.TeamName, team.GlobalScore.ToString() }));
                i++;
            }

        }   

        private void button1_Click(object sender, EventArgs e)
        {
            Start_Screen start_Screen = new Start_Screen();
            this.Hide();
            start_Screen.Show();
        }
    }
}
