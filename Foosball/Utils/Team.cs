namespace Foosball.Utils
{
    public class Team
    {
        public string TeamName { get; set; }
        public int GlobalScore { get; set; }

        public Team(string teamName, int globalScore)
        {
            TeamName = teamName;
            GlobalScore = globalScore;
        }

    }
}
