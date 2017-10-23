﻿using Foosball.Utils;
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
    
        public static void WriteDataToFile(ICollection<Team> teams, string filePath)
        {
            string line, path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), filePath);

            if (!File.Exists(path))
                File.WriteAllText(path, String.Empty);

            foreach(Team team in teams)
            {
                line = team.TeamName + " " + team.GlobalScore.ToString() + " " + Environment.NewLine;
                try
                {
                    File.AppendAllText(path, line);
                }
                catch (InvalidOperationException ReadOnly)
                {
                    MessageBox.Show("File is read only");
                }
            }
            
        }

        public static void updateResults(Team team1, Team team2, string filePath)
        {
            ICollection<Team> teams = ReadDataFromFile(filePath);
            /*var newList = from i in teams
                          where i.TeamName.Equals(team1.TeamName)
                          select i;*/
            bool team1Added = false, team2Added = false;
            Console.WriteLine("Dydis: " + teams.Count);
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
           // Console.WriteLine()
            WriteDataToFile(teams, filePath);
        }

        public static ICollection<Team> ReadDataFromFile(string filePath)
        {
            string path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), filePath);

            if (!File.Exists(path))
                File.WriteAllText(path, String.Empty);

            var lines = File.ReadLines(path);
            ICollection<Team> teams = new List<Team>();

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

        public bool TeamIsOnTheList(Team team)
        {


            return true;
        }

    }
}

