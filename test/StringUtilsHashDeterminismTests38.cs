using NUnit.Framework;
using PolyhydraGames.Valheim.Plugin;
using PolyhydraGames.Valheim.Plugin.Extensions;
using ValheimRcon.Commands;

namespace PolyhydraGames.RCon.Test
{
    [TestFixture]
    public class StringUtilsHashDeterminismTests38
    {
        [Test]
        public void GetRpcCommandName_MapIncludesUseGuardianPower()
        {
            Assert.That(RpcCommand.UseGuardianPower.GetRpcCommandName(), Is.EqualTo("RPC_UseGuardianPower"));
        }
    }
}
