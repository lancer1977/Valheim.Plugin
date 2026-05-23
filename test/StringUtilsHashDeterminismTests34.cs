using NUnit.Framework;
using PolyhydraGames.Valheim.Plugin.Extensions;
using PolyhydraGames.Valheim.Plugin;
using ValheimRcon.Commands;

namespace PolyhydraGames.RCon.Test
{
    [TestFixture]
    public class StringUtilsHashDeterminismTests34
    {
        [Test]
        public void GetRpcCommandName_MapIncludesTakeAllRespons()
        {
            Assert.That(RpcCommand.TakeAllRespons.GetRpcCommandName(), Is.EqualTo("RPC_TakeAllRespons"));
        }
    }
}
