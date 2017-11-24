using Foosball_dll.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foosball_dll.Interfaces
{
    public interface IWriteReadData
    {
        Task WriteTeamsDataToFileAsync(Team team1, Team team2);
        Task<List<Team>> ReadTeamsDataFromFileAsync();
        Task<Team> GetTeamAsync(String teamName);
        Task<int> GetTeamScore(string teamName);
        Task WriteMatchesDataToFileAsync();
        Task<List<MatchInfo>> ReadMatchesDataFromFileAsync();

    }
}
