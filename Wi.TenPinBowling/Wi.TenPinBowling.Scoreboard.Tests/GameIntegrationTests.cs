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
    }
}
