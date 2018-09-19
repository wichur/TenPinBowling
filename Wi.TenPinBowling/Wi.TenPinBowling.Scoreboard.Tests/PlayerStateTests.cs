using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using Wi.TenPinBowling.Scoreboard.Model;

namespace Wi.TenPinBowling.Scoreboard.Tests
{
    [TestClass]
    public class PlayerStateTests
    {
        [TestMethod]
        public void Frame_CurrentFrame_Valid()
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
        public void Frame_CurrentFrame_Null()
        {
            var sut = new PlayerState();

            Assert.IsNull(sut.CurrentFrame);
        }
    }
}
