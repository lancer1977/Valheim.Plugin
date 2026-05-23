using NUnit.Framework;
using PolyhydraGames.Valheim.Plugin.Extensions;

namespace PolyhydraGames.RCon.Test
{
    [TestFixture]
    public class StringUtilsHashDeterminismTests11
    {
        [Test]
        public void GetRemainingString_IndexZero_ReturnsEntireInput()
        {
            var args = new ValheimRcon.Commands.CommandArgs("first second".Split(' '));
            Assert.That(args.GetRemainingString(0), Is.EqualTo("first second"));
        }
    }
}
