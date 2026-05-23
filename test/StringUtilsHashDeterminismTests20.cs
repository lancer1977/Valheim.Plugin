using NUnit.Framework;
using PolyhydraGames.Valheim.Plugin.Extensions;

namespace PolyhydraGames.RCon.Test
{
    [TestFixture]
    public class StringUtilsHashDeterminismTests20
    {
        [Test]
        public void GetRemainingString_IndexAtEnd_ReturnsEmptyString()
        {
            var args = new ValheimRcon.Commands.CommandArgs("one two".Split(' '));
            Assert.That(args.GetRemainingString(2), Is.EqualTo(string.Empty));
        }
    }
}
