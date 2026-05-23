using NUnit.Framework;
using PolyhydraGames.Valheim.Plugin.Extensions;

namespace PolyhydraGames.RCon.Test
{
    [TestFixture]
    public class StringUtilsHashDeterminismTests05
    {
        [Test]
        public void GetStableHashCode_LongInputIsStable()
        {
            var value = "x".PadLeft(128, 'x');
            Assert.That(value.GetStableHashCode(), Is.EqualTo(-1518922491));
        }
    }
}
