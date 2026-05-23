using NUnit.Framework;
using PolyhydraGames.Valheim.Plugin;
using PolyhydraGames.Valheim.Plugin.Extensions;
using ValheimRcon.Commands;

namespace PolyhydraGames.RCon.Test
{
    [TestFixture]
    public class StringUtilsHashDeterminismTests14
    {
        [Test]
        public void GetRpcCommandName_MapIncludesAddFuel()
        {
            Assert.That(RpcCommand.AddFuel.GetRpcCommandName(), Is.EqualTo("RPC_AddFuel"));
        }
    }
}
