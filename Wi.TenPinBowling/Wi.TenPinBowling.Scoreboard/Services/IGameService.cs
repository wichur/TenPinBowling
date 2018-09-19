using Wi.TenPinBowling.Scoreboard.Model;

namespace Wi.TenPinBowling.Scoreboard.Services
{
    public interface IGameService
    {
        void MoveToNextPlayer(Game game);
        Game StartNewGame(int numberOfPlayers);
    }
}