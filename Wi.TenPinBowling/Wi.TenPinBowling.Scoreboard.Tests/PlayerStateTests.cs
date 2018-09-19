using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using Wi.TenPinBowling.Scoreboard.Model;
using Wi.TenPinBowling.Scoreboard.Rules;

namespace Wi.TenPinBowling.Scoreboard.Tests
{
    [TestClass]
    public class PlayerStateTests
    {
        [TestMethod]
        public void PlayerState_CurrentFrame_Valid()
        {
            var sut = new PlayerState();

            sut.Frames = new List<Frame>
            {
                new Frame
                {
                    FrameNumber = 0,
                },
                new Frame
                {
                    FrameNumber = 1,
                }
            };

            Assert.AreEqual(sut.Frames.Last(), sut.CurrentFrame);
        }

        [TestMethod]
        public void PlayerState_CurrentFrame_Null()
        {
            var sut = new PlayerState();

            Assert.IsNull(sut.CurrentFrame);
        }

        [TestMethod]
        public void PlayerState_GutterGame_True()
        {
            var sut = new PlayerState();

            Assert.IsTrue(sut.GutterGame);
        }

        [TestMethod]
        public void PlayerState_PerfectGame_True()
        {
            var sut = new PlayerState();

            for (int i = 0; i < StaticRules.MaxFrames; i++)
            {
                var frame = new Frame();

                frame.Rolls.Add(new Roll
                {
                    RollNumber = 0,
                    PinsKockedDown = StaticRules.PinsPerFrame
                });
                sut.Frames.Add(frame);
            }

            var lastFrame = sut.Frames.Last();
            lastFrame.Rolls.Add(new Roll
            {
                RollNumber = 1,
                PinsKockedDown = StaticRules.PinsPerFrame
            });
            lastFrame.Rolls.Add(new Roll
            {
                RollNumber = 2,
                PinsKockedDown = StaticRules.PinsPerFrame
            });
            Assert.IsTrue(sut.PerfectGame);
        }
    }
}
