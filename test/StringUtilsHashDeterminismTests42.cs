using NUnit.Framework;
using PolyhydraGames.Valheim.Plugin;
using PolyhydraGames.Valheim.Plugin.Extensions;
using ValheimRcon.Commands;

namespace PolyhydraGames.RCon.Test
{
    [TestFixture]
    public class StringUtilsHashDeterminismTests42
    {
        [Test]
        public void GetRpcCommandName_MapIncludesDisconnect()
        {
            Assert.That(RpcCommand.Disconnect.GetRpcCommandName(), Is.EqualTo("RPC_Disconnect"));
        }
    }
}
