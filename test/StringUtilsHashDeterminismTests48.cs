using NUnit.Framework;
using PolyhydraGames.Valheim.Plugin;
using PolyhydraGames.Valheim.Plugin.Extensions;
using ValheimRcon.Commands;

namespace PolyhydraGames.RCon.Test
{
    [TestFixture]
    public class StringUtilsHashDeterminismTests48
    {
        [Test]
        public void GetRpcCommandName_MapIncludesRequestControl()
        {
            Assert.That(RpcCommand.RequestControl.GetRpcCommandName(), Is.EqualTo("RPC_RequestControl"));
        }
    }
}
