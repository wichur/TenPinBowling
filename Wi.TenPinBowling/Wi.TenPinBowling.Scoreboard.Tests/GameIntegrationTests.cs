using Microsoft.VisualStudio.TestTools.UnitTesting;
using Wi.TenPinBowling.Scoreboard.Model;
using Wi.TenPinBowling.Scoreboard.Rules;
using Wi.TenPinBowling.Scoreboard.Services;

namespace Wi.TenPinBowling.Scoreboard.Tests
{
    [TestClass]
    public class GameIntegrationTests
    {
        [TestMethod]
        public void GameGovernorService_NormalRolls_True()
        {
            var sut = new GameGovernorService(new GameService(), new PlayerService(), new FrameService(), new ScoreService());

            sut.StartNewGame(1);

            sut.MoveToNextPlayer();

            sut.MoveToNextFrame();
            sut.MoveToNextRoll();
            sut.StoreRollOutcome(1);

            Assert.AreEqual(1, sut.CurrentGame.CurrentPlayer.TotalPoints);

            sut.MoveToNextRoll();
            sut.StoreRollOutcome(1);

            Assert.AreEqual(2, sut.CurrentGame.CurrentPlayer.TotalPoints);

            sut.MoveToNextFrame();
            sut.MoveToNextRoll();
            sut.StoreRollOutcome(1);

            Assert.AreEqual(3, sut.CurrentGame.CurrentPlayer.TotalPoints);

            sut.MoveToNextRoll();
            sut.StoreRollOutcome(1);

            Assert.AreEqual(4, sut.CurrentGame.CurrentPlayer.TotalPoints);

            sut.MoveToNextFrame();
            sut.MoveToNextRoll();
            sut.StoreRollOutcome(1);

            Assert.AreEqual(5, sut.CurrentGame.CurrentPlayer.TotalPoints);

            sut.MoveToNextRoll();
            sut.StoreRollOutcome(1);

            Assert.AreEqual(6, sut.CurrentGame.CurrentPlayer.TotalPoints);
        }

        [TestMethod]
        public void GameGovernorService_OneSpare_True()
        {
            var sut = new GameGovernorService(new GameService(), new PlayerService(), new FrameService(), new ScoreService());

            sut.StartNewGame(1);

            sut.MoveToNextPlayer();

            sut.MoveToNextFrame();
            sut.MoveToNextRoll();
            sut.StoreRollOutcome(1);

            Assert.AreEqual(1, sut.CurrentGame.CurrentPlayer.TotalPoints);

            sut.MoveToNextRoll();
            sut.StoreRollOutcome(9);

            Assert.AreEqual(10, sut.CurrentGame.CurrentPlayer.TotalPoints);

            sut.MoveToNextFrame();
            sut.MoveToNextRoll();
            sut.StoreRollOutcome(1);

            Assert.AreEqual(12, sut.CurrentGame.CurrentPlayer.TotalPoints);

            sut.MoveToNextRoll();
            sut.StoreRollOutcome(1);

            Assert.AreEqual(13, sut.CurrentGame.CurrentPlayer.TotalPoints);
        }

        [TestMethod]
        public void GameGovernorService_TwoSpares_True()
        {
            var sut = new GameGovernorService(new GameService(), new PlayerService(), new FrameService(), new ScoreService());

            sut.StartNewGame(1);

            sut.MoveToNextPlayer();

            sut.MoveToNextFrame();
            sut.MoveToNextRoll();
            sut.StoreRollOutcome(1);

            Assert.AreEqual(1, sut.CurrentGame.CurrentPlayer.TotalPoints);

            sut.MoveToNextRoll();
            sut.StoreRollOutcome(9);

            Assert.AreEqual(10, sut.CurrentGame.CurrentPlayer.TotalPoints);

            sut.MoveToNextFrame();
            sut.MoveToNextRoll();
            sut.StoreRollOutcome(1);

            Assert.AreEqual(12, sut.CurrentGame.CurrentPlayer.TotalPoints);

            sut.MoveToNextRoll();
            sut.StoreRollOutcome(9);

            Assert.AreEqual(21, sut.CurrentGame.CurrentPlayer.TotalPoints);

            sut.MoveToNextFrame();
            sut.MoveToNextRoll();
            sut.StoreRollOutcome(1);

            Assert.AreEqual(23, sut.CurrentGame.CurrentPlayer.TotalPoints);
        }

