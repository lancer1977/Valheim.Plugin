using NUnit.Framework;
using PolyhydraGames.Valheim.Plugin.Extensions;

namespace PolyhydraGames.RCon.Test
{
    [TestFixture]
    public class StringUtilsHashDeterminismTests04
    {
        [Test]
        public void GetStableHashCode_WhitespaceAndLetters_Differ()
        {
            Assert.That("a ".GetStableHashCode(), Is.Not.EqualTo("a".GetStableHashCode()));
        }
    }
}
