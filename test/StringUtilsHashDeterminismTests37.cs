using NUnit.Framework;
using PolyhydraGames.Valheim.Plugin.Extensions;
using PolyhydraGames.Valheim.Plugin;
using ValheimRcon.Commands;

namespace PolyhydraGames.RCon.Test
{
    [TestFixture]
    public class StringUtilsHashDeterminismTests37
    {
        [Test]
        public void GetRpcCommandName_MapIncludesRemoteCommand()
        {
            Assert.That(RpcCommand.RemoteCommand.GetRpcCommandName(), Is.EqualTo("RPC_RemoteCommand"));
        }
    }
}
