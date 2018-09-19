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

        public PlayerState()
        {
            this.Frames = new List<Frame>();
        }
    }
}
