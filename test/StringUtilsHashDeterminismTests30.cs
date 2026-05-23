using NUnit.Framework;
using PolyhydraGames.Valheim.Plugin.Extensions;
using PolyhydraGames.Valheim.Plugin;
using ValheimRcon.Commands;

namespace PolyhydraGames.RCon.Test
{
    [TestFixture]
    public class StringUtilsHashDeterminismTests30
    {
        [Test]
        public void GetRpcCommandName_MapIncludesSpawnObject()
        {
            Assert.That(RpcCommand.SpawnObject.GetRpcCommandName(), Is.EqualTo("RPC_SpawnObject"));
        }
    }
}
