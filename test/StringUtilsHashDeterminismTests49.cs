using NUnit.Framework;
using PolyhydraGames.Valheim.Plugin;
using PolyhydraGames.Valheim.Plugin.Extensions;
using ValheimRcon.Commands;

namespace PolyhydraGames.RCon.Test
{
    [TestFixture]
    public class StringUtilsHashDeterminismTests49
    {
        [Test]
        public void GetRpcCommandName_MapIncludesSetFuelAmount()
        {
            Assert.That(RpcCommand.SetFuelAmount.GetRpcCommandName(), Is.EqualTo("RPC_SetFuelAmount"));
        }
    }
}
