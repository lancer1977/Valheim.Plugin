using NUnit.Framework;
using PolyhydraGames.Valheim.Plugin.Extensions;

namespace PolyhydraGames.RCon.Test
{
    [TestFixture]
    public class StringUtilsHashDeterminismTests02
    {
        [Test]
        public void GetStableHashCode_SameInput_RepeatsSameHash()
        {
            const string input = "repeat";
            Assert.That(input.GetStableHashCode(), Is.EqualTo(2123762162));
        }
    }
}
