using NUnit.Framework;
using PolyhydraGames.Valheim.Plugin.Extensions;

namespace PolyhydraGames.RCon.Test
{
    [TestFixture]
    public class StringUtilsHashDeterminismTests10
    {
        [Test]
        public void GetRemainingString_IndexTooLarge_ReturnsEmpty()
        {
            var args = new ValheimRcon.Commands.CommandArgs("a b".Split(' '));
            Assert.That(args.GetRemainingString(10), Is.EqualTo(string.Empty));
        }
    }
}
