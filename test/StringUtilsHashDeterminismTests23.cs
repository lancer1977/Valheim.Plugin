using NUnit.Framework;
using PolyhydraGames.Valheim.Plugin;
using PolyhydraGames.Valheim.Plugin.Extensions;
using ValheimRcon.Commands;

namespace PolyhydraGames.RCon.Test
{
    [TestFixture]
    public class StringUtilsHashDeterminismTests23
    {
        [Test]
        public void GetRpcCommandName_MapIncludesSetTime()
        {
            Assert.That(RpcCommand.Stagger.GetRpcCommandName(), Is.EqualTo("RPC_Stagger"));
        }
    }
}
