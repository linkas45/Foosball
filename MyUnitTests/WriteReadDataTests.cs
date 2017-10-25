using Foosball;
using Foosball.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
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
            ICollection<Team> teams = WriteReadData.ReadDataFromFile(filePath);

        }

    }
}
