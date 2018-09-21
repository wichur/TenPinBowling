using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Wi.TenPinBowling.Scoreboard.Model
{
    public class Player
    {
        public int PlayerNumber { get; set; }

        public IList<Frame> Frames { get; set; }
        public Frame CurrentFrame => this.Frames.OrderBy(o => o.FrameNumber).LastOrDefault();

        public int TotalPoints => this.Frames.Sum(p => p.TotalPoints);

        public bool IsGutterGame => this.Frames.Sum(p => p.PinsKnockedDown) == 0;

        public bool IsPerfectGame
        {
            get
            {
                var rolls = this.Frames.SelectMany(p => p.Rolls);
                var count = rolls.Count(p => p.IsStrike);
                return count == 12;
            }
        }

        public Player()
        {
            this.Frames = new List<Frame>();
        }
    }
}
