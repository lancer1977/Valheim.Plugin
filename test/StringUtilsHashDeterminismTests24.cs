using NUnit.Framework;
using PolyhydraGames.Valheim.Plugin;
using PolyhydraGames.Valheim.Plugin.Extensions;
using ValheimRcon.Commands;

namespace PolyhydraGames.RCon.Test
{
    [TestFixture]
    public class StringUtilsHashDeterminismTests24
    {
        [Test]
        public void GetRpcCommandName_MapIncludesSetTamed()
        {
            Assert.That(RpcCommand.SetTamed.GetRpcCommandName(), Is.EqualTo("RPC_SetTamed"));
        }
    }
}