        [TestMethod]
        public void GameGovernorService_OneStrikeOneRoll_True()
        {
            var sut = new GameGovernorService(new GameService(), new PlayerService(), new FrameService(), new ScoreService());

            sut.StartNewGame(1);

            sut.MoveToNextPlayer();

            sut.MoveToNextFrame();
            sut.MoveToNextRoll();
            sut.StoreRollOutcome(10);

            Assert.AreEqual(10, sut.CurrentGame.CurrentPlayer.TotalPoints);

            sut.MoveToNextFrame();
            sut.MoveToNextRoll();
            sut.StoreRollOutcome(1);

            Assert.AreEqual(12, sut.CurrentGame.CurrentPlayer.TotalPoints);
        }

        [TestMethod]
        public void GameGovernorService_OneStrikeTwoRolls_True()
        {
            var sut = new GameGovernorService(new GameService(), new PlayerService(), new FrameService(), new ScoreService());

            sut.StartNewGame(1);

            sut.MoveToNextPlayer();

            sut.MoveToNextFrame();
            sut.MoveToNextRoll();
            sut.StoreRollOutcome(10);

            Assert.AreEqual(10, sut.CurrentGame.CurrentPlayer.TotalPoints);

            sut.MoveToNextFrame();
            sut.MoveToNextRoll();
            sut.StoreRollOutcome(1);
            sut.MoveToNextRoll();
            sut.StoreRollOutcome(1);

            Assert.AreEqual(14, sut.CurrentGame.CurrentPlayer.TotalPoints);
        }

        [TestMethod]
        public void GameGovernorService_OneStrikeFollowedByStrike_True()
        {
            var sut = new GameGovernorService(new GameService(), new PlayerService(), new FrameService(), new ScoreService());

            sut.StartNewGame(1);

            sut.MoveToNextPlayer();

            sut.MoveToNextFrame();
            sut.MoveToNextRoll();
            sut.StoreRollOutcome(10);

            Assert.AreEqual(10, sut.CurrentGame.CurrentPlayer.TotalPoints);

            sut.MoveToNextFrame();
            sut.MoveToNextRoll();
            sut.StoreRollOutcome(10);

            Assert.AreEqual(30, sut.CurrentGame.CurrentPlayer.TotalPoints);

            sut.MoveToNextFrame();
            sut.MoveToNextRoll();
            sut.StoreRollOutcome(1);

            Assert.AreEqual(33, sut.CurrentGame.CurrentPlayer.TotalPoints);

            sut.MoveToNextRoll();
            sut.StoreRollOutcome(1);

            Assert.AreEqual(35, sut.CurrentGame.CurrentPlayer.TotalPoints);

            sut.MoveToNextFrame();
            sut.MoveToNextRoll();
            sut.StoreRollOutcome(1);

            Assert.AreEqual(36, sut.CurrentGame.CurrentPlayer.TotalPoints);
        }

        [TestMethod]
        public void GameGovernorService_OneStrikeFollowedBySpare_True()
        {
            var sut = new GameGovernorService(new GameService(), new PlayerService(), new FrameService(), new ScoreService());

            sut.StartNewGame(1);

            sut.MoveToNextPlayer();

            sut.MoveToNextFrame();
            sut.MoveToNextRoll();
            sut.StoreRollOutcome(10);

            Assert.AreEqual(10, sut.CurrentGame.CurrentPlayer.TotalPoints);

            sut.MoveToNextFrame();
            sut.MoveToNextRoll();
            sut.StoreRollOutcome(1);

            Assert.AreEqual(12, sut.CurrentGame.CurrentPlayer.TotalPoints);

            sut.MoveToNextRoll();
            sut.StoreRollOutcome(9);

            Assert.AreEqual(30, sut.CurrentGame.CurrentPlayer.TotalPoints);

            sut.MoveToNextFrame();
            sut.MoveToNextRoll();
            sut.StoreRollOutcome(1);

            Assert.AreEqual(32, sut.CurrentGame.CurrentPlayer.TotalPoints);

            sut.MoveToNextRoll();
            sut.StoreRollOutcome(1);

            Assert.AreEqual(33, sut.CurrentGame.CurrentPlayer.TotalPoints);
        }

