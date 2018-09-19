using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Wi.TenPinBowling.Scoreboard.Rules;

namespace Wi.TenPinBowling.Scoreboard.Model
{
    public class Frame
    {
        public int FrameNumber { get; set; }

        public IList<Roll> Rolls { get; set; }

        public Roll CurrentRoll => this.Rolls.OrderBy(o => o.RollNumber).LastOrDefault();

        public bool IsStrike => this.Rolls.Any(p => p.IsStrike);

        public bool IsSpare => this.Rolls.Sum(p => p.PinsKockedDown) == StaticRules.PinsPerFrame;

        public bool IsLast => this.FrameNumber == (StaticRules.MaxFrames - 1);

        public int PinsKnockedDown => this.Rolls.Sum(p => p.PinsKockedDown);

        public Frame()
        {
            this.Rolls = new List<Roll>();
        }
    }
}
