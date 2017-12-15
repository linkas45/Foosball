using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foosball
{
    class Tournament
    {

        private string TeamName { get; set; }
        private int GoalsScored { get; set; }
        private int GoalsLost { get; set; }
        private int GoalsRatio { get; set; }


        public Tournament(string teamName, int GoalsScored, int GoalsLost, int GoalsRatio)
        {
            TeamName = teamName;
            this.GoalsScored = GoalsScored;
            this.GoalsLost = GoalsLost;
            this.GoalsRatio = GoalsRatio;
        }
    }
}
