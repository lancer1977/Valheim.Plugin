using NUnit.Framework;
using PolyhydraGames.Valheim.Plugin;
using PolyhydraGames.Valheim.Plugin.Extensions;
using ValheimRcon.Commands;

namespace PolyhydraGames.RCon.Test
{
    [TestFixture]
    public class StringUtilsHashDeterminismTests46
    {
        [Test]
        public void GetRpcCommandName_MapIncludesSetAreaHealth()
        {
            Assert.That(RpcCommand.SetAreaHealth.GetRpcCommandName(), Is.EqualTo("RPC_SetAreaHealth"));
        }
    }
}
