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
                if (frame.IsStrike && !frame.IsLast)
                {
                    var nextFrame = player.Frames.SingleOrDefault(p => p.FrameNumber == frame.FrameNumber + 1);

                    if (nextFrame == null)
                    {
                        continue;
                    }

                    if(nextFrame.IsLast)
                    {
                        frame.StrikePoints = nextFrame.Rolls.First().PinsKockedDown;

                        var secondRoll = nextFrame.Rolls.Skip(1).FirstOrDefault();

                        if(secondRoll != null)
                        {
                            frame.StrikePoints += secondRoll.PinsKockedDown;
                        }

                        continue;
                    }

                    var nextExtraFrame = player.Frames.SingleOrDefault(p => p.FrameNumber == frame.FrameNumber + 2);

                    if(nextExtraFrame != null && nextExtraFrame.IsLast)
                    {
                        frame.StrikePoints = nextFrame.Rolls.First().PinsKockedDown;
                        frame.StrikePoints += nextExtraFrame.Rolls.First().PinsKockedDown;
                        continue;
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
                else if (frame.IsSpare && !frame.IsLast)
                {
                    var nextFrame = player.Frames.SingleOrDefault(p => p.FrameNumber == frame.FrameNumber + 1);

                    if (nextFrame == null)
                    {
                        continue;
                    }

                    frame.SparePoints = nextFrame.Rolls.First().PinsKockedDown;
                }
            }
        }
    }
}
