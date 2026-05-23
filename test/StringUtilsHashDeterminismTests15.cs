using NUnit.Framework;
using PolyhydraGames.Valheim.Plugin.Extensions;

namespace PolyhydraGames.RCon.Test
{
    [TestFixture]
    public class StringUtilsHashDeterminismTests15
    {
        [Test]
        public void GetRemainingString_IndexOne_ReturnsEverythingAfterFirst()
        {
            var args = new ValheimRcon.Commands.CommandArgs("say hello world".Split(' '));
            Assert.That(args.GetRemainingString(1), Is.EqualTo("hello world"));
        }
    }
}
