using NUnit.Framework;
using Polyhydra.Valheim.Api;

namespace PolyhydraGames.RCon.Test
{
    public class ValheimParseTests
    {

        [TestCase("Online 1\n76561197962914477:Knäckebröd - (-502.89, 42.47, -217.33)(-8,-3)")]
        public void ParseLinesTest(string raw)
        {
            var result = Parser.ParseLines(raw);
            Assert.That(result.Count == 2);
        }
        [TestCase("Online 1\n76561197962914477:Knäckebröd - (-502.89, 42.47, -217.33)(-8,-3)")]
        public void ParsePlayerResponse(string raw)
        {
            var result = Parser.ParsePlayers(raw);
            Assert.That(result.Count == 1);
        }

        [TestCase("76561197962914477:Knäckebröd - (-502.89, 42.47, -217.33)(-8,-3)")]
        public void ParsePlayer(string raw)
        {
            var result = Parser.ParsePlayer(raw);
            Assert.That(result != null);
            Assert.That(result.Name == "Knäckebröd");

        }

        [TestCase("Current server time: 6213.97990670428 sec. Day: 3", ExpectedResult = 3)]
        public int ParseTimeText(string value)
        {
            var result = Parser.ParseTime(value);
            return result.Day;
        }

        [TestCase("- Prefab: wood_wall_half Distance: 5.866813 Id: 8123 UserId: 2044454741 Position: (-505.09, 44.88, -216.57)(-8,-3) Rotation: (0.00, 337.50, 0.00) Creator: 3377368518 Health: 400 Support: 80")]
        public void ParseObject(string data)
        {
            var result = Parser.GetWorldObject(data);
            Assert.That(result.UserId == 2044454741);
            Assert.That(result.Prefab == "wood_wall_half");
            Assert.That(result.Distance, Is.EqualTo(5.866813));
            Assert.That(result.Id == 8123);
            Assert.That(result.Position.ToString() == "-505.09 -216.57 44.88");
            Assert.That(result.Creator == 3377368518);
            Assert.That(result.Health == 400);
            Assert.That(result.Support, Is.EqualTo(80));


        }
    }
}