        [TestMethod]
        public void GameGovernorService_IsGutter_True()
        {
            var sut = new GameGovernorService(new GameService(), new PlayerService(), new FrameService(), new ScoreService());

            sut.StartNewGame(1);

            sut.MoveToNextPlayer();

            for (int i = 0; i < 10; i++)
            {
                sut.MoveToNextFrame();
                sut.MoveToNextRoll();
                sut.StoreRollOutcome(0);
                sut.MoveToNextRoll();
                sut.StoreRollOutcome(0);
            }

            Assert.IsTrue(sut.CurrentGame.CurrentPlayer.IsGutterGame);
            Assert.AreEqual(0, sut.CurrentGame.CurrentPlayer.TotalPoints);
        }

        [TestMethod]
        public void GameGovernorService_IsPerfect_True()
        {
            var sut = new GameGovernorService(new GameService(), new PlayerService(), new FrameService(), new ScoreService());

            sut.StartNewGame(1);

            sut.MoveToNextPlayer();

            for (int i = 0; i < 10; i++)
            {
                sut.MoveToNextFrame();
                sut.MoveToNextRoll();
                sut.StoreRollOutcome(10);
            }

            Assert.AreEqual(270, sut.CurrentGame.CurrentPlayer.TotalPoints);

            sut.MoveToNextRoll();
            sut.StoreRollOutcome(10);

            Assert.AreEqual(290, sut.CurrentGame.CurrentPlayer.TotalPoints);

            sut.MoveToNextRoll();
            sut.StoreRollOutcome(10);

            Assert.IsTrue(sut.CurrentGame.CurrentPlayer.IsPerfectGame);
            Assert.AreEqual(300, sut.CurrentGame.CurrentPlayer.TotalPoints);
        }

        [TestMethod]
        public void GameGovernorService_LastGameIsStrike_True()
        {
            var sut = new GameGovernorService(new GameService(), new PlayerService(), new FrameService(), new ScoreService());

            sut.StartNewGame(1);

            sut.MoveToNextPlayer();

            sut.MoveToNextFrame();
            sut.MoveToNextRoll();
            sut.StoreRollOutcome(10);

            Assert.AreEqual(10, sut.CurrentGame.CurrentPlayer.TotalPoints);

            sut.MoveToNextFrame();
            sut.MoveToNextRoll();
            sut.StoreRollOutcome(10);

            Assert.AreEqual(30, sut.CurrentGame.CurrentPlayer.TotalPoints);

            sut.MoveToNextFrame();
            sut.MoveToNextRoll();
            sut.StoreRollOutcome(10);

            Assert.AreEqual(60, sut.CurrentGame.CurrentPlayer.TotalPoints);

            sut.MoveToNextFrame();
            sut.MoveToNextRoll();
            sut.StoreRollOutcome(10);

            Assert.AreEqual(90, sut.CurrentGame.CurrentPlayer.TotalPoints);

            sut.MoveToNextFrame();
            sut.MoveToNextRoll();
            sut.StoreRollOutcome(10);

            Assert.AreEqual(120, sut.CurrentGame.CurrentPlayer.TotalPoints);

            sut.MoveToNextFrame();
            sut.MoveToNextRoll();
            sut.StoreRollOutcome(10);

            Assert.AreEqual(150, sut.CurrentGame.CurrentPlayer.TotalPoints);

            sut.MoveToNextFrame();
            sut.MoveToNextRoll();
            sut.StoreRollOutcome(10);

            Assert.AreEqual(180, sut.CurrentGame.CurrentPlayer.TotalPoints);

            sut.MoveToNextFrame();
            sut.MoveToNextRoll();
            sut.StoreRollOutcome(10);

            Assert.AreEqual(210, sut.CurrentGame.CurrentPlayer.TotalPoints);

            sut.MoveToNextFrame();
            sut.MoveToNextRoll();
            sut.StoreRollOutcome(10);

            Assert.AreEqual(240, sut.CurrentGame.CurrentPlayer.TotalPoints);

            sut.MoveToNextFrame();
            sut.MoveToNextRoll();
            sut.StoreRollOutcome(10);

            Assert.AreEqual(270, sut.CurrentGame.CurrentPlayer.TotalPoints);
        }

