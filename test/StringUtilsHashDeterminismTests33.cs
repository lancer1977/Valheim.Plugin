using NUnit.Framework;
using PolyhydraGames.Valheim.Plugin.Extensions;
using PolyhydraGames.Valheim.Plugin;
using ValheimRcon.Commands;

namespace PolyhydraGames.RCon.Test
{
    [TestFixture]
    public class StringUtilsHashDeterminismTests33
    {
        [Test]
        public void GetRpcCommandName_MapIncludesRequestOwn()
        {
            Assert.That(RpcCommand.RequestOwn.GetRpcCommandName(), Is.EqualTo("RPC_RequestOwn"));
        }
    }
}
