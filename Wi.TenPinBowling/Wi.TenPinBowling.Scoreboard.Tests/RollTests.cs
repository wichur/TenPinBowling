using Microsoft.VisualStudio.TestTools.UnitTesting;
using Wi.TenPinBowling.Scoreboard.Model;

namespace Wi.TenPinBowling.Scoreboard.Tests
{
    [TestClass]
    public class RollTests
    {
        [TestMethod]
        public void Roll_IsStrike_True()
        {
            var sut = new Roll();

            sut.PinsKockedDown = 10;

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
