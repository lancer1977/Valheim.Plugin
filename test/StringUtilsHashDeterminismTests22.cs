using NUnit.Framework;
using PolyhydraGames.Valheim.Plugin;
using PolyhydraGames.Valheim.Plugin.Extensions;
using ValheimRcon.Commands;

namespace PolyhydraGames.RCon.Test
{
    [TestFixture]
    public class StringUtilsHashDeterminismTests22
    {
        [Test]
        public void GetRpcCommandName_MapIncludesUseDoor()
        {
            Assert.That(RpcCommand.UseDoor.GetRpcCommandName(), Is.EqualTo("RPC_UseDoor"));
        }
    }
}
