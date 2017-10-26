using Foosball.Utils;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Foosball
{
    public class WriteReadData
    {
        private static string FILE_ERROR = "File is read only";

        public static void updateResults(Team team1, Team team2, string filePath)
        {
            List<Team> teams = ReadDataFromFile(filePath);
            bool team1Added = false, team2Added = false;
            foreach(Team team in teams)
            {
                if (team.TeamName.Equals(team1.TeamName))
                {
                    team.GlobalScore = team1.GlobalScore;
                    team1Added = true;
                } else if (team.TeamName.Equals(team2.TeamName))
                {
                    team.GlobalScore = team2.GlobalScore;
                    team2Added = true;
                }
            }
            if (!team1Added) teams.Add(team1);
            if (!team2Added) teams.Add(team2);
            WriteDataToFile(teams, filePath);
        }

        public static void WriteDataToFile(List<Team> teams, string filePath)
        {
            string line, path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), filePath);

            if (!File.Exists(path)) {
                File.WriteAllText(path, String.Empty);
            }

            File.WriteAllText(path, String.Empty);

            List<Team> SortedList = teams.OrderByDescending(x => x.GlobalScore).ToList();

            foreach (Team team in SortedList)
            {
                line = team.TeamName + " " + team.GlobalScore.ToString() + " " + Environment.NewLine;
                try
                {
                    File.AppendAllText(path, line);
                }
                catch (InvalidOperationException ReadOnly)
                {
                    MessageBox.Show(FILE_ERROR);
                }
            }

        }

        public static List<Team> ReadDataFromFile(string filePath)
        {
            string path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), filePath);

            if (!File.Exists(path))
                File.WriteAllText(path, String.Empty);

            var lines = File.ReadLines(path);
            List<Team> teams = new List<Team>();

            //possible Regex
            foreach (String line in lines)
            {

                string[] linesToSplit = line.Split(' ');

                try
                {
                    teams.Add(new Team(linesToSplit[0], Int32.Parse(linesToSplit[1])));
                }
                catch (FormatException e)
                {
                    Console.WriteLine(e.Message);
                }
            }

            return teams;
        }

        public static Team getTeam(String teamName, String filePath)
        {
            List<Team> teams = ReadDataFromFile(filePath);
            if (teams != null) {
                var team = (from i in teams
                            where i.TeamName == teamName
                            select i).ToList();

                if (team.Count != 0) return team.ElementAt(0);
                else return new Team(teamName, -1);
            }
            else {
                return new Team(teamName, -1);
            }
        }

    }
}

