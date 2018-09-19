using Wi.TenPinBowling.Scoreboard.Model;

namespace Wi.TenPinBowling.Scoreboard.Services
{
    public interface IFrameService
    {
        void MoveToNextRoll(Frame currentFrame);
        void StoreRollOutcome(Frame currentFrame, int pinsKnockedDown);
    }
}