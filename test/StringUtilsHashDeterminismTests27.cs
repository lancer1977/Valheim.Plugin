using NUnit.Framework;
using PolyhydraGames.Valheim.Plugin.Extensions;

namespace PolyhydraGames.RCon.Test
{
    [TestFixture]
    public class StringUtilsHashDeterminismTests27
    {
        [Test]
        public void GetStableHashCode_KnownString_UsesExpectedDeterministicValue()
        {
            Assert.That("abc".GetStableHashCode(), Is.EqualTo(193409669));
        }
    }
}
