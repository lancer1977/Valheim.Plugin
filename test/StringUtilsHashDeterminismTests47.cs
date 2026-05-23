using NUnit.Framework;
using PolyhydraGames.Valheim.Plugin;
using PolyhydraGames.Valheim.Plugin.Extensions;
using ValheimRcon.Commands;

namespace PolyhydraGames.RCon.Test
{
    [TestFixture]
    public class StringUtilsHashDeterminismTests47
    {
        [Test]
        public void GetRpcCommandName_MapIncludesDestroyZdo()
        {
            Assert.That(RpcCommand.DestroyZDO.GetRpcCommandName(), Is.EqualTo("RPC_DestroyZDO"));
        }
    }
}
