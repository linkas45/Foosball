using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Foosball_dll.Utils;

namespace Foosball_dll
{

    public class CalculateRanking
    {
        //Constants
        private static int INITIAL_SCORE = 1000;
        private static int NO_VALUE = -1;
        private static double PROBABILITY_FOR_GEO_PROGRESSION = 0.999;
        private static int AMOUNT_FOR_SCORE = 50;
        private static int DEFAULT_RESULT = 100;
        private static int ZERO_VALUE = 0;

        public static async void CalcRanking(int GoalsCount1, int GoalsCount2)
        {
            int GlobalScore1 = await WriteReadData.getTeamScore(CurrentGameInfo.Team1Name);
            int GlobalScore2 = await WriteReadData.getTeamScore(CurrentGameInfo.Team2Name);

            int[] scores = new int[2];

            if (GlobalScore1 == NO_VALUE)
                GlobalScore1 = INITIAL_SCORE;
            if (GlobalScore2 == NO_VALUE)
                GlobalScore2 = INITIAL_SCORE;

            int result, xScore = GlobalScore1, yScore = GlobalScore2;

            if ((xScore >= yScore && GoalsCount1 >= GoalsCount2) || (xScore <= yScore && GoalsCount1 <= GoalsCount2))
            {
                result = (int)(Math.Abs(GoalsCount1 - GoalsCount2) * AMOUNT_FOR_SCORE * Math.Pow(PROBABILITY_FOR_GEO_PROGRESSION, xScore - yScore));

            }
            else if ((xScore < yScore && GoalsCount1 > GoalsCount2) || (xScore > yScore && GoalsCount1 < GoalsCount2))
            {
                result = (int)(Math.Abs(GoalsCount1 - GoalsCount2) * AMOUNT_FOR_SCORE * 2 * Math.Pow(PROBABILITY_FOR_GEO_PROGRESSION, xScore - yScore));
            }
            else
            {
                result = DEFAULT_RESULT;
            }

            if (GoalsCount1 > GoalsCount2)
            {
                xScore += result;
                yScore -= result;
            }
            else if (GoalsCount1 < GoalsCount2)
            {
                xScore -= result;
                yScore += result;
            }
            else
            {
                xScore += result;
                yScore += result;
            }

            if (xScore < ZERO_VALUE) xScore = ZERO_VALUE;
            if (yScore < ZERO_VALUE) yScore = ZERO_VALUE;

            GlobalScore1 = xScore;
            GlobalScore2 = yScore;

            Team team1 = new Team(CurrentGameInfo.Team1Name, GlobalScore1);
            Team team2 = new Team(CurrentGameInfo.Team2Name, GlobalScore2);

            await WriteReadData.WriteTeamsDataToFileAsync(team1, team2);

        }
    }

    
}
