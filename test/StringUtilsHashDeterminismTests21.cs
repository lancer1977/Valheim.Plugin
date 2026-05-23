using NUnit.Framework;
using PolyhydraGames.Valheim.Plugin;
using PolyhydraGames.Valheim.Plugin.Extensions;
using ValheimRcon.Commands;

namespace PolyhydraGames.RCon.Test
{
    [TestFixture]
    public class StringUtilsHashDeterminismTests21
    {
        [Test]
        public void GetRpcCommandName_MapIncludesSpawnBoss()
        {
            Assert.That(RpcCommand.SpawnBoss.GetRpcCommandName(), Is.EqualTo("RPC_SpawnBoss"));
        }
    }
}
