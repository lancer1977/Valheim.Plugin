using NUnit.Framework;
using PolyhydraGames.Valheim.Plugin;
using PolyhydraGames.Valheim.Plugin.Extensions;
using ValheimRcon.Commands;

namespace PolyhydraGames.RCon.Test
{
    [TestFixture]
    public class StringUtilsHashDeterminismTests41
    {
        [Test]
        public void GetRpcCommandName_MapIncludesRemotePrint()
        {
            Assert.That(RpcCommand.RemotePrint.GetRpcCommandName(), Is.EqualTo("RPC_RemotePrint"));
        }
    }
}
