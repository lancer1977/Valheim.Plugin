using NUnit.Framework;
using PolyhydraGames.Valheim.Plugin.Extensions;

namespace PolyhydraGames.RCon.Test
{
    [TestFixture]
    public class StringUtilsHashDeterminismTests06
    {
        [Test]
        public void GetStableHashCode_NumericText_DiffersFromAlpha()
        {
            Assert.That("12345".GetStableHashCode(), Is.Not.EqualTo("abcde".GetStableHashCode()));
        }
    }
}
