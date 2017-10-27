using Foosball;
using Foosball.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MyUnitTests
{
    [TestClass]
    public class WriteReadDataTests
    {
        [TestMethod]
        [ExpectedException (typeof(System.IO.DirectoryNotFoundException))]
        public void TestReadDataFromFile()
        {
            string filePath = @"Data/Leaderboards.txt";
            List<Team> teams = WriteReadData.ReadDataFromFile(filePath);

        }


        [TestMethod]
        public void TestWriteDataToFile()
        {
            Team team1 = new Team("left", 9);
            Team team2 = new Team("right", 1);
            List<Team> teams = new List<Team>();
            teams.Add(team1);
            teams.Add(team2);

            string filePath = @"Data/Leaderboards.txt";
            string dir = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), filePath);
            bool expected = true;
            bool result;

            WriteReadData.WriteDataToFile(teams, dir);

            if (new FileInfo(dir).Length != 0) result = true;
            else result = false;

            Assert.AreEqual(expected, result);

        }

    
    }
}
