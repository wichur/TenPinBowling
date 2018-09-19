using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Wi.TenPinBowling.Scoreboard.Model;
using Wi.TenPinBowling.Scoreboard.Rules;

namespace Wi.TenPinBowling.Scoreboard.Services
{
    public class PlayerService : IPlayerService
    {
        public void MoveToNextFrame(Player currentPlayer)
        {
            var framesCount = currentPlayer.Frames.Count();

            if (framesCount >= StaticRules.MaxFrames)
            {
                throw new Exception($"Each player can have only {StaticRules.MaxFrames} frames per game");
            }

            var frame = new Frame
            {
                FrameNumber = framesCount
            };

            currentPlayer.Frames.Add(frame);
        }
    }
}
