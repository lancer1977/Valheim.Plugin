using NUnit.Framework;
using PolyhydraGames.Valheim.Plugin.Extensions;

namespace PolyhydraGames.RCon.Test
{
    [TestFixture]
    public class StringUtilsHashDeterminismTests29
    {
        [Test]
        public void GetRemainingString_EmptyInputReturnsEmpty()
        {
            var args = new ValheimRcon.Commands.CommandArgs(new string[0]);
            Assert.That(args.GetRemainingString(0), Is.EqualTo(string.Empty));
        }
    }
}
