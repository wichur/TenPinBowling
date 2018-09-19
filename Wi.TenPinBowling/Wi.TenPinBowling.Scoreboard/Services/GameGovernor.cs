using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Wi.TenPinBowling.Scoreboard.Model;
using Wi.TenPinBowling.Scoreboard.Rules;

namespace Wi.TenPinBowling.Scoreboard.Services
{
    public class GameGovernor : IGameGovernor
    {
        public GameState CurrentGame { get; private set; }

        public void StartNewGame(int numberOfPlayers)
        {
            if (this.CurrentGame != null)
            {
                throw new Exception("Cannot start new game until old one is closed");
            }

            if (numberOfPlayers < 1)
            {
                throw new ArgumentException("Game can start only if there is at least one player");
            }

            this.CurrentGame = new GameState();

            for (int i = 0; i < numberOfPlayers; i++)
            {
                this.CurrentGame.Players.Add(new PlayerState
                {
                    PlayerNumber = i
                });
            }
        }

        public void EndGame()
        {
            /// TODO Move game to history of games

            this.CurrentGame = null;
        }

        public void MoveToNextPlayer()
        {
            if (CurrentGame.CurrentPlayer == null)
            {
                CurrentGame.CurrentPlayer = CurrentGame.Players
                .OrderBy(p => p.PlayerNumber)
                .First();

                return;
            }

            if (CurrentGame.CurrentPlayer == CurrentGame.Players.OrderBy(p => p.PlayerNumber).Last())
            {
                CurrentGame.CurrentPlayer = CurrentGame.Players
                .OrderBy(p => p.PlayerNumber)
                .First();

                return;
            }

            CurrentGame.CurrentPlayer = CurrentGame.Players
                .Where(p => CurrentGame.CurrentPlayer.PlayerNumber + 1 == p.PlayerNumber)
                .Single();
        }

        public void MoveToNextFrame()
        {
            var currentPlayer = this.CurrentGame.CurrentPlayer;
            var framesCount = currentPlayer.Frames.Count();

            if (framesCount >= StaticRules.MaxFrames)
            {
                throw new Exception($"Each player can have only {StaticRules.MaxFrames} frames per game");
            }

            var frame = new Frame
            {
                FrameNumber = currentPlayer.Frames.Count()
            };

            currentPlayer.Frames.Add(frame);
        }

        public void MoveToNextRoll()
        {
            var currentFrame = this.CurrentGame.CurrentPlayer.CurrentFrame;

            var roll = new Roll
            {
                RollNumber = currentFrame.Rolls.Count()
            };

            if (!currentFrame.IsLast && roll.RollNumber >= StaticRules.NormalFrameMaxRolls)
            {
                throw new Exception($"Each player can have only {StaticRules.NormalFrameMaxRolls} rolls per frame");
            }

            if (currentFrame.IsLast && currentFrame.Rolls.Count() == StaticRules.LastFrameMaxRolls)
            {
                throw new Exception($"Each player can have only {StaticRules.LastFrameMaxRolls} rolls in last frame");
            }

            /// TODO Refactor this

            if (currentFrame.IsLast && currentFrame.PinsKnockedDown == StaticRules.PinsPerFrame && 
                currentFrame.Rolls.Count() < StaticRules.LastFrameMaxRolls)
            {
                currentFrame.Rolls.Add(roll);
                return;
            }

            if (currentFrame.PinsKnockedDown < StaticRules.PinsPerFrame)
            {
                currentFrame.Rolls.Add(roll);
                return;
            }            
        }

        public void StoreRollOutcome(int pinsKnockedDown)
        {
            var currentFrame = this.CurrentGame.CurrentPlayer.CurrentFrame;

            if (pinsKnockedDown < 0 || pinsKnockedDown > StaticRules.PinsPerFrame)
            {
                throw new ArgumentException($"Player can knock down only from 0 to {StaticRules.PinsPerFrame} pins in one Roll");
            }

            var pinsLeftStanding = StaticRules.PinsPerFrame - currentFrame.PinsKnockedDown;
            if (pinsKnockedDown > pinsLeftStanding)
            {
                throw new ArgumentException($"Player cannot knock down more than {pinsLeftStanding} of standing pins");
            }

            currentFrame.CurrentRoll.PinsKockedDown = pinsKnockedDown;
        }
    }
}
