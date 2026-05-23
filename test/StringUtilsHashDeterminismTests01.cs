using NUnit.Framework;
using PolyhydraGames.Valheim.Plugin.Extensions;

namespace PolyhydraGames.RCon.Test
{
    [TestFixture]
    public class StringUtilsHashDeterminismTests01
    {
        [Test]
        public void GetStableHashCode_Empty_ReturnsSameValue()
        {
            Assert.That("".GetStableHashCode(), Is.EqualTo(5381));
        }
    }
}
