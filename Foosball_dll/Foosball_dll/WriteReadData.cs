﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PCLStorage;
using System.IO;
using System.Text.RegularExpressions;
using Foosball_dll.Utils;
using Foosball_dll.Interfaces;
using System.Diagnostics;
using System.Threading;

namespace Foosball_dll
{
    public class WriteReadData : IWriteReadData
    {
        private ISelectFile _selectFile = new SelectFile();

        public WriteReadData()
        {
        }

        //Update leaderboards information with last game info
        private async Task<List<Team>> UpdateResultsAsync(Team team1, Team team2)
        {
            List<Team> teams = await ReadTeamsDataFromFileAsync();

            bool team1Added = false, team2Added = false;
            foreach (Team team in teams)
            {
                //Searching for team to update
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


        //Write leaderboards information to file
        //Data in file form:
        //Name:Score
        public async Task WriteTeamsDataToFileAsync(Team team1, Team team2)
        {

            List<Team> teams = await UpdateResultsAsync(team1, team2);
            var leaderboardsFile = await _selectFile.GetDataWrite();



            string line;
            List<Team> SortedList = teams.OrderByDescending(x => x.GlobalScore).ToList();

            Monitor.Enter(SortedList);

            try
            {

                using (Stream streamToWrite = await leaderboardsFile.OpenAsync(PCLStorage.FileAccess.ReadAndWrite))
                {
                    streamToWrite.Position = streamToWrite.Length;

                    if (streamToWrite.CanWrite)
                    {
                        foreach (Team team in SortedList)
                        {
                            line = team.TeamName + ":" + team.GlobalScore.ToString() + Environment.NewLine;
                            var bufferArray = Encoding.UTF8.GetBytes(line);
                            await streamToWrite.WriteAsync(bufferArray, 0, bufferArray.Length);
                        }
                    }

                }
            }
            finally
            {
                Monitor.Exit(SortedList);
            }

        }


        //Read leaderboards information from file
        public async Task<List<Team>> ReadTeamsDataFromFileAsync()
        {

            List<Team> teams = new List<Team>();
            var leaderboardsFile = await _selectFile.GetDataRead();

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

            //Split lines into parts
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


        //Get team information. Team name and global score
        public async Task<Team> GetTeamAsync(String teamName)
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

        //Get team global score.
        public async Task<int> GetTeamScore(string teamName)
        {
            Team team = await GetTeamAsync(teamName);

            return team.GlobalScore;
        }


        //Add match to history list
        private async Task<List<MatchInfo>> UpdateMatchesAsync()
        {
            List<MatchInfo> matches = await ReadMatchesDataFromFileAsync();
            matches.Add(new MatchInfo());
            return matches;
        }


        //Write history data to file
        public async Task WriteMatchesDataToFileAsync()
        {
            //Line to write
            //Format:
            //Name1::Name2::Score1:Score2

            List<MatchInfo> Matches = await UpdateMatchesAsync();
            var historyFile = await _selectFile.GetMatchesWrite();

            string line;

            using (Stream streamToWrite = await historyFile.OpenAsync(PCLStorage.FileAccess.ReadAndWrite))
            {
                streamToWrite.Position = streamToWrite.Length;

                if (streamToWrite.CanWrite)
                {
                    foreach (MatchInfo match in Matches)
                    {
                        line = match.Team1Name + "::" + match.Team2Name + "::" + match.Score + Environment.NewLine;
                        var bufferArray = Encoding.UTF8.GetBytes(line);
                        await streamToWrite.WriteAsync(bufferArray, 0, bufferArray.Length);
                    }
                }

            }

        }


        //Read history data from file
        public async Task<List<MatchInfo>> ReadMatchesDataFromFileAsync()
        {
            List<MatchInfo> matches = new List<MatchInfo>();
            var historyFile = await _selectFile.GetMatchesRead();
            var regexPattern = @"(.*)::(.*)::(.*)\n";

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

            //Split lines read to parse info
            MatchCollection Matches = Regex.Matches(text, regexPattern);

            foreach(Match match in Matches)
            {
                matches.Add(new MatchInfo(match.Groups[1].Value, match.Groups[2].Value, match.Groups[3].Value));
            }

            return matches;
        }
        
    }
}
