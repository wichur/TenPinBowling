using Wi.TenPinBowling.Scoreboard.Model;

namespace Wi.TenPinBowling.Scoreboard.Services
{
    public interface IScoreService
    {
        void ProcessPlayerPoints(Player player);
    }
}