using System;
using System.Collections.Generic;
using System.Text;

namespace Wi.TenPinBowling.Scoreboard.Model
{
    public class Game
    {
        public IList<Player> Players { get; set; }

        public Player CurrentPlayer { get; set; }

        public Game()
        {
            this.Players = new List<Player>();
        }
    }
}
