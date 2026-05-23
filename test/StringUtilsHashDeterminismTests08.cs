using NUnit.Framework;
using PolyhydraGames.Valheim.Plugin.Extensions;

namespace PolyhydraGames.RCon.Test
{
    [TestFixture]
    public class StringUtilsHashDeterminismTests08
    {
        [Test]
        public void GetStableHashCode_MixedCaseProducesDifferentHash()
        {
            Assert.That("Case".GetStableHashCode(), Is.Not.EqualTo("case".GetStableHashCode()));
        }
    }
}
