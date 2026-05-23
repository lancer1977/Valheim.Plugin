using NUnit.Framework;
using PolyhydraGames.Valheim.Plugin.Extensions;

namespace PolyhydraGames.RCon.Test
{
    [TestFixture]
    public class StringUtilsHashDeterminismTests28
    {
        [Test]
        public void GetStableHashCode_KnownString_AlternateCaseDiffers()
        {
            Assert.That("open_sesame".GetStableHashCode(), Is.EqualTo(-2006022974));
        }
    }
}
