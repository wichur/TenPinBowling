using Microsoft.VisualStudio.TestTools.UnitTesting;
using Wi.TenPinBowling.Scoreboard.Model;
using Wi.TenPinBowling.Scoreboard.Rules;

namespace Wi.TenPinBowling.Scoreboard.Tests
{
    [TestClass]
    public class RollTests
    {
        [TestMethod]
        public void Roll_IsStrike_True()
        {
            var sut = new Roll();

            sut.PinsKockedDown = StaticRules.PinsPerFrame;

            Assert.IsTrue(sut.IsStrike);
        }

        [TestMethod]
        public void Roll_IsStrike_False()
        {
            var sut = new Roll();

            sut.PinsKockedDown = 9;

            Assert.IsFalse(sut.IsStrike);
        }
    }
}
