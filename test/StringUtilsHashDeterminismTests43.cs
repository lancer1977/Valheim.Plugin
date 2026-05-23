using NUnit.Framework;
using PolyhydraGames.Valheim.Plugin;
using PolyhydraGames.Valheim.Plugin.Extensions;
using ValheimRcon.Commands;

namespace PolyhydraGames.RCon.Test
{
    [TestFixture]
    public class StringUtilsHashDeterminismTests43
    {
        [Test]
        public void GetRpcCommandName_MapIncludesSetVisualItem()
        {
            Assert.That(RpcCommand.SetVisualItem.GetRpcCommandName(), Is.EqualTo("RPC_SetVisualItem"));
        }
    }
}
