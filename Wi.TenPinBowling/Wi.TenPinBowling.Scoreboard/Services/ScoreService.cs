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
        public void ProcessPlayerPoints(Player player)
        {
            foreach (var frame in player.Frames)
            {
                if(frame.IsSpare)
                {
                    var nextFrame = player.Frames.SingleOrDefault(p => p.FrameNumber == frame.FrameNumber + 1);

                    if(nextFrame == null)
                    {
                        continue;
                    }

                    frame.SparePoints = nextFrame.Rolls.First().PinsKockedDown;
                }
                else if (frame.IsStrike)
                {
                    var nextFrame = player.Frames.SingleOrDefault(p => p.FrameNumber == frame.FrameNumber + 1);

                    if (nextFrame == null)
                    {
                        continue;
                    }

                    var nextExtraFrame = player.Frames.SingleOrDefault(p => p.FrameNumber == frame.FrameNumber + 2);

                    frame.SparePoints = nextFrame.Rolls.First().PinsKockedDown;

                    if(nextFrame.Rolls.Count() == StaticRules.NormalFrameMaxRolls)
                    {
                        frame.SparePoints += nextFrame.Rolls.Last().PinsKockedDown;
                    }
                    else if(nextExtraFrame != null)
                    {
                        frame.SparePoints += nextExtraFrame.Rolls.First().PinsKockedDown;
                    }
                }

            }
        }
    }
}
