using NUnit.Framework;
using PolyhydraGames.Valheim.Plugin;
using PolyhydraGames.Valheim.Plugin.Extensions;
using ValheimRcon.Commands;

namespace PolyhydraGames.RCon.Test
{
    [TestFixture]
    public class StringUtilsHashDeterminismTests12
    {
        [Test]
        public void GetRpcCommandName_MapsKnownCommand()
        {
            Assert.That(RpcCommand.Ban.GetRpcCommandName(), Is.EqualTo("RPC_Ban"));
        }
    }
}
