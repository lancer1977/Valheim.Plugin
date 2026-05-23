using NUnit.Framework;
using PolyhydraGames.Valheim.Plugin;
using PolyhydraGames.Valheim.Plugin.Extensions;
using ValheimRcon.Commands;

namespace PolyhydraGames.RCon.Test
{
    [TestFixture]
    public class StringUtilsHashDeterminismTests39
    {
        [Test]
        public void GetRpcCommandName_MapIncludesPeerInfo()
        {
            Assert.That(RpcCommand.PeerInfo.GetRpcCommandName(), Is.EqualTo("RPC_PeerInfo"));
        }
    }
}
