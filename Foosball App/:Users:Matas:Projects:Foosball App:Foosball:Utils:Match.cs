using System;

using Xamarin.Forms;

namespace Foosball.Utils
{
    public class Match
    {
        public string TeamName { get; set; }
        public int GlobalScore { get; set; }
        public int Standing { get; set; }
        public Match(string teamName, int globalScore)
        {
            TeamName = teamName;
            GlobalScore = globalScore;
        }

    }
}

