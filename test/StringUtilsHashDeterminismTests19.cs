using NUnit.Framework;
using PolyhydraGames.Valheim.Plugin.Extensions;

namespace PolyhydraGames.RCon.Test
{
    [TestFixture]
    public class StringUtilsHashDeterminismTests19
    {
        [Test]
        public void GetStableHashCode_SurrogatePair_HasConsistentHash()
        {
            var value = "𝄞";
            Assert.That(value.GetStableHashCode(), Is.EqualTo(5292719));
        }
    }
}
