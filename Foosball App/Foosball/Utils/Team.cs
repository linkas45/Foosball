using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foosball.Utils
{
    public class Team
    {
        public string TeamName { get; set; }
        public int GlobalScore { get; set; }
        public int Standing { get; set; }
        public Team(string teamName, int globalScore)
        {
            TeamName = teamName;
            GlobalScore = globalScore;
        }

    }
}
