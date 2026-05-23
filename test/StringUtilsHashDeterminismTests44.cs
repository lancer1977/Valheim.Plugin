using NUnit.Framework;
using PolyhydraGames.Valheim.Plugin;
using PolyhydraGames.Valheim.Plugin.Extensions;
using ValheimRcon.Commands;

namespace PolyhydraGames.RCon.Test
{
    [TestFixture]
    public class StringUtilsHashDeterminismTests44
    {
        [Test]
        public void GetRpcCommandName_MapIncludesKick()
        {
            Assert.That(RpcCommand.Kick.GetRpcCommandName(), Is.EqualTo("RPC_Kick"));
        }
    }
}
