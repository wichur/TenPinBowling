using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Wi.TenPinBowling.Scoreboard.Model
{
    public class PlayerState
    {
        public int PlayerNumber { get; set; }

        public IList<Frame> Frames { get; set; }

        public Frame CurrentFrame => this.Frames.OrderBy(o => o.FrameNumber).LastOrDefault();

        public bool GutterGame
        {
            get
            {
                return this.Frames.Sum(p => p.PinsKnockedDown) == 0;
            }
        }

        public bool PerfectGame
        {
            get
            {
                var rolls = this.Frames.SelectMany(p => p.Rolls);
                var count = rolls.Count(p => p.IsStrike);
                return count == 12;
            }
        }

        public PlayerState()
        {
            this.Frames = new List<Frame>();
        }
    }
}
