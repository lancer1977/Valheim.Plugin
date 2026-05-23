using NUnit.Framework;
using PolyhydraGames.Valheim.Plugin;
using PolyhydraGames.Valheim.Plugin.Extensions;
using ValheimRcon.Commands;

namespace PolyhydraGames.RCon.Test
{
    [TestFixture]
    public class StringUtilsHashDeterminismTests40
    {
        [Test]
        public void GetRpcCommandName_MapIncludesNetTime()
        {
            Assert.That(RpcCommand.NetTime.GetRpcCommandName(), Is.EqualTo("RPC_NetTime"));
        }
    }
}
