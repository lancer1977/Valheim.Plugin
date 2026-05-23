using NUnit.Framework;
using PolyhydraGames.Valheim.Plugin;
using PolyhydraGames.Valheim.Plugin.Extensions;
using ValheimRcon.Commands;

namespace PolyhydraGames.RCon.Test
{
    [TestFixture]
    public class StringUtilsHashDeterminismTests17
    {
        [Test]
        public void GetRpcCommandName_MapIncludesChatMessage()
        {
            Assert.That(RpcCommand.ChatMessage.GetRpcCommandName(), Is.EqualTo("RPC_ChatMessage"));
        }
    }
}
