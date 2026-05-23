using NUnit.Framework;
using PolyhydraGames.Valheim.Plugin;
using PolyhydraGames.Valheim.Plugin.Extensions;
using ValheimRcon.Commands;

namespace PolyhydraGames.RCon.Test
{
    [TestFixture]
    public class StringUtilsTests
    {
        [Test]
        public void GetStableHashCode_EmptyString_ReturnsSeed()
        {
            Assert.That("".GetStableHashCode(), Is.EqualTo(5381));
        }

        [Test]
        public void GetStableHashCode_DifferentStrings_ShouldNotMatch()
        {
            Assert.That("hello".GetStableHashCode(), Is.Not.EqualTo("Hello".GetStableHashCode()));
        }

        [Test]
        public void GetStableHashCode_SpacesPreserveDifferentInputs()
        {
            Assert.That("a b".GetStableHashCode(), Is.Not.EqualTo("a  b".GetStableHashCode()));
        }

        [Test]
        public void GetStableHashCode_LeadingAndTrailingWhitespaceCanBeDifferent()
        {
            Assert.That(" a".GetStableHashCode(), Is.Not.EqualTo("a ".GetStableHashCode()));
        }

        [Test]
        public void GetStableHashCode_KnownString_UsesExpectedDeterministicValue()
        {
            Assert.That("abc".GetStableHashCode(), Is.EqualTo(193409669));
        }

        [Test]
        public void GetStableHashCode_KnownString_AlternateCaseDiffers()
        {
            Assert.That("open_sesame".GetStableHashCode(), Is.EqualTo(-2006022974));
            Assert.That("CASE-SENSITIVE".GetStableHashCode(), Is.EqualTo(-362795888));
        }

        [Test]
        public void GetStableHashCode_UnicodeWorksWithoutChangingSeed()
        {
            Assert.That("😀".GetStableHashCode(), Is.EqualTo(5308056));
        }

        [Test]
        public void GetStableHashCode_RepeatInput_IsDeterministic()
        {
            var value = "polyhydra";
            var expected = value.GetStableHashCode();
            var actual = value.GetStableHashCode();
            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void GetStableHashCode_LongInput_IsStableHash()
        {
            var value = "This is a longer string used as a deterministic hashing fixture.";
            Assert.That(value.GetStableHashCode(), Is.EqualTo(-649124107));
        }

        [Test]
        public void GetStableHashCode_WhenNull_Throws()
        {
            string? value = null;
            Assert.That(() => value.GetStableHashCode(), Throws.TypeOf<NullReferenceException>());
        }

        [Test]
        public void GetRemainingString_IndexZero_ReturnsEverything()
        {
            var args = new CommandArgs("kick this player now".Split(" "));
            Assert.That(args.GetRemainingString(0), Is.EqualTo("kick this player now"));
        }

        [Test]
        public void GetRemainingString_IndexOne_ReturnsTail()
        {
            var args = new CommandArgs("whisper bob hello there".Split(" "));
            Assert.That(args.GetRemainingString(1), Is.EqualTo("bob hello there"));
        }

        [Test]
        public void GetRemainingString_IndexTwo_ReturnsTailFromThird()
        {
            var args = new CommandArgs("cmd target hello there".Split(" "));
            Assert.That(args.GetRemainingString(2), Is.EqualTo("hello there"));
        }

        [Test]
        public void GetRemainingString_IndexAtEnd_ReturnsEmpty()
        {
            var args = new CommandArgs("only one".Split(" "));
            Assert.That(args.GetRemainingString(2), Is.EqualTo(string.Empty));
        }

        [Test]
        public void GetRemainingString_IndexPastEnd_ReturnsEmpty()
        {
            var args = new CommandArgs("only one".Split(" "));
            Assert.That(args.GetRemainingString(4), Is.EqualTo(string.Empty));
        }

        [Test]
        public void GetRemainingString_NegativeIndex_ReturnsAllArguments()
        {
            var args = new CommandArgs("all the tokens".Split(" "));
            Assert.That(args.GetRemainingString(-1), Is.EqualTo("all the tokens"));
        }

        [Test]
        public void GetRemainingString_EmptyInput_ReturnsEmpty()
        {
            var args = new CommandArgs(new string[0]);
            Assert.That(args.GetRemainingString(0), Is.EqualTo(string.Empty));
        }

        [Test]
        public void GetRemainingString_SingleTokenOnlyAndIndexOne_ReturnsEmpty()
        {
            var args = new CommandArgs("single".Split(" "));
            Assert.That(args.GetRemainingString(1), Is.EqualTo(string.Empty));
        }

        [Test]
        public void GetRpcCommandName_ReturnsKnownMapping_ForChatMessage()
        {
            Assert.That(RpcCommand.ChatMessage.GetRpcCommandName(), Is.EqualTo("RPC_ChatMessage"));
        }

        [Test]
        public void GetRpcCommandName_ReturnsKnownMapping_ForTeleportPlayer()
        {
            Assert.That(RpcCommand.TeleportPlayer.GetRpcCommandName(), Is.EqualTo("RPC_TeleportPlayer"));
        }

        [Test]
        public void GetRpcCommandName_ReturnsKnownMapping_ForAddFuel()
        {
            Assert.That(RpcCommand.AddFuel.GetRpcCommandName(), Is.EqualTo("RPC_AddFuel"));
        }

        [Test]
        public void GetRpcCommandName_ReturnsKnownMapping_ForSpawnBoss()
        {
            Assert.That(RpcCommand.SpawnBoss.GetRpcCommandName(), Is.EqualTo("RPC_SpawnBoss"));
        }

        [Test]
        public void GetRpcCommandName_ReturnsKnownMapping_ForUnSummon()
        {
            Assert.That(RpcCommand.UnSummon.GetRpcCommandName(), Is.EqualTo("RPC_UnSummon"));
        }

        [Test]
        public void GetRpcCommandName_ReturnsKnownMapping_ForUseDoor()
        {
            Assert.That(RpcCommand.UseDoor.GetRpcCommandName(), Is.EqualTo("RPC_UseDoor"));
        }

        [Test]
        public void GetRpcCommandName_ReturnsKnownMapping_ForStaggerCreature()
        {
            Assert.That(RpcCommand.StaggerCreature.GetRpcCommandName(), Is.EqualTo("RPC_Stagger"));
        }

        [Test]
        public void GetRpcCommandName_UnknownCommand_ReturnsFallback()
        {
            var command = (RpcCommand)9999;
            Assert.That(command.GetRpcCommandName(), Is.EqualTo("RPC_Unknown"));
        }
    }
}