        [TestMethod]
        public void GameGovernorService_ByTestDataEndedBySpare_True()
        {
            var sut = new GameGovernorService(new GameService(), new PlayerService(), new FrameService(), new ScoreService());

            sut.StartNewGame(1);

            sut.MoveToNextPlayer();

            // 1
            sut.MoveToNextFrame();
            sut.MoveToNextRoll();
            sut.StoreRollOutcome(1);
            Assert.AreEqual(1, sut.CurrentGame.CurrentPlayer.TotalPoints);
            sut.MoveToNextRoll();
            sut.StoreRollOutcome(4);
            Assert.AreEqual(5, sut.CurrentGame.CurrentPlayer.TotalPoints);

            // 2
            sut.MoveToNextFrame();
            sut.MoveToNextRoll();
            sut.StoreRollOutcome(4);
            Assert.AreEqual(9, sut.CurrentGame.CurrentPlayer.TotalPoints);
            sut.MoveToNextRoll();
            sut.StoreRollOutcome(5);
            Assert.AreEqual(14, sut.CurrentGame.CurrentPlayer.TotalPoints);

            // 3 (SPARE)
            sut.MoveToNextFrame();
            sut.MoveToNextRoll();
            sut.StoreRollOutcome(6);
            Assert.AreEqual(20, sut.CurrentGame.CurrentPlayer.TotalPoints);
            sut.MoveToNextRoll();
            sut.StoreRollOutcome(4);
            Assert.AreEqual(24, sut.CurrentGame.CurrentPlayer.TotalPoints);

            // 4 (SPARE)
            sut.MoveToNextFrame();
            sut.MoveToNextRoll();
            sut.StoreRollOutcome(5);
            Assert.AreEqual(34, sut.CurrentGame.CurrentPlayer.TotalPoints);
            sut.MoveToNextRoll();
            sut.StoreRollOutcome(5);
            Assert.AreEqual(39, sut.CurrentGame.CurrentPlayer.TotalPoints);

            // 5 (STRIKE)
            sut.MoveToNextFrame();
            sut.MoveToNextRoll();
            sut.StoreRollOutcome(10);
            Assert.AreEqual(59, sut.CurrentGame.CurrentPlayer.TotalPoints);

            // 6
            sut.MoveToNextFrame();
            sut.MoveToNextRoll();
            sut.StoreRollOutcome(0);
            Assert.AreEqual(59, sut.CurrentGame.CurrentPlayer.TotalPoints);
            sut.MoveToNextRoll();
            sut.StoreRollOutcome(1);
            Assert.AreEqual(61, sut.CurrentGame.CurrentPlayer.TotalPoints);

            // 7 (SPARE)
            sut.MoveToNextFrame();
            sut.MoveToNextRoll();
            sut.StoreRollOutcome(7);
            Assert.AreEqual(68, sut.CurrentGame.CurrentPlayer.TotalPoints);
            sut.MoveToNextRoll();
            sut.StoreRollOutcome(3);
            Assert.AreEqual(71, sut.CurrentGame.CurrentPlayer.TotalPoints);

            // 8 (SPARE)
            sut.MoveToNextFrame();
            sut.MoveToNextRoll();
            sut.StoreRollOutcome(6);
            Assert.AreEqual(83, sut.CurrentGame.CurrentPlayer.TotalPoints);
            sut.MoveToNextRoll();
            sut.StoreRollOutcome(4);
            Assert.AreEqual(87, sut.CurrentGame.CurrentPlayer.TotalPoints);

            // 9 (STRIKE)
            sut.MoveToNextFrame();
            sut.MoveToNextRoll();
            sut.StoreRollOutcome(10);
            Assert.AreEqual(107, sut.CurrentGame.CurrentPlayer.TotalPoints);

            // 10 (SPARE)
            sut.MoveToNextFrame();
            sut.MoveToNextRoll();
            sut.StoreRollOutcome(2);
            Assert.AreEqual(111, sut.CurrentGame.CurrentPlayer.TotalPoints);

            sut.MoveToNextRoll();
            sut.StoreRollOutcome(8);
            Assert.AreEqual(127, sut.CurrentGame.CurrentPlayer.TotalPoints);

            sut.MoveToNextRoll();
            sut.StoreRollOutcome(6);
            Assert.AreEqual(133, sut.CurrentGame.CurrentPlayer.TotalPoints);

        }

