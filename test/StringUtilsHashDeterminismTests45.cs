using NUnit.Framework;
using PolyhydraGames.Valheim.Plugin;
using PolyhydraGames.Valheim.Plugin.Extensions;
using ValheimRcon.Commands;

namespace PolyhydraGames.RCon.Test
{
    [TestFixture]
    public class StringUtilsHashDeterminismTests45
    {
        [Test]
        public void GetRpcCommandName_MapIncludesDropItemByName()
        {
            Assert.That(RpcCommand.DropItemByName.GetRpcCommandName(), Is.EqualTo("RPC_DropItemByName"));
        }
    }
}
