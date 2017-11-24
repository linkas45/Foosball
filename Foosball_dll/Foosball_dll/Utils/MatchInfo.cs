namespace Foosball_dll.Utils
{
    public class MatchInfo
    {
        public string Team1Name { get; set; }
        public string Team2Name { get; set; }
        public string Score { get; set; }

        public MatchInfo(string Name1, string Name2, string score)
        {
            Team1Name = Name1;
            Team2Name = Name2;

            Score = score;
        }

        public MatchInfo()
        {
            Team1Name = CurrentGameInfo.Team1Name;
            Team2Name = CurrentGameInfo.Team2Name;
            Score = CurrentGameInfo.Team1Score + ":" + CurrentGameInfo.Team2Score;
    }

    }
}
