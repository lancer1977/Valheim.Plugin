using NUnit.Framework;
using PolyhydraGames.Valheim.Plugin;
using PolyhydraGames.Valheim.Plugin.Extensions;
using ValheimRcon.Commands;

namespace PolyhydraGames.RCon.Test
{
    [TestFixture]
    public class StringUtilsHashDeterminismTests13
    {
        [Test]
        public void GetRpcCommandName_UnknownCommand_UsesFallback()
        {
            var command = (RpcCommand)9999;
            Assert.That(command.GetRpcCommandName(), Is.EqualTo("RPC_Unknown"));
        }
    }
}
