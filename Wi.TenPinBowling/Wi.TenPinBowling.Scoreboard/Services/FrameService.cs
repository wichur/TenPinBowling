﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Wi.TenPinBowling.Scoreboard.Model;
using Wi.TenPinBowling.Scoreboard.Rules;

namespace Wi.TenPinBowling.Scoreboard.Services
{
    public class FrameService : IFrameService
    {
        /// TODO Refactor
        public void MoveToNextRoll(Frame currentFrame)
        {
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

            if(currentFrame.IsLast && !currentFrame.IsSpare && !currentFrame.IsStrike && currentFrame.Rolls.Count() == StaticRules.LastFrameMaxRolls-1)
            {
                throw new Exception($"In last frame 3rd roll is allowed only if there is a Strike or Spare in two previous rolls");
            }            

            if (currentFrame.IsLast && currentFrame.Rolls.Count() < StaticRules.LastFrameMaxRolls)
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

        /// TODO Refactor
        public void StoreRollOutcome(Frame currentFrame, int pinsKnockedDown)
        {
            if (pinsKnockedDown < 0 || pinsKnockedDown > StaticRules.PinsPerFrame)
            {
                throw new ArgumentException($"Player can knock down only from 0 to {StaticRules.PinsPerFrame} pins in one Roll");
            }

            var pinsLeftStanding = StaticRules.PinsPerFrame;
            
            if (!currentFrame.IsLast)
            {
                pinsLeftStanding = StaticRules.PinsPerFrame - currentFrame.PinsKnockedDown;
            }
            else
            {
                currentFrame.CurrentRoll.PinsKockedDown = 0;
            }
            
            if (pinsKnockedDown > pinsLeftStanding)
            {
                throw new ArgumentException($"Player cannot knock down more than {pinsLeftStanding} of standing pins");
            }

            currentFrame.CurrentRoll.PinsKockedDown = pinsKnockedDown;

        }
    }
}
