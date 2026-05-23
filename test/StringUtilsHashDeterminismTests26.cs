using NUnit.Framework;
using PolyhydraGames.Valheim.Plugin.Extensions;

namespace PolyhydraGames.RCon.Test
{
    [TestFixture]
    public class StringUtilsHashDeterminismTests26
    {
        [Test]
        public void GetStableHashCode_LeadingAndTrailingWhitespaceCanBeDifferent()
        {
            Assert.That(" a".GetStableHashCode(), Is.Not.EqualTo("a ".GetStableHashCode()));
        }
    }
}
