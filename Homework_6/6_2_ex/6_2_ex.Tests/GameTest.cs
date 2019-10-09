using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace _6_2_ex.Tests
{
    [TestClass]
    public class GameTest
    {
        [TestMethod]
        [ExpectedException(typeof(NoCharacterException))]
        public void NoCharacterTest()
        {
            string fileName = "TestMap.txt";

            var Game = new Game();
            Game.Start(fileName);
        }
    }
}
