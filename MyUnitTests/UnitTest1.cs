using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Foosball;

namespace MyUnitTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void wasGoalTest()
        {
            String filePath = "./Resources/VID_20171020_100012.mp4";

            Counting_Goals goal = new Counting_Goals();
            bool success = goal.wasGoal(filePath);
            Assert.AreEqual(1, success);
        }
    }
}
