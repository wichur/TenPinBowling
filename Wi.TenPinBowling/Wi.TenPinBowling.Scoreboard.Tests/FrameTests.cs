using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using Wi.TenPinBowling.Scoreboard.Model;
using Wi.TenPinBowling.Scoreboard.Rules;

namespace Wi.TenPinBowling.Scoreboard.Tests
{
    [TestClass]
    public class FrameTests
    {
        [TestMethod]
        public void Frame_IsStrike_True()
        {
            var sut = new Frame();

            sut.Rolls = new List<Roll>
            {
                new Roll
                {
                    RollNumber = 0,
                    PinsKockedDown = StaticRules.PinsPerFrame
                }
            };

            Assert.IsTrue(sut.IsStrike);
        }

        [TestMethod]
        public void Frame_OneRollIsStrike_False()
        {
            var sut = new Frame();

            sut.Rolls = new List<Roll>
            {
                new Roll
                {
                    RollNumber = 0,
                    PinsKockedDown = 9
                }
            };

            Assert.IsFalse(sut.IsStrike);
        }

        [TestMethod]
        public void Frame_TwoRollsIsStrike_False()
        {
            var sut = new Frame();

            sut.Rolls = new List<Roll>
            {
                new Roll
                {
                    RollNumber = 0,
                    PinsKockedDown = 9
                },
                new Roll
                {
                    RollNumber = 1,
                    PinsKockedDown = 1
                }
            };

            Assert.IsFalse(sut.IsStrike);
        }

        [TestMethod]
        public void Frame_IsSpare_True()
        {
            var sut = new Frame();

            sut.Rolls = new List<Roll>
            {
                new Roll
                {
                    RollNumber = 0,
                    PinsKockedDown = 9
                },
                new Roll
                {
                    RollNumber = 1,
                    PinsKockedDown = 1
                }
            };

            Assert.IsTrue(sut.IsSpare);
        }

        [TestMethod]
        public void Frame_IsSpare_False()
        {
            var sut = new Frame();

            sut.Rolls = new List<Roll>
            {
                new Roll
                {
                    RollNumber = 0,
                    PinsKockedDown = 8
                },
                new Roll
                {
                    RollNumber = 1,
                    PinsKockedDown = 1
                }
            };

            Assert.IsFalse(sut.IsSpare);
        }

        [TestMethod]
        public void Frame_IsLast_True()
        {
            var sut = new Frame
            {
                FrameNumber = StaticRules.MaxFrames - 1
            };

            Assert.IsTrue(sut.IsLast);
        }

        [TestMethod]
        public void Frame_IsLast_False()
        {
            var sut = new Frame
            {
                FrameNumber = 8
            };

            Assert.IsFalse(sut.IsLast);
        }

        [TestMethod]
        public void Frame_CurrentRoll_Valid()
        {
            var sut = new Frame();

            sut.Rolls = new List<Roll>
            {
                new Roll
                {
                    RollNumber = 0,
                },
                new Roll
                {
                    RollNumber = 1,
                }
            };

            Assert.AreEqual(sut.Rolls.Last(), sut.CurrentRoll);
        }

        [TestMethod]
        public void Frame_CurrentRoll_Null()
        {
            var sut = new Frame();

            Assert.IsNull(sut.CurrentRoll);
        }
    }
}
