using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace _6_2_ex.Tests
{
    [TestClass]
    public class GameTest
    {
        private Game game;

        [TestMethod]
        public void IsReadingMapCorrestTest()
        {

        }

        [TestMethod]
        public void GoToWallTest()
        {
            game = new Game("TestMap.txt", null);

            Assert.IsFalse(game.OnDown());
            Assert.IsFalse(game.OnRight());

            var startMap = FileExtraFunctions.MakeArrayFromList(FileExtraFunctions.ReadMapFromFile("TestMap.txt"));

            for (int i = 0; i < startMap.GetLength(0); ++i)
            {
                for (int j = 0; j < startMap.GetLength(1); ++j)
                {
                    Assert.AreEqual(startMap[i, j], game.Map.Map[i, j]);
                }
            }
        }

        [TestMethod]
        public void GoToEndOfMapTest()
        {
            game = new Game("TestMapEndPosition.txt", null);

            Assert.IsFalse(game.OnLeft());

            var startMap = FileExtraFunctions.MakeArrayFromList(FileExtraFunctions.ReadMapFromFile("TestMapEndPosition.txt"));

            for (int i = 0; i < startMap.GetLength(0); ++i)
            {
                for (int j = 0; j < startMap.GetLength(1); ++j)
                {
                    Assert.AreEqual(startMap[i, j], game.Map.Map[i, j]);
                }
            }
        }

        [TestMethod]
        public void GoToSpaceTest()
        {
            game = new Game("TestMap.txt", null);

            Assert.IsTrue(game.OnLeft());
            Assert.IsTrue(game.OnLeft());
            Assert.IsTrue(game.OnRight());
            Assert.IsTrue(game.OnLeft());
            Assert.IsTrue(game.OnDown());
            Assert.IsTrue(game.OnUp());

            var mapAfterSteps = FileExtraFunctions.MakeArrayFromList(FileExtraFunctions.ReadMapFromFile("TestMapAfterSteps.txt"));

            for (int i = 0; i < mapAfterSteps.GetLength(0); ++i)
            {
                for (int j = 0; j < mapAfterSteps.GetLength(1); ++j)
                {
                    Assert.AreEqual(mapAfterSteps[i, j], game.Map.Map[i, j]);
                }
            }
        }

        [TestMethod]
        public void ExceptionsTest()
        {
            Assert.ThrowsException<NoCharacterException>(() => game = new Game("TestMapNoCharacter.txt", null));
        }
    }
}
