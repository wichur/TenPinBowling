using System;
using System.Collections.Generic;
using System.Text;
using Wi.TenPinBowling.Scoreboard.Rules;

namespace Wi.TenPinBowling.Scoreboard.Model
{
    public class Roll
    {
        public int RollNumber { get; set; }

        public int PinsKockedDown { get; set; }

        public bool IsStrike => PinsKockedDown == StaticRules.PinsPerFrame;
    }
}
