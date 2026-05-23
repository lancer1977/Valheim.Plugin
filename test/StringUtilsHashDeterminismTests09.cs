using NUnit.Framework;
using PolyhydraGames.Valheim.Plugin.Extensions;

namespace PolyhydraGames.RCon.Test
{
    [TestFixture]
    public class StringUtilsHashDeterminismTests09
    {
        [Test]
        public void GetRemainingString_WhenIndexIsNegative_ReturnsAllTokens()
        {
            var args = new ValheimRcon.Commands.CommandArgs("a b c".Split(' '));
            Assert.That(args.GetRemainingString(-1), Is.EqualTo("a b c"));
        }
    }
}
