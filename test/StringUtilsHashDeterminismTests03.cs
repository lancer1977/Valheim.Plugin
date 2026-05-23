using NUnit.Framework;
using PolyhydraGames.Valheim.Plugin.Extensions;

namespace PolyhydraGames.RCon.Test
{
    [TestFixture]
    public class StringUtilsHashDeterminismTests03
    {
        [Test]
        public void GetStableHashCode_DifferentInputs_ProduceDifferentValues()
        {
            Assert.That("abc".GetStableHashCode(), Is.Not.EqualTo("acb".GetStableHashCode()));
        }
    }
}
