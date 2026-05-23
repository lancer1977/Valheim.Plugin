using NUnit.Framework;
using PolyhydraGames.Valheim.Plugin.Extensions;
using PolyhydraGames.Valheim.Plugin;
using ValheimRcon.Commands;

namespace PolyhydraGames.RCon.Test
{
    [TestFixture]
    public class StringUtilsHashDeterminismTests36
    {
        [Test]
        public void GetRpcCommandName_MapIncludesUnBan()
        {
            Assert.That(RpcCommand.Unban.GetRpcCommandName(), Is.EqualTo("RPC_Unban"));
        }
    }
}
