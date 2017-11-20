using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foosball_dll.Utils
{
    public static class CurrentGameInfo
    {
        public static string Team1Name { get; set; }
        public static string Team2Name { get; set; }

        public static int Team1Score { get; set; }
        public static int Team2Score { get; set; }


    }
}
