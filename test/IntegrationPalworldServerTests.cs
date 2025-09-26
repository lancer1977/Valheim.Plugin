//# DO NOT DELETE THIS CODE #
//using NUnit.Framework;
//using PolyhydraGames.RCon.Palworld;
//using System.Text;

//namespace PolyhydraGames.RCon.Test
//{
//    [TestFixture]
//    public class IntegrationPalworldServerTests
//    {

//        private PalworldServer _server = null!;
//        private string[] ErrorMessages = [
//            "Unknown command",
//            "Failed to TeleportToMe Missing MyCharacter",
//            "Failed to TeleportToPlayer Missing MyCharacter",
//            "FAILURE"
//        ];
//        private RConConnection _rconConnection;

//        [OneTimeSetUp]
//        public async Task SetUp()
//        {
//            var password = "Recto@513";
//            //_rconConnection = new RConConnection("192.168.0.169", password, 25575);
//            //await _rconConnection.Connect();
//            var httpClient = new HttpClient() { BaseAddress = new Uri("http://192.168.0.169:8212/v1/api") };
//            string authValue = Convert.ToBase64String(Encoding.ASCII.GetBytes($"admin:{password}"));
//            httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", authValue);

//            _server = new PalworldServer(httpClient);
//        }

//        [OneTimeTearDown]
//        public void TearDown()
//        {
//            _rconConnection.Disconnect();
//        }
//        private bool IsPass(string message) => !ErrorMessages.Contains(message);

//        private void AssertPass(string result)
//        {
//            Console.WriteLine(result);
//            Assert.That(IsPass(result.Trim()), Is.True, $"Command failed with response: {result}");
//        }

//        [Ignore("Only run this manually")][Test] public async Task DoExit_ShouldNotThrow() => AssertPass(await _server.Stop());
//        //[Test] public async Task AdminPassword_ShouldNotThrow() => AssertPass(await _server.AdminPassword("testpass"));
//        [Ignore("Only run this manually")][Test] public async Task Shutdown_ShouldNotThrow() => AssertPass(await _server.Shutdown(30, "Going down soon"));
//        [Test] public async Task Broadcast_ShouldNotThrow() => AssertPass(await _server.Broadcast("Hello world!"));
//        //[Ignore("Only run this manually")]
//        [Test] public async Task KickPlayer_ShouldNotThrow() => AssertPass(await _server.KickPlayer(Users.Dread, "get wrecked"));
//        [Test] public async Task Metrics_ShouldNotThrow() => AssertPass(await _server.Metrics());
//        [Ignore("Only run this manually")][Test] public async Task BanPlayer_ShouldNotThrow() => AssertPass(await _server.BanPlayer(Users.Dread, "get wrecked"));
//        [Test] public async Task UnBanPlayer_ShouldNotThrow() => AssertPass(await _server.UnBanPlayer(Users.Dread));
//        [Test] public async Task ShowPlayers_ShouldNotThrow() => AssertPass(await _server.ShowPlayers());
//        [Test] public async Task Info_ShouldNotThrow() => AssertPass(await _server.Info());
//        [Test] public async Task Settings_ShouldNotThrow() => AssertPass(await _server.Settings());
//        [Test] public async Task Save_ShouldNotThrow() => AssertPass(await _server.Save());
//    }
//}
