using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Wi.TenPinBowling.Scoreboard.Model;
using Wi.TenPinBowling.Scoreboard.Rules;

namespace Wi.TenPinBowling.Scoreboard.Services
{
    public class ScoreService : IScoreService
    {
        /// TODO Refactor
        public void ProcessPlayerPoints(Player player)
        {
            foreach (var frame in player.Frames)
            {
                if(frame.IsLast)
                {
                    continue;
                }
                else if (frame.IsStrike)
                {
                    this.HandleWhenFrameIsStrike(player, frame);
                }                
                else if (frame.IsSpare)
                {
                    this.HandleWhenFrameIsSpare(player, frame);
                }
            }
        }

        private void HandleWhenFrameIsSpare(Player player, Frame frame)
        {
            var nextFrame = player.Frames.SingleOrDefault(p => p.FrameNumber == frame.FrameNumber + 1);

            if (nextFrame != null)
            {
                frame.SparePoints = nextFrame.Rolls.First().PinsKockedDown;
            }
        }

        private void HandleWhenFrameIsStrike(Player player, Frame frame)
        {
            var nextFrame = player.Frames.SingleOrDefault(p => p.FrameNumber == frame.FrameNumber + 1);

            if (nextFrame == null)
            {
                return;
            }

            if (nextFrame.IsLast)
            {
                frame.StrikePoints = nextFrame.Rolls.First().PinsKockedDown;

                var secondRoll = nextFrame.Rolls.Skip(1).FirstOrDefault();

                if (secondRoll != null)
                {
                    frame.StrikePoints += secondRoll.PinsKockedDown;
                }

                return;
            }

            var nextExtraFrame = player.Frames.SingleOrDefault(p => p.FrameNumber == frame.FrameNumber + 2);

            if (nextExtraFrame?.IsLast == true)
            {
                frame.StrikePoints = nextFrame.Rolls.First().PinsKockedDown;
                frame.StrikePoints += nextExtraFrame.Rolls.First().PinsKockedDown;
                return;
            }

            frame.StrikePoints = nextFrame.Rolls.First().PinsKockedDown;

            if (nextFrame.Rolls.Count() == StaticRules.NormalFrameMaxRolls)
            {
                frame.StrikePoints += nextFrame.Rolls.Last().PinsKockedDown;
            }
            else if (nextExtraFrame != null)
            {
                frame.StrikePoints += nextExtraFrame.Rolls.First().PinsKockedDown;
            }
        }
    }
}
