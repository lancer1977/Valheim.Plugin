
//using Moq;
//using Moq.Protected;
//using NUnit.Framework;
//using PolyhydraGames.RCon.Valheim;

//namespace PolyhydraGames.RCon.Test;
//[TestFixture]
//public class ValheimRconServerTests
//{
//    // NOTE: we’re constructing the real class but stubbing its protected SendAsync
//    private Mock<ValheimRconServer> _serverMock = null!;

//    [SetUp]
//    public void SetUp()
//    {
//        // Use a harmless config; constructor should not open sockets.
//        var cfg = new RConServerConfig("192.168.0.251", 2458, "d519bc00-8cb8-49ad-818c-3af8a18cd15d");

//        _serverMock = new Mock<ValheimRconServer>(cfg) { CallBase = true };
//    }

//    private void SetupMockSend(string expectedCommand, string returnValue = "ok")
//    {
//        _serverMock
//            .Protected()
//            .Setup<Task<string>>(
//                "SendAsync",
//                ItExpr.Is<string>(s => s == expectedCommand),
//                ItExpr.IsAny<CancellationToken>())
//            .ReturnsAsync(returnValue);
//    }

//    private void VerifySent(string expectedCommand)
//    {
//        _serverMock
//            .Protected()
//            .Verify(
//                "SendAsync",
//                Times.Once(),
//                ItExpr.Is<string>(s => s == expectedCommand),
//                ItExpr.IsAny<CancellationToken>());
//    }



//    // === Commands with options/flags ===

//    [Test]
//    public async Task FindObjects_WithOptions_SendsExpected()
//    {
//        const string expected = "findObjects -prefab piece_workbench -creator 111 -id 222 -userid 333 -tag spawned";
//        SetupMockSend(expected);

//        var s = _serverMock.Object;
//        var opts = new ObjectQueryOptions(
//            Prefab: "piece_workbench",
//            CreatorId: "111",
//            Id: "222",
//            UserId: "333",
//            Tag: "spawned"
//        );

//        var result = await s.FindObjectsAsync(opts);

//        Assert.That(result.Response, Is.EqualTo("ok"));
//        VerifySent(expected);
//    }

//    [Test]
//    public async Task FindObjectsNear_WithOptions_SendsExpected()
//    {
//        const string expected = "findObjectsNear 100 200 5 50 -prefab Boar -tag t1";
//        SetupMockSend(expected);

//        var s = _serverMock.Object;
//        var opts = new ObjectQueryOptions(Prefab: "Boar", Tag: "t1");

//        var result = await s.FindObjectsNearAsync(100, 200, 5, 50, opts);

//        Assert.That(result.Response, Is.EqualTo("ok"));
//        VerifySent(expected);
//    }

//    [Test]
//    public async Task DeleteObjects_WithOptions_SendsExpected()
//    {
//        const string expected = "deleteObjects -creator 111 -id 222 -userid 333 -tag prune";
//        SetupMockSend(expected);

//        var s = _serverMock.Object;
//        var opts = new DeleteObjectsOptions(CreatorId: "111", Id: "222", UserId: "333", Tag: "prune");

//        var result = await s.DeleteObjectsAsync(opts);

//        Assert.That(result.Response, Is.EqualTo("ok"));
//        VerifySent(expected);
//    }

//    [Test]
//    public async Task Spawn_WithOptions_SendsExpected()
//    {
//        // Order matters: -count, -radius, -level, -rotation, -tag, -tamed
//        const string expected = "spawn Boar 10 5 10 -count 3 -radius 2 -level 2 -rotation 0 90 0 -tag tamedBoar -tamed";
//        SetupMockSend(expected);

//        var s = _serverMock.Object;
//        var opts = new SpawnOptions(
//            Count: 3,
//            Radius: 2,
//            Level: 2,
//            Rotation: new(0, 90, 0),
//            Tag: "tamedBoar",
//            Tamed: true
//        );
//        var position = new Position(10, 5, 10);
//        var result = await s.SpawnAsync("Boar", position, opts);

//        Assert.That(result.Response, Is.EqualTo("ok"));
//        VerifySent(expected);
//    }

//    // === A couple of output-parsing tests (players/stats) ===

//    [Test]
//    public async Task Players_ParsesList()
//    {
//        const string raw =
//            "Name: Bob (SteamID: 76561198000000000), Pos: (10,5,10) Zone: Meadows\n" +
//            "Name: Alice (SteamID: 76561198000000001), Pos: (20,5,20) Zone: BlackForest\n";
//        SetupMockSend("players", raw);

//        var playersResponse = await _serverMock.Object.GetPlayersAsync();
//        var players = playersResponse.Result;
//        Assert.That(players, Has.Count.EqualTo(2));
//        Assert.That(players[0].Name, Is.EqualTo("Bob"));
//        Assert.That(players[0].SteamId, Is.EqualTo("76561198000000000"));
//        Assert.That(players[0].X, Is.EqualTo(10f));
//        Assert.That(players[0].Zone, Is.EqualTo("Meadows"));
//        VerifySent("players");
//    }

//    [Test]
//    public async Task ServerStats_ParsesValues()
//    {
//        const string raw =
//            "Players: 3 | FPS: 59.9 | Memory: 2048 MB | World: DedicatedWorld | Day: 12";
//        SetupMockSend("serverStats", raw);

//        var statsResponse = await _serverMock.Object.GetServerStatsAsync();
//        var stats = statsResponse.Result;
//        Assert.That(stats, Is.Not.Null);
        
//        Assert.That(stats, Is.Not.Null);
//        Assert.That(stats!.Players > 0);
//        Assert.That(stats.Fps > 0);
//        Assert.That(stats.MonoMemory > 0);
//        Assert.That(stats.Objects > 0);
//        Assert.That(stats.Day > 0);
//        Assert.That(stats.Day, Is.EqualTo(12));
//        VerifySent("serverStats");
//    }
//}