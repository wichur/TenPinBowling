using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Wi.TenPinBowling.Scoreboard.Model;
using Wi.TenPinBowling.Scoreboard.Rules;

namespace Wi.TenPinBowling.Scoreboard.Services
{
    public class GameGovernorService : IGameGovernorService
    {
        private readonly IGameService gameService;
        private readonly IPlayerService playerService;
        private readonly IFrameService frameService;
        private readonly IScoreService scoreService;

        public Game CurrentGame { get; private set; }

        public GameGovernorService(
            IGameService gameService, 
            IPlayerService playerService, 
            IFrameService frameService, 
            IScoreService scoreService)
        {
            this.gameService = gameService;
            this.playerService = playerService;
            this.frameService = frameService;
            this.scoreService = scoreService;
        }

        public void StartNewGame(int numberOfPlayers)
        {
            if (this.CurrentGame != null)
            {
                throw new Exception("Cannot start new game until old one is closed");
            }

            this.CurrentGame = this.gameService.StartNewGame(numberOfPlayers);
        }

        public void EndGame()
        {
            /// TODO Move game to history of games

            this.CurrentGame = null;
        }

        public void MoveToNextPlayer()
        {
            this.gameService.MoveToNextPlayer(this.CurrentGame);
        }

        public void MoveToNextFrame()
        {
            this.playerService.MoveToNextFrame(this.CurrentGame.CurrentPlayer);
        }

        public void MoveToNextRoll()
        {
            this.frameService.MoveToNextRoll(this.CurrentGame.CurrentPlayer.CurrentFrame);           
        }

        public void StoreRollOutcome(int pinsKnockedDown)
        {
            this.frameService.StoreRollOutcome(this.CurrentGame.CurrentPlayer.CurrentFrame, pinsKnockedDown);

            this.scoreService.ProcessPlayerPoints(this.CurrentGame.CurrentPlayer);
        }
    }
}