        [TestMethod]
        public void GameGovernorService_ByTestDataEndedByStrikeInFirst_True()
        {
            var sut = new GameGovernorService(new GameService(), new PlayerService(), new FrameService(), new ScoreService());

            sut.StartNewGame(1);

            sut.MoveToNextPlayer();

            // 1
            sut.MoveToNextFrame();
            sut.MoveToNextRoll();
            sut.StoreRollOutcome(1);
            Assert.AreEqual(1, sut.CurrentGame.CurrentPlayer.TotalPoints);
            sut.MoveToNextRoll();
            sut.StoreRollOutcome(4);
            Assert.AreEqual(5, sut.CurrentGame.CurrentPlayer.TotalPoints);

            // 2
            sut.MoveToNextFrame();
            sut.MoveToNextRoll();
            sut.StoreRollOutcome(4);
            Assert.AreEqual(9, sut.CurrentGame.CurrentPlayer.TotalPoints);
            sut.MoveToNextRoll();
            sut.StoreRollOutcome(5);
            Assert.AreEqual(14, sut.CurrentGame.CurrentPlayer.TotalPoints);

            // 3 (SPARE)
            sut.MoveToNextFrame();
            sut.MoveToNextRoll();
            sut.StoreRollOutcome(6);
            Assert.AreEqual(20, sut.CurrentGame.CurrentPlayer.TotalPoints);
            sut.MoveToNextRoll();
            sut.StoreRollOutcome(4);
            Assert.AreEqual(24, sut.CurrentGame.CurrentPlayer.TotalPoints);

            // 4 (SPARE)
            sut.MoveToNextFrame();
            sut.MoveToNextRoll();
            sut.StoreRollOutcome(5);
            Assert.AreEqual(34, sut.CurrentGame.CurrentPlayer.TotalPoints);
            sut.MoveToNextRoll();
            sut.StoreRollOutcome(5);
            Assert.AreEqual(39, sut.CurrentGame.CurrentPlayer.TotalPoints);

            // 5 (STRIKE)
            sut.MoveToNextFrame();
            sut.MoveToNextRoll();
            sut.StoreRollOutcome(10);
            Assert.AreEqual(59, sut.CurrentGame.CurrentPlayer.TotalPoints);

            // 6
            sut.MoveToNextFrame();
            sut.MoveToNextRoll();
            sut.StoreRollOutcome(0);
            Assert.AreEqual(59, sut.CurrentGame.CurrentPlayer.TotalPoints);
            sut.MoveToNextRoll();
            sut.StoreRollOutcome(1);
            Assert.AreEqual(61, sut.CurrentGame.CurrentPlayer.TotalPoints);

            // 7 (SPARE)
            sut.MoveToNextFrame();
            sut.MoveToNextRoll();
            sut.StoreRollOutcome(7);
            Assert.AreEqual(68, sut.CurrentGame.CurrentPlayer.TotalPoints);
            sut.MoveToNextRoll();
            sut.StoreRollOutcome(3);
            Assert.AreEqual(71, sut.CurrentGame.CurrentPlayer.TotalPoints);

            // 8 (SPARE)
            sut.MoveToNextFrame();
            sut.MoveToNextRoll();
            sut.StoreRollOutcome(6);
            Assert.AreEqual(83, sut.CurrentGame.CurrentPlayer.TotalPoints);
            sut.MoveToNextRoll();
            sut.StoreRollOutcome(4);
            Assert.AreEqual(87, sut.CurrentGame.CurrentPlayer.TotalPoints);

            // 9 (STRIKE)
            sut.MoveToNextFrame();
            sut.MoveToNextRoll();
            sut.StoreRollOutcome(10);
            Assert.AreEqual(107, sut.CurrentGame.CurrentPlayer.TotalPoints);

            // 10 (SPARE)
            sut.MoveToNextFrame();
            sut.MoveToNextRoll();
            sut.StoreRollOutcome(10);
            Assert.AreEqual(127, sut.CurrentGame.CurrentPlayer.TotalPoints);

            sut.MoveToNextRoll();
            sut.StoreRollOutcome(1);
            Assert.AreEqual(129, sut.CurrentGame.CurrentPlayer.TotalPoints);

            sut.MoveToNextRoll();
            sut.StoreRollOutcome(1);
            Assert.AreEqual(130, sut.CurrentGame.CurrentPlayer.TotalPoints);
        }

