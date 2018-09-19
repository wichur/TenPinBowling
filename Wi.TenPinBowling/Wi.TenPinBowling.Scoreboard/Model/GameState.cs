using System;
using System.Collections.Generic;
using System.Text;

namespace Wi.TenPinBowling.Scoreboard.Model
{
    public class GameState
    {
        public IList<PlayerState> Players { get; set; }

        public PlayerState CurrentPlayer { get; set; }

        public GameState()
        {
            this.Players = new List<PlayerState>();
        }
    }
}
