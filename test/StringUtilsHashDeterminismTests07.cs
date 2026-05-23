using NUnit.Framework;
using PolyhydraGames.Valheim.Plugin.Extensions;

namespace PolyhydraGames.RCon.Test
{
    [TestFixture]
    public class StringUtilsHashDeterminismTests07
    {
        [Test]
        public void GetStableHashCode_UnicodeRune_IsDeterministic()
        {
            const string value = "😀";
            Assert.That(value.GetStableHashCode(), Is.EqualTo(5308056));
        }
    }
}