        [TestMethod]
        public void GameGovernorService_ByTestDataEndedByStrikeInSecond_True()
        {
            var sut = new GameGovernorService(new GameService(), new PlayerService(), new FrameService(), new ScoreService());

            sut.StartNewGame(1);

            sut.MoveToNextPlayer();

            // 1
            sut.MoveToNextFrame();
            sut.MoveToNextRoll();
            sut.StoreRollOutcome(1);
            Assert.AreEqual(1, sut.CurrentGame.CurrentPlayer.TotalPoints);
            sut.MoveToNextRoll();
            sut.StoreRollOutcome(4);
            Assert.AreEqual(5, sut.CurrentGame.CurrentPlayer.TotalPoints);

            // 2
            sut.MoveToNextFrame();
            sut.MoveToNextRoll();
            sut.StoreRollOutcome(4);
            Assert.AreEqual(9, sut.CurrentGame.CurrentPlayer.TotalPoints);
            sut.MoveToNextRoll();
            sut.StoreRollOutcome(5);
            Assert.AreEqual(14, sut.CurrentGame.CurrentPlayer.TotalPoints);

            // 3 (SPARE)
            sut.MoveToNextFrame();
            sut.MoveToNextRoll();
            sut.StoreRollOutcome(6);
            Assert.AreEqual(20, sut.CurrentGame.CurrentPlayer.TotalPoints);
            sut.MoveToNextRoll();
            sut.StoreRollOutcome(4);
            Assert.AreEqual(24, sut.CurrentGame.CurrentPlayer.TotalPoints);

            // 4 (SPARE)
            sut.MoveToNextFrame();
            sut.MoveToNextRoll();
            sut.StoreRollOutcome(5);
            Assert.AreEqual(34, sut.CurrentGame.CurrentPlayer.TotalPoints);
            sut.MoveToNextRoll();
            sut.StoreRollOutcome(5);
            Assert.AreEqual(39, sut.CurrentGame.CurrentPlayer.TotalPoints);

            // 5 (STRIKE)
            sut.MoveToNextFrame();
            sut.MoveToNextRoll();
            sut.StoreRollOutcome(10);
            Assert.AreEqual(59, sut.CurrentGame.CurrentPlayer.TotalPoints);

            // 6
            sut.MoveToNextFrame();
            sut.MoveToNextRoll();
            sut.StoreRollOutcome(0);
            Assert.AreEqual(59, sut.CurrentGame.CurrentPlayer.TotalPoints);
            sut.MoveToNextRoll();
            sut.StoreRollOutcome(1);
            Assert.AreEqual(61, sut.CurrentGame.CurrentPlayer.TotalPoints);

            // 7 (SPARE)
            sut.MoveToNextFrame();
            sut.MoveToNextRoll();
            sut.StoreRollOutcome(7);
            Assert.AreEqual(68, sut.CurrentGame.CurrentPlayer.TotalPoints);
            sut.MoveToNextRoll();
            sut.StoreRollOutcome(3);
            Assert.AreEqual(71, sut.CurrentGame.CurrentPlayer.TotalPoints);

            // 8 (SPARE)
            sut.MoveToNextFrame();
            sut.MoveToNextRoll();
            sut.StoreRollOutcome(6);
            Assert.AreEqual(83, sut.CurrentGame.CurrentPlayer.TotalPoints);
            sut.MoveToNextRoll();
            sut.StoreRollOutcome(4);
            Assert.AreEqual(87, sut.CurrentGame.CurrentPlayer.TotalPoints);

            // 9 (STRIKE)
            sut.MoveToNextFrame();
            sut.MoveToNextRoll();
            sut.StoreRollOutcome(10);
            Assert.AreEqual(107, sut.CurrentGame.CurrentPlayer.TotalPoints);

            // 10 (SPARE)
            sut.MoveToNextFrame();
            sut.MoveToNextRoll();
            sut.StoreRollOutcome(1);
            Assert.AreEqual(109, sut.CurrentGame.CurrentPlayer.TotalPoints);

            sut.MoveToNextRoll();
            sut.StoreRollOutcome(10);
            Assert.AreEqual(129, sut.CurrentGame.CurrentPlayer.TotalPoints);

            sut.MoveToNextRoll();
            sut.StoreRollOutcome(1);
            Assert.AreEqual(130, sut.CurrentGame.CurrentPlayer.TotalPoints);
        }
    }
}
