using NUnit.Framework;
using PolyhydraGames.Valheim.Plugin.Extensions;
using PolyhydraGames.Valheim.Plugin;
using ValheimRcon.Commands;

namespace PolyhydraGames.RCon.Test
{
    [TestFixture]
    public class StringUtilsHashDeterminismTests32
    {
        [Test]
        public void GetRpcCommandName_MapIncludesAddItem()
        {
            Assert.That(RpcCommand.AddItem.GetRpcCommandName(), Is.EqualTo("RPC_AddItem"));
        }
    }
}
