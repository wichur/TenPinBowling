using Wi.TenPinBowling.Scoreboard.Model;

namespace Wi.TenPinBowling.Scoreboard.Services
{
    public interface IPlayerService
    {
        void MoveToNextFrame(Player currentPlayer);
    }
}