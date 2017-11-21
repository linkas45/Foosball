using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PCLStorage;
using System.IO;
using System.Text.RegularExpressions;
using Foosball_dll.Utils;
using System.Diagnostics;

namespace Foosball_dll
{
    public class WriteReadData
    {
        public static async Task<List<Team>> updateResultsAsync(Team team1, Team team2)
        {
            List<Team> teams = await ReadTeamsDataFromFileAsync();

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

            return teams;
        }

        public static async Task WriteTeamsDataToFileAsync(Team team1, Team team2)
        {

            List<Team> teams = await updateResultsAsync(team1, team2);
            var leaderboardsFile = await SelectFile.GetDataWrite();

            string line;
            List<Team> SortedList = teams.OrderByDescending(x => x.GlobalScore).ToList();

            using (Stream streamToWrite = await leaderboardsFile.OpenAsync(PCLStorage.FileAccess.ReadAndWrite))
            {
                streamToWrite.Position = streamToWrite.Length;

                if (streamToWrite.CanWrite)
                {
                    foreach (Team team in SortedList)
                    {
                        line = team.TeamName + ":" + team.GlobalScore.ToString() +  Environment.NewLine;
                        var bufferArray = Encoding.UTF8.GetBytes(line);
                        await streamToWrite.WriteAsync(bufferArray, 0, bufferArray.Length);
                    }
                }

            }

        }


        public static async Task<List<Team>> ReadTeamsDataFromFileAsync()
        {
            List<Team> teams = new List<Team>();
            var leaderboardsFile = await SelectFile.GetDataRead();

            string text = "";
            try
            {
                text = await leaderboardsFile.ReadAllTextAsync();
            }

            catch (Exception ex)
            {
                
            }
            if (text.Equals(string.Empty))
                return teams;

            string[] linesToSplit = Regex.Split(text, ":|\n");
            int teamsNumber = linesToSplit.Length;

            for (int i = 0; i < teamsNumber - 1; i += 2)
            {
                try
                {
                    var name = linesToSplit[i];
                    var score = linesToSplit[i + 1];
                    teams.Add(new Team(name, Int32.Parse(score)));

                }
                catch (FormatException e)
                {

                }
            }
            return teams;
        }


        public static async Task<Team> getTeamAsync(String teamName)
        {
            List<Team> teams= await ReadTeamsDataFromFileAsync();
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

        public static async Task<int> getTeamScore(string teamName)
        {
            Team team = await getTeamAsync(teamName);

            return team.GlobalScore;
        }

        public static async Task<List<string>> updateMatchesAsync(string match)
        {
            List<string> matches = await ReadMatchesDataFromFileAsync();
            matches.Add(match);
            return matches;
        }


        public static async Task WriteMatchesDataToFileAsync(string matchInfo)
        {
            matchInfo = CurrentGameInfo.Team1Name + " " + CurrentGameInfo.Team2Name + " " + matchInfo;
            List<string> Matches = await updateMatchesAsync(matchInfo);
            var historyFile = await SelectFile.GetMatchesWrite();

            string line;

            using (Stream streamToWrite = await historyFile.OpenAsync(PCLStorage.FileAccess.ReadAndWrite))
            {
                streamToWrite.Position = streamToWrite.Length;

                if (streamToWrite.CanWrite)
                {
                    foreach (string match in Matches)
                    {
                        line = match + " " + Environment.NewLine;
                        var bufferArray = Encoding.UTF8.GetBytes(line);
                        await streamToWrite.WriteAsync(bufferArray, 0, bufferArray.Length);
                    }
                }

            }

        }

        public static async Task<List<string>> ReadMatchesDataFromFileAsync()
        {
            List<string> matches = new List<string>();
            var historyFile = await SelectFile.GetMatchesRead();

            string text = "";
            try
            {
                text = await historyFile.ReadAllTextAsync();
            }
            
            catch (Exception ex)
            {

            }
            if (text.Equals(string.Empty))
                return matches;

            string[] linesToSplit = Regex.Split(text, "\\s+");
            int matchesNumber = linesToSplit.Length;

            for (int i = 0; i < matchesNumber - 1; i++)
            {
                try
                {

                    var match = linesToSplit[i];
                    matches.Add(match);

                }
                catch (FormatException e)
                {
                    Debug.WriteLine(e);
                }
            }
            return matches;
        }



    }
}
