using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using PCLStorage;
using System.Diagnostics;
using System.Text.RegularExpressions;

namespace Foosball.Utils
{
    public class WriteReadData
    {
        private static string FILE_ERROR = "File is read only";


        public static async Task updateResultsAsync(Team team1, Team team2)
        {
            
            List<Team> teams = await ReadDataFromFileAsync();
            bool team1Added = false, team2Added = false;
            foreach (Team team in teams)
            {
                if (team.TeamName.Equals(team1.TeamName))
                {
                    team.GlobalScore = team1.GlobalScore;
                    team1Added = true;
                }
                else if (team.TeamName.Equals(team2.TeamName))
                {
                    team.GlobalScore = team2.GlobalScore;
                    team2Added = true;
                }
            }
            if (!team1Added) teams.Add(team1);
            if (!team2Added) teams.Add(team2);
            await WriteDataToFileAsync(teams);
        }

        public static async Task WriteDataToFileAsync(List<Team> teams)
        {
            string line;
            List<Team> SortedList = teams.OrderByDescending(x => x.GlobalScore).ToList();

            IFolder rootFolder = FileSystem.Current.LocalStorage;
            IFolder dataFolder = await rootFolder.CreateFolderAsync("Data", CreationCollisionOption.OpenIfExists).ConfigureAwait(false);
            IFile leaderboardsFile = await dataFolder.CreateFileAsync("Leaderboards.txt", CreationCollisionOption.ReplaceExisting);

            using (Stream streamToWrite = await leaderboardsFile.OpenAsync(FileAccess.ReadAndWrite))
            {
                streamToWrite.Position = streamToWrite.Length;

                if (streamToWrite.CanWrite)
                {
                    foreach(Team team in SortedList)
                    {
                        line = team.TeamName + " " + team.GlobalScore.ToString() + " " + Environment.NewLine;
                        var bufferArray = Encoding.UTF8.GetBytes(line);
                        await streamToWrite.WriteAsync(bufferArray, 0, bufferArray.Length);
                    }
                }

            }

        }


        public static async Task<List<Team>> ReadDataFromFileAsync()
        {
            var text = "";
            try
            {
                IFolder rootFolder = FileSystem.Current.LocalStorage;
                IFolder dataFolder = await rootFolder.CreateFolderAsync("Data", CreationCollisionOption.OpenIfExists).ConfigureAwait(false);
                IFile leaderboardsFile = await dataFolder.CreateFileAsync("Leaderboards.txt", CreationCollisionOption.OpenIfExists);
                text = await leaderboardsFile.ReadAllTextAsync();
            }

            catch(Exception ex)
            {
                Debug.WriteLine(ex);
            }

            List<Team> teams = new List<Team>();
            if (text.Equals(string.Empty))
                return teams;


            string[] linesToSplit = Regex.Split(text, "\\s+");
                int teamsNumber = linesToSplit.Length;


                for (int i = 0; i < teamsNumber - 1; i+=2)
                {
                    try
                    {
                    var name = linesToSplit[i];
                    var score = linesToSplit[i + 1];
                        teams.Add(new Team(name, Int32.Parse(score)));

                    }
                    catch (FormatException e)
                    {
                        Debug.WriteLine(e);
                    }
                }
            return teams;
        }
        

        public static async Task<Team> getTeamAsync(String teamName)
        {
            List<Team> teams = await ReadDataFromFileAsync();
            if (teams != null)
            {
                var team = (from i in teams
                            where i.TeamName == teamName
                            select i).ToList();

                if (team.Count != 0) return team.ElementAt(0);
                else return new Team(teamName, -1);
            }
            else
            {
                return new Team(teamName, -1);
            }
        }

    }

}
