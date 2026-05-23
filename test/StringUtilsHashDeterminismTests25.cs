using NUnit.Framework;
using PolyhydraGames.Valheim.Plugin;
using PolyhydraGames.Valheim.Plugin.Extensions;
using ValheimRcon.Commands;

namespace PolyhydraGames.RCon.Test
{
    [TestFixture]
    public class StringUtilsHashDeterminismTests25
    {
        [Test]
        public void GetRpcCommandName_MapIncludesAddNoise()
        {
            Assert.That(RpcCommand.AddNoise.GetRpcCommandName(), Is.EqualTo("RPC_AddNoise"));
        }
    }
}
