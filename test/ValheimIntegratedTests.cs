using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NUnit.Framework;
using Polyhydra.Valheim.Api;
using Polyhydra.Valheim.Api.Models;
using PolyhydraGames.Core.Test;

namespace PolyhydraGames.RCon.Test;

[TestFixture]
public partial class ValheimIntegratedTests
{
    protected IMessageService MessageService { get; }
    protected ValheimServerManager _valheimServer;
    private ValheimServer _rcon => _valheimServer.Server;
    private PositionType DefaultPosition => _valheimServer?.Points?.Start ?? GenericPosition;
    private static PositionType GenericPosition = new PositionType(0, 0, 0, 0, 0);
    protected PlayerInfo DreadId;
    protected PlayerInfo LockId;
    protected PlayerInfo LanceId;
    protected PlayerInfo GingerId;
    protected PlayerInfo AlecktoId;
    protected PlayerInfo PoohId;
#pragma warning disable NUnit1032
    public IHost App { get; set; }
#pragma warning restore NUnit1032
    public ValheimIntegratedTests()
    {
        //76561197962914477
        //76561197962914477
        DreadId = new PlayerInfo("DreadId", "76561197962914477", DefaultPosition);
        LockId = new PlayerInfo("LockId", "76561198080456333", DefaultPosition);
        LanceId = new PlayerInfo("LanceId", "76561198150290231", DefaultPosition);
        GingerId = new PlayerInfo("GingerId", "76561198006885330", DefaultPosition);
        AlecktoId = new PlayerInfo("AlecktoId", "76561198095936057", DefaultPosition);
        PoohId = new PlayerInfo("PoohId", "76561199439067919", DefaultPosition);
        App = TestHelpers.GetHost((x, services) =>
        {
            services.AddSingleton<IValheimRestServerConfig>(new ApiBridgeConfig("dev-key-123", "http://192.168.0.21:292/valheim1/"));
            services.AddSingleton<HttpClient>();
            services.AddSingleton<IMessageService, HttpBridge>();
            services.AddSingleton<ValheimServerManager>();
        });
        _valheimServer = App.Services.GetRequiredService<ValheimServerManager>();
    }
    [OneTimeSetUp]
    public async Task SetUp()
    {

        var result = await _valheimServer.Initialize();
        if (!result) throw new Exception("Initialization failed");
        await Task.Delay(1000);
        _valheimServer.Points.Start = Position.Create("(-321.22, 33.84, 262.72)");
        UpdatePlayers();
        //var result = await _serverMock.Connect();
        //if (result == false) throw new Exception("Connection failed!?");
    }

    private void UpdatePlayers()
    {
        DreadId = _valheimServer.Players.FirstOrDefault(x => x.SteamId == PlayerIds.DreadId) ?? DreadId;
        LockId = _valheimServer.Players.FirstOrDefault(x => x.SteamId == PlayerIds.LockId) ?? LockId;
        LanceId = _valheimServer.Players.FirstOrDefault(x => x.SteamId == PlayerIds.LanceId) ?? LanceId;
        GingerId = _valheimServer.Players.FirstOrDefault(x => x.SteamId == PlayerIds.GingerId) ?? GingerId;
        AlecktoId = _valheimServer.Players.FirstOrDefault(x => x.SteamId == PlayerIds.AlecktoId) ?? AlecktoId;
        PoohId = _valheimServer.Players.FirstOrDefault(x => x.SteamId == PlayerIds.PoohId) ?? PoohId;
    }

    [OneTimeTearDown]
    public void TearDown()
    {
        //_valheimServer.Dispose();
    }
    private void ProcessResult(RestResult result, string successMessage = "", string errorMessage = "")
    {
        Console.WriteLine(result.OutgoingMessage);
        Console.WriteLine(result.Response);
        if (!result.Successful) Console.WriteLine(errorMessage);
        Assert.That(result.Successful, successMessage);
    }
}