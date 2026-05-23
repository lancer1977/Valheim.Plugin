using NUnit.Framework;
using PolyhydraGames.Valheim.Plugin;
using PolyhydraGames.Valheim.Plugin.Extensions;
using ValheimRcon.Commands;

namespace PolyhydraGames.RCon.Test
{
    [TestFixture]
    public class StringUtilsHashDeterminismTests50
    {
        [Test]
        public void GetRpcCommandName_MapIncludesToggleOn()
        {
            Assert.That(RpcCommand.ToggleOn.GetRpcCommandName(), Is.EqualTo("RPC_ToggleOn"));
        }
    }
}
