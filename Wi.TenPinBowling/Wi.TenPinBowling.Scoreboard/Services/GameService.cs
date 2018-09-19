using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Wi.TenPinBowling.Scoreboard.Model;

namespace Wi.TenPinBowling.Scoreboard.Services
{
    public class GameService : IGameService
    {
        public Game StartNewGame(int numberOfPlayers)
        {
            if (numberOfPlayers < 1)
            {
                throw new ArgumentException("Game can start only if there is at least one player");
            }

            var game = new Game();

            for (int i = 0; i < numberOfPlayers; i++)
            {
                game.Players.Add(new Player
                {
                    PlayerNumber = i
                });
            }

            return game;
        }
        
        public void MoveToNextPlayer(Game game)
        {
            if (game.CurrentPlayer == null)
            {
                game.CurrentPlayer = game.Players
                .OrderBy(p => p.PlayerNumber)
                .First();

                return;
            }

            if (game.CurrentPlayer == game.Players.OrderBy(p => p.PlayerNumber).Last())
            {
                game.CurrentPlayer = game.Players
                .OrderBy(p => p.PlayerNumber)
                .First();

                return;
            }

            game.CurrentPlayer = game.Players
                .Where(p => game.CurrentPlayer.PlayerNumber + 1 == p.PlayerNumber)
                .Single();
        }
    }
}
