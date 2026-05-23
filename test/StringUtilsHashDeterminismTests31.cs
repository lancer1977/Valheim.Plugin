using NUnit.Framework;
using PolyhydraGames.Valheim.Plugin.Extensions;
using PolyhydraGames.Valheim.Plugin;
using ValheimRcon.Commands;

namespace PolyhydraGames.RCon.Test
{
    [TestFixture]
    public class StringUtilsHashDeterminismTests31
    {
        [Test]
        public void GetRpcCommandName_MapIncludesDropItem()
        {
            Assert.That(RpcCommand.DropItem.GetRpcCommandName(), Is.EqualTo("RPC_DropItem"));
        }
    }
}
