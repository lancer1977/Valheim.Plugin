using NUnit.Framework;
using PolyhydraGames.Valheim.Plugin.Extensions;
using PolyhydraGames.Valheim.Plugin;
using ValheimRcon.Commands;

namespace PolyhydraGames.RCon.Test
{
    [TestFixture]
    public class StringUtilsHashDeterminismTests35
    {
        [Test]
        public void GetRpcCommandName_MapIncludesHeal()
        {
            Assert.That(RpcCommand.Heal.GetRpcCommandName(), Is.EqualTo("RPC_Heal"));
        }
    }
}
