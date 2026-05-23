using NUnit.Framework;
using PolyhydraGames.Valheim.Plugin;
using PolyhydraGames.Valheim.Plugin.Extensions;
using ValheimRcon.Commands;

namespace PolyhydraGames.RCon.Test
{
    [TestFixture]
    public class StringUtilsHashDeterminismTests16
    {
        [Test]
        public void GetRpcCommandName_MapIncludesTeleportPlayer()
        {
            Assert.That(RpcCommand.TeleportPlayer.GetRpcCommandName(), Is.EqualTo("RPC_TeleportPlayer"));
        }
    }
}
