using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Foosball;
using Foosball.Utils;

namespace MyUnitTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void CorrectRanking()
        {
            Team team1 = new Team("good_team", 1600);
            Team team2 = new Team("bad_team", 400);
            int GoalCount1 = 3, GoalCount2 = 0;
            ScoreInput scoreInput = new ScoreInput(GoalCount1, GoalCount2, "good_team", "bad_team");
            scoreInput.CalculateRanking(ref team1, ref team2, GoalCount1, GoalCount2);
            Assert.IsTrue((team1.GlobalScore > 1600 && team2.GlobalScore < 400) ? true : false, "Failed");
        }

        [TestMethod]
        public void CorrectRanking2()
        {
            Team team1 = new Team("good_team", 1100);
            Team team2 = new Team("bad_team", 1000);
            int GoalCount1 = 2, GoalCount2 = 0;
            ScoreInput scoreInput = new ScoreInput(GoalCount1, GoalCount2, "good_team", "bad_team");
            scoreInput.CalculateRanking(ref team1, ref team2, GoalCount1, GoalCount2);
            Assert.IsTrue((team1.GlobalScore > 1100 && team2.GlobalScore < 1000) ? true : false, "Failed");
        }

        [TestMethod]
        public void CorrectRanking3()
        {
            Team team1 = new Team("good_team", 1600);
            Team team2 = new Team("bad_team", 400);
            int GoalCount1 = 0, GoalCount2 = 5;
            ScoreInput scoreInput = new ScoreInput(GoalCount1, GoalCount2, "good_team", "bad_team");
            scoreInput.CalculateRanking(ref team1, ref team2, GoalCount1, GoalCount2);
            Assert.IsTrue((team1.GlobalScore < 1500 && team2.GlobalScore > 500) ? true : false, "Failed");
        }

        [TestMethod]
        public void CorrectRanking4()
        {
            Team team1 = new Team("good_team", 700);
            Team team2 = new Team("bad_team", 400);
            int GoalCount1 = 3, GoalCount2 = 0;
            ScoreInput scoreInput = new ScoreInput(GoalCount1, GoalCount2, "good_team", "bad_team");
            scoreInput.CalculateRanking(ref team1, ref team2, GoalCount1, GoalCount2);
            Assert.IsTrue((team1.GlobalScore > 700 && team2.GlobalScore < 400) ? true : false, "Failed");
        }

        [TestMethod]
        public void CorrectRanking5()
        {
            Team team1 = new Team("good_team", 1600);
            Team team2 = new Team("bad_team", 400);
            int GoalCount1 = 3, GoalCount2 = 10;
            ScoreInput scoreInput = new ScoreInput(GoalCount1, GoalCount2, "good_team", "bad_team");
            scoreInput.CalculateRanking(ref team1, ref team2, GoalCount1, GoalCount2);
            Assert.IsTrue((team1.GlobalScore < 1400 && team2.GlobalScore > 600) ? true : false, "Failed");
        }


        [TestMethod]
        public void CorrectRanking6()
        {
            Team team1 = new Team("good_team", 100);
            Team team2 = new Team("bad_team", 200);
            int GoalCount1 = 3, GoalCount2 = 0;
            ScoreInput scoreInput = new ScoreInput(GoalCount1, GoalCount2, "good_team", "bad_team");
            scoreInput.CalculateRanking(ref team1, ref team2, GoalCount1, GoalCount2);
            Assert.IsTrue((team1.GlobalScore > 400 && team2.GlobalScore < 50) ? true : false, "Failed");
        }


        [TestMethod]
        public void CorrectRanking7()
        {
            Team team1 = new Team("good_team", 100);
            Team team2 = new Team("bad_team", 1000);
            int GoalCount1 = 13, GoalCount2 = 0;
            ScoreInput scoreInput = new ScoreInput(GoalCount1, GoalCount2, "good_team", "bad_team");
            scoreInput.CalculateRanking(ref team1, ref team2, GoalCount1, GoalCount2);
            Assert.IsTrue((team1.GlobalScore > 2000 && team2.GlobalScore < 100) ? true : false, "Failed");
        }
    }
}
