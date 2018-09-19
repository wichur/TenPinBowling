using Wi.TenPinBowling.Scoreboard.Model;

namespace Wi.TenPinBowling.Scoreboard.Services
{
    public interface IGameGovernorService
    {
        Game CurrentGame { get; }

        void EndGame();
        void MoveToNextFrame();
        void MoveToNextPlayer();
        void MoveToNextRoll();
        void StartNewGame(int numberOfPlayers);
        void StoreRollOutcome(int pinsKnockedDown);
    }
}