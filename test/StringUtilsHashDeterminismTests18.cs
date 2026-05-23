using NUnit.Framework;
using PolyhydraGames.Valheim.Plugin.Extensions;

namespace PolyhydraGames.RCon.Test
{
    [TestFixture]
    public class StringUtilsHashDeterminismTests18
    {
        [Test]
        public void GetStableHashCode_SymbolsChangeValue()
        {
            Assert.That("abc!".GetStableHashCode(), Is.Not.EqualTo("abc".GetStableHashCode()));
        }
    }
}
